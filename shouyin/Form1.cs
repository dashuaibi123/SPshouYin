using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Data.SQLite;

namespace shouyin
{
    public partial class Form1 : MaterialForm
    {
        private static string dbPath = "Data Source=" + @"data\1.sqlite";//这里加上艾特之后，"\"符号正常显示
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;//不检查异线程操作控件
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            InitializeComponent();
            Process[] ps = Process.GetProcessesByName("shouyin");
            if (ps.Length > 1)
            {
                MessageBox.Show("你已经打开了本软件！");
                System.Environment.Exit(0);//强制关闭进程
            }

        }
        public void JianChaLiXian()
        {
            SQLiteConnection cn = new SQLiteConnection(dbPath);
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.CommandText = "select * from setting where attribute_name = 'frist_open'";
            cn.Open();
            cmd.Connection = cn;
            SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                if (reader.GetBoolean(1) == true)
                {
                    reader.Close();
                    cn.Close();
                    Form3 form3 = new Form3();
                    this.Hide();
                    form3.ShowDialog();
                    Application.ExitThread();

                }
                else
                {
                    reader.Close();
                    cn.Close();
                }
            }
            reader.Close();
            cn.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            JianChaLiXian();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();//加载新布局
            //  this.Visible = false;
            this.Width = 0;
            this.Height = 0;
            this.ShowInTaskbar = false;
            form2.ShowDialog();
            Application.ExitThread();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();//加载新布局
            this.Hide();
            form3.ShowDialog();
            Application.ExitThread();
        }
    }
}
