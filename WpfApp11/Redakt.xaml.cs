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

namespace WpfApp11
{
    /// <summary>
    /// Логика взаимодействия для Redakt.xaml
    /// </summary>
    public partial class Redakt : Window
    {
        int id;
        public Redakt(Complex c)
        {
            InitializeComponent();
            id = c.ID;
            NameZHKTextBox.Text = c.Name;
            KfTextBox.Text = c.ComplexValueAdded.ToString();
            StatusTextBox.Text = c.Status.ToString();
            ZatrTextBox.Text = c.BuildingCost.ToString();
            CityTextBox.Text = c.City;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = NameZHKTextBox.Text;
            int kf = Convert.ToInt32(KfTextBox.Text);
            string status = StatusTextBox.Text;
            int zatr = Convert.ToInt32(ZatrTextBox.Text);
            string city = CityTextBox.Text;
            DataBase.RedaktComplex(id,name,kf,zatr,city,status);
        }
    }
}
