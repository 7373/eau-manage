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
    /// c2.xaml 的交互逻辑
    /// </summary>
    public partial class c2 : Window
    {
        public c2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "select rah_Cname 课程名, AVG(rah_Rmark) 平均成绩"
                    + " from ranah_Result,ranah_Courses"
                    + " where ranah_Result.rah_Couno = ranah_Courses.rah_Couno"
                    + " group by ranah_Result.rah_Couno,rah_Cname";
                dataGrid.DataContext = null;
                SqlCommand cmd = new SqlCommand(sql, Window1.conn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ds.Clear();
                DataTable table1 = new DataTable();
                adp.Fill(ds, "table1");
                dataGrid.DataContext = ds;
            }
            catch (Exception ee)
            {
                MessageBoxResult res = MessageBox.Show(ee.Message);
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1();
            this.Close();
            win1.ShowDialog();
        }
    }
}
