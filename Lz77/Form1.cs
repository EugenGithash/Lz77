using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BitReaderWriter;
using LZ77;
namespace LZ77
{
    public partial class Form1 : Form
    {
        private static string path;
        private static string extension;
        static List<Token> tokenlist1 = new List<Token>();
        static List<Token> tokenlist2 = new List<Token>();
        private static BitWriter bit_writer;
        private static BitReader bit;
        private static Lz77 lz77obj = new Lz77();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\Users\plesa\Desktop";
            openFileDialog1.Title = "Load file ";
            openFileDialog1.Filter = "All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
            }
        }

        private static void WriteAntet(int offsetval, int length)
        {
            bit_writer.WriteNBits(5, (uint)offsetval);
            bit_writer.WriteNBits(3, (uint)length);
        }

        public static void WriteEncodedFile(string path,int offsetval,int length)
        {
            extension = Path.GetExtension(path);
            string fileName = path +"["+ offsetval.ToString()+"]"+ "[" + length.ToString() + "]"+extension+".lz77";
            bit_writer = new BitWriter(fileName);
            WriteAntet(offsetval, length);
            foreach (var token in tokenlist1)
            {

                bit_writer.WriteNBits(offsetval, (uint)token.GetPoziztion());
                bit_writer.WriteNBits(length, (uint)token.GetLength());
                bit_writer.WriteNBits(8, (uint)token.GetCharcter());
            }
            for (int i = 0; i < 7; i++)
            {
                bit_writer.WriteNBits(1, 1);
            }

            bit_writer.Dispose();
        }

        private void encodeButton_Click(object sender, EventArgs e)
        {
            bit = new BitReader(path);
            byte[] text = bit.ReadAllBytes(path);
            tokenlist1 =lz77obj.Encode(text, Int32.Parse(offsetcmbx.Text), Int32.Parse(lengthcmbx.Text));
            if (checkBox1.Checked == true)
            {
                tokenlist1.ForEach(token => textBox1.Text += "(" + token.GetPoziztion().ToString() + "," + token.GetLength().ToString() + "," + token.GetCharcter().ToString() + ")");
            }
            WriteEncodedFile(path, Int32.Parse(offsetcmbx.Text), Int32.Parse(lengthcmbx.Text));
            bit_writer.Dispose();
        }

        private void loadEncodedButton_Click(object sender, EventArgs e)
        {
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                extension = path.Remove(path.Length - 5,5);
                extension = Path.GetExtension(extension);
            }
        }
        public static void WriteDecodedFile(List<byte> chars)
        {
           
            string decode_path = path+".lz77"+ extension;
            bit_writer = new BitWriter(decode_path);

            foreach (var character in chars)
            {
                bit_writer.WriteNBits(8, (uint)character);
            }
            bit_writer.Dispose();
        }

        private void decodeButton_Click(object sender, EventArgs e)
        {
            bit = new BitReader(path);
            uint offsettoread = bit.ReadNBits(5);
            uint lenghttoread= bit.ReadNBits(3);
            long bits_in_file = bit.NumberOfBitsInFile - 8;
            long thresholkod = offsettoread + lenghttoread + 8;
            
            while (bits_in_file >= thresholkod)
            {
                Token token_temp = new Token();
               uint  offset = bit.ReadNBits((int)offsettoread);
               uint lenght = bit.ReadNBits((int)lenghttoread);
                byte symbol = (byte)bit.ReadNBits(8);
                token_temp.SetValues((int)offset, (int)lenght, symbol);
                tokenlist2.Add(token_temp);
                bits_in_file -= offsettoread+ lenghttoread+8;
            }
            bit.Dispose();
            List<byte> decodetext = lz77obj.Decode(tokenlist2);
            WriteDecodedFile(decodetext);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
