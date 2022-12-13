using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _20521587_TH03_Music_Online.DAL;

namespace _20521587_TH03_Music_Online.UI
{
    public partial class ucReviews : UserControl
    {
        ResourceManager rm = new ResourceManager("_20521587_TH03_Music_Online.Properties.Resources",
            Assembly.GetExecutingAssembly());
        ReviewsDAL rvdal = new ReviewsDAL();
        public ucReviews()
        {
            InitializeComponent();
            //guna2CirclePictureBox1.Image =  (Image)rm.GetObject("Văn Lực"); 
        }
        private float _rateStart;
        private bool isLiked = false;
        private bool isUnLiked = false;
        private DataRow _reviewData;

        public DataRow reviewData
        {
            get { return _reviewData; }
            set { _reviewData = value; }
        }

        public float rateStart
        {
            get { return _rateStart; }
            set { _rateStart = value;guna2RatingStar1.Value = (float)Math.Round(value * 2, MidpointRounding.AwayFromZero) / 2; }
        }

        private Image _userImage;

        public Image userImage
        {
            get { return _userImage; }
            set { _userImage = value; guna2CirclePictureBox1.Image = value; }
        }
        private string _maBh;

        public string maBh
        {
            get { return _maBh; }
            set { _maBh = value; }
        }
        private int _soDg;

        public int soDg
        {
            get { return _soDg; }
            set { _soDg = value; }
        }
        private string _ten;

        public string ten
        {
            get { return _ten; }
            set { _ten = value; lbName.Text = value; }
        }
        private string _danhGia;

        public string danhGia
        {
            get { return _danhGia; }
            set { _danhGia = value; tbCommand.Text = value; }
        }
        //private int _rate;

        //public int rate
        //{
        //    get { return _rate; }
        //    set
        //    {
        //        _rate = value;
        //        if (value == 1)
        //            setRate(1, 0, 0, 0, 0);
        //        else if (value == 2)
        //            setRate(1, 1, 0, 0, 0);
        //        else if (value == 3)
        //            setRate(1, 1, 1, 0, 0);
        //        else if (value == 4)
        //            setRate(1, 1, 1, 1, 0);
        //        else
        //            setRate(1, 1, 1, 1, 1);
        //    }
        //}
        private DateTime _thoiGian;

        public DateTime thoiGian
        {
            get { return _thoiGian; }
            set { _thoiGian = value;lbTimeCommand.Text = value.ToString(); }
        }
        private int _like;

        public int like
        {
            get { return _like; }
            set { _like = value; guna2HtmlLabel1.Text = value.ToString(); }
        }
        private int _unLike;

        public int unLike
        {
            get { return _unLike; }
            set { _unLike = value; guna2HtmlLabel2.Text = value.ToString(); }
        }
        private void ucReviews_Load(object sender, EventArgs e)
        {

        }

        private void pbLike_Click(object sender, EventArgs e)
        {
            if(isUnLiked)
            {
                pbDisLike.Image = _20521587_TH03_Music_Online.Properties.Resources.dislike__1_;
                guna2HtmlLabel2.Text = (int.Parse(guna2HtmlLabel2.Text) - 1).ToString();
                isUnLiked = false;
            }
            if(isLiked)
            {
                pbLike.Image = _20521587_TH03_Music_Online.Properties.Resources.like__2_;
                guna2HtmlLabel1.Text = (int.Parse(guna2HtmlLabel1.Text) -1).ToString();
                rvdal.UpdateLike(reviewData[1].ToString(), int.Parse(guna2HtmlLabel1.Text), int.Parse(guna2HtmlLabel2.Text));
                isLiked = false;
            }
            else
            {
                pbLike.Image = _20521587_TH03_Music_Online.Properties.Resources.liked;
                guna2HtmlLabel1.Text = (int.Parse(guna2HtmlLabel1.Text) + 1).ToString();
                rvdal.UpdateLike(reviewData[1].ToString(), int.Parse(guna2HtmlLabel1.Text), int.Parse(guna2HtmlLabel2.Text));
                isLiked = true;

            }
            //_20521587_TH03_Music_Online.Properties.Resources.liked
            //    _20521587_TH03_Music_Online.Properties.Resources.like__2_
            //    _20521587_TH03_Music_Online.Properties.Resources.dislike__1_
            //    _20521587_TH03_Music_Online.Properties.Resources.disliked
        }

        private void pbDisLike_Click(object sender, EventArgs e)
        {
            if (isLiked)
            {
                pbLike.Image = _20521587_TH03_Music_Online.Properties.Resources.like__2_;
                guna2HtmlLabel1.Text = (int.Parse(guna2HtmlLabel1.Text) - 1).ToString();

                isLiked = false;
            }
            if (isUnLiked)
            {
                pbDisLike.Image = _20521587_TH03_Music_Online.Properties.Resources.dislike__1_;
                guna2HtmlLabel2.Text = (int.Parse(guna2HtmlLabel2.Text) - 1).ToString();
                rvdal.UpdateLike(reviewData[1].ToString(), int.Parse(guna2HtmlLabel1.Text), int.Parse(guna2HtmlLabel2.Text));
                isUnLiked = false;
            }
            else
            {
                pbDisLike.Image = _20521587_TH03_Music_Online.Properties.Resources.disliked;
                guna2HtmlLabel2.Text = (int.Parse(guna2HtmlLabel2.Text) + 1).ToString();
                rvdal.UpdateLike(reviewData[1].ToString(), int.Parse(guna2HtmlLabel1.Text), int.Parse(guna2HtmlLabel2.Text));
                isUnLiked = true;

            }
        }

        private void guna2RatingStar1_ValueChanged(object sender, EventArgs e)
        {
            guna2RatingStar1.Value = (float)Math.Round(rateStart * 2, MidpointRounding.AwayFromZero) / 2;
        }
        //private void setRate(int a, int b, int c, int d, int e)
        //{
        //    pbstart1.Image = _20521587_TH03_Music_Online.Properties.Resources.star__2_;
        //    pbstart2.Image = _20521587_TH03_Music_Online.Properties.Resources.star__2_;
        //    pbstart3.Image = _20521587_TH03_Music_Online.Properties.Resources.star__2_;
        //    pbstart4.Image = _20521587_TH03_Music_Online.Properties.Resources.star__2_;
        //    pbstart5.Image = _20521587_TH03_Music_Online.Properties.Resources.star__2_;
        //    if (a == 0)
        //        pbstart1.Image = _20521587_TH03_Music_Online.Properties.Resources.star__4_;
        //    if (b == 0)
        //        pbstart2.Image = _20521587_TH03_Music_Online.Properties.Resources.star__4_;
        //    if (c == 0)
        //        pbstart3.Image = _20521587_TH03_Music_Online.Properties.Resources.star__4_;
        //    if (d == 0)
        //        pbstart4.Image = _20521587_TH03_Music_Online.Properties.Resources.star__4_;
        //    if (e == 0)
        //        pbstart5.Image = _20521587_TH03_Music_Online.Properties.Resources.star__4_;
        //}


    }
}
