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
    public delegate void UcclickHandler(ucSong sender, EventArgs e);

    public partial class ucSong : UserControl
    {
        public event UcclickHandler Ucclick;
        public delegate void ClickEventHandler(object sender, EventArgs e);
        //public event ClickEventHandler Click = delegate { };

        public ucSong()
        {
            InitializeComponent();
            this.pictureBox2.Click += new EventHandler(lbMahb_Click);
            _isPlaying = false;
        }
        private string _tenBh;
        private Image _image;
        private string _caSi;
        private string _theLoai;
        private string _time;
        private string _maBh;
        private Image _playButton;
        private bool _isPlaying ;

        [Category("custom Props")]

        public bool isPlaying
        {
            get { return _isPlaying ; }
            set { _isPlaying  = value; }
        }

        public string maBh
        {
            get { return _maBh; }
            set { _maBh = value;lbMahb.Text = value; }
        }

        public Image image
        {
            get { return _image; }
            set { _image = value; pictureBox1.Image = value; }
        }

        public string theLoai
        {
            get { return _theLoai; }
            set { _theLoai = value; label1.Text = value; }
        }

        public string time
        {
            get { return _time; }
            set { _time = value; label2.Text = value; }
        }
        public event EventHandler playButtonClick
        {
            add { pictureBox2.Click += value; }
            remove { pictureBox2.Click -= value; }
        }
        public Image playButton
        {
            get { return _playButton; }
            set { _playButton = value; pictureBox2.Image = value; }
        }

        public event EventHandler mabhClick
        {
            add { lbMahb.Click += value; }
            remove { lbMahb.Click -= value; }
        }
        public string tenBh
        {
            get { return _tenBh; }
            set { _tenBh = value; lbSongName.Text =value; }
        }

        public string caSi
        {
            get { return _caSi; }
            set { _caSi = value; lbSinger.Text = value; }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Ucclick(this, new EventArgs());
        }
        private void lbMahb_Click(object sender, EventArgs e)
        {
        }
    }
}
