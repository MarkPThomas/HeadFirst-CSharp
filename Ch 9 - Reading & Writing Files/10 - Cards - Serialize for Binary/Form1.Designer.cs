namespace CardsSerializeDeserialize
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.serializeThreeOfClubs = new System.Windows.Forms.Button();
            this.serializeSixOfHearts = new System.Windows.Forms.Button();
            this.compareBinary = new System.Windows.Forms.Button();
            this.binaryKingOfSpades = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Serialize Random Deck";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Deserialize Random Deck";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(198, 41);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(176, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Deserialize the 5 Random Decks";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(198, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(176, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "Serialize 5 Random Decks";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // serializeThreeOfClubs
            // 
            this.serializeThreeOfClubs.Location = new System.Drawing.Point(109, 70);
            this.serializeThreeOfClubs.Name = "serializeThreeOfClubs";
            this.serializeThreeOfClubs.Size = new System.Drawing.Size(140, 23);
            this.serializeThreeOfClubs.TabIndex = 4;
            this.serializeThreeOfClubs.Text = "Serialize Three of Clubs";
            this.serializeThreeOfClubs.UseVisualStyleBackColor = true;
            this.serializeThreeOfClubs.Click += new System.EventHandler(this.serializeThreeOfClubs_Click);
            // 
            // serializeSixOfHearts
            // 
            this.serializeSixOfHearts.Location = new System.Drawing.Point(109, 99);
            this.serializeSixOfHearts.Name = "serializeSixOfHearts";
            this.serializeSixOfHearts.Size = new System.Drawing.Size(140, 23);
            this.serializeSixOfHearts.TabIndex = 5;
            this.serializeSixOfHearts.Text = "Serialize Six of Hearts";
            this.serializeSixOfHearts.UseVisualStyleBackColor = true;
            this.serializeSixOfHearts.Click += new System.EventHandler(this.serializeSixOfHearts_Click);
            // 
            // compareBinary
            // 
            this.compareBinary.Location = new System.Drawing.Point(109, 128);
            this.compareBinary.Name = "compareBinary";
            this.compareBinary.Size = new System.Drawing.Size(140, 23);
            this.compareBinary.TabIndex = 6;
            this.compareBinary.Text = "Compare Binary";
            this.compareBinary.UseVisualStyleBackColor = true;
            this.compareBinary.Click += new System.EventHandler(this.compareBinary_Click);
            // 
            // binaryKingOfSpades
            // 
            this.binaryKingOfSpades.Location = new System.Drawing.Point(103, 157);
            this.binaryKingOfSpades.Name = "binaryKingOfSpades";
            this.binaryKingOfSpades.Size = new System.Drawing.Size(155, 23);
            this.binaryKingOfSpades.TabIndex = 7;
            this.binaryKingOfSpades.Text = "King of Spades from Binary";
            this.binaryKingOfSpades.UseVisualStyleBackColor = true;
            this.binaryKingOfSpades.Click += new System.EventHandler(this.binaryKingOfSpades_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 195);
            this.Controls.Add(this.binaryKingOfSpades);
            this.Controls.Add(this.compareBinary);
            this.Controls.Add(this.serializeSixOfHearts);
            this.Controls.Add(this.serializeThreeOfClubs);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button serializeThreeOfClubs;
        private System.Windows.Forms.Button serializeSixOfHearts;
        private System.Windows.Forms.Button compareBinary;
        private System.Windows.Forms.Button binaryKingOfSpades;
    }
}