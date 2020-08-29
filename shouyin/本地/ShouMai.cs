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
    public partial class ShouMai : Form
    {
        private static string dbPath = "Data Source=" + @"data\1.sqlite";//这里加上艾特之后，"\"符号正常显示

        public ShouMai()
        {
            InitializeComponent();
        }
        public void ChangOrderId()//订单号
        {
            String Year = DateTime.Now.Year.ToString();// 获取年份  
            String Month = DateTime.Now.Month.ToString(); //获取月份   
            String Day = DateTime.Now.Day.ToString();
            String TimeStemp = Units.GetTimeStamp();//获取当前时间戳
            String order_id = "DH" + Year + Month + Day + TimeStemp;//组合生成订单号
            materialLabel2.Text = order_id;

        }
        private void ShouMai_Load(object sender, EventArgs e)
        {
            textBox2.Focus();
            DataTable dt = new DataTable();
            dt.Columns.Add("id",typeof(int));
            dt.Columns.Add("商品名称", typeof(string));
            dt.Columns.Add("单价", typeof(double));
            dt.Columns.Add("条码", typeof(string));
            dt.Columns.Add("数量", typeof(int));
            dt.Columns.Add("总价", typeof(double));
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "商品id";
            dataGridView1.Columns[1].HeaderText = "商品名称";
            dataGridView1.Columns[2].HeaderText = "单价";
            dataGridView1.Columns[3].HeaderText = "条码";
            dataGridView1.Columns[4].HeaderText = "数量";
            dataGridView1.Columns[5].HeaderText = "总价";
            dataGridView1.Columns[2].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns[5].DefaultCellStyle.Format = "N2";
            ChangOrderId();
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                SQLiteConnection cn = new SQLiteConnection(dbPath);
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandText = "select * from product_info where code =" + "'" + textBox2.Text.Trim() + "'";
                cn.Open();
                cmd.Connection = cn;
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)//商品是否存在
                {    
                    reader.Read();
                    int i = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible);//统计当前行数
                    int d = 0;//循环数
                    decimal zong = 0;//设置总价  
                    Boolean hasCode = false;
                    while (d<i)//用来解决添加了多行同一个商品
                    {
                        int end = d;
                        if (end + 1 >= i)
                        {

                        }
                        else
                        {
                            if (textBox2.Text.Trim() == dataGridView1.Rows[d].Cells[3].Value.ToString())
                            {
                                hasCode = true;
                                decimal ZongJiaGe = decimal.Multiply(numericUpDown1.Value, numericUpDown2.Value);//相乘，得出总价格
                                dataGridView1.Rows[d].Cells[4].Value = Convert.ToDecimal(dataGridView1.Rows[d].Cells[4].Value) + numericUpDown2.Value;
                                dataGridView1.Rows[d].Cells[5].Value = Convert.ToDecimal(dataGridView1.Rows[d].Cells[5].Value) + ZongJiaGe;
                                label3.Text = (Convert.ToDecimal(label3.Text) + ZongJiaGe).ToString("F2");
                                break;
                            }
                        }
                        
                        d = d + 1;
                    }
                    if (hasCode == true)
                    {

                    }
                    else
                    {
                        object[] one = {i,textBox1.Text.Trim(), numericUpDown1.Value,textBox2.Text.Trim(), numericUpDown2.Value};
                        ((DataTable)dataGridView1.DataSource).Rows.Add(one);//添加数据
                        for (int a = 0; a < dataGridView1.Rows.Count; a++)//实现每行都出现当前商品总价格
                        {
                            decimal jiaGe = Convert.ToDecimal(dataGridView1.Rows[a].Cells[2].Value);//单价列
                            jiaGe = Math.Round(jiaGe, 2);
                            decimal ShuLiangLie = Convert.ToDecimal(dataGridView1.Rows[a].Cells[4].Value);//数量列
                            ShuLiangLie = Math.Round(ShuLiangLie, 2);
                            decimal ZongJiaGe = decimal.Multiply(ShuLiangLie, jiaGe);//相乘，得出总价格
                            ZongJiaGe = Math.Round(ZongJiaGe, 2);//相乘
                            String c = Convert.ToDecimal(ZongJiaGe).ToString("F2");//设置二位小数
                            dataGridView1.Rows[a].Cells[5].Value = c;
                            zong += jiaGe * ShuLiangLie;
                        }
                        String b = Convert.ToDecimal(zong).ToString("F2");
                        label3.Text = b;
                    }

                    if (checkBox2.Checked == true)
                    {

                        int a = 0;//循环数
                        int kucun = reader.GetInt16(6);
                        int zongShu = 0;
                        while (a < i)
                        {
                            int ShuLiang = Convert.ToInt16(dataGridView1.Rows[a].Cells[4].Value);//数量列
                            zongShu += ShuLiang;
                            a++;
                        }

                    }
                    reader.Close();//一定要断开连接，不然后面代码无法执行

                }
                else
                {
                    MessageBox.Show("商品不存在");
                }
                cn.Close();
            

            }
            catch
            {
                MessageBox.Show("未知错误，请尝试重启软件");
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
            DataTable dt = new DataTable();
            SQLiteConnection cn = new SQLiteConnection(dbPath);
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.CommandText = "select * from product_info where code =" + "'" + textBox2.Text.Trim() + "'";
            cn.Open();
            cmd.Connection = cn;
            SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)//商品是否存在
            {
                    reader.Read();
                    String name = reader.GetString(1);
                    this.textBox1.Text = name;
                    Decimal shoujia = reader.GetDecimal(3);
                    this.numericUpDown1.Value = shoujia;
                    int kucun = reader.GetInt16(6);
                    if (checkBox2.Checked == true)//是否检查库存足够
                    {
                        if(kucun<=0)//如果库存少于0
                        {
                        MessageBox.Show("库存少于0!");
                        }
                    }
                    
                    reader.Close();//一定要断开连接，不然后面代码无法执行

            }
                else
                {
                    MessageBox.Show("商品不存在");
                }
               cn.Close();


            }
           


            
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (this.textBox2.Text == "条码")
            {
                this.textBox2.Text = "";
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SQLiteConnection cn = new SQLiteConnection(dbPath);
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.CommandText = "select * from product_info where code =" + "'" + textBox2.Text.Trim() + "'";
            cn.Open();
            cmd.Connection = cn;
            SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)//商品是否存在
            {
                reader.Read();
                String name = reader.GetString(1);
                this.textBox1.Text = name.Trim();
                Decimal shoujia = reader.GetDecimal(3);
                this.numericUpDown1.Value = shoujia;
                reader.Close();//一定要断开连接，不然后面代码无法执行

            }
            
            cn.Close();
        }

        public static FuKuan fuKuan;//声明窗体类静态变量
        private void button2_Click(object sender, EventArgs e)
        {
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteCommand jiancha = new SQLiteCommand();
            SQLiteConnection jianchalianjie = new SQLiteConnection(dbPath);//检查对象的连接

            SQLiteConnection cn = new SQLiteConnection(dbPath);
            int i = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible);//统计当前行数
            int a = 0;//循环数
            cmd.Connection=cn;
            String time=System.DateTime.Now.ToString();//得出当前时间
            jiancha.Connection = jianchalianjie;

            while (a<i-1)
            {
                cn.Open();
                String sql = "INSERT INTO order_list(name,price,code,create_time,amount_num,order_id) VALUES(" + "\'" + dataGridView1.Rows[a].Cells[1].Value + "\'" + "," + Convert.ToDouble(label3.Text) + "," + "\'" +dataGridView1.Rows[a].Cells[3].Value + "\'" + "," + "\'" + time + "\'" + "," +  dataGridView1.Rows[a].Cells[4].Value + "," +"\'" + materialLabel2.Text.Trim() + "\'"  + ")";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();//调用此方法运行
                cn.Close();

                if (checkBox2.Checked == true)//是否使用库存
                {
                    jianchalianjie.Open();
                    String zhaoShangPIN = "select * from product_info where code = " + "'" + dataGridView1.Rows[a].Cells[3].Value + "'";//查找商品
                    jiancha.CommandText = zhaoShangPIN;
                    SQLiteDataReader reader = jiancha.ExecuteReader();
                    reader.Read();
                    int kucun = reader.GetInt16(6);
                    reader.Close();//一定要断开连接，不然后面代码无法执行
                    jianchalianjie.Close();

                    if (kucun >= 0)
                    {
                        jianchalianjie.Open();
                        int jianKuCun = (int)dataGridView1.Rows[a].Cells[4].Value;
                        String kuCunJianShao = "UPDATE product_info SET amount_num = " + "'"+ (kucun-jianKuCun)+"'"+ " WHERE code =" +"'"+dataGridView1.Rows[a].Cells[3].Value+"'";//库存减少sql语句
                        jiancha.CommandText = kuCunJianShao;
                        jiancha.ExecuteNonQuery();//调用此方法运行
                        jianchalianjie.Close();
                     }
                    else
                    {
                        MessageBox.Show("库存不够了");
                    }
                    
                }
                
                
                a = a + 1;

            }
            if (checkBox1.Checked == true)//调出付款页面
            {
                MessageBox.Show("订单创建成功" + "\n" + "应付金额为:" + "  " + label3.Text.Trim() + "元");
                if (fuKuan == null)
                {
                    fuKuan = new FuKuan();
                    fuKuan.ShowDialog();
                }
                else
                {
                    fuKuan.Activate();
                }
                
            }
            else
            {
                MessageBox.Show("订单创建成功"+"\n"+"应付金额为:"+"  "+label3.Text.Trim() + "元");
            }
            ChangOrderId();
            textBox2.Text = "条码";
            textBox1.Text = "商品名称";
            numericUpDown1.Value = 0.00M;
            numericUpDown2.Value = 1;

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ShouMai_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form3.shouMai = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            dt.Rows.Clear();
            dataGridView1.DataSource = dt;
            this.label3.Text = "0.00";
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dataGridView1.Rows[e.RowIndex].Selected == false)
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (dataGridView1.SelectedRows.Count == 1)
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                    //弹出操作菜单
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                label3.Text = (Convert.ToDecimal(label3.Text) - Convert.ToDecimal(dataGridView1.CurrentRow.Cells[5].Value)).ToString().Trim();
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            }
            catch
            {
                MessageBox.Show("删除失败");
            }
            
        }
    }
}
