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
    /// Логика взаимодействия для Coloring.xaml
    /// </summary>
    public partial class Coloring : Window
    {
        coloringTableAdapter coloring = new coloringTableAdapter();
        public Coloring()
        {
            InitializeComponent();
            coloringDrg.ItemsSource = coloring.GetData();
        }

        private void coloringDrg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (coloringDrg.SelectedItem != null)
            {
                colorTb.Text = (coloringDrg.SelectedItem as DataRowView).Row[1].ToString();
            }
            
        }

        private void Dob_Click(object sender, RoutedEventArgs e)
        {
            
                coloring.InsertQuery(colorTb.Text);
                coloringDrg.ItemsSource = coloring.GetData();
            
            
        }

        private void Obn_Click(object sender, RoutedEventArgs e)
        {
            if (coloringDrg.SelectedItem != null)
            {
                object ID_color = (coloringDrg.SelectedItem as DataRowView).Row[0];
                coloring.UpdateQuery(colorTb.Text, Convert.ToInt32(ID_color));
                coloringDrg.ItemsSource = coloring.GetData();
            }
            
        }

        private void UD_Click(object sender, RoutedEventArgs e)
        {
            if (coloringDrg.SelectedItem != null)
            {
                object ID_color = (coloringDrg.SelectedItem as DataRowView).Row[0];
                coloring.DeleteQuery(Convert.ToInt32(ID_color));
                coloringDrg.ItemsSource = coloring.GetData();
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
