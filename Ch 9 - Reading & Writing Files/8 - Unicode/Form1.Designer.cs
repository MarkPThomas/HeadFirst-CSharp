namespace Unicode
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
            this.writeEureka = new System.Windows.Forms.Button();
            this.bytesAsHexNumbers = new System.Windows.Forms.Button();
            this.writeInHebrew = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // writeEureka
            // 
            this.writeEureka.Location = new System.Drawing.Point(12, 12);
            this.writeEureka.Name = "writeEureka";
            this.writeEureka.Size = new System.Drawing.Size(181, 23);
            this.writeEureka.TabIndex = 0;
            this.writeEureka.Text = "Write Eureka Displayed in Bytes";
            this.writeEureka.UseVisualStyleBackColor = true;
            this.writeEureka.Click += new System.EventHandler(this.writeEureka_Click);
            // 
            // bytesAsHexNumbers
            // 
            this.bytesAsHexNumbers.Location = new System.Drawing.Point(12, 41);
            this.bytesAsHexNumbers.Name = "bytesAsHexNumbers";
            this.bytesAsHexNumbers.Size = new System.Drawing.Size(181, 23);
            this.bytesAsHexNumbers.TabIndex = 1;
            this.bytesAsHexNumbers.Text = "Write Eureka Displayed As Hex Numbers";
            this.bytesAsHexNumbers.UseVisualStyleBackColor = true;
            this.bytesAsHexNumbers.Click += new System.EventHandler(this.bytesAsHexNumbers_Click);
            // 
            // writeInHebrew
            // 
            this.writeInHebrew.Location = new System.Drawing.Point(12, 70);
            this.writeInHebrew.Name = "writeInHebrew";
            this.writeInHebrew.Size = new System.Drawing.Size(181, 23);
            this.writeInHebrew.TabIndex = 2;
            this.writeInHebrew.Text = "Write Eureka in Hebrew";
            this.writeInHebrew.UseVisualStyleBackColor = true;
            this.writeInHebrew.Click += new System.EventHandler(this.writeInHebrew_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Write All To File and Read As Binary";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.writeInHebrew);
            this.Controls.Add(this.bytesAsHexNumbers);
            this.Controls.Add(this.writeEureka);
            this.Name = "Form1";
            this.Text = "Unicode";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button writeEureka;
        private System.Windows.Forms.Button bytesAsHexNumbers;
        private System.Windows.Forms.Button writeInHebrew;
        private System.Windows.Forms.Button button1;
    }
}

