namespace Casting
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
            this.showInteger = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // showInteger
            // 
            this.showInteger.Location = new System.Drawing.Point(12, 12);
            this.showInteger.Name = "showInteger";
            this.showInteger.Size = new System.Drawing.Size(126, 23);
            this.showInteger.TabIndex = 1;
            this.showInteger.Text = "Show Integer Value";
            this.showInteger.UseVisualStyleBackColor = true;
            this.showInteger.Click += new System.EventHandler(this.showInteger_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(177, 52);
            this.Controls.Add(this.showInteger);
            this.Name = "Form1";
            this.Text = "Casting";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button showInteger;
    }
}

