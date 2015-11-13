namespace BaseClassConstructor
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
            this.btnBaseClass = new System.Windows.Forms.Button();
            this.btnSubClass = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBaseClass
            // 
            this.btnBaseClass.Location = new System.Drawing.Point(12, 12);
            this.btnBaseClass.Name = "btnBaseClass";
            this.btnBaseClass.Size = new System.Drawing.Size(75, 23);
            this.btnBaseClass.TabIndex = 0;
            this.btnBaseClass.Text = "Base Class";
            this.btnBaseClass.UseVisualStyleBackColor = true;
            this.btnBaseClass.Click += new System.EventHandler(this.btnBaseClass_Click);
            // 
            // btnSubClass
            // 
            this.btnSubClass.Location = new System.Drawing.Point(12, 41);
            this.btnSubClass.Name = "btnSubClass";
            this.btnSubClass.Size = new System.Drawing.Size(75, 23);
            this.btnSubClass.TabIndex = 1;
            this.btnSubClass.Text = "Sub Class";
            this.btnSubClass.UseVisualStyleBackColor = true;
            this.btnSubClass.Click += new System.EventHandler(this.btnSubClass_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(116, 79);
            this.Controls.Add(this.btnSubClass);
            this.Controls.Add(this.btnBaseClass);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBaseClass;
        private System.Windows.Forms.Button btnSubClass;
    }
}

