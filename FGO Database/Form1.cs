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
        public Boolean szukaj = false;
        public String[] ServId = new string[1000];
        public String region = "NA";
        public JObject przetworzonedane = null;
        public Int32[] skill1ids = new Int32[10];
        public Int32[] skill2ids = new Int32[10];
        public Int32[] skill3ids = new Int32[10];

        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                
            }

            return input.First().ToString().ToUpper() + String.Join("", input.Skip(1));
        }

        public string NaProcent(string liczba, int dzielnik)
        {
            String wynik = "";
            float temp = 0;

            temp = float.Parse(liczba);
            wynik = String.Format("{0}%", temp / dzielnik);

            return wynik;
        }

        public void ZaładujListe (string region)
        {
            String servants = "";
            String url = "";
            String temp = "";

            if (region == "NA")
            {
                url = "https://api.atlasacademy.io/export/NA/basic_servant.json";
            }
            else
            {
                url = "https://api.atlasacademy.io/export/JP/basic_servant_lang_en.json";
            }

            //url = "http://localhost/basic_servant_lang_en.json";

            try
            {
                var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                httpRequest.Accept = "application/json";

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

                MessageBox.Show(ex.Message, "Błąd pobierania listy serwantów", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                for (int j = 0; j < przetworzonedane.Count; j++)
                {
                    temp = cmbLista.Items[j].ToString();
                    temp = temp.Replace("Altria","Arturia");
                    cmbLista.Items[j] = temp;
                }


            }
        }

        public void WykryjOvercharge(JToken danenp)
        {
            Int32[] temp = new int[5];
            Int32 temp2 = 0;
            Int32[] nrfunc = new int[5];
            Int32 licz = 0;
            Int32 licz2 = 0;
            Boolean ovc = false;

            for (int i = 0; i < nrfunc.Length; i++)
            {
                nrfunc[i] = -1;
            }

            for (int i = 0; i < danenp.Count(); i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (danenp.SelectToken("[" + i + "].svals.[" + j + "].Value") != null)
                    {
                        temp[j] = (Int32)danenp.SelectToken("[" + i + "].svals.[" + j + "].Value");
                    }
                    else
                    {
                        if (danenp.SelectToken("[" + i + "].svals.[" + j + "].Rate") != null)
                        {
                            temp[j] = (Int32)danenp.SelectToken("[" + i + "].svals.[" + j + "].Rate");
                        }
                        else
                        {
                            temp[j] = 1;
                        }
                    }
                }

                for (int k = 1; k < 5; k++)
                {
                    if (temp[k - 1] == temp[k] && temp[k - 1] != 1)
                    {
                        temp2++;
                    }
                }

                if(danenp.SelectToken("[" + i + "].svals.[0].Value") != null)
                {
                    if ((Int32)danenp.SelectToken("[" + i + "].svals.[0].Value") == (Int32)danenp.SelectToken("[" + i + "].svals2.[0].Value"))
                    {
                        temp2 = 0;
                    }
                }

                if (danenp.SelectToken("[" + i + "].svals2.[0].Rate") != null)
                {
                    if (danenp.SelectToken("[" + i + "].svals2.[0].Value") == null && (Int32)danenp.SelectToken("[" + i + "].svals2.[0].Rate") == 1000)
                    {
                        temp2 = 0;
                    }
                }

                if (temp2 == 4)
                {
                    ovc = true;
                    nrfunc[licz] = i;
                    licz++;
                    temp2 = 0;
                }

                
            }

            if (danenp.SelectToken("[0].svals.[0].Correction") != null)
            {
                dgvNpdata.Columns.Add("colovc", "OverCharge");

                for (int i = 1; i <= 5; i++)
                {
                    DataGridViewCell kom = dgvNpdata.Rows[i-1].Cells[dgvNpdata.Columns.Count-1];

                    if (i == 1)
                    {
                        kom.Value = danenp.SelectToken("[0].svals.[0].Correction").ToString();
                    }
                    else
                    {
                        kom.Value = danenp.SelectToken("[0].svals" + i + ".[0].Correction").ToString();
                    }
                    
                }

            }

            for (int i = 0; i < nrfunc.Length; i++)
            {
                if (nrfunc[i] != -1)
                {
                    licz2++;
                }
            }


            for (int i = 0; i < licz2; i++)
            {

                if (danenp.SelectToken("[" + nrfunc[i] + "].buffs.[0].name") != null)
                {
                    
                    dgvNpdata.Columns.Add("colovc" + i.ToString(), danenp.SelectToken("[" + nrfunc[i] + "].buffs.[0].name").ToString() + " (OverCharge)");
                }
                else
                {   
                    if ((string)danenp.SelectToken("[" + i + "].funcPopupText") != "" || (string)danenp.SelectToken("[" + i + "].funcPopupText") == "None")
                    {

                        dgvNpdata.Columns.Add("colovc" + i.ToString(), danenp.SelectToken("[" + nrfunc[i] + "].funcPopupText").ToString() + " (OverCharge)");
                    }
                    else
                    {

                        dgvNpdata.Columns.Add("colovc" + i.ToString(), danenp.SelectToken("[" + nrfunc[i] + "].funcType").ToString() + " (OverCharge)");
                    }

                }

                int lc = dgvNpdata.Columns.Count + (i - licz2);
                if (dgvNpdata.Columns[lc].HeaderText == "None")
                {
                    dgvNpdata.Columns[lc].HeaderText = FirstCharToUpper(danenp.SelectToken("[" + nrfunc[i] + "].funcType").ToString());
                }

            }

            if (ovc == true)
            {
                for (int i = 0; i < licz2; i++)
                {
                    int lc = dgvNpdata.Columns.Count + (i - licz2);

                    for (int j = 0; j < 5; j++)
                    {

                        DataGridViewCell kom = dgvNpdata.Rows[j].Cells[lc];
                        String tempfunc = (String)danenp.SelectToken("[" + i + "].funcType");
                        String tempkom = "";

                        if (tempfunc != "none")
                        {
                            if (danenp.SelectToken("[" + nrfunc[i] + "].svals.[0].Value") != null || danenp.SelectToken("[" + nrfunc[i] + "].svals.[0].Rate") != null)
                            {

                                if ((String)danenp.SelectToken("[" + nrfunc[i] + "].svals.[1].Value") != (String)danenp.SelectToken("[" + nrfunc[i] + "].svals2.[1].Value"))
                                {
                                    if (j == 0)
                                    {
                                        tempkom = danenp.SelectToken("[" + nrfunc[i] + "].svals.[0].Value").ToString();
                                        kom.Value = Poprawliczby(tempkom, i, j, tempfunc);
                                    }
                                    else
                                    {
                                        tempkom = danenp.SelectToken("[" + nrfunc[i] + "].svals" + (j + 1) + ".[0].Value").ToString();
                                        kom.Value = Poprawliczby(tempkom, i, j, tempfunc);
                                    }
                                }
                                else
                                {
                                    if (j == 0)
                                    {
                                        tempkom = danenp.SelectToken("[" + nrfunc[i] + "].svals.[0].Rate").ToString();
                                        kom.Value = Poprawliczby(tempkom, i, j, tempfunc);
                                    }
                                    else
                                    {
                                        tempkom = danenp.SelectToken("[" + nrfunc[i] + "].svals" + (j + 1) + ".[0].Rate").ToString();
                                        kom.Value = Poprawliczby(tempkom, i, j, tempfunc);
                                    }
                                }
                            }
                            else
                            {
                                kom.Value = 1;
                            }
                        }
                        else
                        {
                            kom.Value = 1;
                        }

                    }
                    
                }
            }

        }

        public String Poprawliczby (String dane, Int32 i, Int32 j, String functype)
        {

            if (dane != null)
            {

                if ((dane.Length == 3 || dane.Length == 4 || dane.Length == 5) && (functype != "gainHp" || functype != "loseHp" || functype != "lossHpSafe"))
                {
                    if (dane.Length == 3)
                    {
                        dane = NaProcent(dane, 10);
                    }
                    else
                    {
                        if (functype == "damageNp")
                        {
                            dane = NaProcent(dane, 10);
                        }
                        else
                        {
                            dane = NaProcent(dane, 100);
                        }

                    }
                }

                return dane;
            }
            else
            {
                return "1";
            }
        }

        public void WypelnijDaneSkillow (JToken dane, DataGridView dgvskill, TreeView trvskillcooldown, Int32 Nrskilla)
        {
            var skillcooldown = dane.SelectToken("skills.[" + Nrskilla + "].coolDown")?.ToObject<string[]>();
            trvskillcooldown.Nodes.Clear();
            trvskillcooldown.Nodes.Add("Cooldown");

            for (int j = 0; j < skillcooldown.Length; j++)
            {
                int licz = j + 1;
                trvskillcooldown.Nodes[0].Nodes.Add("Lvl " + licz + ": " + skillcooldown[j]);
            }


            dgvskill.Rows.Clear();
            dgvskill.Columns.Clear();
            dgvskill.RowHeadersWidth = 50;

            var skilldet = dane.SelectToken("skills.[" + Nrskilla + "].functions");

            for (int j = 0; j < skilldet.Count(); j++)
            {
                if (skilldet.SelectToken("[" + j + "].buffs").Count() != 0)
                {
                    dgvskill.Columns.Add("col" + j.ToString(), skilldet.SelectToken("[" + j + "].buffs.[0].name").ToString());
                    dgvskill.Columns[j].ToolTipText = skilldet.SelectToken("[" + j + "].buffs.[0].detail").ToString();
                }
                else
                {
                    dgvskill.Columns.Add("col" + j.ToString(), FirstCharToUpper(skilldet.SelectToken("[" + j + "].funcType").ToString()));

                }
            }
            dgvskill.Rows.Add(10);

            for (int j = 0; j < 10; j++)
            {
                dgvskill.Rows[j].HeaderCell.Value = (j + 1).ToString();
            }


            for (int i = 0; i < skilldet.Count(); i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    DataGridViewCell kom = dgvskill.Rows[j].Cells[i];
                    String tempfunc = (String)skilldet.SelectToken("[" + i + "].funcType");
                    String tempkom = "";

                    if ((String)skilldet.SelectToken("[" + i + "].svals.[1].Value") != (String)skilldet.SelectToken("[" + i + "].svals.[2].Value"))
                    {
                        if (skilldet.SelectToken("[" + i + "].svals.[" + j + "].Value") != null)
                        {
                            tempkom = skilldet.SelectToken("[" + i + "].svals.[" + j + "].Value").ToString();
                            kom.Value = Poprawliczby(tempkom, i, j, tempfunc);
                        }
                        else
                        {
                            kom.Value = 1;
                        }
                    }
                    else
                    {
                        if ((String)skilldet.SelectToken("[" + i + "].svals.[1].Rate") != (String)skilldet.SelectToken("[" + i + "].svals.[2].Rate"))
                        {
                            if (skilldet.SelectToken("[" + i + "].svals.[" + j + "].Rate") != null)
                            {
                                tempkom = skilldet.SelectToken("[" + i + "].svals.[" + j + "].Rate").ToString();
                                kom.Value = Poprawliczby(tempkom, i, j, tempfunc);
                            }
                            else
                            {
                                kom.Value = 1;
                            } 
                        }
                        else
                        {
                            if (skilldet.SelectToken("[" + i + "].svals.[" + j + "].Value") != null)
                            {
                                tempkom = skilldet.SelectToken("[" + i + "].svals.[" + j + "].Value").ToString();
                                kom.Value = Poprawliczby(tempkom, i, j, tempfunc);
                            }
                            else
                            {
                                kom.Value = 1;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < skilldet.Count(); i++)
            {

                if (skilldet.SelectToken("[" + i + "].svals.[0].Value") == null)
                {
                    if ((Int32)skilldet.SelectToken("[" + i + "].svals.[0].Rate") == 1000)
                    {
                        dgvskill.Columns[i].Visible = false;
                    } 
                }
                else
                {
                    if ((Int32)skilldet.SelectToken("[" + i + "].svals.[0].Value") == 1)
                    {
                        if ((Int32)skilldet.SelectToken("[" + i + "].svals.[0].Rate") == 1000)
                        {
                            dgvskill.Columns[i].Visible = false;
                        }
                    }
                }

                if ((String)skilldet.SelectToken("[" + i + "].funcType") == "hastenNpturn")
                {
                    dgvskill.Columns[i].Visible = false;
                }
            }
        }

        public void WypelnijDaneNP(JToken dane, Int32 nplicz)
        {
            pcbNpcardtype.Load(Application.StartupPath + "\\img\\" + (string)dane.SelectToken("noblePhantasms.[" + nplicz + "].card") + ".png");
            lblNpname.Text = (string)dane.SelectToken("noblePhantasms.[" + nplicz + "].name");
            txtNpopis.BackColor = Color.FromKnownColor(KnownColor.White);
            txtNpopis.Text = (string)dane.SelectToken("noblePhantasms.[" + nplicz + "].detail");
            lblNprank.Text = "Rank: " + (string)dane.SelectToken("noblePhantasms.[" + nplicz + "].rank");
            lblNptype.Text = "Type: " + (string)dane.SelectToken("noblePhantasms.[" + nplicz + "].type");
            lblNPgain.Text = "NP Charge ATK: " + NaProcent((string)dane.SelectToken("noblePhantasms.[" + nplicz + "].npGain.np.[0]"), 100);
            ttpOpis.SetToolTip(this.lblNPgain, "Affects how much the NP Gauge is increased by when attacking enemies.");
            lblNpdef.Text = "NP Charge DEF: " + NaProcent((string)dane.SelectToken("noblePhantasms.[" + nplicz + "].npGain.defence.[0]"), 100);
            ttpOpis.SetToolTip(this.lblNpdef, "Affects how much the NP Gauge is increased by when being attacked.");

            trvNphitdist.Nodes.Clear();
            var hdnp = dane.SelectToken("noblePhantasms.[" + nplicz + "].npDistribution")?.ToObject<string[]>();
            trvNphitdist.Nodes.Add("Hits: " + hdnp.Length.ToString());

            for (int i = 0; i < hdnp.Length; i++)
            {
                trvNphitdist.Nodes[0].Nodes.Add(hdnp[i]);
            }

            dgvNpdata.Columns.Clear();
            dgvNpdata.Rows.Clear();

            var npdet = dane.SelectToken("noblePhantasms.[" + nplicz + "].functions");

            for (int j = 0; j < npdet.Count(); j++)
            {
                if (npdet.SelectToken("[" + j + "].buffs").Count() != 0)
                {
                    dgvNpdata.Columns.Add("col" + j.ToString(), npdet.SelectToken("[" + j + "].buffs.[0].name").ToString());
                    dgvNpdata.Columns[j].ToolTipText = npdet.SelectToken("[" + j + "].buffs.[0].detail").ToString();
                }
                else
                {
                    if ((string)npdet.SelectToken("[" + j + "].funcPopupText") != "")
                    {
                        dgvNpdata.Columns.Add("col" + j.ToString(), FirstCharToUpper(npdet.SelectToken("[" + j + "].funcPopupText").ToString()));
                    }
                    else
                    {
                        dgvNpdata.Columns.Add("col" + j.ToString(), FirstCharToUpper(npdet.SelectToken("[" + j + "].funcType").ToString()));
                    }
                }

                if (dgvNpdata.Columns[j].HeaderText == "None")
                {
                    dgvNpdata.Columns[j].HeaderText = FirstCharToUpper(npdet.SelectToken("[" + j + "].funcType").ToString());
                }

            }
            dgvNpdata.Rows.Add(5);

            for (int j = 0; j < 5; j++)
            {
                dgvNpdata.Rows[j].HeaderCell.Value = (j + 1).ToString();
            }

            for (int i = 0; i < npdet.Count(); i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    DataGridViewCell kom = dgvNpdata.Rows[j].Cells[i];
                    String tempfunc = (String)npdet.SelectToken("[" + i + "].funcType");
                    String tempkom = "";

                    if ((String)npdet.SelectToken("[" + i + "].svals.[1].Value") != (String)npdet.SelectToken("[" + i + "].svals.[2].Value"))
                    {
                        if (npdet.SelectToken("[" + i + "].svals.[" + j + "].Value") != null)
                        {
                            tempkom = npdet.SelectToken("[" + i + "].svals.[" + j + "].Value").ToString();
                            kom.Value = Poprawliczby(tempkom, i, j, tempfunc);
                        }
                        else
                        {
                            kom.Value = 1;
                        }
                    }
                    else
                    {
                        if ((String)npdet.SelectToken("[" + i + "].svals.[1].Rate") != (String)npdet.SelectToken("[" + i + "].svals.[2].Rate"))
                        {
                            if (npdet.SelectToken("[" + i + "].svals.[" + j + "].Rate") != null)
                            {
                                tempkom = npdet.SelectToken("[" + i + "].svals.[" + j + "].Rate").ToString();
                                kom.Value = Poprawliczby(tempkom, i, j, tempfunc);
                            }
                            else
                            {
                                kom.Value = 1;
                            }
                        }
                        else
                        {
                            if (npdet.SelectToken("[" + i + "].svals.[" + j + "].Value") != null)
                            {
                                tempkom = npdet.SelectToken("[" + i + "].svals.[" + j + "].Value").ToString();
                                kom.Value = Poprawliczby(tempkom, i, j, tempfunc);
                            }
                            else
                            {
                                kom.Value = 1;
                            }
                        }
                    }

                }
            }

            WykryjOvercharge(npdet);

            for (int i = 0; i < npdet.Count(); i++)
            {
                if ((String)npdet.SelectToken("[" + i + "].funcType") != "none")
                {
                    if (npdet.SelectToken("[" + i + "].svals.[0].Value") == null)
                    {
                        if ((Int32)npdet.SelectToken("[" + i + "].svals.[0].Rate") == 1000)
                        {
                            dgvNpdata.Columns[i].Visible = false;
                        }
                    }
                    else
                    {
                        if ((Int32)npdet.SelectToken("[" + i + "].svals.[0].Value") == 1 || npdet.SelectToken("[" + i + "].svals.[0].Value").ToString().Length == 6)
                        {
                            if ((Int32)npdet.SelectToken("[" + i + "].svals.[0].Rate") == 1000)
                            {
                                dgvNpdata.Columns[i].Visible = false;
                            }
                        }
                    }
                }
                else
                {
                    dgvNpdata.Columns[i].Visible = false;
                }

                if ((String)npdet.SelectToken("[" + i + "].funcType") == "hastenNpturn")
                {
                    dgvNpdata.Columns[i].Visible = false;
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

            ZaładujListe(region);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String dane = "";

            if (cmbLista.Items.Count != 0)
            {
                int id = cmbLista.SelectedIndex + 1;
                var url = "";

                if (szukaj == false)
                {
                    url = "https://api.atlasacademy.io/nice/"+ region +"/servant/" + id.ToString() + "?lore=true&lang=en"; 
                }
                else
                {
                    url = "https://api.atlasacademy.io/nice/"+ region +"/servant/" + ServId[id - 1] + "?lore=true&lang=en";
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

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Błąd pobierania danych serwanta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    toolStripStatusLabel2.Text = "Pobieranie Danych: Błąd";
                    toolStripProgressBar1.Visible = false;

                    //throw;
                }

                if (dane != "")
                {
                    przetworzonedane = JObject.Parse(dane);
                    cmbLista.Enabled = false;
                    bgwObrazyAscezji.RunWorkerAsync(przetworzonedane);

                    String appid = "";
                    String temp = "";

                    int tid = (Int16)przetworzonedane.SelectToken("collectionNo");
                    appid = "#" + tid.ToString("000");
                    lblNazwa.Text = (string)przetworzonedane.SelectToken("name");
                    temp = lblNazwa.Text;
                    temp = temp.Replace("Altria", "Arturia");
                    lblNazwa.Text = temp;
                    lblNazwa.Text.Replace("Altria", "Arturia");
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
                    lblStarGen.Text = "Star generation: " + NaProcent((string)przetworzonedane.SelectToken("starGen"), 10);
                    lblIDChange.Text = "Instant Death Chance: " + NaProcent((string)przetworzonedane.SelectToken("instantDeathChance"), 10);
                    int numtraits = przetworzonedane.SelectToken("traits").Count();
                    var traits = przetworzonedane.SelectToken("traits");

                    lblTraits.Text = "Traits: ";
                    for (int j = 3; j < numtraits; j++)
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

                    cmb1Skillvariants.Items.Clear();
                    cmb2Skillvariants.Items.Clear();
                    cmb3Skillvariants.Items.Clear();

                    Int32 liczpsk1 = 0;
                    Int32 liczpsk2 = 0;
                    Int32 liczpsk3 = 0;

                    for (int i = 0; i < przetworzonedane.SelectToken("skills").Count(); i++)
                    {
                        Int32 switch_on = 0;
                        switch_on = (Int32)przetworzonedane.SelectToken("skills.[" + i + "].num");

                        switch (switch_on)
                        {
                            case 1:
                                cmb1Skillvariants.Items.Add((String)przetworzonedane.SelectToken("skills.[" + i + "].name"));
                                cmb1Skillvariants.SelectedIndex = 0;
                                skill1ids[liczpsk1] = i;
                                liczpsk1++;
                                break;

                            case 2:
                                cmb2Skillvariants.Items.Add((String)przetworzonedane.SelectToken("skills.[" + i + "].name"));
                                cmb2Skillvariants.SelectedIndex = 0;
                                skill2ids[liczpsk2] = i;
                                liczpsk2++;
                                break;

                            case 3:
                                cmb3Skillvariants.Items.Add((String)przetworzonedane.SelectToken("skills.[" + i + "].name"));
                                cmb3Skillvariants.SelectedIndex = 0;
                                skill3ids[liczpsk3] = i;
                                liczpsk3++;
                                break;

                            default:

                                break;

                        }

                    }

                    WypelnijDaneSkillow(przetworzonedane, dgv1Skillevels, trv1Skillcooldown, 0);
                    WypelnijDaneSkillow(przetworzonedane, dgv2Skillevels, trv2Skillcooldown, 1);
                    WypelnijDaneSkillow(przetworzonedane, dgv3Skillevels, trv3Skillcooldown, 2);

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
                            MessageBox.Show(ex.Message, "Błąd obrazów skill passive", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //throw;
                        }

                    }

                    int nplicz = 0;

                    cmbNPvariants.Items.Clear();

                    for (int i = 0; i < nplicz + 1; i++)
                    {
                        cmbNPvariants.Items.Add((string)przetworzonedane.SelectToken("noblePhantasms.[" + i + "].name") + " Rank: " + (string)przetworzonedane.SelectToken("noblePhantasms.[" + i + "].rank"));
                    }
                    cmbNPvariants.SelectedIndex = nplicz;

                    WypelnijDaneNP(przetworzonedane, nplicz);

                    var bondlvl = przetworzonedane.SelectToken("bondGrowth")?.ToObject<int[]>();
                    trvBondlvl.Nodes.Clear();
                    trvBondlvl.Nodes.Add("Bond Lvl");

                    for (int i = 0; i < bondlvl.Length; i++)
                    {
                        trvBondlvl.Nodes[0].Nodes.Add((i + 1).ToString() + ": " + bondlvl[i].ToString());
                    }

                    var bondceid = (string)przetworzonedane.SelectToken("bondEquip");
                    var urlce = "https://api.atlasacademy.io/nice/" + region + "/equip/" + bondceid + "?lang=en";
                    var httpRequestce = (HttpWebRequest)WebRequest.Create(urlce);
                    string danece = "";

                    try
                    {
                        var httpResponsece = (HttpWebResponse)httpRequestce.GetResponse();
                        using (var streamReaderce = new StreamReader(httpResponsece.GetResponseStream()))
                        {
                            var resultce = streamReaderce.ReadToEnd();
                            danece = resultce.ToString();
                        }

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Błąd pobierania danych bond ce", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        toolStripStatusLabel2.Text = "Pobieranie Danych: Błąd";

                        //throw;
                    }

                    JObject przetworzonedanece = JObject.Parse(danece);
                    if (danece != "")
                    {
                        try
                        {
                            pcbBondce.Load((string)przetworzonedanece.SelectToken("extraAssets.faces.equip." + bondceid));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Błąd pobierania obraza bond ce", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //throw;
                        }

                        lblBondceName.Text = (string)przetworzonedanece.SelectToken("name");
                        lblBondcedet.Text = "";

                        for (int i = 0; i < przetworzonedanece.SelectToken("skills").Count(); i++)
                        {
                            lblBondcedet.Text = lblBondcedet.Text + (string)przetworzonedanece.SelectToken("skills.[" + i + "].detail") + "\r\n";
                            temp = lblBondcedet.Text;
                            temp = temp.Replace("Altria", "Arturia");
                            lblBondcedet.Text = temp;
                        }

                    }

                    //kontynuacja

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
                MessageBox.Show(ex.Message, "Błąd ładowania obrazów ascezji", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ZaładujListe(region);
        }

        private void btnSzukaj_Click(object sender, EventArgs e)
        {
            String servants = "";
            szukaj = true;
            var url = "https://api.atlasacademy.io/basic/" + region + "/servant/search?name="+txtSzukaj.Text+"&lang=en";
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

                MessageBox.Show(ex.Message, "Błąd pobierania listy wyszukiwania", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            cmbLista.Items.Clear();
            ZaładujListe(region);
            szukaj = false;
        }

        private void rdbJP_CheckedChanged(object sender, EventArgs e)
        {
            region = "JP";
            cmbLista.Items.Clear();
            ZaładujListe(region);
            szukaj = false;
        }

        private void txtSzukaj_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==(char)13)
            {
                btnSzukaj.PerformClick();
            }
        }

        private void cmbNPvariants_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbNPvariants.Items.Count != 0)
            {
                WypelnijDaneNP(przetworzonedane, cmbNPvariants.SelectedIndex);
            }
        }

        private void cmb1Skillvariants_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmb1Skillvariants.Items.Count != 0)
            {
                WypelnijDaneSkillow(przetworzonedane, dgv1Skillevels, trv1Skillcooldown, skill1ids[cmb1Skillvariants.SelectedIndex]);
            }
        }

        private void cmb2Skillvariants_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb3Skillvariants.Items.Count != 0)
            {
                WypelnijDaneSkillow(przetworzonedane, dgv2Skillevels, trv2Skillcooldown, skill2ids[cmb2Skillvariants.SelectedIndex]);
            }
        }

        private void cmb3Skillvariants_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb3Skillvariants.Items.Count != 0)
            {
                WypelnijDaneSkillow(przetworzonedane, dgv3Skillevels, trv3Skillcooldown, skill3ids[cmb3Skillvariants.SelectedIndex]);
            }
        }
    }
}
