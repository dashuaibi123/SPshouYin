using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Data.Sql;
using WinHttp;
using System.Data.SQLite;
using System.Threading;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Text.RegularExpressions;

namespace shouyin
{
    public partial class ShangPin : Form
    {
        private static string dbPath = "Data Source=" + @"data\1.sqlite";//这里加上艾特之后，"\"符号正常显示

        public ShangPin()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;//不检查异线程操作控件
            

        }
        private void ShangPin_Load(object sender, EventArgs e)
        {

            ThreadStart threadStart = new ThreadStart(threadNew);
            Thread thread = new Thread(threadStart);
            //  List<String> s;
            SQLiteDataReader s;
            DataTable dt = new DataTable();
            SQLiteConnection cn = new SQLiteConnection(dbPath);
            SQLiteDataAdapter slda = new SQLiteDataAdapter("select * from product_info ", cn);
            DataSet ds = new DataSet();
            //  SQLiteConnection.CreateFile(dbPath);
            cn.Open();

         /*   SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = cn;//把 SQLiteCommand的 Connection和SQLiteConnection 联系起来
            cmd.CommandText = "CREATE TABLE IF NOT EXISTS product_info(id integer,name varchar(255),Purchase_price double(3,2),price double(3,2),code varchar(255),stockp varchar(255),amount_num integer(255))";//输入SQL语句//商品列表/商品名称/进价/售价/条码/库存单位/商品。
            cmd.ExecuteNonQuery();//调用此方法运行
            cmd.CommandText = "CREATE TABLE IF NOT EXISTS order_list(id integer,name varchar(255),price double(3,2),create_time String,commodity varchar(255),stockp varchar(255),amount_num integer(255),order_num integer(255))";
            cmd.ExecuteNonQuery();//调用此方法运行
            s = cmd.ExecuteReader();*/
            slda.Fill(ds);
            dt = ds.Tables[0];//data数据源
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "商品id";
            dataGridView1.Columns[1].HeaderText = "商品名称";
            dataGridView1.Columns[2].HeaderText = "进价";
            dataGridView1.Columns[3].HeaderText = "售价";
            dataGridView1.Columns[4].HeaderText = "商品码";
            dataGridView1.Columns[5].HeaderText = "库存单位";
            dataGridView1.Columns[6].HeaderText = "剩余库存";
            dataGridView1.Columns[2].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns[3].DefaultCellStyle.Format = "N2";//设置小数位数为2位
            //   thread.Start();
            cn.Close();
        }
        public void threadNew() {//子线程，自动刷新
            

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //  contextMenuStrip1.Show();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
        public static TianJiaCommodity tianJiaCommodity;//声明窗体类静态变量
        private void button1_Click(object sender, EventArgs e)
        {
            if (tianJiaCommodity == null)
            {
                tianJiaCommodity = new TianJiaCommodity();
                tianJiaCommodity.TransfEvent += RefreshList;
                tianJiaCommodity.ShowDialog();
            }
            else
            {
                tianJiaCommodity.Activate();
            }
            
        }
        private void RefreshList()
        {
            SQLiteConnection cn = new SQLiteConnection(dbPath);
            SQLiteCommand cmd = new SQLiteCommand();
            DataTable dt = new DataTable();
            SQLiteDataAdapter slda = new SQLiteDataAdapter("select * from product_info ", cn);
            DataSet ds = new DataSet();


            cn.Open();
            dt.Rows.Clear();
            slda.Fill(ds);
            dt = ds.Tables[0];//表名
            dataGridView1.DataSource = dt;
            cn.Close();
        }
       
        

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshList();

        }
        public static String zhi;
        public static String name,kuCunDanWei,id;
        public static int ShengYuKuCun;
        public static String code;
        public static Double jinPrice;
        public static Double Price;
        
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
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
            id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            code = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            jinPrice = (double)dataGridView1.Rows[e.RowIndex].Cells[2].Value;
            Price = (double)dataGridView1.Rows[e.RowIndex].Cells[3].Value;
            name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();//获取值
            kuCunDanWei = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            ShengYuKuCun = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
            ShuXing shu = new ShuXing();
            shu.ShowDialog();//弹出属性页
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SQLiteConnection cn = new SQLiteConnection(dbPath);
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = cn;
            if (dataGridView1.SelectedRows.Count <=1 && dataGridView1.SelectedRows.Count>0)//如果选中的行大于0小于等于1
            {
                int a = dataGridView1.CurrentRow.Index;//选中行
                string str = dataGridView1.Rows[a].Cells["code"].Value.ToString();
               // int ziZengId = (int)dataGridView1.Rows[a].Cells[0].Value;

                String sql = "DELETE FROM product_info WHERE code ="+"\'"+ str+ "\'";
             //   String ChongZhiZiZengId = "DELETE FROM sqlite_sequence WHERE seq='"+ziZengId+"'";
                cn.Open();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();//调用此方法运行
             //   cmd.CommandText = ChongZhiZiZengId;
               // cmd.ExecuteNonQuery();
                cn.Close();
               // MessageBox.Show(str);
            }
            else
            {
                MessageBox.Show("你只能删除选中的一行");
            }
           

