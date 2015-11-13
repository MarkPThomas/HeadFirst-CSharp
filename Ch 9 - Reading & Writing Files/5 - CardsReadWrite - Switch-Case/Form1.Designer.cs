namespace TwoDecks
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
            this.deckList1 = new System.Windows.Forms.ListBox();
            this.moveToDeck2 = new System.Windows.Forms.Button();
            this.deckList2 = new System.Windows.Forms.ListBox();
            this.moveToDeck1 = new System.Windows.Forms.Button();
            this.reset1 = new System.Windows.Forms.Button();
            this.shuffle1 = new System.Windows.Forms.Button();
            this.reset2 = new System.Windows.Forms.Button();
            this.shuffle2 = new System.Windows.Forms.Button();
            this.labelDeck1 = new System.Windows.Forms.Label();
            this.labelDeck2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // deckList1
            // 
            this.deckList1.FormattingEnabled = true;
            this.deckList1.Location = new System.Drawing.Point(12, 27);
            this.deckList1.Name = "deckList1";
            this.deckList1.Size = new System.Drawing.Size(119, 186);
            this.deckList1.TabIndex = 0;
            // 
            // moveToDeck2
            // 
            this.moveToDeck2.Location = new System.Drawing.Point(138, 65);
            this.moveToDeck2.Name = "moveToDeck2";
            this.moveToDeck2.Size = new System.Drawing.Size(43, 22);
            this.moveToDeck2.TabIndex = 1;
            this.moveToDeck2.Text = ">>";
            this.moveToDeck2.UseVisualStyleBackColor = true;
            this.moveToDeck2.Click += new System.EventHandler(this.moveToDeck2_Click);
            // 
            // deckList2
            // 
            this.deckList2.FormattingEnabled = true;
            this.deckList2.Location = new System.Drawing.Point(188, 27);
            this.deckList2.Name = "deckList2";
            this.deckList2.Size = new System.Drawing.Size(119, 186);
            this.deckList2.TabIndex = 2;
            // 
            // moveToDeck1
            // 
            this.moveToDeck1.Location = new System.Drawing.Point(138, 94);
            this.moveToDeck1.Name = "moveToDeck1";
            this.moveToDeck1.Size = new System.Drawing.Size(43, 22);
            this.moveToDeck1.TabIndex = 3;
            this.moveToDeck1.Text = "<<";
            this.moveToDeck1.UseVisualStyleBackColor = true;
            this.moveToDeck1.Click += new System.EventHandler(this.moveToDeck1_Click);
            // 
            // reset1
            // 
            this.reset1.Location = new System.Drawing.Point(11, 219);
            this.reset1.Name = "reset1";
            this.reset1.Size = new System.Drawing.Size(120, 22);
            this.reset1.TabIndex = 4;
            this.reset1.Text = "Reset Deck #1";
            this.reset1.UseVisualStyleBackColor = true;
            this.reset1.Click += new System.EventHandler(this.reset1_Click);
            // 
            // shuffle1
            // 
            this.shuffle1.Location = new System.Drawing.Point(11, 248);
            this.shuffle1.Name = "shuffle1";
            this.shuffle1.Size = new System.Drawing.Size(120, 22);
            this.shuffle1.TabIndex = 5;
            this.shuffle1.Text = "Shuffle Deck #1";
            this.shuffle1.UseVisualStyleBackColor = true;
            this.shuffle1.Click += new System.EventHandler(this.shuffle1_Click);
            // 
            // reset2
            // 
            this.reset2.Location = new System.Drawing.Point(188, 219);
            this.reset2.Name = "reset2";
            this.reset2.Size = new System.Drawing.Size(119, 22);
            this.reset2.TabIndex = 6;
            this.reset2.Text = "Reset Deck #2";
            this.reset2.UseVisualStyleBackColor = true;
            this.reset2.Click += new System.EventHandler(this.reset2_Click);
            // 
            // shuffle2
            // 
            this.shuffle2.Location = new System.Drawing.Point(188, 248);
            this.shuffle2.Name = "shuffle2";
            this.shuffle2.Size = new System.Drawing.Size(119, 22);
            this.shuffle2.TabIndex = 7;
            this.shuffle2.Text = "Shuffle Deck #2";
            this.shuffle2.UseVisualStyleBackColor = true;
            this.shuffle2.Click += new System.EventHandler(this.shuffle2_Click);
            // 
            // labelDeck1
            // 
            this.labelDeck1.AutoSize = true;
            this.labelDeck1.Location = new System.Drawing.Point(12, 8);
            this.labelDeck1.Name = "labelDeck1";
            this.labelDeck1.Size = new System.Drawing.Size(49, 13);
            this.labelDeck1.TabIndex = 8;
            this.labelDeck1.Text = "Deck #1";
            // 
            // labelDeck2
            // 
            this.labelDeck2.AutoSize = true;
            this.labelDeck2.Location = new System.Drawing.Point(185, 8);
            this.labelDeck2.Name = "labelDeck2";
            this.labelDeck2.Size = new System.Drawing.Size(49, 13);
            this.labelDeck2.TabIndex = 9;
            this.labelDeck2.Text = "Deck #2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 282);
            this.Controls.Add(this.labelDeck2);
            this.Controls.Add(this.labelDeck1);
            this.Controls.Add(this.shuffle2);
            this.Controls.Add(this.reset2);
            this.Controls.Add(this.shuffle1);
            this.Controls.Add(this.reset1);
            this.Controls.Add(this.moveToDeck1);
            this.Controls.Add(this.deckList2);
            this.Controls.Add(this.moveToDeck2);
            this.Controls.Add(this.deckList1);
            this.Name = "Form1";
            this.Text = "Two Decks";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox deckList1;
        private System.Windows.Forms.Button moveToDeck2;
        private System.Windows.Forms.ListBox deckList2;
        private System.Windows.Forms.Button moveToDeck1;
        private System.Windows.Forms.Button reset1;
        private System.Windows.Forms.Button shuffle1;
        private System.Windows.Forms.Button reset2;
        private System.Windows.Forms.Button shuffle2;
        private System.Windows.Forms.Label labelDeck1;
        private System.Windows.Forms.Label labelDeck2;
    }
}

