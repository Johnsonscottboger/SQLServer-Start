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
    /// Register.xaml 的交互逻辑
    /// </summary>
    public partial class Register : Window
    {
        string s;
        public Register()
        {
            InitializeComponent();
        }

        private void yes_Click(object sender, RoutedEventArgs e)
        {
            if (String.Compare(password.Password, password1.Password) != 0)
            {
                MessageBox.Show("输入的密码不匹配！");
            }
            else
            {
                //执行linq添加
                if (check.IsChecked.Value)
                {
                    s = "y";  //如果CheckBox被选中，给s赋值为“y”
                }
                DataClassesDataContext db = new DataClassesDataContext();
                var newUser = new 用户管理表
                {
                    学号 = xuehao.Text,
                    用户名 = usernumber.Text,
                    密码 = password.Password,
                    是否为教师账户=s
                };
                db.用户管理表.InsertOnSubmit(newUser);
                db.SubmitChanges();
            }
        }
    }
}
