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
    /// Логика взаимодействия для Brand.xaml
    /// </summary>
    public partial class Brand : Window
    {
        brandTableAdapter brand = new brandTableAdapter();
        public Brand()
        {
            InitializeComponent();
            BrandDrg.ItemsSource = brand.GetData();
        }

        private void BrandDrg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BrandDrg.SelectedItem != null)
            {
                colorTb.Text = (BrandDrg.SelectedItem as DataRowView).Row[1].ToString();
                cTb.Text = (BrandDrg.SelectedItem as DataRowView).Row[2].ToString();
            }
        }

        private void Dob_Click(object sender, RoutedEventArgs e)
        {
            
                brand.InsertQuery(colorTb.Text, cTb.Text);
                BrandDrg.ItemsSource = brand.GetData();
            
        }

        private void Obn_Click(object sender, RoutedEventArgs e)
        {
            if (BrandDrg.SelectedItem != null)
            {
                object ID_color = (BrandDrg.SelectedItem as DataRowView).Row[0];
                brand.UpdateQuery(colorTb.Text, cTb.Text, Convert.ToInt32(ID_color));
                BrandDrg.ItemsSource = brand.GetData();
            }
            
        }

        private void UD_Click(object sender, RoutedEventArgs e)
        {
            if (BrandDrg.SelectedItem != null)
            {
                object ID_color = (BrandDrg.SelectedItem as DataRowView).Row[0];
                brand.DeleteQuery(Convert.ToInt32(ID_color));
                BrandDrg.ItemsSource = brand.GetData();
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
