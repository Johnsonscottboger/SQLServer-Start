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
    /// Select_Result.xaml 的交互逻辑
    /// </summary>
    public partial class Select_Result : Page
    {
        
        public Select_Result()
        {
            InitializeComponent();
            //从查询结果表中查询数据，以显示在页面中
            DataClassesDataContext db=new DataClassesDataContext ();
            var query = from n in db.查询结果存储表
                        select n;
           listBox.ItemsSource = query.ToList();
            

        }
        
        private void xuehaopailie_Checked(object sender, RoutedEventArgs e)
        {
            DataClassesDataContext db = new DataClassesDataContext();
            var query = from n in db.查询结果存储表
                        orderby n.学号
                        select n;
            listBox.ItemsSource = query.ToList();
        }

        private void banjipailie_Checked(object sender, RoutedEventArgs e)
        {
            DataClassesDataContext db = new DataClassesDataContext();
            var query = from n in db.查询结果存储表
                        orderby n.班级
                        select n;
            listBox.ItemsSource = query.ToList();
        }
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //获取数据模板中元素的值
            Table tl = listBox.SelectedItem as Table;
            ListBox ls = sender as ListBox;
            ListBoxItem lstitem = ls.ItemContainerGenerator.ContainerFromItem(ls.SelectedItem) as ListBoxItem;
            
            var m=((学生学籍管理系统.查询结果存储表)(lstitem.Content)).学号;
            MainWindow.num = m;
            if (Selection.arg == "fromInfo")
            {
                StudentInfo si = new StudentInfo();   //第一次初始化，StudentInfo中的Getstring()方法并未被赋值
                si.Getstring(m);                      //所以需要第二次初始化，以得到正确结果
                StudentInfo si1 = new StudentInfo();
                this.NavigationService.Navigate(si1);
            }
            else if(Selection.arg=="fromAch")
            {
                StudentAchievement sa = new StudentAchievement();
                sa.Getstring(m);
                StudentAchievement sa1 = new StudentAchievement();
                this.NavigationService.Navigate(sa1);
            }
            else if(Selection.arg=="fromFile")
            {
                StudentFile sf = new StudentFile();
                sf.Getstring(m);
                StudentFile sf1 = new StudentFile();
                this.NavigationService.Navigate(sf1);
            }
        }

    }
}
