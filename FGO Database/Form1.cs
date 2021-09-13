﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FGO_Database
{
    public partial class frmOknoGl : Form
    {
        public Boolean szukaj = false;
        public String[] ServId = new string[1000];
        public String region = "NA";

        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Pusty String!");
            }

            return input.First().ToString().ToUpper() + String.Join("", input.Skip(1));
        }

        public string NaProcent(string liczba)
        {
            String wynik = "";
            Int32 temp = 0;

            temp = Int32.Parse(liczba);
            wynik = String.Format("{0}%", temp / 10);

            return wynik;
        }

        public void ZaładujListe ()
        {
            String servants = "";

            //var url = "https://api.atlasacademy.io/export/JP/basic_servant_lang_en.json";
            var url = "http://localhost/basic_servant_lang_en.json";
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.Accept = "application/json";

            try
            {
                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    servants = result.ToString();
                }

                toolStripStatusLabel1.Text = "Pobieranie Listy: " + httpResponse.StatusCode.ToString();
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Pobieranie Listy: Błąd";
                //throw;
            }

            if (servants != "")
            {
                cmbLista.Items.Clear();
                JArray przetworzonedane = JArray.Parse(servants);
                //Console.WriteLine((string)przetworzonedane.SelectToken("[0].name"));

                for (int i = 0; i < przetworzonedane.Count; i++)
                {
                    String nazwa = (string)przetworzonedane.SelectToken("[" + i + "].name") + " [" + (string)przetworzonedane.SelectToken("[" + i + "].className") + "]";

                    cmbLista.Items.Add(nazwa);
                }
            }
        }

        public frmOknoGl()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // Create the ToolTip and associate with the Form container.
            ToolTip ttpOpis = new ToolTip();

            // Set up the delays for the ToolTip.
            ttpOpis.AutoPopDelay = 5000;
            ttpOpis.InitialDelay = 1000;
            ttpOpis.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            ttpOpis.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            ttpOpis.SetToolTip(this.lblMaxhp, "Hp na maksymalny levelu");
            ttpOpis.SetToolTip(this.lblMaxatk, "Atak na maksymalny levelu");
            rdbNA.Checked = true;

            ZaładujListe();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String dane = "";
            String appid = "";
            Boolean JPonly = false;

            if (cmbLista.Items.Count != 0)
            {
                int id = cmbLista.SelectedIndex + 1;
                var url = "";
                var url2 = "";

                if (szukaj == false)
                {
                    url = "https://api.atlasacademy.io/nice/NA/servant/" + id.ToString() + "?lore=true&lang=en"; 
                }
                else
                {
                    url = "https://api.atlasacademy.io/nice/NA/servant/" + ServId[id - 1] + "?lore=true&lang=en";
                }
                //var url = "http://localhost/239.json";

                var httpRequest = (HttpWebRequest)WebRequest.Create(url);

                httpRequest.Accept = "application/json";
                toolStripProgressBar1.Visible = true;
                toolStripStatusLabel2.Text = "Pobieranie Danych: W trakce";

                try
                {
                    var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        dane = result.ToString();

                        toolStripStatusLabel2.Text = "Pobieranie Danych: " + httpResponse.StatusCode.ToString();
                    }

                }

                catch (Exception)
                {
                    //MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //toolStripStatusLabel2.Text = "Pobieranie Danych: Błąd";
                    //toolStripProgressBar1.Visible = false;
                    JPonly = true;
                    //throw;
                }

                if (JPonly == true)
                {
                    if (szukaj == false)
                    {
                        url2 = "https://api.atlasacademy.io/nice/JP/servant/" + id.ToString() + "?lore=true&lang=en";
                    }
                    else
                    {
                        url2 = "https://api.atlasacademy.io/nice/JP/servant/" + ServId[id - 1] + "?lore=true&lang=en";
                    }
                    //var url2 = "http://localhost/239.json";
                    var httpRequest2 = (HttpWebRequest)WebRequest.Create(url2);

                    httpRequest2.Accept = "application/json";
                    toolStripProgressBar1.Visible = true;
                    toolStripStatusLabel2.Text = "Pobieranie Danych: W trakce";

                    try
                    {
                        var httpResponse2 = (HttpWebResponse)httpRequest2.GetResponse();
                        using (var streamReader = new StreamReader(httpResponse2.GetResponseStream()))
                        {
                            var result = streamReader.ReadToEnd();
                            dane = result.ToString();

                            toolStripStatusLabel2.Text = "Pobieranie Danych: " + httpResponse2.StatusCode.ToString();
                        }

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        toolStripStatusLabel2.Text = "Pobieranie Danych: Błąd";
                        toolStripProgressBar1.Visible = false;
                        //throw;
                    }
                }

                if (dane != "")
                {
                    JObject przetworzonedane = JObject.Parse(dane);

                    cmbLista.Enabled = false;
                    bgwObrazyAscezji.RunWorkerAsync(przetworzonedane);

                    int tid = (Int16)przetworzonedane.SelectToken("collectionNo");
                    appid = "#" + tid.ToString("000");

                    lblNazwa.Text = (string)przetworzonedane.SelectToken("name");
                    pcbClassIcon.Load(Application.StartupPath + "\\img\\" + (string)przetworzonedane.SelectToken("className") + ".png");
                    lblClassName.Text = FirstCharToUpper((string)przetworzonedane.SelectToken("className"));
                    pcbStars.Load(Application.StartupPath + "\\img\\" + (string)przetworzonedane.SelectToken("rarity") + "star.png");
                    lblSid.Text = appid;
                    lblCost.Text = "Cost: " + (string)przetworzonedane.SelectToken("cost");
                    lblMaxlvl.Text = "Max Lvl: " + (string)przetworzonedane.SelectToken("lvMax");
                    LblHP1lvl.Text = "Hp: " + (string)przetworzonedane.SelectToken("hpBase");
                    LblATK1lvl.Text = "Atk: " + (string)przetworzonedane.SelectToken("atkBase");
                    lblMaxhp.Text = "Hp: " + (string)przetworzonedane.SelectToken("hpMax");
                    lblMaxatk.Text = "Atk: " + (string)przetworzonedane.SelectToken("atkMax");
                    var cards = przetworzonedane.SelectToken("cards")?.ToObject<string[]>();
                    pcbCard1.Load(Application.StartupPath + "\\img\\" + cards[0] + ".png");
                    pcbCard2.Load(Application.StartupPath + "\\img\\" + cards[1] + ".png");
                    pcbCard3.Load(Application.StartupPath + "\\img\\" + cards[2] + ".png");
                    pcbCard4.Load(Application.StartupPath + "\\img\\" + cards[3] + ".png");
                    pcbCard5.Load(Application.StartupPath + "\\img\\" + cards[4] + ".png");
                    var hda = przetworzonedane.SelectToken("hitsDistribution.arts")?.ToObject<string[]>();
                    var hdq = przetworzonedane.SelectToken("hitsDistribution.quick")?.ToObject<string[]>();
                    var hdb = przetworzonedane.SelectToken("hitsDistribution.buster")?.ToObject<string[]>();
                    var hde = przetworzonedane.SelectToken("hitsDistribution.extra")?.ToObject<string[]>();
                    trvArt.Nodes.Clear();
                    trvArt.Nodes.Add("Arts: " + hda.Length.ToString());
                    trvBuster.Nodes.Clear();
                    trvBuster.Nodes.Add("Buster: " + hdb.Length.ToString());
                    trvQuick.Nodes.Clear();
                    trvQuick.Nodes.Add("Quick: " + hdq.Length.ToString());
                    trvExtra.Nodes.Clear();
                    trvExtra.Nodes.Add("Extra: " + hde.Length.ToString());

                    for (int i = 0; i < hda.Length; i++)
                    {
                        trvArt.Nodes[0].Nodes.Add(hda[i]);
                    }

                    for (int i = 0; i < hdb.Length; i++)
                    {
                        trvBuster.Nodes[0].Nodes.Add(hdb[i]);
                    }

                    for (int i = 0; i < hdq.Length; i++)
                    {
                        trvQuick.Nodes[0].Nodes.Add(hdq[i]);
                    }

                    for (int i = 0; i < hde.Length; i++)
                    {
                        trvExtra.Nodes[0].Nodes.Add(hde[i]);
                    }

                    lblGender.Text = "Gender: " + FirstCharToUpper((string)przetworzonedane.SelectToken("gender"));
                    lblAttr.Text = "Attribute: " + FirstCharToUpper((string)przetworzonedane.SelectToken("attribute"));
                    lblCv.Text = "Cv: " + (string)przetworzonedane.SelectToken("profile.cv");
                    lblIllustartor.Text = "Illustrator: " + (string)przetworzonedane.SelectToken("profile.illustrator");
                    lblStarAbs.Text = "Star Absorb: " + (string)przetworzonedane.SelectToken("starAbsorb");
                    lblStarGen.Text ="Star generation: " + NaProcent((string)przetworzonedane.SelectToken("starGen"));
                    lblIDChange.Text = "Instant Death Chance: " + NaProcent((string)przetworzonedane.SelectToken("instantDeathChance"));
                    int numtraits = przetworzonedane.SelectToken("traits").Count();
                    var traits = przetworzonedane.SelectToken("traits");

                    lblTraits.Text = "Traits: ";
                    for (int j=3; j<numtraits; j++)
                    {
                      lblTraits.Text = lblTraits.Text + traits.SelectToken("[" + j + "].name").ToString() + " ; ";
                    }

                    lblStrength.Text = "Strength: " + (string)przetworzonedane.SelectToken("profile.stats.strength");
                    lblEndurance.Text = "Endurance: " + (string)przetworzonedane.SelectToken("profile.stats.endurance");
                    lblAgility.Text = "Agility: " + (string)przetworzonedane.SelectToken("profile.stats.agility");
                    lblMagic.Text = "Magic: " + (string)przetworzonedane.SelectToken("profile.stats.magic");
                    lblLuck.Text = "Luck: " + (string)przetworzonedane.SelectToken("profile.stats.luck");
                    lblNp.Text = "NP: " + (string)przetworzonedane.SelectToken("profile.stats.np");
                    lbl1skill.Text = (string)przetworzonedane.SelectToken("skills.[0].name");
                    pcb1skill.Load((string)przetworzonedane.SelectToken("skills.[0].icon"));
                    lbl1skillOpis.Text = (string)przetworzonedane.SelectToken("skills.[0].detail");
                    lbl2skill.Text = (string)przetworzonedane.SelectToken("skills.[1].name");
                    pcb2skill.Load((string)przetworzonedane.SelectToken("skills.[1].icon"));
                    lbl2skillOpis.Text = (string)przetworzonedane.SelectToken("skills.[1].detail");
                    lbl3skill.Text = (string)przetworzonedane.SelectToken("skills.[2].name");
                    pcb3skill.Load((string)przetworzonedane.SelectToken("skills.[2].icon"));
                    lbl3skillOpis.Text = (string)przetworzonedane.SelectToken("skills.[2].detail");

                    var fskillcooldown = przetworzonedane.SelectToken("skills.[0].coolDown")?.ToObject<string[]>();
                    trv1Skillcooldown.Nodes.Clear();
                    trv1Skillcooldown.Nodes.Add("Cooldown");

                    for (int j = 0; j < fskillcooldown.Length; j++)
                    {
                        int licz = j + 1;
                        trv1Skillcooldown.Nodes[0].Nodes.Add("Lvl "+ licz +": " + fskillcooldown[j]);
                    }

                    var sskillcooldown = przetworzonedane.SelectToken("skills.[1].coolDown")?.ToObject<string[]>();
                    trv2Skillcooldown.Nodes.Clear();
                    trv2Skillcooldown.Nodes.Add("Cooldown");

                    for (int j = 0; j < sskillcooldown.Length; j++)
                    {
                        int licz = j + 1;
                        trv2Skillcooldown.Nodes[0].Nodes.Add("Lvl " + licz + ": " + sskillcooldown[j]);
                    }

                    var tskillcooldown = przetworzonedane.SelectToken("skills.[2].coolDown")?.ToObject<string[]>();
                    trv3Skillcooldown.Nodes.Clear();
                    trv3Skillcooldown.Nodes.Add("Cooldown");

                    for (int j = 0; j < tskillcooldown.Length; j++)
                    {
                        int licz = j + 1;
                        trv3Skillcooldown.Nodes[0].Nodes.Add("Lvl " + licz + ": " + tskillcooldown[j]);
                    }

                    dgv1Skillevels.Rows.Clear();
                    dgv1Skillevels.Columns.Clear();
                    dgv1Skillevels.RowHeadersWidth = 50;

                    var fskilldet = przetworzonedane.SelectToken("skills.[0].functions");

                    for (int j = 0; j < fskilldet.Count() ; j++)
                    {
                        if (fskilldet.SelectToken("[" + j + "].buffs").Count() != 0)
                        {
                            dgv1Skillevels.Columns.Add("col" + j.ToString(), fskilldet.SelectToken("[" + j + "].buffs.[0].name").ToString());
                            dgv1Skillevels.Columns[j].ToolTipText = fskilldet.SelectToken("[" + j + "].buffs.[0].detail").ToString();  
                        }
                        else
                        {
                            dgv1Skillevels.Columns.Add("col" + j.ToString(), FirstCharToUpper(fskilldet.SelectToken("[" + j + "].funcType").ToString()));
                            dgv1Skillevels.Columns[j].ReadOnly = true;
                        }
                    }
                    dgv1Skillevels.Rows.Add(10);

                    for (int j = 0; j < 10; j++)
                    {
                        dgv1Skillevels.Rows[j].HeaderCell.Value = (j + 1).ToString();
                    }
                        

                    for (int i = 0; i < fskilldet.Count(); i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            DataGridViewCell kom = dgv1Skillevels.Rows[j].Cells[i];

                            if (fskilldet.SelectToken("[" + i + "].svals.[" + j + "].Value") != null)
                            {
                                kom.Value = fskilldet.SelectToken("[" + i + "].svals.[" + j + "].Value").ToString();
                            }
                            else
                            {
                                kom.Value = 1;
                            }
                        }
                    }

                    dgv2Skillevels.Rows.Clear();
                    dgv2Skillevels.Columns.Clear();
                    dgv2Skillevels.RowHeadersWidth = 50;

                    var sskilldet = przetworzonedane.SelectToken("skills.[1].functions");

                    for (int j = 0; j < sskilldet.Count(); j++)
                    {
                        if (sskilldet.SelectToken("[" + j + "].buffs").Count() != 0)
                        {
                            dgv2Skillevels.Columns.Add("col" + j.ToString(), sskilldet.SelectToken("[" + j + "].buffs.[0].name").ToString());
                            dgv2Skillevels.Columns[j].ToolTipText = sskilldet.SelectToken("[" + j + "].buffs.[0].detail").ToString();
                        }
                        else
                        {
                            dgv2Skillevels.Columns.Add("col" + j.ToString(), FirstCharToUpper(sskilldet.SelectToken("[" + j + "].funcType").ToString()));
                            dgv2Skillevels.Columns[j].ReadOnly = true;
                        }
                    }
                    dgv2Skillevels.Rows.Add(10);

                    for (int j = 0; j < 10; j++)
                    {
                        dgv2Skillevels.Rows[j].HeaderCell.Value = (j + 1).ToString();
                    }


                    for (int i = 0; i < sskilldet.Count(); i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            DataGridViewCell kom = dgv2Skillevels.Rows[j].Cells[i];

                            if (sskilldet.SelectToken("[" + i + "].svals.[" + j + "].Value") != null)
                            {
                                kom.Value = sskilldet.SelectToken("[" + i + "].svals.[" + j + "].Value").ToString();
                            }
                            else
                            {
                                kom.Value = 1;
                            }
                        }
                    }

                    dgv3Skillevels.Rows.Clear();
                    dgv3Skillevels.Columns.Clear();
                    dgv3Skillevels.RowHeadersWidth = 50;

                    var tskilldet = przetworzonedane.SelectToken("skills.[2].functions");

                    for (int j = 0; j < tskilldet.Count(); j++)
                    {
                        if (tskilldet.SelectToken("[" + j + "].buffs").Count() != 0)
                        {
                            dgv3Skillevels.Columns.Add("col" + j.ToString(), tskilldet.SelectToken("[" + j + "].buffs.[0].name").ToString());
                            dgv3Skillevels.Columns[j].ToolTipText = tskilldet.SelectToken("[" + j + "].buffs.[0].detail").ToString();
                        }
                        else
                        {
                            dgv3Skillevels.Columns.Add("col" + j.ToString(), FirstCharToUpper(tskilldet.SelectToken("[" + j + "].funcType").ToString()));
                            dgv3Skillevels.Columns[j].ReadOnly = true;
                        }
                    }
                    dgv3Skillevels.Rows.Add(10);

                    for (int j = 0; j < 10; j++)
                    {
                        dgv3Skillevels.Rows[j].HeaderCell.Value = (j + 1).ToString();
                    }


                    for (int i = 0; i < tskilldet.Count(); i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            DataGridViewCell kom = dgv3Skillevels.Rows[j].Cells[i];

                            if (tskilldet.SelectToken("[" + i + "].svals.[" + j + "].Value") != null)
                            {
                                kom.Value = tskilldet.SelectToken("[" + i + "].svals.[" + j + "].Value").ToString();
                            }
                            else
                            {
                                kom.Value = 1;
                            }
                        }
                    }

                    var passiveskills = przetworzonedane.SelectToken("classPassive");
                    int numpasssk = przetworzonedane.SelectToken("classPassive").Count();
                    WebClient wc = new WebClient();

                    dgvPassiveSkills.Rows.Clear();
                    dgvPassiveSkills.Columns.Clear();

                    DataGridViewImageColumn dgvImageColumn = new DataGridViewImageColumn();
                    dgvImageColumn.HeaderText = "Icon";
                    dgvImageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    dgvImageColumn.Width = 48;
                    DataGridViewTextBoxColumn dgvNameColumn = new DataGridViewTextBoxColumn();
                    dgvNameColumn.HeaderText = "Name";
                    DataGridViewTextBoxColumn dgvDetailColumn = new DataGridViewTextBoxColumn();
                    dgvDetailColumn.HeaderText = "Deatil";

                    dgvPassiveSkills.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dgvPassiveSkills.RowTemplate.Height = 48;
                    dgvPassiveSkills.AllowUserToAddRows = false;

                    dgvPassiveSkills.Columns.Add(dgvImageColumn);
                    dgvPassiveSkills.Columns.Add(dgvNameColumn);
                    dgvPassiveSkills.Columns.Add(dgvDetailColumn);

                    for (int j = 0; j < numpasssk; j++)
                    {
                        try
                        {
                            byte[] bytes1 = wc.DownloadData((string)przetworzonedane.SelectToken("classPassive.[" + j + "].icon"));
                            MemoryStream ms1 = new MemoryStream(bytes1);
                            System.Drawing.Image image1 = System.Drawing.Image.FromStream(ms1);

                            dgvPassiveSkills.Rows.Add(image1, passiveskills.SelectToken("[" + j + "].name").ToString(), passiveskills.SelectToken("[" + j + "].detail").ToString());

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //throw;
                        }
                        
                    }

                }
            }
        }

        private void pcbAscezja1_Click(object sender, EventArgs e)
        {
            frmPoglad form = new frmPoglad();

            Control[] ctrls = form.Controls.Find("pcbZdjecie", false);
            if (ctrls.Length > 0)
            {
                PictureBox pcbZdjecie = (PictureBox)ctrls[0];
                pcbZdjecie.Image = pcbAscezja1.Image;
            }

            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void pcbAscezja2_Click(object sender, EventArgs e)
        {
            frmPoglad form = new frmPoglad();

            Control[] ctrls = form.Controls.Find("pcbZdjecie", false);
            if (ctrls.Length > 0)
            {
                PictureBox pcbZdjecie = (PictureBox)ctrls[0];
                pcbZdjecie.Image = pcbAscezja2.Image;
            }

            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void pcbAscezja3_Click(object sender, EventArgs e)
        {
            frmPoglad form = new frmPoglad();

            Control[] ctrls = form.Controls.Find("pcbZdjecie", false);
            if (ctrls.Length > 0)
            {
                PictureBox pcbZdjecie = (PictureBox)ctrls[0];
                pcbZdjecie.Image = pcbAscezja3.Image;
            }

            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void pcbAscezja4_Click(object sender, EventArgs e)
        {
            frmPoglad form = new frmPoglad();

            Control[] ctrls = form.Controls.Find("pcbZdjecie", false);
            if (ctrls.Length > 0)
            {
                PictureBox pcbZdjecie = (PictureBox)ctrls[0];
                pcbZdjecie.Image = pcbAscezja4.Image;
            }

            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            JObject przetworzonedane = (JObject)e.Argument;

            try
            {
                pcbPortret.Load((string)przetworzonedane.SelectToken("extraAssets.status.ascension.1"));
                pcbAscezja1.Load((string)przetworzonedane.SelectToken("extraAssets.charaGraph.ascension.1"));
                pcbAscezja2.Load((string)przetworzonedane.SelectToken("extraAssets.charaGraph.ascension.2"));
                pcbAscezja3.Load((string)przetworzonedane.SelectToken("extraAssets.charaGraph.ascension.3"));
                pcbAscezja4.Load((string)przetworzonedane.SelectToken("extraAssets.charaGraph.ascension.4"));
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //throw;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripProgressBar1.Visible = false;
            cmbLista.Enabled = true;
        }

        private void btnLista_Click(object sender, EventArgs e)
        {
            szukaj = false;
            ZaładujListe();
        }

        private void btnSzukaj_Click(object sender, EventArgs e)
        {
            String servants = "";
            szukaj = true;
            var url = "https://api.atlasacademy.io/basic/JP/servant/search?name="+txtSzukaj.Text+"&lang=en";
            //var url = "http://localhost/basic_servant_lang_en.json";
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.Accept = "application/json";

            try
            {
                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    servants = result.ToString();
                }

                toolStripStatusLabel1.Text = "Pobieranie Listy: " + httpResponse.StatusCode.ToString();
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Pobieranie Listy: Błąd";
                //throw;
            }

            if (servants != "")
            {
                cmbLista.Items.Clear();
                JArray przetworzonedane = JArray.Parse(servants);
                //Console.WriteLine((string)przetworzonedane.SelectToken("[0].name"));

                for (int j=0; j<ServId.Length; j++)
                {
                    ServId[j] = null;
                }

                for (int i = 0; i < przetworzonedane.Count; i++)
                {
                    String nazwa = (string)przetworzonedane.SelectToken("[" + i + "].name") + " [" + (string)przetworzonedane.SelectToken("[" + i + "].className") + "]";
                    ServId[i] = (string)przetworzonedane.SelectToken("[" + i + "].collectionNo");
                    cmbLista.Items.Add(nazwa);
                }
            }
        }

        private void rdbNA_CheckedChanged(object sender, EventArgs e)
        {
            region = "NA";
        }

        private void rdbJP_CheckedChanged(object sender, EventArgs e)
        {
            region = "JP";
        }

    }
}
