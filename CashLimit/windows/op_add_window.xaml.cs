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

namespace CashLimit
{
    /// <summary>
    /// Логика взаимодействия для op_add.xaml
    /// </summary>
    public partial class op_add_window : Window
    {
        cashlimit_class cashlimit;
        public op_add_window(cashlimit_class cashlimit)
        {
            InitializeComponent();
            this.cashlimit = cashlimit;
        }

        private void close(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void cancel_btn(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void add_to_database_btn(object sender, RoutedEventArgs e)
        {
            cashlimit.PrimeOperations.addRecord(new operations {date = DateTime.Now.ToString(), description = description_box.Text, type = 0, value = Convert.ToInt32(value_box.Text) });
            Close();
        }
    }
}
