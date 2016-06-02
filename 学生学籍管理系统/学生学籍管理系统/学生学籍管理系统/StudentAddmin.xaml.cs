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
    /// StudentAddmin.xaml 的交互逻辑
    /// </summary>
    public partial class StudentAddmin : Page
    {
        public StudentAddmin()
        {
            InitializeComponent();

            DataClassesDataContext db = new DataClassesDataContext();
            //查询“临时用户表”中登录的用户名
            string lastuser = db.临时用户管理表.AsEnumerable().Last().用户名;
            //MessageBox.Show(lastuser);
            user.Text = lastuser;
        }
        //重置
        private void resetting_Click(object sender, RoutedEventArgs e)
        {
            DataClassesDataContext db = new DataClassesDataContext();
            var query = from n in db.用户管理表
                        where n.用户名 == user.Text
                        select n;
            foreach (var m in query)
            {
                m.密码 = "000000";    //重置密码为“000000”
                MessageBox.Show("密码重置成功！");
            }
        }
        //修改
        private void modify_password_Click(object sender, RoutedEventArgs e)
        {
            ModifyPassword mp = new ModifyPassword();
            mp.ShowDialog();     //调用修改密码窗口
        }
    }
}
