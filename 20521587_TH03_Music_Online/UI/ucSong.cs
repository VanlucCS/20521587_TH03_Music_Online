using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _20521587_TH03_Music_Online.DAL;

namespace _20521587_TH03_Music_Online.UI
{
    public delegate void UcclickHandler(ucSong sender, EventArgs e);

    public partial class ucSong : UserControl
    {
        public event UcclickHandler Ucclick;
        public delegate void ClickEventHandler(object sender, EventArgs e);
        //public event ClickEventHandler Click = delegate { };
        FvorSongDAL fvordal = new FvorSongDAL();
        public ucSong()
        {
            InitializeComponent();
            this.pictureBox2.Click += new EventHandler(lbMahb_Click);
            _isPlaying = false;
            isFavor = false;
        }
        private string _tenBh;
        private Image _image;
        private string _caSi;
        private string _theLoai;
        private string _time;
        private string _maBh;
        private Image _playButton;
        private bool _isPlaying ;
        private string _quocGia;
        private string _tacGia;
        private bool _isFavor;
        private int _setXPositionTimeSong;

        public int setXPositionTimeSong
        {
            get { return _setXPositionTimeSong; }
            set { _setXPositionTimeSong = value;label2.Location = new Point(label2.Location.X-value, label2.Location.Y); }
        }

        public bool isFavor
        {
            get { return _isFavor; }
            set { _isFavor = value; checkFavor(); }
        }

        public string tacGia
        {
            get { return _tacGia; }
            set { _tacGia = value; }
        }

        public string quocGia
        {
            get { return _quocGia; }
            set { _quocGia = value; }
        }

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
        private void checkFavor()
        {
            if(isFavor)
            {
                pictureBox3.Image = _20521587_TH03_Music_Online.Properties.Resources.tim4;
            }
            else
                pictureBox3.Image = _20521587_TH03_Music_Online.Properties.Resources.tim3;

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Ucclick(this, new EventArgs());
        }
        private void lbMahb_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            if (isFavor)
                pictureBox3.Image = _20521587_TH03_Music_Online.Properties.Resources.tim4;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            if(!isFavor)
                pictureBox3.Image = _20521587_TH03_Music_Online.Properties.Resources.tim3;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //dt = fvordal.Select();
            //DataRow datasong = listSongData.AsEnumerable().SingleOrDefault(r => r.Field<string>("MABH") == dr[2].ToString());

            if (isFavor)
            {
                pictureBox3.Image = _20521587_TH03_Music_Online.Properties.Resources.tim3;
                isFavor = false;
                fvordal.Remove(this.maBh);

            }
            else
            {
                pictureBox3.Image = _20521587_TH03_Music_Online.Properties.Resources.tim4;
                isFavor = true;

                fvordal.Insert(this.maBh);
            }

        }

        private void ucSong_Load(object sender, EventArgs e)
        {

        }
    }
}
