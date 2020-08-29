using System;
using System.Data;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace shouyin
{
    public partial class DingDan : Form
    {
        private static string dbPath = "Data Source=" + @"data\1.sqlite";//这里加上艾特之后，"\"符号正常显示
        public DingDan()
        {
            InitializeComponent();
        }

        private void DingDan_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SQLiteConnection cn = new SQLiteConnection(dbPath);
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataAdapter slda = new SQLiteDataAdapter("SELECT id,order_id,GROUP_CONCAT(name),GROUP_CONCAT(code),price,GROUP_CONCAT(amount_num),create_time FROM order_list where create_time like " + "'%" + dateTimePicker1.Value.ToShortDateString() + "%'" + "GROUP BY order_id", cn);
            DataSet ds = new DataSet();
            cmd.CommandText = "SELECT id,order_id,GROUP_CONCAT(name),GROUP_CONCAT(code),price,GROUP_CONCAT(amount_num),create_time FROM order_list where create_time like " + "'%" + dateTimePicker1.Value.ToShortDateString() + "%'" + "GROUP BY order_id";
            cn.Open();
            slda.Fill(ds);
            dt = ds.Tables[0];//data数据源
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "订单id";
            dataGridView1.Columns[1].HeaderText = "订单号";
            dataGridView1.Columns[2].HeaderText = "商品名称";
            dataGridView1.Columns[3].HeaderText = "条码";
            dataGridView1.Columns[4].HeaderText = "总价";
            dataGridView1.Columns[5].HeaderText = "数量";
            dataGridView1.Columns[6].HeaderText = "时间";
            dataGridView1.Columns[4].DefaultCellStyle.Format = "N2";
            cn.Close();
        }

        private void DingDan_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form3.dingDan = null;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == @"订单号\商品条码\商品名称")
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = @"订单号\商品条码\商品名称";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                DataTable dt = new DataTable();
                SQLiteConnection cn = new SQLiteConnection(dbPath);
                SQLiteCommand cmd = new SQLiteCommand();
                SQLiteDataAdapter slda = new SQLiteDataAdapter("SELECT id,order_id,GROUP_CONCAT(name),GROUP_CONCAT(code),price,GROUP_CONCAT(amount_num),create_time FROM order_list where create_time like " + "'%" + dateTimePicker1.Value.ToShortDateString() + "%'" + "GROUP BY order_id", cn);
                DataSet ds = new DataSet();
                cmd.CommandText = "SELECT id,order_id,GROUP_CONCAT(name),GROUP_CONCAT(code),price,GROUP_CONCAT(amount_num),create_time FROM order_list where create_time like " + "'%" + dateTimePicker1.Value.ToShortDateString() + "%'" + "GROUP BY order_id";
                cn.Open();
                cmd.Connection = cn;
                dt.Rows.Clear();
                slda.Fill(ds);
                dt = ds.Tables[0];//表名
                dataGridView1.DataSource = dt;
                cn.Close();
            }
            if (Regex.IsMatch(textBox1.Text, @"[\u4e00-\u9fa5]") || Regex.IsMatch(textBox1.Text, @"[a-zA-Z]"))//如果输入的是中文[a-zA-Z]
            {
                if (textBox1.Text == "" || textBox1.Text == @"订单号\商品条码\商品名称")
                {
                    DataTable dt = new DataTable();
                    SQLiteConnection cn = new SQLiteConnection(dbPath);
                    SQLiteCommand cmd = new SQLiteCommand();
                    SQLiteDataAdapter slda = new SQLiteDataAdapter("SELECT id,order_id,GROUP_CONCAT(name),GROUP_CONCAT(code),price,GROUP_CONCAT(amount_num),create_time FROM order_list where create_time like " + "'%" + dateTimePicker1.Value.ToShortDateString() + "%'" + "GROUP BY order_id", cn);
                    DataSet ds = new DataSet();
                    cmd.CommandText = "SELECT id,order_id,GROUP_CONCAT(name),GROUP_CONCAT(code),price,GROUP_CONCAT(amount_num),create_time FROM order_list where create_time like " + "'%" + dateTimePicker1.Value.ToShortDateString() + "%'" + "GROUP BY order_id";
                    cn.Open();
                    cmd.Connection = cn;
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
                    SQLiteDataAdapter slda = new SQLiteDataAdapter("SELECT id,order_id,GROUP_CONCAT(name),GROUP_CONCAT(code),price,GROUP_CONCAT(amount_num),create_time FROM order_list where name like " + "'%" + textBox1.Text + "%'" +"GROUP BY order_id", cn);
                    DataSet ds = new DataSet();
                    cmd.CommandText = "SELECT id,order_id,GROUP_CONCAT(name),GROUP_CONCAT(code),price,GROUP_CONCAT(amount_num),create_time FROM order_list where name like " + "'%" + textBox1.Text + "%'" + "GROUP BY order_id";
                    cn.Open();
                    cmd.Connection = cn;
                    dt.Rows.Clear();
                    slda.Fill(ds);
                    dt = ds.Tables[0];//表名
                    dataGridView1.DataSource = dt;
                    cn.Close();

                }

            }
            else if(Regex.IsMatch(textBox1.Text, @"[1-9]"))//如果输入的是条码
            {
                if (textBox1.Text == "" || textBox1.Text == @"订单号\商品条码\商品名称")
                {
                    DataTable dt = new DataTable();
                    SQLiteConnection cn = new SQLiteConnection(dbPath);
                    SQLiteCommand cmd = new SQLiteCommand();
                    SQLiteDataAdapter slda = new SQLiteDataAdapter("SELECT id,order_id,GROUP_CONCAT(name),GROUP_CONCAT(code),price,GROUP_CONCAT(amount_num),create_time FROM order_list where create_time like " + "'%" + dateTimePicker1.Value.ToShortDateString() + "%'" + "GROUP BY order_id", cn);
                    DataSet ds = new DataSet();
                    cmd.CommandText = "SELECT id,order_id,GROUP_CONCAT(name),GROUP_CONCAT(code),price,GROUP_CONCAT(amount_num),create_time FROM order_list where create_time like " + "'%" + dateTimePicker1.Value.ToShortDateString() + "%'" + "GROUP BY order_id";
                    cn.Open();
                    cmd.Connection = cn;
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
                    SQLiteDataAdapter slda = new SQLiteDataAdapter("SELECT id,order_id,GROUP_CONCAT(name),GROUP_CONCAT(code),price,GROUP_CONCAT(amount_num),create_time FROM order_list where name like " + "'%" + textBox1.Text + "%'" + "GROUP BY order_id", cn);
                    DataSet ds = new DataSet();
                    cmd.CommandText = "SELECT id,order_id,GROUP_CONCAT(name),GROUP_CONCAT(code),price,GROUP_CONCAT(amount_num),create_time FROM order_list where name like " + "'%" + textBox1.Text + "%'" + "GROUP BY order_id";
                    cn.Open();
                    cmd.Connection = cn;
                    dt.Rows.Clear();
                    slda.Fill(ds);
                    dt = ds.Tables[0];//表名
                    dataGridView1.DataSource = dt;
                    cn.Close();

                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = @"订单号\商品条码\商品名称";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SQLiteConnection cn = new SQLiteConnection(dbPath);
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataAdapter slda = new SQLiteDataAdapter("SELECT id,order_id,GROUP_CONCAT(name),GROUP_CONCAT(code),price,GROUP_CONCAT(amount_num),create_time FROM order_list where create_time like " + "'%" + dateTimePicker1.Value.ToShortDateString() + "%'" + "GROUP BY order_id", cn);
            DataSet ds = new DataSet();
            cmd.CommandText = "SELECT id,order_id,GROUP_CONCAT(name),GROUP_CONCAT(code),price,GROUP_CONCAT(amount_num),create_time FROM order_list where create_time like " + "'%" + dateTimePicker1.Value.ToShortDateString() + "%'" + "GROUP BY order_id";
            cn.Open();
            cmd.Connection = cn;
            dt.Rows.Clear();
            slda.Fill(ds);
            dt = ds.Tables[0];//表名
            dataGridView1.DataSource = dt;
            cn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SQLiteConnection cn = new SQLiteConnection(dbPath);
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataAdapter slda = new SQLiteDataAdapter("SELECT id,order_id,GROUP_CONCAT(name),GROUP_CONCAT(code),price,GROUP_CONCAT(amount_num),create_time FROM order_list where create_time like " + "'%" + dateTimePicker1.Value.ToShortDateString() + "%'" + "GROUP BY order_id", cn);
            DataSet ds = new DataSet();
            cmd.CommandText = "SELECT id,order_id,GROUP_CONCAT(name),GROUP_CONCAT(code),price,GROUP_CONCAT(amount_num),create_time FROM order_list where create_time like " + "'%" + dateTimePicker1.Value.ToShortDateString() + "%'" + "GROUP BY order_id";
            cn.Open();
            cmd.Connection = cn;
            dt.Rows.Clear();
            slda.Fill(ds);
            dt = ds.Tables[0];//表名
            dataGridView1.DataSource = dt;
            cn.Close();
        }
    }
}
