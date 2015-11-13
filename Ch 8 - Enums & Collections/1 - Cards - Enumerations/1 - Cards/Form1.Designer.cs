namespace Cards
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
            this.showCard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // showCard
            // 
            this.showCard.Location = new System.Drawing.Point(12, 12);
            this.showCard.Name = "showCard";
            this.showCard.Size = new System.Drawing.Size(117, 23);
            this.showCard.TabIndex = 0;
            this.showCard.Text = "Show me your card!";
            this.showCard.UseVisualStyleBackColor = true;
            this.showCard.Click += new System.EventHandler(this.showCard_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(173, 67);
            this.Controls.Add(this.showCard);
            this.Name = "Form1";
            this.Text = "Cards";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button showCard;
    }
}

