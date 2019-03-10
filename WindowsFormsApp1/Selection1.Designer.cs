namespace WindowsFormsApp1
{
    partial class Selection1
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
            this.btnEMBA = new System.Windows.Forms.Button();
            this.btnMBA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEMBA
            // 
            this.btnEMBA.Location = new System.Drawing.Point(12, 12);
            this.btnEMBA.Name = "btnEMBA";
            this.btnEMBA.Size = new System.Drawing.Size(138, 62);
            this.btnEMBA.TabIndex = 0;
            this.btnEMBA.Text = "EMBA";
            this.btnEMBA.UseVisualStyleBackColor = true;
            this.btnEMBA.Click += new System.EventHandler(this.btnEMBA_Click);
            // 
            // btnMBA
            // 
            this.btnMBA.Location = new System.Drawing.Point(152, 12);
            this.btnMBA.Name = "btnMBA";
            this.btnMBA.Size = new System.Drawing.Size(138, 62);
            this.btnMBA.TabIndex = 1;
            this.btnMBA.Text = "MBA";
            this.btnMBA.UseVisualStyleBackColor = true;
            this.btnMBA.Click += new System.EventHandler(this.btnMBA_Click);
            // 
            // Selection1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 95);
            this.ControlBox = false;
            this.Controls.Add(this.btnMBA);
            this.Controls.Add(this.btnEMBA);
            this.Name = "Selection1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEMBA;
        private System.Windows.Forms.Button btnMBA;
    }
}