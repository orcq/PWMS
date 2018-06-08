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
using System.IO;

namespace PWMS
{
    using Word = Microsoft.Office.Interop.Word;
    using System.Globalization;
    public partial class F_MainFile : Form
    {
        SQLiteConnection mConn;
        SQLiteDataAdapter mAdapter;
        DataTable mTable;
      
        PerForm pf = new PerForm();
        byte[] oto = null;//存入数据库的照片

        public F_MainFile()
        {
            InitializeComponent();
          
        }

        private void Sta_Add_Click(object sender, EventArgs e)
        {
           pf.Clear_Control(tabControl1.TabPages[0].Controls);//清空职工信息的相应文本框
           S_0.Text = pf.GetAutocoding("tb_Staffbasic","ID");//自动添加编号
           hold_n =1;//用于记录添加操作的表识
           Img_Save.Enabled = true;//使图片选择按钮为可用按钮
           Img_Clear.Enabled = true;
           Sta_Save.Enabled = true;
        }

      

        private void Sta_Amend_Click(object sender, EventArgs e)//保存按钮用来更新职工信息
        {
            hold_n = 2;//用于记录添加操作的表识
            Img_Save.Enabled = true;//使图片选择按钮为可用按钮
            Img_Clear.Enabled = true;
            Sta_Save.Enabled = true;
        }

       
        private void Sta_Save_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabPage1")//如果当前是职工基本信息选项卡
            {
              
                System.Byte[] Photo = oto;
                string ID = S_0.Text, StaffName = S_1.Text, Folk = S_2.Text, Culture = S_5.Text, Marriage = S_6.Text, Sex = S_7.Text;
                string Visage = S_8.Text, Employee = S_12.Text, IDCard = S_9.Text, Business = S_13.Text, Laborage = S_14.Text, Branch = S_15.Text;
                string Duthcall = S_16.Text, Phone = S_17.Text, Handset = S_18.Text, School = S_19.Text, Speciality = S_20.Text, Address = S_22.Text;
                string Age = S_4.Text, WorkLength = S_11.Text, M_Pay = S_25.Text, Pact_Y = S_29.Text;
                string BeAware = S_23.Text, City = S_24.Text, Bank = S_26.Text;

                DateTime Birthday, Workdate, GraduateDate, Pact_B, Pact_E;
                Birthday = Convert.ToDateTime(this.S_3.Text.Trim()); ;
                Workdate = Convert.ToDateTime(this.S_10.Text.Trim()); ;
                GraduateDate = Convert.ToDateTime(this.S_21.Text.Trim());
                Pact_B = Convert.ToDateTime(this.S_27.Text.Trim()); ;
                Pact_E = Convert.ToDateTime(this.S_28.Text.Trim()); ;
             
            
                 
                    string s = string.Format(@"INSERT INTO tb_Staffbasic  VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}')"
                  , ID, StaffName, Folk, Birthday, Age, Culture, Marriage, Sex, Visage, IDCard, WorkLength, Workdate, Employee, Business, Laborage, Branch, Duthcall, Phone, Handset, School, Speciality, GraduateDate, Address, oto, BeAware, City, M_Pay, Bank,
                  Pact_B, Pact_E, Pact_Y);

                    MyMeans.getsqlcom(s);
                    Sta_Save.Enabled = false;
             

                button6_Click(sender,e);
            }
        }

        public string tem_ID { get; set; }
       
       string strimg = "";

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Img_Save_Click(object sender, EventArgs e)
        {
                OpenFileDialog openF = new OpenFileDialog();
                PictureBox MyImage = new PictureBox();
                openF.Filter = "JPG图片|*.jpg|BMP图片|*.bmp|Gif图片|*.gif";//指定控件打开的文件格式
                if (openF.ShowDialog(this) == DialogResult.OK)//如果打开了图片文件
                {
                    MyImage.Image = System.Drawing.Image.FromFile(openF.FileName);//图片文件存入 PictureBox 控件
                    strimg = openF.FileName.ToString();//记录图片的路径
                    openF.CheckFileExists = true;
                    openF.CheckPathExists = true;
                    openF.Multiselect = false;
                    S_Photo.ImageLocation = openF.FileName;
                    FileStream fs = new FileStream(strimg, FileMode.Open, FileAccess.Read); //将图片以文件流的形式进行保存
                    BinaryReader br = new BinaryReader(fs);
                    byte[] imgBytesIn = br.ReadBytes((int)fs.Length); //将流读入到字节数组中
                    oto = imgBytesIn;
                }
                else
                {
                    MessageBox.Show("没有选择图片");
                }
             
        }