            DataTable dt = new DataTable();
            SQLiteDataAdapter slda = new SQLiteDataAdapter("select * from product_info ", cn);//刷新数据
            DataSet ds = new DataSet();
            cn.Open();
            dt.Rows.Clear();
            slda.Fill(ds);
            dt = ds.Tables[0];//表名
            dataGridView1.DataSource = dt;
            cn.Close();
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(Regex.IsMatch(textBox1.Text, @"[\u4e00-\u9fa5]")|| Regex.IsMatch(textBox1.Text, @"[a-zA-Z]"))//如果输入的是中文[a-zA-Z]
            {
                if (textBox1.Text == "" || textBox1.Text == "商品名称/条码")
                {
                    SQLiteConnection cn = new SQLiteConnection(dbPath);
                    SQLiteCommand cmd = new SQLiteCommand();
                    DataTable dt = new DataTable();
                    SQLiteDataAdapter slda = new SQLiteDataAdapter("select * from product_info ", cn);
                    DataSet ds = new DataSet();


                    cn.Open();
                    dt.Rows.Clear();
                    slda.Fill(ds);
                    dt = ds.Tables[0];//表名
                    dataGridView1.DataSource = dt;
                    cn.Close();

                }
                else
                {
                    DataTable dt = new DataTable();
                    SQLiteConnection cn = new SQLiteConnection(dbPath);
                    SQLiteCommand cmd = new SQLiteCommand();
                    SQLiteDataAdapter slda = new SQLiteDataAdapter("select * from product_info where name like " + "'%" + textBox1.Text + "%'", cn);
                    DataSet ds = new DataSet();
                    cmd.CommandText = "select * from product_info where name like " + "'%" + textBox1.Text + "%'";
                    cn.Open();
                    cmd.Connection = cn;
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    dt.Rows.Clear();
                    slda.Fill(ds);
                    dt = ds.Tables[0];//表名
                    dataGridView1.DataSource = dt;
                    cn.Close();

                }
            
        }
            else//如果输入的是条码
            {
                if(textBox1.Text==""||textBox1.Text== "商品名称/条码")
            {
                SQLiteConnection cn = new SQLiteConnection(dbPath);
                SQLiteCommand cmd = new SQLiteCommand();
                DataTable dt = new DataTable();
                SQLiteDataAdapter slda = new SQLiteDataAdapter("select * from product_info ", cn);
                DataSet ds = new DataSet();


                cn.Open();
                dt.Rows.Clear();
                slda.Fill(ds);
                dt = ds.Tables[0];//表名
                dataGridView1.DataSource = dt;
                cn.Close();

            }
            else
            {
                DataTable dt = new DataTable();
                SQLiteConnection cn = new SQLiteConnection(dbPath);
                SQLiteCommand cmd = new SQLiteCommand();
                SQLiteDataAdapter slda = new SQLiteDataAdapter("select * from product_info where code like " + "'%" + textBox1.Text + "%'", cn);
                DataSet ds = new DataSet();
                cmd.CommandText = "select * from product_info where code like " + "'%" + textBox1.Text + "%'";
                cn.Open();
                cmd.Connection = cn;
                SQLiteDataReader reader = cmd.ExecuteReader();
                dt.Rows.Clear();
                slda.Fill(ds);
                dt = ds.Tables[0];//表名
                dataGridView1.DataSource = dt;
                cn.Close();

        }
            }
            
            }
            

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "商品名称/条码";
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "商品名称/条码")
            {
            textBox1.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "商品名称/条码";
            }
        }

 

        private void ShangPin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form3.shangpin = null;
        }
    }
}

