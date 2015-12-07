namespace SecretIngredients
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
            this.useIngredient = new System.Windows.Forms.Button();
            this.getSuzanne = new System.Windows.Forms.Button();
            this.getAmy = new System.Windows.Forms.Button();
            this.amount = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.amount)).BeginInit();
            this.SuspendLayout();
            // 
            // useIngredient
            // 
            this.useIngredient.Location = new System.Drawing.Point(12, 12);
            this.useIngredient.Name = "useIngredient";
            this.useIngredient.Size = new System.Drawing.Size(108, 23);
            this.useIngredient.TabIndex = 0;
            this.useIngredient.Text = "Get the Ingredient";
            this.useIngredient.UseVisualStyleBackColor = true;
            this.useIngredient.Click += new System.EventHandler(this.useIngredient_Click);
            // 
            // getSuzanne
            // 
            this.getSuzanne.Location = new System.Drawing.Point(12, 41);
            this.getSuzanne.Name = "getSuzanne";
            this.getSuzanne.Size = new System.Drawing.Size(154, 23);
            this.getSuzanne.TabIndex = 1;
            this.getSuzanne.Text = "Get Suzanne\'s Delegate";
            this.getSuzanne.UseVisualStyleBackColor = true;
            this.getSuzanne.Click += new System.EventHandler(this.getSuzanne_Click);
            // 
            // getAmy
            // 
            this.getAmy.Location = new System.Drawing.Point(12, 70);
            this.getAmy.Name = "getAmy";
            this.getAmy.Size = new System.Drawing.Size(154, 23);
            this.getAmy.TabIndex = 2;
            this.getAmy.Text = "Get Amy\'s Delegate";
            this.getAmy.UseVisualStyleBackColor = true;
            this.getAmy.Click += new System.EventHandler(this.getAmy_Click);
            // 
            // amount
            // 
            this.amount.Location = new System.Drawing.Point(126, 15);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(40, 20);
            this.amount.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(174, 102);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.getAmy);
            this.Controls.Add(this.getSuzanne);
            this.Controls.Add(this.useIngredient);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Secret Ingredients";
            ((System.ComponentModel.ISupportInitialize)(this.amount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button useIngredient;
        private System.Windows.Forms.Button getSuzanne;
        private System.Windows.Forms.Button getAmy;
        private System.Windows.Forms.NumericUpDown amount;
    }
}

