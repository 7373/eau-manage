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
    /// c3.xaml 的交互逻辑
    /// </summary>
    public partial class c3 : Window
    {
        public c3()
        {
            InitializeComponent();
            Select();
        }
        public void Select()
        {
            string sql1 = "select rah_Dname"
                + " from ranah_Department";
            SqlCommand cmd = new SqlCommand(sql1, Window1.conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cmd.Dispose();
            comboBox.DisplayMemberPath = "rah_Dname";
            comboBox.ItemsSource = dt.DefaultView;
            comboBox.SelectedIndex = 0;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string s = comboBox.Text;
                s = s.Trim();
                string sql = "select distinct rah_Cname 课程名"
                    + " from ranah_Class, ranah_Class_Course, ranah_Courses"
                    + " where ranah_Class.rah_Cno = ranah_Class_Course.rah_Cno"
                    + " and ranah_Class_Course.rah_Couno = ranah_Courses.rah_Couno"
                    + " and ranah_Class_Course.rah_Cno = '" + textBox.Text + "'"
                    + " and ranah_Class_Course.rah_Dno = ("
                    + " select rah_Dno"
                    + " from ranah_Department"
                    + " where rah_Dname='" + s + "')";
                dataGrid.DataContext = null;
                SqlCommand cmd = new SqlCommand(sql, Window1.conn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ds.Clear();
                DataTable table1 = new DataTable();
                adp.Fill(ds, "table1");
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBoxResult res = MessageBox.Show("查询无结果");
                    return;
                }
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
