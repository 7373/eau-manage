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
using System.Data;
using System.Data.SqlClient;

namespace WpfApplication1
{
    /// <summary>
    /// t1.xaml 的交互逻辑
    /// </summary>
    public partial class t1 : Window
    {
        public t1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "select rah_Tname 教师名,rah_Cname 课程名"
                    + " from ranah_Teachers,ranah_Courses,ranah_Courses_Teacher"
                    + " where ranah_Teachers.rah_Tno = ranah_Courses_Teacher.rah_Tno"
                    + " and ranah_Courses.rah_Couno=ranah_Courses_Teacher.rah_Couno"
                    + " and ranah_Teachers.rah_Tno = '" + textBox.Text + "'";
                dataGrid.DataContext = null;
                SqlCommand cmd = new SqlCommand(sql, Window1.conn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ds.Clear();
                DataTable table1 = new DataTable();
                adp.Fill(ds, "table1");
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBoxResult res = MessageBox.Show("查无结果");
                    return;
                }
                dataGrid.DataContext = ds;
            }
            catch (Exception ee)
            {
                MessageBoxResult res = MessageBox.Show(ee.Message);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1();
            this.Close();
            win1.ShowDialog();
        }
    }
}
