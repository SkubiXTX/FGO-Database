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
        public frmOknoGl()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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

                MessageBox.Show(ex.Message,"Błąd",MessageBoxButtons.OK,MessageBoxIcon.Error);
                //throw;
            }

            JArray przetworzonedane = JArray.Parse(servants);
            //Console.WriteLine((string)przetworzonedane.SelectToken("[0].name"));

            for (int i = 0; i < przetworzonedane.Count; i++)
            {
                String nazwa = (string)przetworzonedane.SelectToken("[" + i + "].name") + " [" + (string)przetworzonedane.SelectToken("[" + i + "].className") + "]";

                cmbLista.Items.Add(nazwa);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String dane = "";

            if (cmbLista.Items.Count != 0)
            {
                int id = cmbLista.SelectedIndex + 1;
                //var url = "https://api.atlasacademy.io/nice/JP/servant/" + id.ToString();
                var url = "http://localhost/239.json";
                var httpRequest = (HttpWebRequest)WebRequest.Create(url);

                httpRequest.Accept = "application/json";
                toolStripStatusLabel2.Visible = true;
                toolStripProgressBar1.Visible = true;

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
                    MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //throw;
                }

                JObject przetworzonedane = JObject.Parse(dane);

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
                
                lblNazwa.Text = (string)przetworzonedane.SelectToken("name");
                pcbClassIcon.Load(Application.StartupPath + "\\img\\" + (string)przetworzonedane.SelectToken("className")+".png");
                lblClassName.Text = (string)przetworzonedane.SelectToken("className");

                toolStripProgressBar1.Visible = false;
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

            form.Show();
        }
    }
}
