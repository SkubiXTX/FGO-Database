using Newtonsoft.Json.Linq;
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
        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("Pusty String!");
            return input.First().ToString().ToUpper() + String.Join("", input.Skip(1));
        }

        public frmOknoGl()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String servants = "";

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

                MessageBox.Show(ex.Message,"Błąd",MessageBoxButtons.OK,MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Pobieranie Listy: Błąd";
                //throw;
            }

            if (servants != "")
            {
                JArray przetworzonedane = JArray.Parse(servants);
                //Console.WriteLine((string)przetworzonedane.SelectToken("[0].name"));

                for (int i = 0; i < przetworzonedane.Count; i++)
                {
                    String nazwa = (string)przetworzonedane.SelectToken("[" + i + "].name") + " [" + (string)przetworzonedane.SelectToken("[" + i + "].className") + "]";

                    cmbLista.Items.Add(nazwa);
                } 
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String dane = "";
            String appid = "";
            Boolean JPonly = false;

            if (cmbLista.Items.Count != 0)
            {
                int id = cmbLista.SelectedIndex + 1;
                var url = "https://api.atlasacademy.io/nice/NA/servant/" + id.ToString()+ "?lore=true&lang=en";
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

                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //toolStripStatusLabel2.Text = "Pobieranie Danych: Błąd";
                    //toolStripProgressBar1.Visible = false;
                    JPonly = true;
                    //throw;
                }

                if (JPonly == true)
                {
                    var url2 = "https://api.atlasacademy.io/nice/JP/servant/" + id.ToString() + "?lore=true&lang=en";
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
                    lblIllustartor.Text = "Illustrator: " + (string)przetworzonedane.SelectToken("profile.illustrator"); ;
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
    }
}
