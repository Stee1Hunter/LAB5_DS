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
    /// Логика взаимодействия для Engine.xaml
    /// </summary>
    public partial class Engine : Window
    {
        EngineTableAdapter engine = new EngineTableAdapter();
        FuleTableAdapter fule = new FuleTableAdapter();
        public Engine()
        {
            InitializeComponent();
            EngineDrg.ItemsSource = engine.GetData();
            Engin.ItemsSource = fule.GetData();
            Engin.DisplayMemberPath = "Fule";
        }

        private void EngineDrg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EngineDrg.SelectedItem != null)
            {
                Cyl.Text = (EngineDrg.SelectedItem as DataRowView).Row[1].ToString();
                HP.Text = (EngineDrg.SelectedItem as DataRowView).Row[2].ToString();
                DVS.Text = (EngineDrg.SelectedItem as DataRowView).Row[3].ToString();
                ECO.Text = (EngineDrg.SelectedItem as DataRowView).Row[4].ToString();
            }
            
        }

        private void dob_Click(object sender, RoutedEventArgs e)
        {
            
                engine.InsertQuery(Convert.ToInt32(Cyl.Text), Convert.ToInt32(HP.Text), DVS.Text, ECO.Text, (int)(Engin.SelectedItem as DataRowView).Row[0]);
                EngineDrg.ItemsSource = engine.GetData();
            
            
        }

        private void Obn_Click(object sender, RoutedEventArgs e)
        {
            if (EngineDrg.SelectedItem != null)
            {
                object ID_color = (EngineDrg.SelectedItem as DataRowView).Row[0];
                engine.UpdateQuery(Convert.ToInt32(Cyl.Text), Convert.ToInt32(HP.Text), DVS.Text, ECO.Text, (int)(Engin.SelectedItem as DataRowView).Row[0], Convert.ToInt32(ID_color));
                EngineDrg.ItemsSource = engine.GetData();
            }
            
        }

        private void UD_Click(object sender, RoutedEventArgs e)
        {
            if (EngineDrg.SelectedItem != null)
            {
                object ID_color = (EngineDrg.SelectedItem as DataRowView).Row[0];
                engine.DeleteQuery(Convert.ToInt32(ID_color));
                EngineDrg.ItemsSource = engine.GetData();
            }
            
        }

        private void end_Click(object sender, RoutedEventArgs e)
        {
            Window2 mn = new Window2();
            mn.Show();
            this.Close();
        }

        private void Engin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Engin.SelectedItem != null)
            {
                var ID_Role = (int)(Engin.SelectedItem as DataRowView).Row[0];
            }
        }
    }
}
