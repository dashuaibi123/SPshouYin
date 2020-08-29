using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Threading;

namespace shouyin
{
    public partial class ZaiXian : MaterialForm
    {
        public ZaiXian()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            InitializeComponent();
        }
        String user;
        public String url = "http://192.168.31.139:8080/sell/";

        public ZaiXian(String username)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            InitializeComponent();
            user = username;
        }
        public void GetCommodityList()
        {
            String CommodityListUrl = url + "commoditylist";
            String getJson=null;
            Dictionary<string, String> list = new Dictionary<string, String>(6);
            list.Add("username", user);
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("商品名称", typeof(string));
            dt.Columns.Add("进价", typeof(double));
            dt.Columns.Add("售价", typeof(string));
            dt.Columns.Add("库存单位", typeof(int));
            dt.Columns.Add("商品条码", typeof(double));
            dataGridView2.DataSource = dt;
            dataGridView2.Columns[0].HeaderText = "商品id";
            dataGridView2.Columns[1].HeaderText = "商品名称";
            dataGridView2.Columns[2].HeaderText = "进价";
            dataGridView2.Columns[3].HeaderText = "售价";
            dataGridView2.Columns[4].HeaderText = "库存单位";
            dataGridView2.Columns[5].HeaderText = "商品条码";
            dataGridView2.Columns[2].DefaultCellStyle.Format = "N2";
            dataGridView2.Columns[3].DefaultCellStyle.Format = "N2";//设置小数位数为2位
            try
            {
                // Clipboard.SetText(Units.Post(url, list));
                getJson = Units.Post(CommodityListUrl, list);
            }
            catch
            {
                弹窗.worry worry = new 弹窗.worry();
                worry.ShowDialog();
            }
            try
            {
                List<在线.CommodityList> commodityList = JsonConvert.DeserializeObject<List<在线.CommodityList>>(getJson);
                for (int i = 0; i < commodityList.Count; i++)
                {

                    object[] one = { i, commodityList[i].name,commodityList[i].Purchase_price, commodityList[i].price,commodityList[i].stockp,commodityList[i].code };
                    ((DataTable)dataGridView2.DataSource).Rows.Add(one);
                }
            }
            catch
            {
                MessageBox.Show("未知错误");
            }

 
            

        }
        public void ChangeOrderId()
        {
            String Year = DateTime.Now.Year.ToString();// 获取年份  
            String Month = DateTime.Now.Month.ToString(); //获取月份   
            String Day = DateTime.Now.Day.ToString();
            String TimeStemp = Units.GetTimeStamp();//获取当前时间戳
            String order_id = "DH" + Year + Month + Day + TimeStemp;//组合生成订单号
            materialLabel2.Text = user + order_id;
        }

        private void ZaiXian_Load(object sender, EventArgs e)
        {
            ThreadStart threadStart = new ThreadStart(GetCommodityList);
            Thread thread = new Thread(threadStart);
            thread.Start();
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("商品名称", typeof(string));
            dt.Columns.Add("售价", typeof(double));
            dt.Columns.Add("条码", typeof(string));
            dt.Columns.Add("数量", typeof(int));
            dt.Columns.Add("总价", typeof(double));
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "商品id";
            dataGridView1.Columns[1].HeaderText = "商品名称";
            dataGridView1.Columns[2].HeaderText = "售价";
            dataGridView1.Columns[3].HeaderText = "条码";
            dataGridView1.Columns[4].HeaderText = "数量";
            dataGridView1.Columns[5].HeaderText = "总价";
            dataGridView1.Columns[2].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns[5].DefaultCellStyle.Format = "N2";
            ChangeOrderId();
        }

        private void ZaiXian_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);//关闭全部线程，结束程序
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void materialTabSelector1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            dt.Rows.Clear();
            dataGridView1.DataSource = dt;
            this.label3.Text = "0.00";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                int i = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Visible);//统计当前行数
                int d = 0;//循环数
                decimal zong = 0;//设置总价  
                Boolean hasCode = false;
                while (d < i)//用来解决添加了多行同一个商品
                {
                    int end = d;
                    if (end + 1 >= i)
                    {

                    }
                    else
                    {
                        if (textBox2.Text == dataGridView1.Rows[d].Cells[3].Value.ToString())
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
                    object[] one = { i, textBox1.Text, numericUpDown1.Value, textBox2.Text, numericUpDown2.Value };
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
            

            }
            catch
            {
                MessageBox.Show("未知错误，请尝试重启软件");
            }

        }
        public void DingDanDone()
        {
            String TiJiaoDingDanUrl = url + "createOrder";

            String order_number = materialLabel2.Text;
            Dictionary<string, String> list = new Dictionary<string, String>(6);
            list.Add("order_number",order_number);
            list.Add("commodity",);
            list.Add("",);
            list.Add("",);
            list.Add("",);
            list.Add("",);
            Units.Post(TiJiaoDingDanUrl,list);
            ChangeOrderId();
            textBox2.Text = "条码";
            textBox1.Text = "商品名称";
            numericUpDown1.Value = 0.00M;
            numericUpDown2.Value = 1;

        }
        private void button4_Click(object sender, EventArgs e)
        {
            ThreadStart threadStart = new ThreadStart(DingDanDone);
            Thread thread = new Thread(threadStart);
            在线.ZhiFuYe zhiFuYe = new 在线.ZhiFuYe();
            zhiFuYe.ShowDialog();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int a = 0;
            while (a < dataGridView2.Rows.GetRowCount(DataGridViewElementStates.Visible))
            {
                if(textBox2.Text== dataGridView2.Rows[a].Cells[5].Value.ToString())
                {
                    textBox1.Text = dataGridView2.Rows[a].Cells[1].Value.ToString();
                    numericUpDown1.Value = Convert.ToDecimal(dataGridView2.Rows[a].Cells[3].Value);
                }
            }
        }
    }
}
