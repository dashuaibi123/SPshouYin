using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace shouyin.弹窗
{
    public partial class worry : Form
    {
        public worry()
        {
            InitializeComponent();
        }

        private void worry_Load(object sender, EventArgs e)
        {

        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            materialLabel1.Text = "作者QQ1791286695";
        }
    }
}
