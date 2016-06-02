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
    /// Add_StudentAchievement.xaml 的交互逻辑
    /// </summary>
    public partial class Add_StudentAchievement : Page
    {
        public Add_StudentAchievement()
        {
            InitializeComponent();
        }

        private void Add_SA_btn_Click(object sender, RoutedEventArgs e)
        {
           
            
                //执行linq添加
                DataClassesDataContext db = new DataClassesDataContext();
                var newStudentArch = new 学生成绩表
                {
                    学号 = xuehao.Text,
                    专业 = zhuanye.Text,
                    班级 = banji.Text,
                    姓名 = xingming.Text,
                    高等数学_上_ = kemu1.Text,
                    高等数学_下_ = kemu2.Text,
                    概率论 = kemu3.Text,
                    线性代数 = kemu4.Text,
                    c语言程序设计 = kemu5.Text,
                    离散数学 = kemu6.Text
                };
                bool bReturn = db.学生成绩表.Any(p => p.学号 == xuehao.Text);
                if (!bReturn)
                {
                    // MessageBox.Show("学号不存在");
                    //添加

                    db.学生成绩表.InsertOnSubmit(newStudentArch);
                    db.SubmitChanges();
                }
                else
                {
                    //如果学号存在，修改操作
                    学生成绩表 ch = db.学生成绩表.Where(a => a.学号 == xuehao.Text).First();
                    ch.学号 = xuehao.Text;
                    ch.专业 = zhuanye.Text;
                    ch.班级 = banji.Text;
                    ch.姓名 = xingming.Text;
                    ch.c语言程序设计 = fenshu5.Text;
                    ch.高等数学_上_ = fenshu1.Text;
                    ch.高等数学_下_ = fenshu2.Text;
                    ch.概率论 = fenshu3.Text;
                    ch.离散数学 = fenshu6.Text;
                    ch.线性代数 = fenshu4.Text;
                    db.SubmitChanges();
                }
                MessageBox.Show("已添加");      
        }
    }
}
