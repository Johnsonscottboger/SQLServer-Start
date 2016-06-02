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
using System.Windows.Shapes;

namespace 学生学籍管理系统
{
    /// <summary>
    /// ModifyPassword.xaml 的交互逻辑
    /// </summary>
    public partial class ModifyPassword : Window
    {
        public ModifyPassword()
        {
            InitializeComponent();
        }

        private void yes_Click(object sender, RoutedEventArgs e)
        {
            DataClassesDataContext db = new DataClassesDataContext();
            var query = from n in db.用户管理表
                        where n.用户名 == db.临时用户管理表.AsEnumerable().Last().用户名
                        select n;

            foreach (var m in query)
            {
                if (String.Compare(m.密码, password.Password) != 0)
                {
                    MessageBox.Show("用户名或密码错误！");
                }
                else if (String.Compare(newpassword.Password, newpassword1.Password) != 0)
                {
                    MessageBox.Show("输入的密码不匹配！");
                }
                else      //执行修改语句
                {
                    // DataClassesDataContext db = new DataClassesDataContext();
                    var q = from n in db.用户管理表
                            where n.用户名 == db.临时用户管理表.AsEnumerable().Last().用户名
                            select n;
                    foreach (var mn in query)
                    {
                        m.密码 = newpassword.Password;    //修改密码
                        MessageBox.Show("密码修改成功！");
                    }
                }
            }
        }
    }
}
