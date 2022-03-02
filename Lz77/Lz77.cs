using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace LZ77
{
    class Token
    {
        int poz;
        int length;
        byte caracter;

        public void SetValues(int poz, int length, byte car)
        {
            this.poz = poz;
            this.length = length;
            this.caracter = car;
        }

        public int GetLength()
        {
            return this.length;
        }
        public int GetPoziztion()
        {
            return this.poz;
        }

        public byte GetCharcter()
        {
            return this.caracter;
        }
    }
    class Lz77
    {
        static List<Token> list_of_tokens = new List<Token>();
        static List<byte> look_ahead_buffer = new List<byte>();
        static List<byte> decoder = new List<byte>();
        static int offsetval;
        static int lengthval;

        public static void SetOffset(int value)
        {
            offsetval = (int)Math.Pow(2, value) - 1;
        }

        public static void SetLength(int value)
        {
            lengthval = (int)Math.Pow(2, value) - 1;
        }

        public List<Token> Encode(byte[] text,int offset, int length)
        {
            look_ahead_buffer = text.ToList();
            var bufferlength = look_ahead_buffer.Count();
            SetOffset(offset);
            SetLength(length);
            int sizesb = 0;
            int indexlab = 0;
            Token token = new Token();
            while (indexlab < bufferlength)
            {
                if (indexlab != 0)
                {
                    var value = GenerateToken(indexlab, out token, sizesb);
                    list_of_tokens.Add(token);
                    indexlab += value + 1;                    
                    sizesb += value + 1;
                    if(sizesb> offsetval)
                    {
                        sizesb = offsetval;
                    }
                }
                else
                {
                    token.SetValues(0, 0, look_ahead_buffer[indexlab]);
                    list_of_tokens.Add(token);
                    indexlab += 1;
                    sizesb += 1;
                }
            }
            return list_of_tokens;
        }

        static private int GenerateToken(int indexlab, out Token token, int sizesb)
        {
            token = new Token();
            Token temptoken = new Token();
            int value = 0;
            List<int> IndexList = GetIndexList(look_ahead_buffer[indexlab], indexlab, sizesb);
            if (IndexList.Count == 0)
            {
                token.SetValues(0, 0, look_ahead_buffer[indexlab]);
                value = 0;
            }
            else
            {
                foreach(var indexsb in IndexList)
                {
                    Token token_temp = new Token();
                    int maxlenght = 0;
                    bool chekcer = true;
                    while (chekcer)
                    {
                        if (look_ahead_buffer.Count - 1 != indexlab + maxlenght)
                        {
                            if (look_ahead_buffer[indexlab + maxlenght] == look_ahead_buffer[indexsb + maxlenght])
                            {
                                if (maxlenght >= lengthval)
                                {
                                    maxlenght = lengthval;
                                    token_temp.SetValues(indexlab - indexsb - 1, maxlenght, look_ahead_buffer[indexlab + maxlenght]);
                                    chekcer = false;
                                }
                                else
                                {
                                    maxlenght += 1;
                                }
                            }
                            else
                            {
                                chekcer = false;
                                token_temp.SetValues(indexlab - indexsb - 1, maxlenght, look_ahead_buffer[indexlab + maxlenght]);
                            }
                        }
                    
                        else
                        {
                            token_temp.SetValues(indexlab - indexsb - 1, maxlenght - 1, look_ahead_buffer[indexlab + maxlenght - 1]);
                            chekcer = false;
                        }
                    }
                    if (temptoken.GetLength() < token_temp.GetLength())
                    {
                        temptoken.SetValues(token_temp.GetPoziztion(), token_temp.GetLength(), token_temp.GetCharcter());
                    }
                }

                value = temptoken.GetLength();
                token = temptoken;
            }
            return value;
        }

        private static List<int> GetIndexList(byte symbol, int starpoint, int endpoint)
        {
            List<int> index = new List<int>();
            for (int i = starpoint - 1; i >= starpoint - endpoint; i -= 1)
            {
                if (look_ahead_buffer[i] == symbol)
                {
                    index.Add(i);
                }
            }
            return index;
        }

        public List<byte> Decode(List<Token> tokenlist)
        {
            int poz_of_buffer = 0;
            foreach (var tokens in tokenlist)
            {
                if (tokens.GetLength() == 0)
                {
                    decoder.Add(tokens.GetCharcter());
                    poz_of_buffer++;
                }
                else
                {
                    int char_to_add = tokens.GetLength();
                    while (char_to_add >0)
                    {
                        decoder.Add(decoder[poz_of_buffer - tokens.GetPoziztion() - 1]);
                        poz_of_buffer += 1;
                        char_to_add -= 1;
                    }
                    decoder.Add(tokens.GetCharcter()); 
                    poz_of_buffer += 1;
                }
            }
            return decoder;
        }
    }
}