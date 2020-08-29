using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace shouyin
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
        public static ShangPin shangpin;//声明窗体类静态变量
        private void button1_Click(object sender, EventArgs e)
        {
            if (shangpin == null)
            {
                shangpin = new ShangPin();
                shangpin.Show();

            }
            else
            {
                shangpin.Activate();
            }
            
        }
        public static ShouMai shouMai;//声明窗体类静态变量
        private void button2_Click(object sender, EventArgs e)
        {
            if (shouMai == null)
            {
                shouMai = new ShouMai();
                shouMai.Show();
            }
            else
            {
                shouMai.Activate();
            }

        }
        public static DingDan dingDan;//声明窗体类静态变量
        private void button3_Click(object sender, EventArgs e)
        {
            if (dingDan == null)
            {
                dingDan = new DingDan();
                dingDan.Show();
            }
            else
            {
                dingDan.Activate();
            }
            
        }
        public static SheZhi sheZhi;//声明窗体类静态变量
        private void button4_Click(object sender, EventArgs e)
        {
            if (sheZhi == null)
            {
                sheZhi = new SheZhi();
                sheZhi.Show();
            }
            else
            {
                sheZhi.Activate();
            }
        }
        
        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
