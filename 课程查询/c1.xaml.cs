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
    /// c1.xaml 的交互逻辑
    /// </summary>
    public partial class c1 : Window
    {
        public c1()
        {
            InitializeComponent();
        }

        public void Rterm_select()
        {
            string sql1 = "select distinct rah_Rterm"
                + " from ranah_Result"
                + " where rah_Couno='"+ textBox.Text +"'";
            SqlCommand cmd = new SqlCommand(sql1, Window1.conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cmd.Dispose();
            Rterm.DisplayMemberPath = "rah_Rterm";
            Rterm.ItemsSource = dt.DefaultView;
            Rterm.SelectedIndex = 0;
        }
        public void data_change(string s)
        {
            string sql = "select rah_Sno 学号,rah_Rmark 成绩"
                + " from ranah_Result"
                + " where rah_Couno = '" + textBox.Text + "'"
                + " and rah_Rterm='" + s + "'"
                + " order by rah_Rmark desc";
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Rterm.Text = null;
                Rterm_select();

                string sql = "select rah_Sno 学号,rah_Couno 课程号,rah_Rmark 成绩"
                    + " from ranah_Result"
                    + " where rah_Couno = '" + textBox.Text + "'"
                    + " and rah_Rterm='" + Rterm.Text.Trim() + "'"
                    + " order by rah_Rmark desc";
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
            catch(Exception ee)
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

        private void Rterm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object obj = (object)e.AddedItems;
            if (((object[])(obj)).Count()>0)
            {
                string str = Convert.ToString(((System.Data.DataRowView)(((object[])(obj))[0])).Row.ItemArray[0]);
                data_change(str);
            }
        }
    }
}
