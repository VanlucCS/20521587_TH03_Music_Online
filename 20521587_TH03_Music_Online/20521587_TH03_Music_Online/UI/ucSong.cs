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
    public partial class ucSong : UserControl
    {
       


        public ucSong()
        {
            InitializeComponent();
            
        }
        private string _tenBh;
        private Image _image;

        public Image image
        {
            get { return _image; }
            set { _image = value; pictureBox1.Image = value; }
        }


        public string tenBh
        {
            get { return _tenBh; }
            set { _tenBh = value; lbSongName.Text =value; }
        }
        private string _caSi;

        public string caSi
        {
            get { return _caSi; }
            set { _caSi = value; lbSinger.Text = value; }
        }
    }
}
