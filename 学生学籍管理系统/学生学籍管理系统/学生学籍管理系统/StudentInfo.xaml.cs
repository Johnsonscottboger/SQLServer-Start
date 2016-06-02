using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 学生学籍管理系统
{
    /// <summary>
    /// StudentInfo.xaml 的交互逻辑
    /// </summary>
    public partial class StudentInfo : Page
    {
        static public string arg;  
        public StudentInfo()
        {
            InitializeComponent();
            UserIs();
        }
        public string Getstring(string args)   //获取数据，为学号
        {
            return arg = args;  
        }
        public void UserIs()
        {
            //查询登陆的用户是否为教师用户
            DataClassesDataContext db = new DataClassesDataContext();
            //查询“临时用户表”中登录的用户名
            string lastuser = db.临时用户管理表.AsEnumerable().Last().用户名;
            //查询“用户管理表”用户名
            var query = from n in db.用户管理表
                        where n.用户名 == lastuser
                        select n.是否为教师账户;
            foreach (var m in query)
            {
                if (String.Compare(m, "y") == 0)    //如果用户名是教师账户
                {
                    fromTable_Teacher();
                }
                else           //如果是学生账户
                {
                    fromTable_Student();
                }
            }
        }
        public void fromTable_Teacher()
        {  
                //从查询结果表中查询数据，以显示在页面中
                DataClassesDataContext db = new DataClassesDataContext();
                var query = from n in db.学生信息表
                            where n.学号 == arg
                            select n;
                listBox.ItemsSource = query.ToList();
        }
        public void fromTable_Student()
        {
                //如果是学生用户，只能在此页查看个人信息，就是不能查看别人的信息
                //从查询结果表中查询数据，以显示在页面中
                DataClassesDataContext db = new DataClassesDataContext();
                var query = from n in db.学生信息表
                            join p in db.临时用户管理表 on n.学号 equals p.学号
                            select n;
                listBox.ItemsSource = query.ToList();
        }
    }
}
