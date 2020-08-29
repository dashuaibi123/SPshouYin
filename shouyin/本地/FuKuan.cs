using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace shouyin
{
    public partial class FuKuan : Form
    {
        public FuKuan()
        {
            InitializeComponent();
        //    MessageBox.Show(System.IO.Directory.GetCurrentDirectory());
            pictureBox1.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\image\wxzf.jpg", true);
            pictureBox2.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\image\zfb.jpg", true);

        }


        private void FuKuan_FormClosed(object sender, FormClosedEventArgs e)
        {
            ShouMai.fuKuan = null;
        }

        private void FuKuan_Load_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
