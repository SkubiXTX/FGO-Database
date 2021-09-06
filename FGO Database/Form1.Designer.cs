
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
            this.components = new System.ComponentModel.Container();
            this.btnLista = new System.Windows.Forms.Button();
            this.cmbLista = new System.Windows.Forms.ComboBox();
            this.stsInfo = new System.Windows.Forms.StatusStrip();
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
            this.lblInfo = new System.Windows.Forms.Label();
            this.bgwObrazyAscezji = new System.ComponentModel.BackgroundWorker();
            this.pcbStars = new System.Windows.Forms.PictureBox();
            this.lblSid = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblMaxlvl = new System.Windows.Forms.Label();
            this.LblHP1lvl = new System.Windows.Forms.Label();
            this.LblATK1lvl = new System.Windows.Forms.Label();
            this.lblMaxhp = new System.Windows.Forms.Label();
            this.lblMaxatk = new System.Windows.Forms.Label();
            this.tbcCards = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.pcbCard5 = new System.Windows.Forms.PictureBox();
            this.pcbCard4 = new System.Windows.Forms.PictureBox();
            this.pcbCard3 = new System.Windows.Forms.PictureBox();
            this.pcbCard2 = new System.Windows.Forms.PictureBox();
            this.pcbCard1 = new System.Windows.Forms.PictureBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.trvExtra = new System.Windows.Forms.TreeView();
            this.trvQuick = new System.Windows.Forms.TreeView();
            this.trvBuster = new System.Windows.Forms.TreeView();
            this.trvArt = new System.Windows.Forms.TreeView();
            this.ttpOpis = new System.Windows.Forms.ToolTip(this.components);
            this.lblGender = new System.Windows.Forms.Label();
            this.lblAttr = new System.Windows.Forms.Label();
            this.lblCv = new System.Windows.Forms.Label();
            this.lblIllustartor = new System.Windows.Forms.Label();
            this.lblStarAbs = new System.Windows.Forms.Label();
            this.lblStarGen = new System.Windows.Forms.Label();
            this.lblIDChange = new System.Windows.Forms.Label();
            this.txtSzukaj = new System.Windows.Forms.TextBox();
            this.btnSzukaj = new System.Windows.Forms.Button();
            this.stsInfo.SuspendLayout();
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
            this.tbcCards.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCard5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCard4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCard3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCard1)).BeginInit();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLista
            // 
            this.btnLista.Location = new System.Drawing.Point(274, 12);
            this.btnLista.Name = "btnLista";
            this.btnLista.Size = new System.Drawing.Size(75, 21);
            this.btnLista.TabIndex = 0;
            this.btnLista.Text = "Pełna Lista";
            this.btnLista.UseVisualStyleBackColor = true;
            this.btnLista.Click += new System.EventHandler(this.btnLista_Click);
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
            // stsInfo
            // 
            this.stsInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripProgressBar1});
            this.stsInfo.Location = new System.Drawing.Point(0, 533);
            this.stsInfo.Name = "stsInfo";
            this.stsInfo.Size = new System.Drawing.Size(800, 22);
            this.stsInfo.TabIndex = 2;
            this.stsInfo.Text = "statusStrip1";
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
            this.pcbPortret.Location = new System.Drawing.Point(10, 72);
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
            this.lblNazwa.Location = new System.Drawing.Point(144, 68);
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
            this.tbcAscezje.Location = new System.Drawing.Point(508, 126);
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
            this.pcbClassIcon.Location = new System.Drawing.Point(153, 126);
            this.pcbClassIcon.Name = "pcbClassIcon";
            this.pcbClassIcon.Size = new System.Drawing.Size(40, 40);
            this.pcbClassIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbClassIcon.TabIndex = 6;
            this.pcbClassIcon.TabStop = false;
            // 
            // lblClassName
            // 
            this.lblClassName.AutoSize = true;
            this.lblClassName.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblClassName.Location = new System.Drawing.Point(247, 126);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(47, 22);
            this.lblClassName.TabIndex = 7;
            this.lblClassName.Text = "class";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(559, 9);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(181, 13);
            this.lblInfo.TabIndex = 8;
            this.lblInfo.Text = "Kliknij w obraz po pełną rozdzielcość";
            // 
            // bgwObrazyAscezji
            // 
            this.bgwObrazyAscezji.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.bgwObrazyAscezji.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // pcbStars
            // 
            this.pcbStars.Location = new System.Drawing.Point(153, 168);
            this.pcbStars.Name = "pcbStars";
            this.pcbStars.Size = new System.Drawing.Size(168, 32);
            this.pcbStars.TabIndex = 9;
            this.pcbStars.TabStop = false;
            // 
            // lblSid
            // 
            this.lblSid.AutoSize = true;
            this.lblSid.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSid.Location = new System.Drawing.Point(199, 126);
            this.lblSid.Name = "lblSid";
            this.lblSid.Size = new System.Drawing.Size(47, 22);
            this.lblSid.TabIndex = 10;
            this.lblSid.Text = "#000";
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(10, 207);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(31, 13);
            this.lblCost.TabIndex = 11;
            this.lblCost.Text = "Cost:";
            // 
            // lblMaxlvl
            // 
            this.lblMaxlvl.AutoSize = true;
            this.lblMaxlvl.Location = new System.Drawing.Point(10, 220);
            this.lblMaxlvl.Name = "lblMaxlvl";
            this.lblMaxlvl.Size = new System.Drawing.Size(47, 13);
            this.lblMaxlvl.TabIndex = 12;
            this.lblMaxlvl.Text = "Max Lvl:";
            // 
            // LblHP1lvl
            // 
            this.LblHP1lvl.AutoSize = true;
            this.LblHP1lvl.Location = new System.Drawing.Point(102, 207);
            this.LblHP1lvl.Name = "LblHP1lvl";
            this.LblHP1lvl.Size = new System.Drawing.Size(25, 13);
            this.LblHP1lvl.TabIndex = 13;
            this.LblHP1lvl.Text = "HP:";
            // 
            // LblATK1lvl
            // 
            this.LblATK1lvl.AutoSize = true;
            this.LblATK1lvl.Location = new System.Drawing.Point(162, 207);
            this.LblATK1lvl.Name = "LblATK1lvl";
            this.LblATK1lvl.Size = new System.Drawing.Size(31, 13);
            this.LblATK1lvl.TabIndex = 14;
            this.LblATK1lvl.Text = "ATK:";
            // 
            // lblMaxhp
            // 
            this.lblMaxhp.AutoSize = true;
            this.lblMaxhp.Location = new System.Drawing.Point(102, 220);
            this.lblMaxhp.Name = "lblMaxhp";
            this.lblMaxhp.Size = new System.Drawing.Size(25, 13);
            this.lblMaxhp.TabIndex = 15;
            this.lblMaxhp.Text = "HP:";
            // 
            // lblMaxatk
            // 
            this.lblMaxatk.AutoSize = true;
            this.lblMaxatk.Location = new System.Drawing.Point(162, 220);
            this.lblMaxatk.Name = "lblMaxatk";
            this.lblMaxatk.Size = new System.Drawing.Size(31, 13);
            this.lblMaxatk.TabIndex = 16;
            this.lblMaxatk.Text = "ATK:";
            // 
            // tbcCards
            // 
            this.tbcCards.Controls.Add(this.tabPage5);
            this.tbcCards.Controls.Add(this.tabPage6);
            this.tbcCards.Location = new System.Drawing.Point(9, 378);
            this.tbcCards.Name = "tbcCards";
            this.tbcCards.SelectedIndex = 0;
            this.tbcCards.Size = new System.Drawing.Size(366, 150);
            this.tbcCards.TabIndex = 17;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.pcbCard5);
            this.tabPage5.Controls.Add(this.pcbCard4);
            this.tabPage5.Controls.Add(this.pcbCard3);
            this.tabPage5.Controls.Add(this.pcbCard2);
            this.tabPage5.Controls.Add(this.pcbCard1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(358, 124);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "Cards";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // pcbCard5
            // 
            this.pcbCard5.Location = new System.Drawing.Point(287, 7);
            this.pcbCard5.Name = "pcbCard5";
            this.pcbCard5.Size = new System.Drawing.Size(64, 64);
            this.pcbCard5.TabIndex = 4;
            this.pcbCard5.TabStop = false;
            // 
            // pcbCard4
            // 
            this.pcbCard4.Location = new System.Drawing.Point(217, 7);
            this.pcbCard4.Name = "pcbCard4";
            this.pcbCard4.Size = new System.Drawing.Size(64, 64);
            this.pcbCard4.TabIndex = 3;
            this.pcbCard4.TabStop = false;
            // 
            // pcbCard3
            // 
            this.pcbCard3.Location = new System.Drawing.Point(147, 7);
            this.pcbCard3.Name = "pcbCard3";
            this.pcbCard3.Size = new System.Drawing.Size(64, 64);
            this.pcbCard3.TabIndex = 2;
            this.pcbCard3.TabStop = false;
            // 
            // pcbCard2
            // 
            this.pcbCard2.Location = new System.Drawing.Point(77, 7);
            this.pcbCard2.Name = "pcbCard2";
            this.pcbCard2.Size = new System.Drawing.Size(64, 64);
            this.pcbCard2.TabIndex = 1;
            this.pcbCard2.TabStop = false;
            // 
            // pcbCard1
            // 
            this.pcbCard1.Location = new System.Drawing.Point(7, 7);
            this.pcbCard1.Name = "pcbCard1";
            this.pcbCard1.Size = new System.Drawing.Size(64, 64);
            this.pcbCard1.TabIndex = 0;
            this.pcbCard1.TabStop = false;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.trvExtra);
            this.tabPage6.Controls.Add(this.trvQuick);
            this.tabPage6.Controls.Add(this.trvBuster);
            this.tabPage6.Controls.Add(this.trvArt);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(358, 124);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "Hits Distribution";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // trvExtra
            // 
            this.trvExtra.Location = new System.Drawing.Point(264, 6);
            this.trvExtra.Name = "trvExtra";
            this.trvExtra.Size = new System.Drawing.Size(80, 109);
            this.trvExtra.TabIndex = 3;
            // 
            // trvQuick
            // 
            this.trvQuick.Location = new System.Drawing.Point(178, 6);
            this.trvQuick.Name = "trvQuick";
            this.trvQuick.Size = new System.Drawing.Size(80, 109);
            this.trvQuick.TabIndex = 2;
            // 
            // trvBuster
            // 
            this.trvBuster.Location = new System.Drawing.Point(92, 6);
            this.trvBuster.Name = "trvBuster";
            this.trvBuster.Size = new System.Drawing.Size(80, 109);
            this.trvBuster.TabIndex = 1;
            // 
            // trvArt
            // 
            this.trvArt.Location = new System.Drawing.Point(6, 6);
            this.trvArt.Name = "trvArt";
            this.trvArt.Size = new System.Drawing.Size(80, 109);
            this.trvArt.TabIndex = 0;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(10, 233);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(48, 13);
            this.lblGender.TabIndex = 18;
            this.lblGender.Text = "Gender: ";
            // 
            // lblAttr
            // 
            this.lblAttr.AutoSize = true;
            this.lblAttr.Location = new System.Drawing.Point(102, 233);
            this.lblAttr.Name = "lblAttr";
            this.lblAttr.Size = new System.Drawing.Size(49, 13);
            this.lblAttr.TabIndex = 19;
            this.lblAttr.Text = "Attribute:";
            // 
            // lblCv
            // 
            this.lblCv.AutoSize = true;
            this.lblCv.Location = new System.Drawing.Point(203, 152);
            this.lblCv.Name = "lblCv";
            this.lblCv.Size = new System.Drawing.Size(26, 13);
            this.lblCv.TabIndex = 20;
            this.lblCv.Text = "Cv: ";
            // 
            // lblIllustartor
            // 
            this.lblIllustartor.AutoSize = true;
            this.lblIllustartor.Location = new System.Drawing.Point(559, 25);
            this.lblIllustartor.Name = "lblIllustartor";
            this.lblIllustartor.Size = new System.Drawing.Size(55, 13);
            this.lblIllustartor.TabIndex = 21;
            this.lblIllustartor.Text = "Illustrator: ";
            // 
            // lblStarAbs
            // 
            this.lblStarAbs.AutoSize = true;
            this.lblStarAbs.Location = new System.Drawing.Point(10, 246);
            this.lblStarAbs.Name = "lblStarAbs";
            this.lblStarAbs.Size = new System.Drawing.Size(65, 13);
            this.lblStarAbs.TabIndex = 22;
            this.lblStarAbs.Text = "Star Absorb:";
            // 
            // lblStarGen
            // 
            this.lblStarGen.AutoSize = true;
            this.lblStarGen.Location = new System.Drawing.Point(102, 246);
            this.lblStarGen.Name = "lblStarGen";
            this.lblStarGen.Size = new System.Drawing.Size(82, 13);
            this.lblStarGen.TabIndex = 23;
            this.lblStarGen.Text = "Star generation:";
            // 
            // lblIDChange
            // 
            this.lblIDChange.AutoSize = true;
            this.lblIDChange.Location = new System.Drawing.Point(10, 259);
            this.lblIDChange.Name = "lblIDChange";
            this.lblIDChange.Size = new System.Drawing.Size(114, 13);
            this.lblIDChange.TabIndex = 24;
            this.lblIDChange.Text = "Instant Death Chance:";
            // 
            // txtSzukaj
            // 
            this.txtSzukaj.Location = new System.Drawing.Point(12, 39);
            this.txtSzukaj.Name = "txtSzukaj";
            this.txtSzukaj.Size = new System.Drawing.Size(256, 20);
            this.txtSzukaj.TabIndex = 25;
            // 
            // btnSzukaj
            // 
            this.btnSzukaj.Location = new System.Drawing.Point(274, 39);
            this.btnSzukaj.Name = "btnSzukaj";
            this.btnSzukaj.Size = new System.Drawing.Size(75, 20);
            this.btnSzukaj.TabIndex = 26;
            this.btnSzukaj.Text = "Szukaj";
            this.btnSzukaj.UseVisualStyleBackColor = true;
            this.btnSzukaj.Click += new System.EventHandler(this.btnSzukaj_Click);
            // 
            // frmOknoGl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 555);
            this.Controls.Add(this.btnSzukaj);
            this.Controls.Add(this.txtSzukaj);
            this.Controls.Add(this.lblIDChange);
            this.Controls.Add(this.lblStarGen);
            this.Controls.Add(this.lblStarAbs);
            this.Controls.Add(this.lblIllustartor);
            this.Controls.Add(this.lblNazwa);
            this.Controls.Add(this.lblCv);
            this.Controls.Add(this.lblClassName);
            this.Controls.Add(this.lblAttr);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.tbcCards);
            this.Controls.Add(this.lblMaxatk);
            this.Controls.Add(this.lblMaxhp);
            this.Controls.Add(this.LblATK1lvl);
            this.Controls.Add(this.LblHP1lvl);
            this.Controls.Add(this.lblMaxlvl);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.lblSid);
            this.Controls.Add(this.pcbStars);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.pcbClassIcon);
            this.Controls.Add(this.tbcAscezje);
            this.Controls.Add(this.pcbPortret);
            this.Controls.Add(this.stsInfo);
            this.Controls.Add(this.cmbLista);
            this.Controls.Add(this.btnLista);
            this.Name = "frmOknoGl";
            this.Text = "FGO Database";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.stsInfo.ResumeLayout(false);
            this.stsInfo.PerformLayout();
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
            this.tbcCards.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbCard5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCard4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCard3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCard1)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLista;
        private System.Windows.Forms.ComboBox cmbLista;
        private System.Windows.Forms.StatusStrip stsInfo;
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
        private System.Windows.Forms.Label lblInfo;
        private System.ComponentModel.BackgroundWorker bgwObrazyAscezji;
        private System.Windows.Forms.PictureBox pcbStars;
        private System.Windows.Forms.Label lblSid;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Label lblMaxlvl;
        private System.Windows.Forms.Label LblHP1lvl;
        private System.Windows.Forms.Label LblATK1lvl;
        private System.Windows.Forms.Label lblMaxhp;
        private System.Windows.Forms.Label lblMaxatk;
        private System.Windows.Forms.TabControl tbcCards;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.PictureBox pcbCard5;
        private System.Windows.Forms.PictureBox pcbCard4;
        private System.Windows.Forms.PictureBox pcbCard3;
        private System.Windows.Forms.PictureBox pcbCard2;
        private System.Windows.Forms.PictureBox pcbCard1;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TreeView trvArt;
        private System.Windows.Forms.TreeView trvExtra;
        private System.Windows.Forms.TreeView trvQuick;
        private System.Windows.Forms.TreeView trvBuster;
        private System.Windows.Forms.ToolTip ttpOpis;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblAttr;
        private System.Windows.Forms.Label lblCv;
        private System.Windows.Forms.Label lblIllustartor;
        private System.Windows.Forms.Label lblStarAbs;
        private System.Windows.Forms.Label lblStarGen;
        private System.Windows.Forms.Label lblIDChange;
        private System.Windows.Forms.TextBox txtSzukaj;
        private System.Windows.Forms.Button btnSzukaj;
    }
}

