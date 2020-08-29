using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Threading;
using System.Text.RegularExpressions;

namespace shouyin
{
    public partial class TianJiaCommodity : Form
    {
        private static string dbPath = "Data Source=" + @"data\1.sqlite";//这里加上艾特之后，"\"符号正常显示
        public TianJiaCommodity()
        {
            InitializeComponent();
        }

        private void TianJiaCommodity_Load(object sender, EventArgs e)
        {
            textBox2.Focus();
            
        }
        public void TianJiaChengGong()
        {
            this.label4.Text = "状态：添加成功";
            Thread.Sleep(2000);
            this.label4.Text = "状态：待添加";
            
        }

        public delegate void TransfDelegate();//异窗口传值，委托
        public event TransfDelegate TransfEvent;

        private void button1_Click(object sender, EventArgs e)
        {
            ThreadStart threadStart = new ThreadStart(TianJiaChengGong);
            Thread thread = new Thread(threadStart);
            DataTable dt = new DataTable();
            SQLiteConnection cn = new SQLiteConnection(dbPath);
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.CommandText = "select * from product_info where code =" + "'" + textBox2.Text + "'";
            cn.Open();
            cmd.Connection = cn;
            SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)//是否存在行
            {
                MessageBox.Show("商品已存在");

                /*while (reader.Read())
                {
                    Console.WriteLine("ID: " + reader.GetInt16(0));
                    Console.WriteLine("name: " + reader.GetString(1));
                }*/                //调试文本,检查是否有数据
            }
            else
            {
                if (textBox2.Text == "条码"||textBox2.Text==" ")
                {
                    MessageBox.Show("请修改条码,方便扫码枪的使用");
                }
                else
                {
                    reader.Close();
                    String sql = "INSERT INTO product_info(name,Purchase_price,price,code,stockp,amount_num) VALUES(" + "\'"+textBox1.Text+"\'"+","+numericUpDown1.Value + ","+numericUpDown2.Value+"," + "\'" + textBox2.Text + "\'" + "," + "\'" + textBox3.Text + "\'" + "," + "\'" + numericUpDown3.Value + "\'" + ")";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();//调用此方法运行
                    thread.Start();
                    textBox2.Focus();
                    TransfEvent();
                }

            }
            cn.Close();
            this.textBox1.Text = "商品名称";
            this.textBox2.Text = "";//条码需要自动获取焦点
            //this.textBox3.Text = "";    //库存单位。不需要改动了
            this.numericUpDown1.Value= 0.00M;
            this.numericUpDown2.Value = 0.00M;
            this.numericUpDown1.Value = 0;
            textBox2.Focus();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (this.textBox2.Text == "条码")
            {
                this.textBox2.Text = "";
            }

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (this.textBox2.Text == "")
            {
                this.textBox2.Text = "条码";
            }
            else
            {
                if (this.textBox2.Text.Length < 13)
                {
                    MessageBox.Show("请检查条形码是否输错");
                }
            }
            if(Regex.IsMatch(textBox2.Text,"[a-zA-Z]")|| Regex.IsMatch(textBox2.Text, @"[\u4e00-\u9fa5]"))//设置条形码必须为数字
            {
                if(this.textBox2.Text == "条码")
                {
                
                }
                else
                {
                    MessageBox.Show("条形码必须为数字！！");
                    textBox2.Focus();
                }
             
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "商品名称")
            {
                this.textBox1.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "")
            {
                this.textBox1.Text = "商品名称";
            }
            
                
            
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (this.textBox3.Text == "库存单位")
            {
                this.textBox3.Text = "";
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (this.textBox3.Text == "")
            {
                this.textBox3.Text = "库存单位";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox2.Text, "[a-zA-Z]") || Regex.IsMatch(textBox2.Text, @"[\u4e00-\u9fa5]"))//设置条形码必须为数字
            {
                if (textBox2.Text == "条码")
                {

                }
                else
                {
                MessageBox.Show("条形码必须为数字！！");

                }
            }
        }

        private void TianJiaCommodity_FormClosed(object sender, FormClosedEventArgs e)
        {
            ShangPin.tianJiaCommodity = null;
        }
    }
}
