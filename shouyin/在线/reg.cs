using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace shouyin
{
    public partial class reg : MaterialForm
    {
        public reg()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void reg_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form2.reg = null;
        }

        private void reg_Load(object sender, EventArgs e)
        {
            materialFlatButton2.Focus();
        }
        private String url = "http://192.168.31.139:8080/sell/reg";



        private void materialFlatButton1_Click(object sender, EventArgs e)
        {

        }
        public delegate void TransfDelegate(String value);//异窗口传值，委托
        public event TransfDelegate TransfEvent;
        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            String password=Units.md5Encrypt(materialSingleLineTextField1.Text.Trim());
            Dictionary<string, String> list = new Dictionary<string, String>(6);
            list.Add("username", materialSingleLineTextField1.Text.Trim());
            list.Add("password", password);
            list.Add("phone_number", materialSingleLineTextField3.Text.Trim());
            try
            {
                switch (Units.Post(url, list))
                {
                    case "101":
                        MessageBox.Show("用户名为空");
                        return;
                    case "102":
                        MessageBox.Show("密码为空");
                        return;
                    case "103":
                        MessageBox.Show("手机号为空");
                        return;
                    case "200":
                        MessageBox.Show("注册成功，请登录");
                        TransfEvent(materialSingleLineTextField1.Text);
                        this.Close();
                        return;
                    case "201":
                        MessageBox.Show("账号已存在");
                        return;
                    case "202":
                        MessageBox.Show("手机号已存在");
                        return;
                    case "301":
                        MessageBox.Show("请勿使用特殊字符");
                        return;
                    case "302":
                        MessageBox.Show("请输入正确的手机号码");
                        return;
                    default:
                        MessageBox.Show("未知原因，请查看是否有更新");
                        return;
                }
            }
            catch
            {
                弹窗.worry worry = new 弹窗.worry();
                worry.ShowDialog();
            }

        }

        private void materialSingleLineTextField1_Enter(object sender, EventArgs e)
        {
            if (materialSingleLineTextField1.Text == "账号")
            {
                materialSingleLineTextField1.Text = "";
            }
        }

        private void materialSingleLineTextField1_Leave(object sender, EventArgs e)
        {
            if (materialSingleLineTextField1.Text == "")
            {
                materialSingleLineTextField1.Text = "账号";
            }
        }

        private void materialSingleLineTextField2_Enter(object sender, EventArgs e)
        {
            if (materialSingleLineTextField2.Text == "密码")
            {
                materialSingleLineTextField2.Text = "";
            }
            materialSingleLineTextField2.PasswordChar = '*';

        }

        private void materialSingleLineTextField2_Leave(object sender, EventArgs e)
        {
            if (materialSingleLineTextField2.Text == "")
            {
                materialSingleLineTextField2.PasswordChar = '\0';
                materialSingleLineTextField2.Text = "密码";
            }
        }

        private void materialSingleLineTextField3_Enter(object sender, EventArgs e)
        {
            if (materialSingleLineTextField3.Text == "手机号码")
            {
                materialSingleLineTextField3.Text = "";
            }
        }

        private void materialSingleLineTextField3_Leave(object sender, EventArgs e)
        {
            if (materialSingleLineTextField3.Text == "")
            {
                materialSingleLineTextField3.Text = "手机号码";
            }
        }

        private void materialSingleLineTextField4_Enter(object sender, EventArgs e)
        {
            if (materialSingleLineTextField4.Text == "验证码")
            {
                materialSingleLineTextField4.Text = "";
            }
        }

        private void materialSingleLineTextField4_Leave(object sender, EventArgs e)
        {
            if (materialSingleLineTextField4.Text == "")
            {
                materialSingleLineTextField4.Text = "验证码";
            }
        }

        private void materialSingleLineTextField3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9')))//表示输入的是数字
            {
                e.Handled = true;//true表示已经处理该事件，则屏蔽输入
            }
        }

        private void materialSingleLineTextField3_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField1_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Regex.IsMatch(e.KeyChar.ToString(),"[a-zA-Z0-9@]")))//表示输入的是数字
            {
                e.Handled = true;//true表示已经处理该事件，则屏蔽输入
            }
        }

        private void materialSingleLineTextField2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Regex.IsMatch(e.KeyChar.ToString(), @"[a-zA-Z0-9\.]")))//表示输入的是数字
            {
                e.Handled = true;//true表示已经处理该事件，则屏蔽输入
                MessageBox.Show("只允许输入大小写字母与数字和\".\"");
            }
        }
    }
}
