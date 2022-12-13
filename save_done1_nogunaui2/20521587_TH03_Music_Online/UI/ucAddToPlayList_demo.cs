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
    public partial class ucAddToPlayList_demo : UserControl
    {
        private string _playListName;

        public string playListName
        {
            get { return _playListName; }
            set { _playListName = value; }
        }

        public ucAddToPlayList_demo()
        {
            InitializeComponent();
            string[] plLines = System.IO.File.ReadAllLines("./PlayListName.txt");

            foreach (string item in plLines)
            {
                Label b = new Label();
                b.Text = item;
                flowLayoutPanel1.Controls.Add(b);
                b.Click += B_Click;
            }
        }

        private void B_Click(object sender, EventArgs e)
        {
        }
    }
}
