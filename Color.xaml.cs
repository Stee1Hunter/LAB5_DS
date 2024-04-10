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
    /// Логика взаимодействия для Color.xaml
    /// </summary>
    public partial class Color : Window
    {
        colorTableAdapter color = new colorTableAdapter();
        public Color()
        {
            InitializeComponent();
            colorDrg.ItemsSource=color.GetData();
        }
        private void Dob_Click(object sender, RoutedEventArgs e)
        {
            
                color.InsertQuery(colorTb.Text);
                colorDrg.ItemsSource = color.GetData();
            
            
        }

        private void Obn_Click(object sender, RoutedEventArgs e)
        {
            if (colorDrg.SelectedItem != null)
            {
                object ID_color = (colorDrg.SelectedItem as DataRowView).Row[0];
                color.UpdateQuery(colorTb.Text, Convert.ToInt32(ID_color));
                colorDrg.ItemsSource = color.GetData();
            }
            
        }

        private void UD_Click(object sender, RoutedEventArgs e)
        {
            if (colorDrg.SelectedItem != null)
            {
                object ID_color = (colorDrg.SelectedItem as DataRowView).Row[0];
                color.DeleteQuery(Convert.ToInt32(ID_color));
                colorDrg.ItemsSource = color.GetData();
            }
            
        }

        private void end_Click(object sender, RoutedEventArgs e)
        {
            Window2 mn = new Window2();
            mn.Show();
            this.Close();
        }

        private void colorDrg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (colorDrg.SelectedItem != null)
            {
                colorTb.Text = (colorDrg.SelectedItem as DataRowView).Row[1].ToString();
            }
            
        }
    }
}
