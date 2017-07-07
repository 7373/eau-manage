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
    /// s1.xaml 的交互逻辑
    /// </summary>
    public partial class s1 : Window
    {
        public s1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "select rah_Rterm 学年,AVG(rah_Rmark) 平均成绩"
                    + " from ranah_Result"
                    + " where rah_Sno = '" + textBox.Text
                    + "' group by rah_Rterm";
                dataGrid.DataContext = null;
                SqlCommand cmd = new SqlCommand(sql, Window1.conn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ds.Clear();
                DataTable table1 = new DataTable();
                adp.Fill(ds, "table1");
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBoxResult res = MessageBox.Show("无结果");
                    return;
                }
                dataGrid.DataContext = ds;
            }
            catch(Exception ee)
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