        private void Img_Clear_Click(object sender, EventArgs e)
        {
            S_Photo.Image = null;
        }

        private void Sta_Delete_Click(object sender, EventArgs e)//删除人事档案信息
        {
            if (MyDS_Grid.RowCount < 2)//判断控件中是否有记录
            {
                MessageBox.Show("数据表为空，不可以删除！");
                return;
            }

            MyMeans.getsqlcom("Delete tb_Staffbasic where = ID'"+ S_0.Text.Trim()+"'");
            MyMeans.getsqlcom("Delete tb_WorkResume where = Stu_ID'" + S_0.Text.Trim() + "'");
            MyMeans.getsqlcom("Delete tb_Family where = Sta_ID'" + S_0.Text.Trim() + "'");
            MyMeans.getsqlcom("Delete tb_TrainNote where = Sta_ID '" + S_0.Text.Trim() + "'");
            MyMeans.getsqlcom("Delete tb_RANDP where = Sta_ID'" + S_0.Text.Trim() + "'");
            MyMeans.getsqlcom("Delete tb_WorkResume where = Sta_ID'" + S_0.Text.Trim() + "'");
            MyMeans.getsqlcom("Delete tb_Individual where = ID'" + S_0.Text.Trim() + "'");

            button6_Click(sender, e);
        }
        public static string tem_Field = "";
     

        private void Sta_Table_Click(object sender, EventArgs e)
        {
            object Nothing = System.Reflection.Missing.Value;
            object missing = System.Reflection.Missing.Value;
            //创建Word文档
            Word.Application wordApp = new Word.Application();
            Word.Document wordDoc = wordApp.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);
            wordApp.Visible = true;

            //设置文档宽度
            wordApp.Selection.PageSetup.LeftMargin = wordApp.CentimetersToPoints(float.Parse("2"));
            wordApp.ActiveWindow.ActivePane.HorizontalPercentScrolled = 11;
            wordApp.Selection.PageSetup.RightMargin = wordApp.CentimetersToPoints(float.Parse("2"));

            Object start = Type.Missing;
            Object end = Type.Missing;

