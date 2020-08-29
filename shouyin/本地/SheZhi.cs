using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;
using System.Threading;

namespace shouyin
{
    public partial class SheZhi : Form
    {
        private static string dbPath = "Data Source=" + @"data\1.sqlite";//这里加上艾特之后，"\"符号正常显示
        public SheZhi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TianRuShouKuan tian = new TianRuShouKuan();
            tian.ShowDialog();
        }


        private void SheZhi_Load(object sender, EventArgs e)
        {
            SQLiteConnection cn = new SQLiteConnection(dbPath);
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.CommandText = "select * from setting";
            cn.Open();
            cmd.Connection = cn;
            SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                for(int i = 0; i < reader.FieldCount; i++)
                {
                    MessageBox.Show(reader.FieldCount.ToString());
                    switch (reader.GetValue(0))
                    {

                    case "frist_open":
                        {
                            if (reader.GetBoolean(1) == true)
                            {
                                checkBox1.Checked = true;
                            }
                            else
                            {
                                checkBox1.Checked = false;
                            }
                            return;
                        }
                    case "updata":
                        {
                            if (reader.GetBoolean(1) == true)
                            {
                                checkBox3.Checked = true;
                            }
                            else
                            {
                                checkBox3.Checked = false;
                            }
                            return;
                        }

                    }
                    reader.Read();

                }


            }
            reader.Close();
            cn.Close();

        }//直到我想到该如何改这里为止。

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

                MessageBox.Show("1");
               if (checkBox1.Checked == true)
               {
                SQLiteConnection cn = new SQLiteConnection(dbPath);
                SQLiteCommand cmd = new SQLiteCommand();
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = "update setting set value = true where attribute_name = 'frist_open'";
                cmd.ExecuteNonQuery();//调用此方法运行
                cn.Close();
               }
               else
               {
                    MessageBox.Show("2");
                SQLiteConnection cn = new SQLiteConnection(dbPath);
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandText = "update setting set value = false where attribute_name = 'frist_open'";
                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteReader();
                cn.Close();
               }
            
            
        }

        private void SheZhi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form3.sheZhi = null;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox3.Checked == true)
            {
                SQLiteConnection cn = new SQLiteConnection(dbPath);
                SQLiteCommand cmd = new SQLiteCommand();
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = "update setting set value = true where attribute_name = 'updata'";
                cmd.ExecuteNonQuery();//调用此方法运行
                cn.Close();
            }
            else
            {
                SQLiteConnection cn = new SQLiteConnection(dbPath);
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandText = "update setting set value = false where attribute_name = 'updata'";
                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();//调用此方法运行
                cn.Close();
            }
            

        }


    }
}
