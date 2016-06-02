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
    /// WelcomePage.xaml 的交互逻辑
    /// </summary>
    public partial class WelcomePage : Page
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private void UserLogin_Click(object sender, RoutedEventArgs e)
        {
            Login lg = new Login();
            lg.Title = "登录";
            lg.ShowDialog();
        }
    }
}
