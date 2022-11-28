using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20521587_TH03_Music_Online.UI
{
    public partial class ucAddReview : UserControl
    {
        public ucAddReview()
        {
            InitializeComponent();
        }

        private void setRate(int a, int b, int c, int d, int e)
        {
            pbstart1.Image = _20521587_TH03_Music_Online.Properties.Resources.star__2_;
            pbstart2.Image = _20521587_TH03_Music_Online.Properties.Resources.star__2_;
            pbstart3.Image = _20521587_TH03_Music_Online.Properties.Resources.star__2_;
            pbstart4.Image = _20521587_TH03_Music_Online.Properties.Resources.star__2_;
            pbstart5.Image = _20521587_TH03_Music_Online.Properties.Resources.star__2_;
            if (e == 0)
                pbstart1.Image = _20521587_TH03_Music_Online.Properties.Resources.star__4_;
            if (d == 0)
                pbstart2.Image = _20521587_TH03_Music_Online.Properties.Resources.star__4_;
            if (c == 0)
                pbstart3.Image = _20521587_TH03_Music_Online.Properties.Resources.star__4_;
            if (b == 0)
                pbstart4.Image = _20521587_TH03_Music_Online.Properties.Resources.star__4_;
            if (a == 0)
                pbstart5.Image = _20521587_TH03_Music_Online.Properties.Resources.star__4_;
        }

        private void pbstart1_Click(object sender, EventArgs e)
        {
            setRate(1,0,0,0,0);
        }

        private void pbstart2_Click(object sender, EventArgs e)
        {
            setRate(1, 1, 0, 0, 0);
        }

        private void pbstart3_Click(object sender, EventArgs e)
        {
            setRate(1, 1, 1, 0, 0);
        }
        private void pbstart4_Click(object sender, EventArgs e)
        {
            setRate(1, 1, 1, 1, 0);
        }

        private void pbstart5_Click(object sender, EventArgs e)
        {
            setRate(1, 1, 1, 1, 1);
        }
    }
}
