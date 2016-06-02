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
    /// detail.xaml 的交互逻辑
    /// </summary>
    public partial class detail : Page
    {
        static public string arg;   
        public detail()
        {
            InitializeComponent();
            detailPage();
        }
        public string Getstring(string args)  //获取参数arg,为"学号"
        {
            return arg = args;
        }
        public void detailPage()
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
                if (String.Compare(m, "y")== 0)    //如果用户名是教师账户
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
            
            //从Selection页面获取静态数据
            if (Selection.arg == "fromInfo")  //从学生信息表中查询数据
            {
                //跳转页面，传递参数
                StudentInfo si=new StudentInfo ();
                si.Getstring(arg);
                this.NavigationService.Navigate(si);
            }
            else if(Selection.arg=="fromAch")
            {
               
                //跳转页面，传递参数
                StudentAchievement sa = new StudentAchievement();
                sa.Getstring(arg);
                this.NavigationService.Navigate(sa);
            }
            else if (Selection.arg == "fromFile")
            {
               
                //跳转页面，传递参数 
                StudentFile sf = new StudentFile();
                sf.Getstring(arg);
                this.NavigationService.Navigate(sf);
            }
        }
        public void fromTable_Student()
        {
          
            if (Selection.arg == "fromInfo")  //从学生信息表中查询数据
            {
              
                StudentInfo si = new StudentInfo();
                si.Getstring(arg);
                this.NavigationService.Navigate(si);
            }
            else if (Selection.arg == "fromAch")
            {
                StudentAchievement sa = new StudentAchievement();
                sa.Getstring(arg);
                this.NavigationService.Navigate(sa);
            }
            else if (Selection.arg == "fromFile")
            {
                StudentFile sf = new StudentFile();
                sf.Getstring(arg);
                this.NavigationService.Navigate(sf);
            }
        }
    }
}
