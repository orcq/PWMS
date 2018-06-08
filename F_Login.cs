using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using PWMS.DataClass;

namespace PWMS
{
    public partial class F_Login : Form
    {
        public F_Login()
        {
            InitializeComponent();
        }

        private void textName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')//是否按下Enter
                textPass.Focus(); //鼠标焦点移动到"密码"文本框
        }

        private void textPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')//是否按下Enter
                butLogin.Focus(); //鼠标焦点移动到"登录"文本框
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butLogin_Click(object sender, EventArgs e)
        {
            if (textName.Text != "" & textPass.Text != "")
            {   //数据表中查找是否有当前登录用户
                SQLiteDataReader temDR = MyMeans.getcom("select * from  tb_Login where Name='" + textName.Text.Trim() + "'and Pass='" + textPass.Text.Trim() + "'");
                bool ifcom = temDR.Read();//必须用Reab方法读
                //当有记录时表示用户名和密码正确
                if (ifcom)
                {
                    DataClass.MyMeans.Login_Name = textName.Text.Trim();//将用户名记录到公共变量中
                    DataClass.MyMeans.Login_ID = temDR.GetString(0);//获取当前的操作员编号
                    DataClass.MyMeans.My_con.Close();
                    DataClass.MyMeans.My_con.Dispose();
                    DataClass.MyMeans.Login_n = (int)(this.Tag);//记录当前窗体的Tag属性
                   
                    this.Close();
                    
                  
                }
                else
                {
                    MessageBox.Show("用户名或密码错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textName.Text = "";
                    textPass.Text = "";
                }
            }
            else
            {
                MessageBox.Show("请将登录信息填写完整", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



    }
}
