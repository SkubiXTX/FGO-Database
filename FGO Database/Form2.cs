using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FGO_Database
{
    public partial class frmPoglad : Form
    {
        public frmPoglad()
        {
            InitializeComponent();

        }

        private void frmPoglad_Load(object sender, EventArgs e)
        {
      
        }

        private void frmPoglad_FormClosed(object sender, FormClosedEventArgs e)
        {
            pcbZdjecie.Dispose();
        }
    }
}
