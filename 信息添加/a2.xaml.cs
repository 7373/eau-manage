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
    /// a2.xaml 的交互逻辑
    /// </summary>
    public partial class a2 : Window
    {
        public a2()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string sql = "insert into ranah_Teachers values('"
                + Tno.Text + "','" + Tname.Text + "','" + Tsex.Text + "',"
                + Tage.Text + "," + Ttitle.Text + "','" + Tphone + "')";
            SqlCommand cmd = new SqlCommand(sql, Window1.conn);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBoxResult res = MessageBox.Show("插入成功");
            }
            catch (Exception ee)
            {
                MessageBoxResult res = MessageBox.Show("插入失败" + ee.Message);
            }
            clear();
        }
        public void clear()
        {
            Tno.Text = null;
            Tname.Text = null;
            Tage.Text = null;
            Ttitle.Text = null;
            Tphone.Text = null;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1();
            this.Close();
            win1.ShowDialog();
        }
    }
}
