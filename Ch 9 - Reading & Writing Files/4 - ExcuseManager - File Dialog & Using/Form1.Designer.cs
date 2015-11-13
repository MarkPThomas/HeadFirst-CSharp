namespace ExcuseManager
{
    partial class ExcuseManager
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
            this.label1 = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.TextBox();
            this.folder = new System.Windows.Forms.Button();
            this.lastUsed = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.results = new System.Windows.Forms.TextBox();
            this.save = new System.Windows.Forms.Button();
            this.open = new System.Windows.Forms.Button();
            this.randomExcuse = new System.Windows.Forms.Button();
            this.fileDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Excuse";
            // 
            // description
            // 
            this.description.Location = new System.Drawing.Point(71, 6);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(200, 20);
            this.description.TabIndex = 1;
            this.description.TextChanged += new System.EventHandler(this.description_TextChanged);
            // 
            // folder
            // 
            this.folder.Location = new System.Drawing.Point(12, 118);
            this.folder.Name = "folder";
            this.folder.Size = new System.Drawing.Size(51, 23);
            this.folder.TabIndex = 2;
            this.folder.Text = "Folder";
            this.folder.UseVisualStyleBackColor = true;
            this.folder.Click += new System.EventHandler(this.folder_Click);
            // 
            // lastUsed
            // 
            this.lastUsed.Location = new System.Drawing.Point(71, 60);
            this.lastUsed.Name = "lastUsed";
            this.lastUsed.Size = new System.Drawing.Size(200, 20);
            this.lastUsed.TabIndex = 3;
            this.lastUsed.ValueChanged += new System.EventHandler(this.lastUsed_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Results";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Last Used";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "File Date";
            // 
            // results
            // 
            this.results.Location = new System.Drawing.Point(71, 34);
            this.results.Name = "results";
            this.results.Size = new System.Drawing.Size(200, 20);
            this.results.TabIndex = 7;
            this.results.TextChanged += new System.EventHandler(this.results_TextChanged);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(69, 118);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(51, 23);
            this.save.TabIndex = 9;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(126, 118);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(51, 23);
            this.open.TabIndex = 10;
            this.open.Text = "Open";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // randomExcuse
            // 
            this.randomExcuse.Location = new System.Drawing.Point(183, 118);
            this.randomExcuse.Name = "randomExcuse";
            this.randomExcuse.Size = new System.Drawing.Size(75, 23);
            this.randomExcuse.TabIndex = 11;
            this.randomExcuse.Text = "Random";
            this.randomExcuse.UseVisualStyleBackColor = true;
            this.randomExcuse.Click += new System.EventHandler(this.randomExcuse_Click);
            // 
            // fileDate
            // 
            this.fileDate.AutoEllipsis = true;
            this.fileDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fileDate.Location = new System.Drawing.Point(71, 87);
            this.fileDate.Name = "fileDate";
            this.fileDate.Size = new System.Drawing.Size(200, 23);
            this.fileDate.TabIndex = 12;
            // 
            // ExcuseManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 154);
            this.Controls.Add(this.fileDate);
            this.Controls.Add(this.randomExcuse);
            this.Controls.Add(this.open);
            this.Controls.Add(this.save);
            this.Controls.Add(this.results);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lastUsed);
            this.Controls.Add(this.folder);
            this.Controls.Add(this.description);
            this.Controls.Add(this.label1);
            this.Name = "ExcuseManager";
            this.Text = "Excuse Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.Button folder;
        private System.Windows.Forms.DateTimePicker lastUsed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox results;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.Button randomExcuse;
        private System.Windows.Forms.Label fileDate;
    }
}

