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
    public partial class PerForm : Form
    {
        DataClass.MyMeans MyDataClass = new PWMS.DataClass.MyMeans();
        public static string ADDs = "";//添加或修改SQL语句
        public static string FindValue = "";//存储查询条件
        public static string Address_ID = "";//存储通讯录添加修改的ID
        public static string User_ID = "";//存储用户的ID
        public static string User_Name = "";//存储用户名
        
        public PerForm()
        {
            InitializeComponent();
            GetMenu(treeView1,menuStrip1);
          
        }
      

        public void Show_Form(string FrmName, int n)//窗体的调用
        {
            if (n == 1)//标识
            {
                if (FrmName == "人事档案管理")//判断要打开的窗体的Text属性值
                {
                    F_MainFile FrmManFile = new F_MainFile();
                    FrmManFile.Text = "人事档案管理";
                    FrmManFile.ShowDialog();//显示窗口
                    FrmManFile.Dispose();
                }
                if (FrmName == "人事资料查询")
                {
                    F_ind FrmFind = new F_ind();
                    FrmFind.Text = "人事资料查询";
                    FrmFind.ShowDialog();
                    FrmFind.Dispose();
                }
                if (FrmName == "人事资料统计")
                {
                    F_Stat FrmStat = new F_Stat();
                    FrmStat.Text = "人事资料统计";
                    FrmStat.ShowDialog();
                    FrmStat.Dispose();
                }
                if (FrmName == "员工生日提示")
                {
                    F_ClewSet FrmClewSet = new F_ClewSet();
                    FrmClewSet.Text = "员工生日提示";
                    FrmClewSet.Tag = 1;//用于判断窗体显示类型
                    FrmClewSet.ShowDialog();
                    FrmClewSet.Dispose();
                }
                if (FrmName == "员工合同提示")
                {
                    F_ClewSet FrmClewSet = new F_ClewSet();
                    FrmClewSet.Text = "员工合同提示";
                    FrmClewSet.Tag = 2;//用于判断窗体显示类型
                    FrmClewSet.ShowDialog();
                    FrmClewSet.Dispose();
                }
                if (FrmName == "日常记事")
                {
                    F_WordPad FrmWordPad = new F_WordPad();
                    FrmWordPad.Text = "日常记事";
                    FrmWordPad.ShowDialog();
                    FrmWordPad.Dispose();
                }
                if (FrmName == "通讯录")
                {
                    F_AddressList FrmAddressList = new F_AddressList();
                    FrmAddressList.Text = "通讯录";
                    FrmAddressList.ShowDialog();
                    FrmAddressList.Dispose();
                }
              
                if (FrmName == "重新登录")
                {
                    F_Login FrmLogin = new F_Login();
                    FrmLogin.Tag = 2;
                    FrmLogin.ShowDialog();
                    FrmLogin.Dispose();
                }
               
                if (FrmName == "计算器")
                {
                    System.Diagnostics.Process.Start("calc.exe");
                }
                if (FrmName == "记事本")
                {
                    System.Diagnostics.Process.Start("notepad.exe");
                }
                if (FrmName == "系统帮助")
                {
                    //System.Diagnostics.Process.Start("readme.doc");
                }

            }
            if (n == 2)
            {
                String FrmStr = "";
                if (FrmName == "民族类别设置")
                {
                    DataClass.MyMeans.Mean_SQL = "select * from tb_Folk";//SQL语句
                    DataClass.MyMeans.Mean_Table = "tb_Folk";//表名
                    DataClass.MyMeans.Mean_Field = "FolkName";//添加修改的字段名
                    FrmStr = FrmName;
                }
                if (FrmName == "职工类别设置")
                {
                    DataClass.MyMeans.Mean_SQL = "select * from tb_EmployeeGenre";//SQL语句
                    DataClass.MyMeans.Mean_Table = "tb_EmployeeGenre";//表名
                    DataClass.MyMeans.Mean_Field = "EmployeeName";//添加修改的字段名
                    FrmStr = FrmName;
                }
                if (FrmName == "文化类别设置")
                {
                    DataClass.MyMeans.Mean_SQL = "select * from tb_Culture";//SQL语句
                    DataClass.MyMeans.Mean_Table = "tb_Culture";//表名
                    DataClass.MyMeans.Mean_Field = "CultureName";//添加修改的字段名
                    FrmStr = FrmName;
                }
                if (FrmName == "政治面貌设置")
                {
                    DataClass.MyMeans.Mean_SQL = "select * from tb_Visage";//SQL语句
                    DataClass.MyMeans.Mean_Table = "tb_Visage";//表名
                    DataClass.MyMeans.Mean_Field = "VisageName";//添加修改的字段名
                    FrmStr = FrmName;
                }
                if (FrmName == "部门类别设置")
                {
                    DataClass.MyMeans.Mean_SQL = "select * from tb_Branch";//SQL语句
                    DataClass.MyMeans.Mean_Table = "tb_Branch";//表名
                    DataClass.MyMeans.Mean_Field = "BranchName";//添加修改的字段名
                    FrmStr = FrmName;
                }
                if (FrmName == "工资类别设置")
                {
                    DataClass.MyMeans.Mean_SQL = "select * from tb_Laborage";//SQL语句
                    DataClass.MyMeans.Mean_Table = "tb_Laborage";//表名
                    DataClass.MyMeans.Mean_Field = "LaborageName";//添加修改的字段名
                    FrmStr = FrmName;
                }
                if (FrmName == "职务类别设置")
                {
                    DataClass.MyMeans.Mean_SQL = "select * from tb_Business";//SQL语句
                    DataClass.MyMeans.Mean_Table = "tb_Business";//表名
                    DataClass.MyMeans.Mean_Field = "BusinessName";//添加修改的字段名
                    FrmStr = FrmName;
                }
                if (FrmName == "职称类别设置")
                {
                    DataClass.MyMeans.Mean_SQL = "select * from tb_Duthcall";//SQL语句
                    DataClass.MyMeans.Mean_Table = "tb_Duthcall";//表名
                    DataClass.MyMeans.Mean_Field = "DuthcallName";//添加修改的字段名
                    FrmStr = FrmName;
                }
                if (FrmName == "奖惩类别设置")
                {
                    DataClass.MyMeans.Mean_SQL = "select * from tb_RPKind";//SQL语句
                    DataClass.MyMeans.Mean_Table = "tb_RPKind";//表名
                    DataClass.MyMeans.Mean_Field = "RPKindName";//添加修改的字段名
                    FrmStr = FrmName;
                }
                if (FrmName == "记事本类别设置")
                {
                    DataClass.MyMeans.Mean_SQL = "select * from tb_WordPad";//SQL语句
                    DataClass.MyMeans.Mean_Table = "tb_WordPad";//表名
                    DataClass.MyMeans.Mean_Field = "WordPadName";//添加修改的字段名
                    FrmStr = FrmName;
                }
                F_Basic FrmBasic = new F_Basic();
                FrmBasic.Text = FrmName;
                FrmBasic.ShowDialog();
                FrmBasic.Dispose();
            }
        }

        public void GetMenu(TreeView treeV, MenuStrip MenuS)// 把sta控件中的信息加载到treeview控件中
        {
            for (int i = 0; i < MenuS.Items.Count; i++)//遍历一级菜单
            {
                TreeNode newNode1 = treeV.Nodes.Add(MenuS.Items[i].Text);//将一级菜单添加到根节点，并设置为newNode1
                ToolStripDropDownItem newmenu = (ToolStripDropDownItem)MenuS.Items[i];//存储菜单项相关信息到newmenu 
                if (newmenu.HasDropDownItems && newmenu.DropDownItems.Count > 0)//判断二级菜单
                    for (int j = 0; j < newmenu.DropDownItems.Count; j++)//遍历二级菜单
                    {
                        TreeNode newNode2 = newNode1.Nodes.Add(newmenu.DropDownItems[j].Text);//将二级菜单添加到newNode1节点，并设置为newNode2
                        ToolStripDropDownItem newmenu2 = (ToolStripDropDownItem)newmenu.DropDownItems[j];//存储菜单项相关信息到ToolStripDropDownItem对象
                        if (newmenu2.HasDropDownItems && newmenu2.DropDownItems.Count > 0)//同上这是三级菜单项
                            for (int p = 0; p < newmenu2.DropDownItems.Count; p++)
                                newNode2.Nodes.Add(newmenu2.DropDownItems[p].Text);
                    }
            }

        }

        internal void Clear_Control(Control.ControlCollection Con)//遍历清空指定控件
        {
            foreach (Control C in Con)
            {//遍历可视化组件中的所有控件
                if (C.GetType().Name == "TextBox")//判断是否是TextBox控件
                    if (((TextBox)C).Visible == true)//判断当前控件的显示状态
                        ((TextBox)C).Clear();//清空当前控件
                if (C.GetType().Name == "MaskedTextBox")//判断是否是MaskedTextBox控件
                    if (((MaskedTextBox)C).Visible == true)//判断当前控件的显示状态
                        ((MaskedTextBox)C).Clear();//清空当前控件
                if (C.GetType().Name == "ComboBox")//判断是否是ComboBox"控件
                    if (((ComboBox)C).Visible == true)//判断当前控件的显示状态
                        ((ComboBox)C).Text = "";//清空当前控件
                if (C.GetType().Name == "PictureBox")//判断是否是PictureBox控件
                    if (((PictureBox)C).Visible == true)//判断当前控件的显示状态
                        ((PictureBox)C).Image = null;//清空当前控件
            }
        }

        public void Find_Grids(Control.ControlCollection GBox, string TName, string ANDSign)//组合查询条件
        {
            string sID = "";
            if (FindValue.Length > 0)
                FindValue = FindValue + ANDSign;
            foreach (Control C in GBox)//遍历控件集中的所有控件
            {
                if (C.GetType().Name == "TextBox" | C.GetType().Name == "ComboBox")//判断是否为遍历的控件
                {
                    if (C.GetType().Name == "ComboBox" && C.Text != "")//当指定控件不为空时
                    {
                        sID = C.Name;
                        if (sID.IndexOf(TName) > -1)//当参数是当前控件的名中的部分信息时
                        {
                            string[] Astr = sID.Split(Convert.ToChar('_'));//分隔当前的控件名字，获取相应的字段名
                            FindValue = FindValue + "(" + Astr[1] + " = ’" + C.Text + "')" + ANDSign;//生成查询条件
                        }
                    }
                    if (C.GetType().Name == "TextBox" && C.Text != "")
                    {
                        sID = C.Name;
                        if (sID.IndexOf(TName) > -1)//当参数是当前控件的名中的部分信息时
                        {
                            string[] Astr = sID.Split(Convert.ToChar('_'));//分隔当前的控件名字，将控件名存入一堆数组中
                            string m_Sign = "";//用于记录逻辑运算符
                            string m_ID = "";//用于记录字段名
                            if (Astr.Length > 2)
                                m_ID = Astr[1] + "_" + Astr[2];//将最后两个元素组成字段名
                            else
                                m_ID = Astr[1];
                            foreach (Control C1 in GBox)
                            {
                                if (C.GetType().Name == "ComboBox")//判断是否为ComboBox组件
                                    if ((C1.Name).IndexOf(m_ID) > -1)//判断当前组件是否包含条件组件的部分文件名
                                    {
                                        if (C1.Text == "")//当查询条件为空
                                            break;
                                        else
                                        {
                                            m_Sign = C1.Text;
                                            break;
                                        }
                                    }
                            }
                            if (m_Sign != "")//当查询条件不为空
                                FindValue = FindValue + "(" + m_ID + m_Sign + C.Text + ")" + ANDSign;
                        }
                    }

                }
            }
            if (FindValue.Length > 0)//当查询条件变量不为空时，删除逻辑运算符
            {
                if (FindValue.IndexOf("AND") > -1)//判断是否用AND做连接条件
                    FindValue = FindValue.Substring(0, FindValue.Length - 4);
                if (FindValue.IndexOf("OR") > -1)
                    FindValue = FindValue.Substring(0, FindValue.Length - 3);
            }
            else
                FindValue = "";
        }

        public String GetAutocoding(string TableName, string ID)//自动编号
        {
            SQLiteDataReader MyDR = PWMS.DataClass.MyMeans.getcom("select max(" + ID + ")NID from " + TableName);//查找指定表中ID最大的记录
            int Num = 0;
            if (MyDR.HasRows)//当查找到记录时
            {
                MyDR.Read();
                if (MyDR[0].ToString() == "")
                    return "0001";
                Num = Convert.ToInt32(MyDR[0].ToString());//将最大的编号转换成整数
                ++Num;
                string s = string.Format("{0:0000}", Num);//将整数值转换成指定的字符串
                return s;
            }
            else
            {
                return "0001";//当数据表没有数据时，返回
            }

        }

        public void TreeMenuF(MenuStrip MenuS, TreeNodeMouseClickEventArgs e)//用treeview调用控件下各菜单的单击事件
        {
            string Men = "";
            for (int i = 0; i < MenuS.Items.Count; i++)//遍历MenuStrip控件中的主菜单项
            {
                Men = ((ToolStripDropDownItem)MenuS.Items[i]).Name;//获取主菜单项的名称
                if (Men.IndexOf("Menu") == -1)//如果没有子菜单
                {
                            break;      
                }
                    ToolStripDropDownItem newmenu = (ToolStripDropDownItem)MenuS.Items[i];
                    if (newmenu.HasDropDownItems && newmenu.DropDownItems.Count > 0)//遍历二级菜单
                        for (int j = 0; j < newmenu.DropDownItems.Count; j++)
                        {
                            Men = newmenu.DropDownItems[j].Name;//获取二级菜单项的名称
                           
                            
                                if ((newmenu.DropDownItems[j]).Text == e.Node.Text)
                                    if ((newmenu.DropDownItems[j]).Enabled == false)
                                    {
                                        MessageBox.Show("当前用户无权调用" + "\"" + e.Node.Text + "\"" + "窗体");
                                        break;
                                    }
                                    else
                                    {
                                        Show_Form((newmenu.DropDownItems[j]).Text.Trim(), 1);
                                    }

                            ToolStripDropDownItem newmenu2 = (ToolStripDropDownItem)newmenu.DropDownItems[j];
                            if (newmenu2.HasDropDownItems && newmenu2.DropDownItems.Count > 0)//遍历三级菜单
                                for (int p = 0; p < newmenu2.DropDownItems.Count; p++)
                                {
                                    if ((newmenu2.DropDownItems[p]).Text == e.Node.Text)
                                        if ((newmenu2.DropDownItems[p]).Enabled == false)
                                        {
                                            MessageBox.Show("当前用户无权调用" + "\"" + e.Node.Text + "\"" + "窗体");
                                            break;
                                        }
                                        else
                                            if ((newmenu2.DropDownItems[p]).Text.Trim() == "员工生日提示" || (newmenu2.DropDownItems[p]).Text.Trim() == "员工合同提示")
                                                Show_Form((newmenu2.DropDownItems[p]).Text.Trim(), 1);
                                            else
                                                Show_Form((newmenu2.DropDownItems[p]).Text.Trim(), 2);
                                }
                        }
                }
            
        }


        private void 人事档案管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show_Form(sender.ToString().Trim(),1);
        }

        private void 民族类别设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show_Form(sender.ToString().Trim(), 2);  
        }

        private void 职工类别设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show_Form(sender.ToString().Trim(), 2);
        }

        private void 文化程度设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show_Form(sender.ToString().Trim(), 2);
        }

        private void 政治面貌设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show_Form(sender.ToString().Trim(), 2);
        }

        private void 部门类别设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show_Form(sender.ToString().Trim(), 2);
        }

        private void 工资类别设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show_Form(sender.ToString().Trim(), 2);
        }

        private void 职务类别设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show_Form(sender.ToString().Trim(), 2);
        }

        private void 职称类别设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show_Form(sender.ToString().Trim(), 2);
        }

        private void 奖惩类别设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show_Form(sender.ToString().Trim(), 2);
        }

        private void 记事本类别设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show_Form(sender.ToString().Trim(), 2);
        }

        private void 员工生日提示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show_Form(sender.ToString().Trim(), 1);
        }

        private void 员工合同提示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show_Form(sender.ToString().Trim(), 1);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (人事档案管理ToolStripMenuItem.Enabled == true)
                人事档案管理ToolStripMenuItem_Click(sender, e);
            else
                MessageBox.Show("当前用户无权调用"+"\""+((ToolStripButton)sender).Text+"\""+"窗体");
        }


      
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (员工合同提示ToolStripMenuItem.Enabled == true)
                员工合同提示ToolStripMenuItem_Click(sender, e);
            else
                MessageBox.Show("当前用户无权调用" + "\"" + ((ToolStripButton)sender).Text + "\"" + "窗体");
        }

        private void 日常记事ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show_Form(sender.ToString().Trim(), 1);
        }

        private void 通讯录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show_Form(sender.ToString().Trim(), 1);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Show_Form(sender.ToString().Trim(), 1);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Show_Form(sender.ToString().Trim(), 1);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 计算器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show_Form(sender.ToString().Trim(), 1);
        }

        private void 记事本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show_Form(sender.ToString().Trim(), 1);
        }

        private void 重新登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show_Form(sender.ToString().Trim(), 1);
          //  toolStripStatusLabel3.OwnerItem.Text = DataClass.MyMeans.Login_Name;
        }

        private void 用户设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show_Form(sender.ToString().Trim(), 1);
        }

        private void 系统退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            TreeMenuF(menuStrip1, e);
        }
     
     

       

    }
}
