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
    /// Логика взаимодействия для CarType.xaml
    /// </summary>
    public partial class CarType : Window
    {
        CarTypeTableAdapter cart = new CarTypeTableAdapter();
        public CarType()
        {
            InitializeComponent();
            CTDrg.ItemsSource = cart.GetData();
        }

        private void CTDrg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CTDrg.SelectedItem != null)
            {
                CTTb.Text = (CTDrg.SelectedItem as DataRowView).Row[1].ToString();
            }
        }

        private void Dob_Click(object sender, RoutedEventArgs e)
        {
            
                cart.InsertQuery(CTTb.Text);
                CTDrg.ItemsSource = cart.GetData();
            
            
        }

        private void Obn_Click(object sender, RoutedEventArgs e)
        {
            if (CTDrg.SelectedItem != null)
            {
                object ID_color = (CTDrg.SelectedItem as DataRowView).Row[0];
                cart.UpdateQuery(CTTb.Text, Convert.ToInt32(ID_color));
                CTDrg.ItemsSource = cart.GetData();
            }
            
        }
        private void UD_Click(object sender, RoutedEventArgs e)
        {
            if (CTDrg.SelectedItem != null)
            {
                object ID_color = (CTDrg.SelectedItem as DataRowView).Row[0];
                cart.DeleteQuery(Convert.ToInt32(ID_color));
                CTDrg.ItemsSource = cart.GetData();
            }
            
        }

        private void end_Click(object sender, RoutedEventArgs e)
        {
            Window2 mn = new Window2();
            mn.Show();
            this.Close();
        }
    }

        
    
}
