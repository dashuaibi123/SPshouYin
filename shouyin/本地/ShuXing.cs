using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;


namespace shouyin
{
    public partial class ShuXing : Form
    {
        private static string dbPath = "Data Source=" + @"data\1.sqlite";//这里加上艾特之后，"\"符号正常显示
        public static int tianJiaKuCun;
        public ShuXing()
        {
            InitializeComponent();
        }

        private void ShuXing_Load(object sender, EventArgs e)
        {
            label1.Text = "id:" + ShangPin.id;
            textBox1.Text = ShangPin.code;
            textBox2.Text = ShangPin.name;
            textBox3.Text = ShangPin.kuCunDanWei;
            numericUpDown1.Value = (decimal)ShangPin.jinPrice;
            numericUpDown2.Value = (decimal)ShangPin.Price;
            numericUpDown3.Value = ShangPin.ShengYuKuCun;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == ShangPin.name && textBox3.Text == ShangPin.kuCunDanWei && numericUpDown1.Value == (decimal)ShangPin.jinPrice && numericUpDown2.Value == (decimal)ShangPin.Price && numericUpDown3.Value == ShangPin.ShengYuKuCun)
            {
               this.Close();
            }
            else
            {
            SQLiteConnection cn = new SQLiteConnection(dbPath);
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = cn;
            String sql = "update product_info set amount_num=" + numericUpDown3.Value+","+"name="+"'"+textBox2.Text+"'"+","+ "Purchase_price="+numericUpDown1.Value+","+ "price="+numericUpDown2.Value+","+ "stockp="+"'"+textBox3.Text +"'"+ " WHERE code =" +"'"+ textBox1.Text+"'";
            //   String ChongZhiZiZengId = "DELETE FROM sqlite_sequence WHERE seq='"+ziZengId+"'";
            cn.Open();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();//调用此方法运行

            cn.Close();
            MessageBox.Show("修改成功，请刷新");
            this.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void frm_TransfEvent(int value)
        {
            numericUpDown3.Value = numericUpDown3.Value + value;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            dialog dialog = new dialog();
            dialog.TransfEvent += frm_TransfEvent;
            dialog.ShowDialog();

        }
    }
}
