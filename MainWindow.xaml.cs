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

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            
            string username = this.username.Text;
            string password = this.password.Password;
            if (username == "admin" && password == "123")
            {
                Window1 dlg = new Window1("1");
                dlg.Owner = this;
                this.Visibility = System.Windows.Visibility.Hidden;
                dlg.ShowDialog();
            }
            else
            {
                MessageBoxResult res = MessageBox.Show("用户名或者密码出错，请重试");
            }
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
