namespace CloneGarbage
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
            this.clone1Button = new System.Windows.Forms.Button();
            this.clone2Button = new System.Windows.Forms.Button();
            this.garbageCollect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clone1Button
            // 
            this.clone1Button.Location = new System.Drawing.Point(12, 12);
            this.clone1Button.Name = "clone1Button";
            this.clone1Button.Size = new System.Drawing.Size(75, 23);
            this.clone1Button.TabIndex = 0;
            this.clone1Button.Text = "Clone 1";
            this.clone1Button.UseVisualStyleBackColor = true;
            this.clone1Button.Click += new System.EventHandler(this.clone1Button_Click);
            // 
            // clone2Button
            // 
            this.clone2Button.Location = new System.Drawing.Point(12, 41);
            this.clone2Button.Name = "clone2Button";
            this.clone2Button.Size = new System.Drawing.Size(75, 23);
            this.clone2Button.TabIndex = 1;
            this.clone2Button.Text = "Clone 2";
            this.clone2Button.UseVisualStyleBackColor = true;
            this.clone2Button.Click += new System.EventHandler(this.clone2Button_Click);
            // 
            // garbageCollect
            // 
            this.garbageCollect.Location = new System.Drawing.Point(12, 70);
            this.garbageCollect.Name = "garbageCollect";
            this.garbageCollect.Size = new System.Drawing.Size(102, 23);
            this.garbageCollect.TabIndex = 2;
            this.garbageCollect.Text = "Garbage Collect";
            this.garbageCollect.UseVisualStyleBackColor = true;
            this.garbageCollect.Click += new System.EventHandler(this.garbageCollect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(126, 102);
            this.Controls.Add(this.garbageCollect);
            this.Controls.Add(this.clone2Button);
            this.Controls.Add(this.clone1Button);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Clones";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button clone1Button;
        private System.Windows.Forms.Button clone2Button;
        private System.Windows.Forms.Button garbageCollect;
    }
}

