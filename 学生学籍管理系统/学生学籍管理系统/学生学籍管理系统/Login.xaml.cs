using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace 学生学籍管理系统
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        public int i = 0;  //声明一个变量
        public Login()
        {
            InitializeComponent();
        }
        public int f()   //定义一个使i增值的方法，在login_Click事件中使用
        {
            i = i + 1;
            return i;
        }
        //注册事件
        private void register_Click(object sender, RoutedEventArgs e)
        {
            Register rg = new Register();
            this.Close();
            rg.ShowDialog();
            
        }
        //修改事件
        private void modify_password_Click(object sender, RoutedEventArgs e)
        {
            ModifyPassword mp = new ModifyPassword();
            this.Close();
            mp.ShowDialog();
            
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {    
            if (string.IsNullOrWhiteSpace(user.Text))
            {
                MessageBox.Show("用户名不能为空！");
            }
            DataClassesDataContext db = new DataClassesDataContext();
            var query = from n in db.用户管理表
                        where n.用户名 == user.Text
                        select n;
            
            foreach (var m in query)
            {
                f();   //如果foreach内部执行，调用f()方法一次;
                if (String.Compare(m.密码,password.Password)!=0)
                {
                    MessageBox.Show("用户名或密码错误！");
                }
                else
                {
                    //先清空“临时用户”表中已经保存的数据，已避免插入重复
                    var query1 = from n in db.临时用户管理表
                                 where n.序号 != 0
                                 select n;
                    foreach (var m1 in query1)
                    {
                        db.临时用户管理表.DeleteAllOnSubmit(query1);
                        db.SubmitChanges();
                    }
                    //将登录成功的用户名保存到临时用户表中
                    var newUsername=new 临时用户管理表
                    {
                        学号=m.学号,
                        用户名=user.Text,
                        密码=password.Password
                    };
                    db.临时用户管理表.InsertOnSubmit(newUsername);
                    db.SubmitChanges();
                    //关闭登录窗口
                    this.Close(); 
                }
            }        
            //如果foreach在数据库中查找不到结果，会直接退出foreach
            //如果foreach内部代码执行，则说明查找的用户名存在，并且顶用了f()方法
            if (i == 0)
            {
                MessageBox.Show("用户名不存在！");
            }
        }
    }
}
