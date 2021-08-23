
namespace FGO_Database
{
    partial class frmOknoGl
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.cmbLista = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.pcbPortret = new System.Windows.Forms.PictureBox();
            this.lblNazwa = new System.Windows.Forms.Label();
            this.tbcAscezje = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pcbAscezja1 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pcbAscezja2 = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pcbAscezja3 = new System.Windows.Forms.PictureBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.pcbAscezja4 = new System.Windows.Forms.PictureBox();
            this.pcbClassIcon = new System.Windows.Forms.PictureBox();
            this.lblClassName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pcbStars = new System.Windows.Forms.PictureBox();
            this.lblSid = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPortret)).BeginInit();
            this.tbcAscezje.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbAscezja1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbAscezja2)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbAscezja3)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbAscezja4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbClassIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbStars)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(274, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 21);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cmbLista
            // 
            this.cmbLista.FormattingEnabled = true;
            this.cmbLista.Location = new System.Drawing.Point(12, 12);
            this.cmbLista.Name = "cmbLista";
            this.cmbLista.Size = new System.Drawing.Size(256, 21);
            this.cmbLista.TabIndex = 1;
            this.cmbLista.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 463);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(145, 17);
            this.toolStripStatusLabel1.Text = "Pobieranie Listy: W trakcie";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(135, 17);
            this.toolStripStatusLabel2.Text = "Pobieranie Danych: Brak";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.MarqueeAnimationSpeed = 40;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(150, 16);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.toolStripProgressBar1.Visible = false;
            // 
            // pcbPortret
            // 
            this.pcbPortret.Location = new System.Drawing.Point(13, 40);
            this.pcbPortret.Name = "pcbPortret";
            this.pcbPortret.Size = new System.Drawing.Size(128, 128);
            this.pcbPortret.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbPortret.TabIndex = 3;
            this.pcbPortret.TabStop = false;
            // 
            // lblNazwa
            // 
            this.lblNazwa.AutoSize = true;
            this.lblNazwa.Font = new System.Drawing.Font("Open Sans Semibold", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNazwa.Location = new System.Drawing.Point(147, 40);
            this.lblNazwa.Name = "lblNazwa";
            this.lblNazwa.Size = new System.Drawing.Size(158, 51);
            this.lblNazwa.TabIndex = 4;
            this.lblNazwa.Text = "Servant";
            // 
            // tbcAscezje
            // 
            this.tbcAscezje.Controls.Add(this.tabPage1);
            this.tbcAscezje.Controls.Add(this.tabPage2);
            this.tbcAscezje.Controls.Add(this.tabPage3);
            this.tbcAscezje.Controls.Add(this.tabPage4);
            this.tbcAscezje.Location = new System.Drawing.Point(511, 28);
            this.tbcAscezje.Name = "tbcAscezje";
            this.tbcAscezje.SelectedIndex = 0;
            this.tbcAscezje.Size = new System.Drawing.Size(277, 402);
            this.tbcAscezje.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pcbAscezja1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(269, 376);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ascesion 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pcbAscezja1
            // 
            this.pcbAscezja1.Location = new System.Drawing.Point(6, 6);
            this.pcbAscezja1.Name = "pcbAscezja1";
            this.pcbAscezja1.Size = new System.Drawing.Size(256, 362);
            this.pcbAscezja1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbAscezja1.TabIndex = 0;
            this.pcbAscezja1.TabStop = false;
            this.pcbAscezja1.Click += new System.EventHandler(this.pcbAscezja1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pcbAscezja2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(269, 376);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Ascesion 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pcbAscezja2
            // 
            this.pcbAscezja2.Location = new System.Drawing.Point(7, 7);
            this.pcbAscezja2.Name = "pcbAscezja2";
            this.pcbAscezja2.Size = new System.Drawing.Size(256, 362);
            this.pcbAscezja2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbAscezja2.TabIndex = 0;
            this.pcbAscezja2.TabStop = false;
            this.pcbAscezja2.Click += new System.EventHandler(this.pcbAscezja2_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.pcbAscezja3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(269, 376);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Ascesion 3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // pcbAscezja3
            // 
            this.pcbAscezja3.Location = new System.Drawing.Point(6, 6);
            this.pcbAscezja3.Name = "pcbAscezja3";
            this.pcbAscezja3.Size = new System.Drawing.Size(256, 362);
            this.pcbAscezja3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbAscezja3.TabIndex = 1;
            this.pcbAscezja3.TabStop = false;
            this.pcbAscezja3.Click += new System.EventHandler(this.pcbAscezja3_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.pcbAscezja4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(269, 376);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Ascesion Final";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // pcbAscezja4
            // 
            this.pcbAscezja4.Location = new System.Drawing.Point(7, 6);
            this.pcbAscezja4.Name = "pcbAscezja4";
            this.pcbAscezja4.Size = new System.Drawing.Size(256, 362);
            this.pcbAscezja4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbAscezja4.TabIndex = 1;
            this.pcbAscezja4.TabStop = false;
            this.pcbAscezja4.Click += new System.EventHandler(this.pcbAscezja4_Click);
            // 
            // pcbClassIcon
            // 
            this.pcbClassIcon.Location = new System.Drawing.Point(156, 94);
            this.pcbClassIcon.Name = "pcbClassIcon";
            this.pcbClassIcon.Size = new System.Drawing.Size(40, 40);
            this.pcbClassIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbClassIcon.TabIndex = 6;
            this.pcbClassIcon.TabStop = false;
            // 
            // lblClassName
            // 
            this.lblClassName.AutoSize = true;
            this.lblClassName.Font = new System.Drawing.Font("Open Sans Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassName.Location = new System.Drawing.Point(257, 108);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(55, 26);
            this.lblClassName.TabIndex = 7;
            this.lblClassName.Text = "class";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(559, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Kliknij w obraz po pełną rozdzielcość";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // pcbStars
            // 
            this.pcbStars.Location = new System.Drawing.Point(156, 136);
            this.pcbStars.Name = "pcbStars";
            this.pcbStars.Size = new System.Drawing.Size(168, 32);
            this.pcbStars.TabIndex = 9;
            this.pcbStars.TabStop = false;
            // 
            // lblSid
            // 
            this.lblSid.AutoSize = true;
            this.lblSid.Font = new System.Drawing.Font("Open Sans Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSid.Location = new System.Drawing.Point(202, 107);
            this.lblSid.Name = "lblSid";
            this.lblSid.Size = new System.Drawing.Size(57, 26);
            this.lblSid.TabIndex = 10;
            this.lblSid.Text = "#000";
            // 
            // frmOknoGl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 485);
            this.Controls.Add(this.lblSid);
            this.Controls.Add(this.pcbStars);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblClassName);
            this.Controls.Add(this.pcbClassIcon);
            this.Controls.Add(this.tbcAscezje);
            this.Controls.Add(this.lblNazwa);
            this.Controls.Add(this.pcbPortret);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cmbLista);
            this.Controls.Add(this.button1);
            this.Name = "frmOknoGl";
            this.Text = "FGO Database";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPortret)).EndInit();
            this.tbcAscezje.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbAscezja1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbAscezja2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbAscezja3)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbAscezja4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbClassIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbStars)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbLista;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.PictureBox pcbPortret;
        private System.Windows.Forms.Label lblNazwa;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.TabControl tbcAscezje;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pcbAscezja1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pcbAscezja2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox pcbAscezja3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.PictureBox pcbAscezja4;
        private System.Windows.Forms.PictureBox pcbClassIcon;
        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pcbStars;
        private System.Windows.Forms.Label lblSid;
    }
}

