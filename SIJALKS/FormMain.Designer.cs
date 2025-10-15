namespace SIJALKS
{
    partial class FormMain
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
            this.lblName = new System.Windows.Forms.Label();
            this.btnMT = new System.Windows.Forms.Button();
            this.btnMS = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(98, 85);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(246, 32);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Welcome, [Name]!";
            // 
            // btnMT
            // 
            this.btnMT.Location = new System.Drawing.Point(238, 266);
            this.btnMT.Name = "btnMT";
            this.btnMT.Size = new System.Drawing.Size(303, 23);
            this.btnMT.TabIndex = 2;
            this.btnMT.Text = "Master Teacher";
            this.btnMT.UseVisualStyleBackColor = true;
            this.btnMT.Click += new System.EventHandler(this.btnMT_Click);
            // 
            // btnMS
            // 
            this.btnMS.Location = new System.Drawing.Point(238, 340);
            this.btnMS.Name = "btnMS";
            this.btnMS.Size = new System.Drawing.Size(303, 23);
            this.btnMS.TabIndex = 3;
            this.btnMS.Text = "Master Student";
            this.btnMS.UseVisualStyleBackColor = true;
            this.btnMS.Click += new System.EventHandler(this.btnMS_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(579, 161);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(114, 39);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnMS);
            this.Controls.Add(this.btnMT);
            this.Controls.Add(this.lblName);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnMT;
        private System.Windows.Forms.Button btnMS;
        private System.Windows.Forms.Button btnLogout;
    }
}