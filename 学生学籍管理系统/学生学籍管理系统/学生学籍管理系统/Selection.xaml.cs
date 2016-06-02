using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Selection.xaml 的交互逻辑
    /// </summary>
    public partial class Selection : Page
    {
        static public string arg;        //定义一个静态变量
        public Selection()
        {
            InitializeComponent();
        }
        public string Getstring(string args)  //获取参数
        {
            return arg = args;
        }
        
        private void selection_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(combox.SelectedValue.ToString()) && string.IsNullOrWhiteSpace(zhuanye.Text) && string.IsNullOrWhiteSpace(xuehao.Text) && string.IsNullOrWhiteSpace(xingming.Text))
            {
                MessageBox.Show("请至少输入一个条件！");
            }
            else
            {
                //查询代码，将查询结果保存到数据库表中，以供其他页面访问
                MainWindow mw = new MainWindow();
                DataClassesDataContext db = new DataClassesDataContext();      
                if (arg=="fromInfo")                                   //在学生信息表中查询
                {
                    //先清空表，再执行写入，以避免重复
                    var query1 = from n in db.查询结果存储表
                                 where n.序号 != 0
                                 select n;
                    foreach (var m1 in query1)
                    {
                        db.查询结果存储表.DeleteAllOnSubmit(query1);
                        db.SubmitChanges();
                    }
                    //查询
                    var query = from n in db.学生信息表
                                where n.学号== xuehao.Text
                                      || n.班级 == combox.SelectedValue
                                      || n.专业 == zhuanye.Text
                                      || n.姓名 == xingming.Text
                                select n;
                    foreach (var m in query)
                    {
                        //将查询结果写入存储表中
                        var newSelectResult = new 查询结果存储表
                        {
                            学号 = m.学号,
                            专业 = m.专业,
                            班级 = m.班级,
                            姓名 = m.姓名,
                            性别 = m.性别,
                            籍贯 = m.籍贯,
                            出生年月 = m.出生年月,
                            家庭地址 = m.家庭住址,
                            联系电话 = m.联系电话,
                            政治面貌 = m.政治面貌
                        };
                        db.查询结果存储表.InsertOnSubmit(newSelectResult);
                        db.SubmitChanges();
                    }
                }
                else if (arg=="fromAch")                                  //在学生成绩表中查询
                {
                    //先清空表，再执行写入，以避免重复
                    var query1 = from n in db.查询结果存储表
                                 where n.序号 != 0
                                 select n;
                    foreach (var m1 in query1)
                    {
                        db.查询结果存储表.DeleteAllOnSubmit(query1);
                        db.SubmitChanges();
                    }
                    //查询
                    var query = from n in db.学生成绩表
                                where n.学号 == xuehao.Text
                                     || n.班级 == combox.SelectedValue
                                     || n.专业 == zhuanye.Text
                                     || n.姓名 == xingming.Text
                                select n;
                    foreach (var m in query)
                    {
                        //将查询结果写入存储表中
                        var newSelectResult = new 查询结果存储表
                        {
                            学号 = m.学号,
                            专业 = m.专业,
                            班级 = m.班级,
                            姓名 = m.姓名,
                            高等数学_上_ = m.高等数学_上_,
                            高等数学_下_ = m.高等数学_下_,
                            概率论 = m.概率论,
                            线性代数 = m.线性代数,
                            C语言程序设计 = m.c语言程序设计,
                            离散数学 = m.离散数学
                        };
                        db.查询结果存储表.InsertOnSubmit(newSelectResult);
                        db.SubmitChanges();
                    }
                }
                else if (arg=="fromFile")                               //在学生档案表中查询
                {
                    //先清空表，再执行写入，以避免重复
                    var query1 = from n in db.查询结果存储表
                                 where n.序号 != 0
                                 select n;
                    foreach (var m1 in query1)
                    {
                        db.查询结果存储表.DeleteAllOnSubmit(query1);
                        db.SubmitChanges();
                    }
                    //查询
                    var query = from n in db.学生档案表
                                where n.学号 == xuehao.Text
                                      || n.班级 == combox.SelectedValue
                                      || n.专业 == zhuanye.Text
                                      || n.姓名 == xingming.Text
                                select n;
                    foreach (var m in query)
                    {
                        //将查询结果写入存储表中
                        var newSelectResult = new 查询结果存储表
                        {
                            学号 = m.学号,
                            专业 = m.专业,
                            班级 = m.班级,
                            姓名 = m.姓名,
                            性别 = m.性别,
                            籍贯 = m.籍贯,
                            民族 = m.民族,
                            家庭地址 = m.家庭住址,
                            联系电话 = m.联系电话,
                            奖罚情况 = m.奖罚情况,
                            留级情况=m.留级情况
                        };
                        db.查询结果存储表.InsertOnSubmit(newSelectResult);
                        db.SubmitChanges();
                    }
                }
            }
            //转到查询结果页面
            Select_Result sr = new Select_Result();  
            this.NavigationService.Navigate(sr);
        }
    }
}
