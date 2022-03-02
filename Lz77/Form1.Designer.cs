namespace LZ77
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loadButton = new System.Windows.Forms.Button();
            this.encodeButton = new System.Windows.Forms.Button();
            this.loadEncodedButton = new System.Windows.Forms.Button();
            this.decodeButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lengthcmbx = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.offsetcmbx = new System.Windows.Forms.ComboBox();
            this.offset = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(16, 63);
            this.loadButton.Margin = new System.Windows.Forms.Padding(4);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(193, 52);
            this.loadButton.TabIndex = 0;
            this.loadButton.Text = "Load File";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // encodeButton
            // 
            this.encodeButton.Location = new System.Drawing.Point(16, 122);
            this.encodeButton.Margin = new System.Windows.Forms.Padding(4);
            this.encodeButton.Name = "encodeButton";
            this.encodeButton.Size = new System.Drawing.Size(193, 52);
            this.encodeButton.TabIndex = 1;
            this.encodeButton.Text = "Encode File";
            this.encodeButton.UseVisualStyleBackColor = true;
            this.encodeButton.Click += new System.EventHandler(this.encodeButton_Click);
            // 
            // loadEncodedButton
            // 
            this.loadEncodedButton.Location = new System.Drawing.Point(704, 63);
            this.loadEncodedButton.Margin = new System.Windows.Forms.Padding(4);
            this.loadEncodedButton.Name = "loadEncodedButton";
            this.loadEncodedButton.Size = new System.Drawing.Size(191, 52);
            this.loadEncodedButton.TabIndex = 6;
            this.loadEncodedButton.Text = "Load Encoded File";
            this.loadEncodedButton.UseVisualStyleBackColor = true;
            this.loadEncodedButton.Click += new System.EventHandler(this.loadEncodedButton_Click);
            // 
            // decodeButton
            // 
            this.decodeButton.Location = new System.Drawing.Point(704, 122);
            this.decodeButton.Margin = new System.Windows.Forms.Padding(4);
            this.decodeButton.Name = "decodeButton";
            this.decodeButton.Size = new System.Drawing.Size(191, 50);
            this.decodeButton.TabIndex = 7;
            this.decodeButton.Text = "Decode File";
            this.decodeButton.UseVisualStyleBackColor = true;
            this.decodeButton.Click += new System.EventHandler(this.decodeButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lengthcmbx
            // 
            this.lengthcmbx.FormattingEnabled = true;
            this.lengthcmbx.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.lengthcmbx.Location = new System.Drawing.Point(16, 244);
            this.lengthcmbx.Margin = new System.Windows.Forms.Padding(4);
            this.lengthcmbx.Name = "lengthcmbx";
            this.lengthcmbx.Size = new System.Drawing.Size(160, 24);
            this.lengthcmbx.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 224);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Length";
            // 
            // offsetcmbx
            // 
            this.offsetcmbx.FormattingEnabled = true;
            this.offsetcmbx.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.offsetcmbx.Location = new System.Drawing.Point(16, 293);
            this.offsetcmbx.Margin = new System.Windows.Forms.Padding(4);
            this.offsetcmbx.Name = "offsetcmbx";
            this.offsetcmbx.Size = new System.Drawing.Size(160, 24);
            this.offsetcmbx.TabIndex = 10;
            // 
            // offset
            // 
            this.offset.AutoSize = true;
            this.offset.Location = new System.Drawing.Point(16, 273);
            this.offset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.offset.Name = "offset";
            this.offset.Size = new System.Drawing.Size(46, 17);
            this.offset.TabIndex = 11;
            this.offset.Text = "Offset";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(16, 362);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(115, 21);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Show Tokens";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(263, 63);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(196, 195);
            this.textBox1.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 575);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.offset);
            this.Controls.Add(this.offsetcmbx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lengthcmbx);
            this.Controls.Add(this.decodeButton);
            this.Controls.Add(this.loadEncodedButton);
            this.Controls.Add(this.encodeButton);
            this.Controls.Add(this.loadButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button encodeButton;
        private System.Windows.Forms.Button loadEncodedButton;
        private System.Windows.Forms.Button decodeButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox lengthcmbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox offsetcmbx;
        private System.Windows.Forms.Label offset;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