            PictureBox pp = new PictureBox();   //新建一个PictureBox控件
            int p1 = 0;
            for (int i = 0; i < MyDS_Grid.Rows.Count; i++)
            {
                try
                {
                    byte[] pic = (byte[])(MyDS_Grid.Rows[i].Cells[23].Value); //将数据库中的图片转换成二进制流
                    MemoryStream ms = new MemoryStream(pic);			//将字节数组存入到二进制流中
                    pp.Image = Image.FromStream(ms);   //二进制流Image控件中显示
                    pp.Image.Save(@"C:\22.bmp");    //将图片存入到指定的路径
                }
                catch
                {
                    p1 = 1;
                }
                object rng = Type.Missing;
                string strInfo = "职工基本信息表" + "(" + MyDS_Grid.Rows[i].Cells[1].Value.ToString() + ")";
                start = 0;
                end = 0;
                wordDoc.Range(ref start, ref end).InsertBefore(strInfo);    //插入文本
                wordDoc.Range(ref start, ref end).Font.Name = "Verdana";    //设置字体
                wordDoc.Range(ref start, ref end).Font.Size = 20;   //设置字体大小
                wordDoc.Range(ref start, ref end).ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter; //设置字体局中

                start = strInfo.Length;
                end = strInfo.Length;
                wordDoc.Range(ref start, ref end).InsertParagraphAfter();//插入回车

                object missingValue = Type.Missing;
                object location = strInfo.Length; //如果location超过已有字符的长度将会出错。一定要比"明细表"串多一个字符
                Word.Range rng2 = wordDoc.Range(ref location, ref location);

                wordDoc.Tables.Add(rng2, 14, 6, ref missingValue, ref missingValue);
                wordDoc.Tables[1].Rows.HeightRule = Word.WdRowHeightRule.wdRowHeightAtLeast;
                wordDoc.Tables[1].Rows.Height = wordApp.CentimetersToPoints(float.Parse("0.8"));
                wordDoc.Tables[1].Range.Font.Size = 10;
                wordDoc.Tables[1].Range.Font.Name = "宋体";

                //设置表格样式
                wordDoc.Tables[1].Borders[Word.WdBorderType.wdBorderLeft].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                wordDoc.Tables[1].Borders[Word.WdBorderType.wdBorderLeft].LineWidth = Word.WdLineWidth.wdLineWidth050pt;
                wordDoc.Tables[1].Borders[Word.WdBorderType.wdBorderLeft].Color = Word.WdColor.wdColorAutomatic;
                wordApp.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;//设置右对齐

                //第5行显示
                wordDoc.Tables[1].Cell(1, 5).Merge(wordDoc.Tables[1].Cell(5, 6));
                //第6行显示
                wordDoc.Tables[1].Cell(6, 5).Merge(wordDoc.Tables[1].Cell(6, 6));
                //第9行显示
                wordDoc.Tables[1].Cell(9, 4).Merge(wordDoc.Tables[1].Cell(9, 6));
                //第12行显示
                wordDoc.Tables[1].Cell(12, 2).Merge(wordDoc.Tables[1].Cell(12, 6));
                //第13行显示
                wordDoc.Tables[1].Cell(13, 2).Merge(wordDoc.Tables[1].Cell(13, 6));
                //第14行显示
                wordDoc.Tables[1].Cell(14, 2).Merge(wordDoc.Tables[1].Cell(14, 6));

                //第1行赋值
                wordDoc.Tables[1].Cell(1, 1).Range.Text = "职工编号：";
                wordDoc.Tables[1].Cell(1, 2).Range.Text = MyDS_Grid.Rows[i].Cells[0].Value.ToString();
                wordDoc.Tables[1].Cell(1, 3).Range.Text = "职工姓名：";
                wordDoc.Tables[1].Cell(1, 4).Range.Text = MyDS_Grid.Rows[i].Cells[1].Value.ToString();

                //插入图片

                if (p1 == 0)
                {
                    string FileName = @"C:\22.bmp";//图片所在路径
                    object LinkToFile = false;
                    object SaveWithDocument = true;
                    object Anchor = wordDoc.Tables[1].Cell(1, 5).Range;    //指定图片插入的区域
                    //将图片插入到单元格中
                    wordDoc.Tables[1].Cell(1, 5).Range.InlineShapes.AddPicture(FileName, ref LinkToFile, ref SaveWithDocument, ref Anchor);
                }
                p1 = 0;

                //第2行赋值
                wordDoc.Tables[1].Cell(2, 1).Range.Text = "民族类别：";
                wordDoc.Tables[1].Cell(2, 2).Range.Text = MyDS_Grid.Rows[i].Cells[2].Value.ToString();
                wordDoc.Tables[1].Cell(2, 3).Range.Text = "出生日期：";
                try
                {
                    wordDoc.Tables[1].Cell(2, 4).Range.Text = Convert.ToString(Convert.ToDateTime(MyDS_Grid.Rows[i].Cells[3].Value).ToShortDateString());
                }
                catch { wordDoc.Tables[1].Cell(2, 4).Range.Text = ""; }
                //Convert.ToString(MyDS_Grid.Tables[0].Rows[i][3]);
                //第3行赋值
                wordDoc.Tables[1].Cell(3, 1).Range.Text = "年龄：";
                wordDoc.Tables[1].Cell(3, 2).Range.Text = Convert.ToString(MyDS_Grid.Rows[i].Cells[4].Value.ToString());
                wordDoc.Tables[1].Cell(3, 3).Range.Text = "文化程序：";
                wordDoc.Tables[1].Cell(3, 4).Range.Text = MyDS_Grid.Rows[i].Cells[5].Value.ToString();
                //第4行赋值
                wordDoc.Tables[1].Cell(4, 1).Range.Text = "婚姻：";
                wordDoc.Tables[1].Cell(4, 2).Range.Text = MyDS_Grid.Rows[i].Cells[6].Value.ToString().ToString();
                wordDoc.Tables[1].Cell(4, 3).Range.Text = "性别：";
                wordDoc.Tables[1].Cell(4, 4).Range.Text = MyDS_Grid.Rows[i].Cells[7].Value.ToString();
                //第5行赋值
                wordDoc.Tables[1].Cell(5, 1).Range.Text = "政治面貌：";
                wordDoc.Tables[1].Cell(5, 2).Range.Text = MyDS_Grid.Rows[i].Cells[8].Value.ToString();
                wordDoc.Tables[1].Cell(5, 3).Range.Text = "单位工作时间：";
                try
                {
                    wordDoc.Tables[1].Cell(5, 4).Range.Text = Convert.ToString(Convert.ToDateTime(MyDS_Grid.Rows[i].Cells[10].Value).ToShortDateString());
                }
                catch { wordDoc.Tables[1].Cell(5, 4).Range.Text = ""; }
                //第6行赋值
                wordDoc.Tables[1].Cell(6, 1).Range.Text = "籍贯：";
                wordDoc.Tables[1].Cell(6, 2).Range.Text = MyDS_Grid.Rows[i].Cells[24].Value.ToString();
                wordDoc.Tables[1].Cell(6, 3).Range.Text = MyDS_Grid.Rows[i].Cells[25].Value.ToString();
                wordDoc.Tables[1].Cell(6, 4).Range.Text = "身份证：";
                wordDoc.Tables[1].Cell(6, 5).Range.Text = MyDS_Grid.Rows[i].Cells[9].Value.ToString();
                //第7行赋值
                wordDoc.Tables[1].Cell(7, 1).Range.Text = "工龄：";
                wordDoc.Tables[1].Cell(7, 2).Range.Text = Convert.ToString(MyDS_Grid.Rows[i].Cells[11].Value);
                wordDoc.Tables[1].Cell(7, 3).Range.Text = "职工类别：";
                wordDoc.Tables[1].Cell(7, 4).Range.Text = MyDS_Grid.Rows[i].Cells[12].Value.ToString();
                wordDoc.Tables[1].Cell(7, 5).Range.Text = "职务类别：";
                wordDoc.Tables[1].Cell(7, 6).Range.Text = MyDS_Grid.Rows[i].Cells[13].Value.ToString();
                //第8行赋值
                wordDoc.Tables[1].Cell(8, 1).Range.Text = "工资类别：";
                wordDoc.Tables[1].Cell(8, 2).Range.Text = MyDS_Grid.Rows[i].Cells[14].Value.ToString();
                wordDoc.Tables[1].Cell(8, 3).Range.Text = "部门类别：";
                wordDoc.Tables[1].Cell(8, 4).Range.Text = MyDS_Grid.Rows[i].Cells[15].Value.ToString();
                wordDoc.Tables[1].Cell(8, 5).Range.Text = "职称类别：";
                wordDoc.Tables[1].Cell(8, 6).Range.Text = MyDS_Grid.Rows[i].Cells[16].Value.ToString();
                //第9行赋值
                wordDoc.Tables[1].Cell(9, 1).Range.Text = "月工资：";
                wordDoc.Tables[1].Cell(9, 2).Range.Text = Convert.ToString(MyDS_Grid.Rows[i].Cells[26].Value);
                wordDoc.Tables[1].Cell(9, 3).Range.Text = "银行帐号：";
                wordDoc.Tables[1].Cell(9, 4).Range.Text = MyDS_Grid.Rows[i].Cells[27].Value.ToString();
                //第10行赋值
                wordDoc.Tables[1].Cell(10, 1).Range.Text = "合同起始日期：";
                try
                {
                    wordDoc.Tables[1].Cell(10, 2).Range.Text = Convert.ToString(Convert.ToDateTime(MyDS_Grid.Rows[i].Cells[28].Value).ToShortDateString());
                }
                catch { wordDoc.Tables[1].Cell(10, 2).Range.Text = ""; }
                //Convert.ToString(MyDS_Grid.Tables[0].Rows[i][28]);
                wordDoc.Tables[1].Cell(10, 3).Range.Text = "合同结束日期：";
                try
                {
                    wordDoc.Tables[1].Cell(10, 4).Range.Text = Convert.ToString(Convert.ToDateTime(MyDS_Grid.Rows[i].Cells[29].Value).ToShortDateString());
                }
                catch { wordDoc.Tables[1].Cell(10, 4).Range.Text = ""; }
                //Convert.ToString(MyDS_Grid.Tables[0].Rows[i][29]);
                wordDoc.Tables[1].Cell(10, 5).Range.Text = "合同年限：";
                wordDoc.Tables[1].Cell(10, 6).Range.Text = Convert.ToString(MyDS_Grid.Rows[i].Cells[30].Value);
                //第11行赋值
                wordDoc.Tables[1].Cell(11, 1).Range.Text = "电话：";
                wordDoc.Tables[1].Cell(11, 2).Range.Text = MyDS_Grid.Rows[i].Cells[17].Value.ToString();
                wordDoc.Tables[1].Cell(11, 3).Range.Text = "手机：";
                wordDoc.Tables[1].Cell(11, 4).Range.Text = MyDS_Grid.Rows[i].Cells[18].Value.ToString();
                wordDoc.Tables[1].Cell(11, 5).Range.Text = "毕业时间：";
                try
                {
                    wordDoc.Tables[1].Cell(11, 6).Range.Text = Convert.ToString(Convert.ToDateTime(MyDS_Grid.Rows[i].Cells[21].Value).ToShortDateString());
                }
                catch { wordDoc.Tables[1].Cell(11, 6).Range.Text = ""; }
                //Convert.ToString(MyDS_Grid.Tables[0].Rows[i][21]);
                //第12行赋值
                wordDoc.Tables[1].Cell(12, 1).Range.Text = "毕业学校：";
                wordDoc.Tables[1].Cell(12, 2).Range.Text = MyDS_Grid.Rows[i].Cells[19].Value.ToString();
                //第13行赋值
                wordDoc.Tables[1].Cell(13, 1).Range.Text = "主修专业：";
                wordDoc.Tables[1].Cell(13, 2).Range.Text = MyDS_Grid.Rows[i].Cells[20].Value.ToString();
                //第14行赋值
                wordDoc.Tables[1].Cell(14, 1).Range.Text = "家庭地址：";
                wordDoc.Tables[1].Cell(14, 2).Range.Text = MyDS_Grid.Rows[i].Cells[22].Value.ToString();

                wordDoc.Range(ref start, ref end).InsertParagraphAfter();//插入回车
                wordDoc.Range(ref start, ref end).ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter; //设置字体局中
            }
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            mAdapter = new SQLiteDataAdapter("SELECT * FROM [" + comboBox3.Text + "]", mConn);
            mTable = new DataTable(); // Don't forget initialize!
            mAdapter.Fill(mTable);

            // 绑定数据到DataGridView
            MyDS_Grid.DataSource = mTable;
        }

       

        private void F_MainFile_Load(object sender, EventArgs e)
        {
            string mDbPath = Application.StartupPath + "\\db_PWMS";//连接数据库
            mConn = new SQLiteConnection("Data Source=" + mDbPath);//如果数据库不存在，则自动创建.
            mConn.Open();//打开数据库文件.
            //获取数据库中表.
            //表 "Tables"中字段 "TABLE_NAME" 包含所有表名信息.
            using (DataTable mTables = mConn.GetSchema("Tables")) // "Tables"包含系统表详细信息；
            {
                for (int i = 0; i < mTables.Rows.Count; i++)
                {
                    comboBox3.Items.Add(mTables.Rows[i].ItemArray[mTables.Columns.IndexOf("TABLE_NAME")].ToString());
                }
                if (comboBox3.Items.Count > 0)
                {
                    comboBox3.SelectedIndex = 0; // 默认选中第一张表.
                }
            }
        }


        public int hold_n { get; set; }

        
    }
}
