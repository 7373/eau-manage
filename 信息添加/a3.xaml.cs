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
    /// a3.xaml 的交互逻辑
    /// </summary>
    public partial class a3 : Window
    {
        public a3()
        {
            InitializeComponent();
            Dname_select();
            Cno_select();

        }
        public void Sno_select()
        {
            string sql1 = "select rah_Sno"
                + " from ranah_Students"
                + " where rah_Cno='" + Cno.Text.Trim() + "'"
                + " and rah_Dno=("
                + " select rah_Dno"
                + " from ranah_Department"
                + " where rah_Dname='" +Dname.Text.Trim()+"')";
            SqlCommand cmd = new SqlCommand(sql1, Window1.conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cmd.Dispose();
            Sno.DisplayMemberPath = "rah_Sno";
            Sno.ItemsSource = dt.DefaultView;
            Sno.SelectedIndex = 0;
        }
        public void Sno_select(String s)
        {
            string sql1 = "select rah_Sno"
                + " from ranah_Students"
                + " where rah_Cno='" + s + "'"
                + " and rah_Dno=("
                + " select rah_Dno"
                + " from ranah_Department"
                + " where rah_Dname='" + Dname.Text.Trim() + "')";
            SqlCommand cmd = new SqlCommand(sql1, Window1.conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cmd.Dispose();
            Sno.DisplayMemberPath = "rah_Sno";
            Sno.ItemsSource = dt.DefaultView;
            Sno.SelectedIndex = 0;
        }

        public void Cname_select()
        {
            string sql1 = "select distinct rah_Cname"
                + " from ranah_Result,ranah_Courses"
                + " where ranah_Result.rah_Couno = ranah_Courses.rah_Couno"
                + " and rah_Sno='"+ Sno.Text.Trim() +"'";
            SqlCommand cmd = new SqlCommand(sql1, Window1.conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cmd.Dispose();
            Cname.DisplayMemberPath = "rah_Cname";
            Cname.ItemsSource = dt.DefaultView;
            Cname.SelectedIndex = 0;
        }
        public void Cname_select(string s)
        {
            string sql1 = "select distinct rah_Cname"
                + " from ranah_Result,ranah_Courses"
                + " where ranah_Result.rah_Couno = ranah_Courses.rah_Couno"
                + " and rah_Sno='" + s + "'";
            SqlCommand cmd = new SqlCommand(sql1, Window1.conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cmd.Dispose();
            Cname.DisplayMemberPath = "rah_Cname";
            Cname.ItemsSource = dt.DefaultView;
            Cname.SelectedIndex = 0;
        }

        public void Dname_select()
        {
            string sql1 = "select rah_Dname"
                + " from ranah_Department";
            SqlCommand cmd = new SqlCommand(sql1, Window1.conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cmd.Dispose();
            Dname.DisplayMemberPath = "rah_Dname";
            Dname.ItemsSource = dt.DefaultView;
            Dname.SelectedIndex = 0;
        }

        public void Cno_select()
        {
            string sql1 = "select rah_Cno"
                + " from ranah_Class"
                + " where rah_Dno = ("
                + " select rah_Dno"
                + " from ranah_Department"
                + " where rah_Dname = '" + Dname.Text.Trim() + "')";
            SqlCommand cmd = new SqlCommand(sql1, Window1.conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cmd.Dispose();
            Cno.DisplayMemberPath = "rah_Cno";
            Cno.ItemsSource = dt.DefaultView;
            Cno.SelectedIndex = 0;
        }
        public void Cno_select(string s)
        {
            string sql1 = "select rah_Cno"
                + " from ranah_Class"
                + " where rah_Dno = ("
                + " select rah_Dno"
                + " from ranah_Department"
                + " where rah_Dname = '" + s.Trim() + "')";
            SqlCommand cmd = new SqlCommand(sql1, Window1.conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cmd.Dispose();
            Cno.DisplayMemberPath = "rah_Cno";
            Cno.ItemsSource = dt.DefaultView;
            Cno.SelectedIndex = 0;
        }

        public void Ssredit_show()
        {
            if (Sno.Text.Trim() != "")
            {
                string sql1 = "select rah_Scredit"
                    + " from ranah_Students"
                    + " where rah_Sno = '" + Sno.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(sql1, Window1.conn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                cmd.Dispose();
                Ssredit.Text = dt.Rows[0].ItemArray[0].ToString();
            }
        }
        public void Ssredit_show(string s)
        {
            string sql1 = "select rah_Scredit"
                + " from ranah_Students"
                + " where rah_Sno = '" + s + "'";
            SqlCommand cmd = new SqlCommand(sql1, Window1.conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cmd.Dispose();
            Ssredit.Text = dt.Rows[0].ItemArray[0].ToString();
        }
        public string Couno_text()
        {
            string sql1 = " select rah_Couno"
                   + " from ranah_Courses"
                   + " where rah_Cname = '" + Cname.Text.Trim() + "'";
            SqlCommand cmd = new SqlCommand(sql1, Window1.conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cmd.Dispose();
            return (string)dt.Rows[0].ItemArray[0];
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string sql = "update ranah_Result"
                + " set rah_Rmark=" + Rmark.Text
                + " where rah_Sno='" + Sno.Text+"'"
                + " and rah_Couno='" + Couno_text() + "'";
            SqlCommand cmd = new SqlCommand(sql, Window1.conn);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBoxResult res = MessageBox.Show("修改成功");
            }
            catch (Exception ee)
            {
                MessageBoxResult res = MessageBox.Show("修改失败" + ee.Message);
            }
            Ssredit.Clear();
        }
        public void clear()
        {
            Sno.ItemsSource = null;
            Cname.ItemsSource = null;
            Ssredit.Clear();
            Rmark.Text = null;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1();
            this.Close();
            win1.ShowDialog();
        }

        private void Dname_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object obj = (object)e.AddedItems;
            string str = Convert.ToString(((System.Data.DataRowView)(((object[])(obj))[0])).Row.ItemArray[0]);
            Cno_select(str);
        }

        private void Cno_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object obj = (object)e.AddedItems;
            if (((object[])(obj)).Count() > 0)
            {
                string str = Convert.ToString(((System.Data.DataRowView)(((object[])(obj))[0])).Row.ItemArray[0]);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            clear();

            Sno_select();
            Cname_select();
            Ssredit_show();
        }

        private void Sno_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object obj = (object)e.AddedItems;
            if (((object[])(obj)).Count() > 0)
            {
                string str = Convert.ToString(((System.Data.DataRowView)(((object[])(obj))[0])).Row.ItemArray[0]);
                Cname_select(str);
                Ssredit_show(str);
            }
        }
    }
}
