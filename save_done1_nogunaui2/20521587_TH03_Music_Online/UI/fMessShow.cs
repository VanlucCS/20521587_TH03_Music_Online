﻿using System;
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
        public fMessShow()
        {
            InitializeComponent();
            t.Interval = 1200;
            t.Tick += T_Tick;
            t.Start();
            //Thread.Sleep(2000);
            //this.Close();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}