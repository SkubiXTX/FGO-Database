
namespace FGO_Database
{
    partial class frmPoglad
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
            this.pcbZdjecie = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbZdjecie)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbZdjecie
            // 
            this.pcbZdjecie.Location = new System.Drawing.Point(13, 13);
            this.pcbZdjecie.Name = "pcbZdjecie";
            this.pcbZdjecie.Size = new System.Drawing.Size(512, 724);
            this.pcbZdjecie.TabIndex = 0;
            this.pcbZdjecie.TabStop = false;
            // 
            // frmPoglad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 751);
            this.Controls.Add(this.pcbZdjecie);
            this.Name = "frmPoglad";
            this.Text = "Ascezja";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPoglad_FormClosed);
            this.Load += new System.EventHandler(this.frmPoglad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbZdjecie)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbZdjecie;
    }
}