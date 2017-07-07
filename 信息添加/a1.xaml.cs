using System;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;

namespace WpfApplication1
{
    /// <summary>
    /// a1.xaml 的交互逻辑
    /// </summary>
    public partial class a1 : Window
    {
        public a1()
        {
            InitializeComponent();
            Dno_select();
            Province_select();
            Cno_select();
            City_select();     
        }
        public void Dno_select()
        {
            string sql1 = "select rah_Dname"
                + " from ranah_Department";
            SqlCommand cmd = new SqlCommand(sql1, Window1.conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cmd.Dispose();
            Dno.DisplayMemberPath = "rah_Dname";
            Dno.ItemsSource = dt.DefaultView;
            Dno.SelectedIndex = 0;
        }
        public void Cno_select()
        {
            string sql1 = "select rah_Cno"
                + " from ranah_Class"
                + " where rah_Dno = ("
                + " select rah_Dno"
                + " from ranah_Department"
                + " where rah_Dname = '"+ Dno.Text.Trim() +"')";
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
        public void Province_select()
        {
            string sql1 = "select distinct rah_Province"
                            + " from ranah_Area";
            SqlCommand cmd = new SqlCommand(sql1, Window1.conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cmd.Dispose();
            Province.DisplayMemberPath = "rah_Province";
            Province.ItemsSource = dt.DefaultView;
            Province.SelectedIndex = 0;
        }
        public void City_select()
        {
            string sql1 = "select rah_City"
                            + " from ranah_Area"
                            + " where rah_Province='" + Province.Text.Trim() + "'";
            SqlCommand cmd = new SqlCommand(sql1, Window1.conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cmd.Dispose();
            City.DisplayMemberPath = "rah_City";
            City.ItemsSource = dt.DefaultView;
            City.SelectedIndex = 0;
        }
        public void City_select(string s)
        {
            string sql1 = "select rah_City"
                            + " from ranah_Area"
                            + " where rah_Province='" + s.Trim() + "'";
            SqlCommand cmd = new SqlCommand(sql1, Window1.conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cmd.Dispose();
            City.DisplayMemberPath = "rah_City";
            City.ItemsSource = dt.DefaultView;
            City.SelectedIndex = 0;
        }
        public string Dno_text()
        {
            string sql1 = " select rah_Dno"
                   + " from ranah_Department"
                   + " where rah_Dname = '" + Dno.Text.Trim() + "'";
            SqlCommand cmd = new SqlCommand(sql1, Window1.conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cmd.Dispose();
            return (string)dt.Rows[0].ItemArray[0];
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string sql = "insert into ranah_Students values('"
                + Sno.Text + "','" + Sname.Text + "','" + Ssex.Text + "',"
                + Sage.Text + "," + Scredit.Text + ",'" + Dno_text() + "','"
                + Cno.Text.Trim() + "','" + Province.Text.Trim() + "','"
                + City.Text.Trim() + "')";
            SqlCommand cmd = new SqlCommand(sql, Window1.conn);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBoxResult res = MessageBox.Show("插入成功");
            }
            catch(Exception ee)
            {
                MessageBoxResult res = MessageBox.Show("插入失败"+ee.Message);
            }
            clear();
        }
        public void clear()
        {
            Sno.Text = null;
            Sname.Text = null;
            Sage.Text = null;
            Scredit.Text = null;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1();
            this.Close();
            win1.ShowDialog();
        }

        private void Dno_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            object obj = (object)e.AddedItems;
            string str = Convert.ToString(((System.Data.DataRowView)(((object[])(obj))[0])).Row.ItemArray[0]);
            Cno_select(str);
        }

        private void Province_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object obj = (object)e.AddedItems;
            string str = Convert.ToString(((System.Data.DataRowView)(((object[])(obj))[0])).Row.ItemArray[0]);
            City_select(str);
        }
    }
}
