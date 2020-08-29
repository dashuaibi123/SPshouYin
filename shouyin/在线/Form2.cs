using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Net;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;

namespace shouyin
{
    public partial class Form2 : MaterialForm
    {
        String url = "http://192.168.31.139:8080/sell/";
        public Form2()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        public String LoginThread(String username,String password)
        {
            String md5password = Units.md5Encrypt(password.Trim());
            String LoginUrl = url + "login";
            Dictionary<string, String> list = new Dictionary<string, String>(6);
            list.Add("username", username);
            list.Add("password", md5password);
            ZaiXian zaiXian = new ZaiXian();
            try
            {
                String returnCode = Units.Post(LoginUrl, list);
                switch (returnCode)
                {
                    case "200":
                        return "200";
                    case "101":
                        return "201";
                    case "102":
                        return "201";
                    case "202":
                        return "202";
                    default:
                        return "未知错误";
                }
            }
            catch
            {
                return "未知错误或没有网络连接";
            }
        }
        public static reg reg;
        public static Form2 form2;
        void frm_TransfEvent(String value)
        {
            materialSingleLineTextField1.Text = value.Trim();
            materialSingleLineTextField2.Focus();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (reg == null)
            {
                reg = new reg();
                reg.TransfEvent += frm_TransfEvent;
                reg.ShowDialog();
            }
            else
            {
                reg.Activate();
            }


        }



        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (materialSingleLineTextField1.Text == "手机号/账号/邮箱" || materialSingleLineTextField2.Text == "密码")
            {
                MessageBox.Show("请输入账号密码");
            }
            else
            {
                if (materialLabel1.Text == "允许5-16字节，允许字母数字和@" || materialLabel2.Text == "只允许以字母开头，长度在6~18之间，只能包含字母、数字和下划线")
                {
                    MessageBox.Show("登陆失败");
                }
                else
                {
                    if (Regex.IsMatch(materialSingleLineTextField1.Text.Trim(), "[a-zA-Z0-9]")&&!Regex.IsMatch(materialSingleLineTextField1.Text.Trim(), "[@]"))
                    {//使用账号登陆

                    }
                    else if(Regex.IsMatch(materialSingleLineTextField1.Text.Trim(), @"^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\d{8}$") && !Regex.IsMatch(materialSingleLineTextField1.Text.Trim(), "[@]")&&!Regex.IsMatch(materialSingleLineTextField1.Text.Trim(), "[a-zA-Z|\u4e00-\u9fa5]"))
                    {//使用手机号码登陆

                    }
                    else if(Regex.IsMatch(materialSingleLineTextField1.Text.Trim(), @"\w[-\w.+]*@([A-Za-z0-9][-A-Za-z0-9]+\.)+[A-Za-z]{2,14}"))
                    {//使用邮箱登录

                    }
                    switch (LoginThread(materialSingleLineTextField1.Text.Trim(), materialSingleLineTextField2.Text.Trim()))
                    {
                        case "200":
                            ZaiXian zaiXian = new ZaiXian(materialSingleLineTextField1.Text.Trim());
                            this.Width = 0;
                            this.Height = 0;
                            zaiXian.Show();
                            return;
                        case "201"://基本用不到这条，只是应用到了后端的101和102返回码
                            MessageBox.Show("账号或密码为空");
                            return;
                        case "202":
                            MessageBox.Show("账号或密码错误");
                            return;
                        default:
                            MessageBox.Show("未知错误，可能是网络问题");
                            return;
                    }
                }
            }
            
            

        }

        private void materialSingleLineTextField1_Enter(object sender, EventArgs e)
        {
            if (materialSingleLineTextField1.Text == "手机号/账号/邮箱")
            {
                materialSingleLineTextField1.Text = "";
            }
        }

        private void materialSingleLineTextField1_Leave(object sender, EventArgs e)
        {
            if (materialSingleLineTextField1.Text == "")
            {
                materialSingleLineTextField1.Text = "手机号/账号/邮箱";
            }
        }

        private void materialSingleLineTextField2_Enter(object sender, EventArgs e)
        {
            if (materialSingleLineTextField2.Text == "密码")
            {
                materialSingleLineTextField2.Text = "";
            }
            materialSingleLineTextField2.PasswordChar ='*';
        }

        private void materialSingleLineTextField2_Leave(object sender, EventArgs e)
        {
            if (materialSingleLineTextField2.Text == "")
            {
                materialSingleLineTextField2.PasswordChar = '\0';
                materialSingleLineTextField2.Text = "密码";
            }

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            form2 = null;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void materialSingleLineTextField2_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField1_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField1_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(materialSingleLineTextField1.Text.Trim(), @"[^a-zA-Z0-9@\.]"))//允许字母数字和@
            {
                if (materialSingleLineTextField1.Text == "手机号/账号/邮箱")
                {

                }
                else
                {
                    if (materialSingleLineTextField1.Text == "")
                    {

                    }
                    else
                    {
                        materialLabel1.Text = "允许5-16字节，允许字母数字和@";

                    }
                }

                
            }
            else
            {
                materialLabel1.Text = "";
            }
        }

        private void materialSingleLineTextField2_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(materialSingleLineTextField2.Text.Trim(), @"[^a-zA-Z0-9]"))//以字母开头，长度在6~18之间，只能包含字母、数字和下划线
            {
                if (materialSingleLineTextField2.Text == "密码")
                {

                }
                else
                {
                    if (materialSingleLineTextField2.Text == "")
                    {

                    }
                    else
                    {
                        materialLabel2.Text = "只允许以字母开头，长度在6~18之间，只能包含字母、数字和下划线";

                    }
                }
            }
            else
            {
                materialLabel2.Text = "";
            }
        }
    }
}
