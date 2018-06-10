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
using System.Data.Entity;



namespace CashLimit
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        cashlimit_class cashlimit;
       
        public MainWindow()
        {
            InitializeComponent();
            cashlimit = cashlimit_class.Create();
            DataContext = new mainWindowViewModel_class();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private async void load_all_records(object sender, RoutedEventArgs e)
        {
            wrappanel.Children.Clear();
            List<operations> list = new List<operations>();
            list = await cashlimit.PrimeOperations.getAllRecords();

            for (int i = 0; i < list.Count; i++)
            {
                Grid grid = new Grid();
                grid.Height = 100;
                grid.Width = this.Width - 20;
                grid.Margin = new Thickness(1);
                grid.DataContext = list[i];
                ContextMenu menu = new ContextMenu();
                MenuItem deleteItem = new MenuItem { Header = "Удалить запись" };
                menu.Items.Add(deleteItem);
                deleteItem.DataContext = list[i];
                deleteItem.Click += DeleteItem_Click;
                grid.ContextMenu = menu;
                Border border = new Border();
                border.BorderBrush = Brushes.Black;
                border.BorderThickness = new Thickness(1);
                TextBlock id = new TextBlock { Text = "#" + (i + 1).ToString() };
                id.FontSize = 25;
                id.Margin = new Thickness(10, 5, 5, 5);
                TextBlock type = new TextBlock { Text = (list[i].type == 0) ? "Доход" : "Расход", Foreground = (list[i].type == 0) ? Brushes.MediumSeaGreen : Brushes.Plum };
                type.FontSize = 18;
                type.Margin = new Thickness(100, 20, 5, 5);
                type.Text += " ("+ DateTime.Parse("2018/1/1").ToShortDateString() + ")";
                TextBlock value = new TextBlock { Text = list[i].value.ToString() };
                value.Margin = new Thickness(100, 50, 5, 5);
                type.FontSize = 15;
                TextBox description_text = new TextBox { Text = list[i].description };
                description_text.BorderThickness = new Thickness(0);
                description_text.IsReadOnly = true;
                description_text.TextWrapping = TextWrapping.Wrap;
                description_text.Margin = new Thickness(350, 5, 5, 5);
                description_text.FontSize = 15;
                grid.Children.Add(border);
                grid.Children.Add(id);
                grid.Children.Add(type);
                grid.Children.Add(value);
                grid.Children.Add(description_text);
                wrappanel.Children.Add(grid);
            }
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            operations op = (operations)item.DataContext;
            cashlimit.PrimeOperations.RemoveRecord(op);
            load_all_records(null, null);
        }

        private void op_add(object sender, RoutedEventArgs e)
        {
            op_add_window op_add = new op_add_window(cashlimit);
            op_add.Owner = this;
            op_add.ShowDialog();
        }

        private void close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void op_min(object sender, RoutedEventArgs e)
        {
            op_min_window op_min = new op_min_window(cashlimit);
            op_min.Owner = this;
            op_min.ShowDialog();
        }
    }
}
