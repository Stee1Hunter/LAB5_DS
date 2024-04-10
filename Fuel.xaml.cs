using LAB5_DS.LABA5DataSetTableAdapters;
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
using System.Windows.Shapes;

namespace LAB5_DS
{
    /// <summary>
    /// Логика взаимодействия для Fuel.xaml
    /// </summary>
    public partial class Fuel : Window
    {
        FuleTableAdapter fuel = new FuleTableAdapter();
        public Fuel()
        {
            InitializeComponent();
            FuelDrg.ItemsSource = fuel.GetData();
        }

        private void FuelDrg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FuelDrg.SelectedItem != null)
            {
                fuelTb.Text = (FuelDrg.SelectedItem as DataRowView).Row[1].ToString();
            }
            
        }

        private void end_Click(object sender, RoutedEventArgs e)
        {
            Window2 wn = new Window2(); 
            wn.Show();
            this.Close();
        }

        private void Dob_Click(object sender, RoutedEventArgs e)
        {
            
                fuel.InsertQuery(fuelTb.Text);
                FuelDrg.ItemsSource = fuel.GetData();
            
            
        }

        private void Obn_Click(object sender, RoutedEventArgs e)
        {
            if (FuelDrg.SelectedItem != null)
            {
                object ID_color = (FuelDrg.SelectedItem as DataRowView).Row[0];
                fuel.UpdateQuery(fuelTb.Text, Convert.ToInt32(ID_color));
                FuelDrg.ItemsSource = fuel.GetData();
            }
            
        }

        private void UD_Click(object sender, RoutedEventArgs e)
        {
            if (FuelDrg.SelectedItem != null)
            {
                object ID_color = (FuelDrg.SelectedItem as DataRowView).Row[0];
                fuel.DeleteQuery(Convert.ToInt32(ID_color));
                FuelDrg.ItemsSource = fuel.GetData();
            }
            
        }
    }
}
