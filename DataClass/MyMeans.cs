using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;

namespace PWMS.DataClass
{
    class MyMeans
    {
        public static string Login_ID = "";//记录当前登录的用户编号
        public static string Login_Name = "";//记录当前登录的用户名
        //定义基础信息各窗体中的表名，SQL语句以及添加，修改的字段名
        public static string Mean_SQL = "", Mean_Table = "", Mean_Field = "";
        //用于判断数据库是否连接成功
        public static SQLiteConnection My_con;
        //定义连接字符串，
        public static string M_str_sqlcon = "Data Source = mrlx\\lx;Database = db_PWMS;Userid = sa;PWD=";
        public static int Login_n = 0;//用户登录和重新登录的标识
        public static string AllSql = "Select * from tb_Staffbasic";  //存储职工信息表
     

        public static SQLiteConnection getcon()
        {
            string connStr = m_strdbpath;//声明一个用于储存连接数据库的字符串
            My_con = new SQLiteConnection(connStr);//与指定的数据库相连
            My_con.Open();//打开数据库连接
            return My_con;//返回SQLiteConnection对象信息
        }

        public static void con_close()
        {
            if (My_con.State == ConnectionState.Open)//判断是否打开与数据的连接
            {
                My_con.Close();
                My_con.Dispose();//释放MY_con的所有空间
            }
        }
      internal static SQLiteDataReader getcom(string SQLstr)
        {
            getcon();//打开于数据库的连接
            SQLiteCommand My_com = My_con.CreateCommand();//用于执行SQL语句
            My_com.CommandText = SQLstr;//获取指定的SQL语句
            SQLiteDataReader My_read = My_com.ExecuteReader();//执行SQL语句,生成SQLiteDataReader的对象
            return My_read;
        }

        public static void getsqlcom(string SQLstr)
        {
            getcon();
            SQLiteCommand SQLcom = new SQLiteCommand(SQLstr, My_con);//创建SQLiteCommand对象用于执行sql语句
            SQLcom.ExecuteNonQuery();//执行Sql语句
            SQLcom.Dispose();
            con_close();
        }

      internal DataSet getDataSet(string SQLstr, string tableName)
        {
            getcon();
            SQLiteDataAdapter SQLda = new SQLiteDataAdapter(SQLstr, My_con);
            DataSet My_DataSet = new DataSet();
            SQLda.Fill(My_DataSet,tableName);
            con_close();
            return My_DataSet;
        }
        //数据库文件路径
        static private string m_strdbpath = "Data Source =" + Application.StartupPath + "\\db_PWMS";



 
                 

       



    }
}

