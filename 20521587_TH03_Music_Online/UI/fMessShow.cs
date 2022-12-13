using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20521587_TH03_Music_Online.UI
{
    public partial class fMessShow : Form
    {
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        public fMessShow(string danhgia)
        {
            InitializeComponent();
            //guna2AnimateWindow1.SetAnimateWindow(this);
            guna2ShadowForm1.SetShadowForm(this);
            //guna2Transition1.ShowSync(this);
            t.Interval = 1500;
            t.Tick += T_Tick;
            t.Start();
            guna2GradientButton1.Text = danhgia;
            //Thread.Sleep(2000);
            //this.Close();

        }

        private void T_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
