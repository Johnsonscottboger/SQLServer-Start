using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        static public string num;        //定义一个静态变量
        public string Getstring_MainWindow(string args)  //获取参数
        {
            return num = args;
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UserLogin_Click(object sender, RoutedEventArgs e)
        {
            Login lg = new Login();
            lg.Title = "登录";
            lg.ShowDialog();

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
                if (String.Compare(m, "y") != 0)    //如果用户名不是教师账户
                {
                    Add.IsEnabled = false;
                    Modify.IsEnabled = false;
                    Delete.IsEnabled = false;
                }
            }
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            StudentInfo si = new StudentInfo();
            Selection sl=new Selection ();
            sl.Getstring("fromInfo");    //向页面传递参数
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
                if (String.Compare(m, "y") != 0)    //如果用户名不是教师账户
                {
                    this.Frame.Content = si;
                  
                }
                else
                {            
                    this.Frame.NavigationService.Navigate(sl);   //跳转到选择页面
                }
            }
                
        }

        private void Achievement_Click(object sender, RoutedEventArgs e)
        {
            StudentAchievement sa = new StudentAchievement();
            Selection sl = new Selection();
            sl.Getstring("fromAch");    //向页面传递参数
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
                if (String.Compare(m, "y") != 0)    //如果用户名不是教师账户
                {
                    this.Frame.Content = sa;
                }
                else
                {
                    this.Frame.NavigationService.Navigate(sl);
                }
            }
        }

        private void File_Click(object sender, RoutedEventArgs e)
        {
            StudentFile sf = new StudentFile();
            Selection sl = new Selection();
            sl.Getstring("fromFile");    //向页面传递参数
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
                if (String.Compare(m, "y") != 0)    //如果用户名不是教师账户
                {
                    this.Frame.Content = sf;
                }
                else
                {
                    this.Frame.NavigationService.Navigate(sl);
                }
            }
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            StudentAddmin sa = new StudentAddmin();
            this.Frame.Content = sa;
        }
        //修改
        public void Modify_Click(object sender, RoutedEventArgs e)
        {
            //仅当教师用户登录可用
            //判断Frame中的Page页面
            var control = Selection.arg;  //从Selection获取参数，判断表
            if (control=="fromInfo")
            {
                Add_StudentInfo asi = new Add_StudentInfo();
                DataClassesDataContext db = new DataClassesDataContext();
                var query = from n in db.学生信息表
                            //where n.学号 == StudentInfo.arg
                            where n.学号 ==num
                            select n;
                foreach(var m in query )
                {
                    asi.xuehao.Text = m.学号;
                    asi.zhuanye.Text = m.专业;
                    asi.zhenghi.Text=m.政治面貌;
                    asi.xingming.Text=m.姓名;
                    asi.xingbie.Text=m.性别;
                    asi.jiating.Text=m.家庭住址;
                    asi.lianxi.Text=m.联系电话;
                    asi.birthday.Text = m.出生年月;
                    asi.banji.Text = m.班级;
                    asi.jiguan.Text = m.籍贯;
                }
                this.Frame.Content = asi;            
            }
            else if (control == "fromAch")
            {
               // Add_StudentInfo asi = new Add_StudentInfo();
                Add_StudentAchievement asa = new Add_StudentAchievement();
                DataClassesDataContext db = new DataClassesDataContext();
                var query = from n in db.学生成绩表
                            //where n.学号 == StudentInfo.arg
                            where n.学号 ==num
                            select n;
                foreach (var m in query)
                {
                    asa.xuehao.Text = m.学号;
                    asa.zhuanye.Text = m.专业;
                    asa.xingming.Text = m.姓名;               
                    asa.banji.Text = m.班级;
                    asa.fenshu1.Text = m.高等数学_上_;
                    asa.fenshu2.Text = m.高等数学_下_;
                    asa.fenshu3.Text = m.概率论;
                    asa.fenshu4.Text = m.线性代数;
                    asa.fenshu5.Text = m.c语言程序设计;
                    asa.fenshu6.Text = m.离散数学;
                }
                this.Frame.Content = asa;
            }
            else if (control == "fromFile")
            {
               // Add_StudentInfo asi = new Add_StudentInfo();
              //  Add_StudentAchievement asa = new Add_StudentAchievement();
                Add_StudentFile asf = new Add_StudentFile();

                DataClassesDataContext db = new DataClassesDataContext();
                var query = from n in db.学生档案表
                            //where n.学号 == StudentInfo.arg
                            where n.学号 ==num
                            select n;
                foreach(var m in query )
                {
                    asf.xuehao.Text = m.学号;
                    asf.zhuanye.Text = m.专业;
                    asf.minzu.Text=m.民族;
                    asf.xingming.Text=m.姓名;
                    asf.xingbie.Text=m.性别;
                    asf.jiating.Text=m.家庭住址;
                    asf.lianxi.Text=m.联系电话;
                    asf.jiangcheng.Text = m.奖罚情况;
                    asf.banji.Text = m.班级;
                    asf.jiguan.Text = m.籍贯;
                    asf.liuji.Text=m.留级情况;
                }
                this.Frame.Content = asf;
            }
        }
        //添加                                                    
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            //仅当教师用户登录可用
            //判断Frame中的Page页面
            var control = Selection.arg;
            if (control == "fromInfo")
            {
                Add_StudentInfo asi = new Add_StudentInfo();
                this.Frame.Content = asi;
            }
            else if (control == "fromAch")
            {
                Add_StudentAchievement asa = new Add_StudentAchievement();
                this.Frame.Content = asa;
            }
            else if (control == "fromFile")
            {
                Add_StudentFile asf = new Add_StudentFile();
                this.Frame.Content = asf;
            }
        }
        //删除
        public void Delete_Click(object sender, RoutedEventArgs e)
        {
            //仅当教师用户登录可用
            var control = Selection.arg;
            if (control == "fromInfo")
            {
                
                //Linq语句
                DataClassesDataContext db = new DataClassesDataContext();
                var query = from n in db.学生信息表
                            where n.学号==StudentInfo.arg
                            select n;
                db.学生信息表.DeleteAllOnSubmit(query);
                db.SubmitChanges();
                MessageBox.Show("已删除");
            }
            else if (control == "fromAchievement")
            {
               
                
                //Linq语句
                DataClassesDataContext db = new DataClassesDataContext();
                var query = from n in db.学生成绩表
                            where n.学号==StudentAchievement.arg
                            select n;
                db.学生成绩表.DeleteAllOnSubmit(query);
                db.SubmitChanges();
                MessageBox.Show("已删除");
            }
            else if (control == "fromFile")
            {
               
                //Linq语句
                DataClassesDataContext db = new DataClassesDataContext();
                var query = from n in db.学生档案表
                            where n.学号==StudentFile.arg
                            select n;
                db.学生档案表.DeleteAllOnSubmit(query);
                db.SubmitChanges();
                MessageBox.Show("已删除");
            }

        }
        //打印
        public void Print_Click(object sender, RoutedEventArgs e)
        {
            var control = Selection.arg;
            if (control == "fromInfo")
            {
                PrintDialog dialog = new PrintDialog();
                if (dialog.ShowDialog() == true)
                {
                    StudentInfo si=new StudentInfo ();
                    dialog.PrintVisual(si.canvas, "Print Test");
                }           
            }
            else if (control == "fromAch")
            {
                PrintDialog dialog = new PrintDialog();
                if (dialog.ShowDialog() == true)
                {
                    StudentAchievement sa = new StudentAchievement();
                    dialog.PrintVisual(sa.canvas, "Print Test");
                }    
            }
            else if (control == "fromFile")
            {
                PrintDialog dialog = new PrintDialog();
                if (dialog.ShowDialog() == true)
                {
                    StudentFile sf = new StudentFile();
                    dialog.PrintVisual(sf.canvas, "Print Test");
                }    
            }
            else
            {
                PrintDialog dialog = new PrintDialog();
                if (dialog.ShowDialog() == true)
                {
                    Select_Result sr = new Select_Result();
                    dialog.PrintVisual(sr.canvas, "Print Test");
                }
            }
 
        }
    }
}
