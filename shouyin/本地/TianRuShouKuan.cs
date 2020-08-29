using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace shouyin
{
    public partial class TianRuShouKuan : Form
    {
        public TianRuShouKuan()
        {
            InitializeComponent();
        }
        public String ImagePatch = System.IO.Directory.GetCurrentDirectory() + @"\image";
        public void JianCeTuPian()
        {
            if (System.IO.File.Exists(ImagePatch+@"\wxzf.jpg"))
            {
                textBox1.Text = ImagePatch+@"\wxzf.jpg";
            }

            if (System.IO.File.Exists(ImagePatch + @"\zfb.jpg"))
            {
                textBox2.Text = ImagePatch+@"\zfb.jpg";
            }
        }

        private void TianRuShouKuan_Load(object sender, EventArgs e)
        {
            JianCeTuPian();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "请选择图片";
            fileDialog.Multiselect = false;//是否允许选择多个文件
            fileDialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            fileDialog.Filter = "(*.jpg)|*.jpg";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] names = fileDialog.FileNames;

                foreach (string file in names)
                {
                    this.textBox1.Text = file;
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "请选择图片";
            fileDialog.Multiselect = false;//是否允许选择多个文件
            fileDialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            fileDialog.Filter = "(*.jpg)|*.jpg";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] names = fileDialog.FileNames;

                foreach (string file in names)
                {
                    this.textBox2.Text = file;
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(textBox1.Text == ""|| textBox1.Text == "支付宝图片路径"))
                {
                    File.Copy(textBox1.Text, ImagePatch+@"\zfb.jpg", true);//三个参数分别是源文件路径，存储路径，若存储路径有相同文件是否替换
                }
                else
                {
                    return;
                }
                if(!(textBox2.Text == "" || textBox2.Text == "微信图片路径"))
                {
                    File.Copy(textBox2.Text, ImagePatch+@"\wxzf.jpg", true);//三个参数分别是源文件路径，存储路径，若存储路径有相同文件是否替换
                }
                else
                {
                    return;
                }
                MessageBox.Show("成功");

            }
            catch
            {
                MessageBox.Show("执行失败，请联系作者");
            }

        }
    }
}
