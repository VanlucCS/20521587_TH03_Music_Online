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
    public partial class ucListenHis : UserControl
    {

        public ucListenHis()
        {
            InitializeComponent();
        }
        private string _luotNghe;
        private string _thoiDiem;

        public string thoiDiem
        {
            get { return _thoiDiem; }
            set
            {
                _thoiDiem = value;
                if (value != null)
                {
                    lbthoidiem.Text = value.Substring(0, 11);
                    lbgio.Text = value.Substring(11);
                }
            }
        }

        public string luotNghe
        {
            get { return _luotNghe; }
            set { _luotNghe = value; lbLuotNghe.Text = value; }
        }
    }
}
