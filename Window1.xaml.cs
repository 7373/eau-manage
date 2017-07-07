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
    /// Window1.xaml 的交互逻辑
    /// </summary>

    public partial class Window1 : Window
    {

        public static SqlConnection conn = new SqlConnection("Server=127.0.01;Database=ranah_sms;uid=sa;pwd=123");//连接数据库
        public Window1()
        {
            InitializeComponent();
        }
        public Window1(string s)
        {
            InitializeComponent();
            conn.Open();
        }

        private void window1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            conn.Close();
            App.Current.Shutdown();
        }

        private void s1_Click(object sender, RoutedEventArgs e)
        {
            s1 s1 = new s1();
            s1.Owner = this;
            this.Visibility = System.Windows.Visibility.Hidden;
            s1.Show();
        }

        private void s2_Click(object sender, RoutedEventArgs e)
        {
            s2 s2 = new s2();
            s2.Owner = this;
            this.Visibility = System.Windows.Visibility.Hidden;
            s2.Show();
        }

        private void s3_Click(object sender, RoutedEventArgs e)
        {
            s3 s3 = new s3();
            s3.Owner = this;
            this.Visibility = System.Windows.Visibility.Hidden;
            s3.Show();
        }

        private void c1_Click(object sender, RoutedEventArgs e)
        {
            c1 c1 = new c1();
            c1.Owner = this;
            this.Visibility = System.Windows.Visibility.Hidden;
            c1.Show();
        }

        private void c2_Click(object sender, RoutedEventArgs e)
        {
            c2 c2 = new c2();
            c2.Owner = this;
            this.Visibility = System.Windows.Visibility.Hidden;
            c2.Show();
        }

        private void c3_Click(object sender, RoutedEventArgs e)
        {
            c3 c3 = new c3();
            c3.Owner = this;
            this.Visibility = System.Windows.Visibility.Hidden;
            c3.Show();
        }

        private void t1_Click(object sender, RoutedEventArgs e)
        {
            t1 t1 = new t1();
            t1.Owner = this;
            this.Visibility = System.Windows.Visibility.Hidden;
            t1.Show();
        }

        private void a1_Click(object sender, RoutedEventArgs e)
        {
            a1 a1 = new a1();
            a1.Owner = this;
            this.Visibility = System.Windows.Visibility.Hidden;
            a1.Show();
        }

        private void a2_Click(object sender, RoutedEventArgs e)
        {
            a2 a2 = new a2();
            a2.Owner = this;
            this.Visibility = System.Windows.Visibility.Hidden;
            a2.Show();
        }

        private void a3_Click(object sender, RoutedEventArgs e)
        {
            a3 a3 = new a3();
            a3.Owner = this;
            this.Visibility = System.Windows.Visibility.Hidden;
            a3.Show();
        }
    }
}
