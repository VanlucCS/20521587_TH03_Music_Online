using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20521587_TH03_Music_Online
{
    public partial class fMusic : Form
    {
        public fMusic()
        {
            InitializeComponent();
        }

        #region abc
        private string _Myvar;

        public string myvar
        {
            get { return _Myvar; }
            set { _Myvar = value; }
        }
        #endregion

        private void gunaGradient2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fMusic_Load(object sender, EventArgs e)
        {

        }
    }
}
