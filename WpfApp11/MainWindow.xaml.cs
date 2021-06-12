using System;
using System.Collections.Generic;
using System.Data;
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

namespace WpfApp11
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataBase.FillDataGrid(MWDataGrid);
        }

        private void MWDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (MWDataGrid.SelectedItem == null) return;
            DataRowView row = (DataRowView)MWDataGrid.SelectedItem;
            int id = Convert.ToInt32(row.Row.ItemArray[0].ToString());
            int ComplexValueAdded = Convert.ToInt32(row.Row.ItemArray[1].ToString());
            string Status = row.Row.ItemArray[4].ToString();
            int BuildingCost = Convert.ToInt32(row.Row.ItemArray[2].ToString());
            string City = row.Row.ItemArray[6].ToString();
            string name = row.Row.ItemArray[3].ToString();
            Complex c = new Complex(id,ComplexValueAdded,Status,BuildingCost,City,name);
            

            Redakt redakt = new Redakt(c);
            redakt.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataBase.FillDataGrid(MWDataGrid);
        }

        private void MWDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MWDataGrid.SelectedItem == null) return;
            DataRowView row = (DataRowView)MWDataGrid.SelectedItem;
            int id = Convert.ToInt32(row.Row.ItemArray[0].ToString());
            DataBase.City(CityDataGrid, id);
        }
    }
}
