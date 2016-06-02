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
    /// Add_StudentFile.xaml 的交互逻辑
    /// </summary>
    public partial class Add_StudentFile : Page
    {
        public Add_StudentFile()
        {
            InitializeComponent();
        }

        private void Add_SF_btn_Click(object sender, RoutedEventArgs e)
        {
            //执行linq添加
            DataClassesDataContext db = new DataClassesDataContext();
            var newStudentFile = new 学生档案表
            {
                学号 = xuehao.Text,
                专业 = zhuanye.Text,
                班级 = banji.Text,
                姓名 = xingming.Text,
                性别 = xingbie.Text,
                籍贯 = jiguan.Text,
                民族 = minzu.Text,
                家庭住址 = jiating.Text,
                联系电话 = lianxi.Text,
                奖罚情况 = jiangcheng.Text,
                留级情况=liuji.Text
            };
            bool bReturn = db.学生档案表.Any(p => p.学号 == xuehao.Text);
            if (!bReturn)
            {
                // MessageBox.Show("学号不存在");
                //添加

                db.学生档案表.InsertOnSubmit(newStudentFile);
                db.SubmitChanges();
            }
            else
            {
                //如果学号存在，修改操作
                学生档案表 ch = db.学生档案表.Where(a => a.学号 == xuehao.Text).First();
                ch.学号 = xuehao.Text;
                ch.专业 = zhuanye.Text;
                ch.班级 = banji.Text;
                ch.姓名 = xingming.Text;
                ch.性别 = xingbie.Text;
                ch.籍贯 = jiguan.Text;
                ch.留级情况 = liuji.Text;
                ch.家庭住址 = jiating.Text;
                ch.联系电话 = lianxi.Text;
                ch.奖罚情况 = jiangcheng.Text;
                db.SubmitChanges();
            }
            MessageBox.Show("已添加");    
        }
    }
}
