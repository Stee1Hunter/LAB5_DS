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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LAB5_DS
{
    /// <summary>
    /// Логика взаимодействия для CarP.xaml
    /// </summary>
    public partial class CarP : Window
    {
        CarsTableAdapter car = new CarsTableAdapter();
        CarTypeTableAdapter carType = new CarTypeTableAdapter();
        brandTableAdapter Brand = new brandTableAdapter();
        EngineTableAdapter Engine = new EngineTableAdapter();
        colorTableAdapter Color = new colorTableAdapter();
        coloringTableAdapter Coloring = new coloringTableAdapter();
        public CarP()
        {
            InitializeComponent();
            CarPDrg.ItemsSource = car.GetData();
            cartype.ItemsSource = carType.GetData();
            cartype.DisplayMemberPath = "CarType";
            brand.ItemsSource = Brand.GetData();
            brand.DisplayMemberPath = "Brand";
            engine.ItemsSource = Engine.GetData();
            engine.DisplayMemberPath = "HP";
            color.ItemsSource = Color.GetData();
            color.DisplayMemberPath = "color";
            coloring.ItemsSource = Coloring.GetData();
            coloring.DisplayMemberPath = "ColoringType";
        }

        private void end_Click(object sender, RoutedEventArgs e)
        {
            Window2 main = new Window2();
            main.Show();
            this.Close();
        }

        private void dob_Click(object sender, RoutedEventArgs e)
        {
            
                car.InsertQuery(weight.Text, Namess.Text, Convert.ToDecimal(price.Text), (int)(cartype.SelectedItem as DataRowView).Row[0], (int)(brand.SelectedItem as DataRowView).Row[0], (int)(engine.SelectedItem as DataRowView).Row[0], (int)(color.SelectedItem as DataRowView).Row[0], (int)(coloring.SelectedItem as DataRowView).Row[0]);
                CarPDrg.ItemsSource = car.GetData();
            
        }

        private void Obn_Click(object sender, RoutedEventArgs e)
        {
            if (CarPDrg.SelectedItem != null)
            {
                object ID_color = (CarPDrg.SelectedItem as DataRowView).Row[0];
                car.UpdateQuery(weight.Text, Namess.Text, Convert.ToDecimal(price.Text), (int)(cartype.SelectedItem as DataRowView).Row[0],(int)(brand.SelectedItem as DataRowView).Row[0], (int)(engine.SelectedItem as DataRowView).Row[0],(int)(color.SelectedItem as DataRowView).Row[0],(int)(coloring.SelectedItem as DataRowView).Row[0], Convert.ToInt32(ID_color));
                CarPDrg.ItemsSource = car.GetData();
            }
        }

        private void UD_Click(object sender, RoutedEventArgs e)
        {
            if (CarPDrg.SelectedItem != null)
            {
                object ID_color = (CarPDrg.SelectedItem as DataRowView).Row[0];
                car.DeleteQuery(Convert.ToInt32(ID_color));
                CarPDrg.ItemsSource = car.GetData();
            }
        }

        private void cartype_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CarPDrg.SelectedItem != null)
            {
                var ID_Role = (int)(cartype.SelectedItem as DataRowView).Row[0];
            }
        }

        private void brand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CarPDrg.SelectedItem != null)
            {
                var ID_Role = (int)(brand.SelectedItem as DataRowView).Row[0];
            }
        }

        private void engine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CarPDrg.SelectedItem != null)
            {
                var ID_Role = (int)(engine.SelectedItem as DataRowView).Row[0];
            }
        }

        private void color_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CarPDrg.SelectedItem != null)
            {
                var ID_Role = (int)(color.SelectedItem as DataRowView).Row[0];
            }
        }

        private void coloring_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CarPDrg.SelectedItem != null)
            {
                var ID_Role = (int)(coloring.SelectedItem as DataRowView).Row[0];
            }
        }

        private void CarPDrg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CarPDrg.SelectedItem != null)
            {
                weight.Text = (CarPDrg.SelectedItem as DataRowView).Row[1].ToString();
                Namess.Text = (CarPDrg.SelectedItem as DataRowView).Row[2].ToString();
                price.Text = (CarPDrg.SelectedItem as DataRowView).Row[3].ToString();
            }
        }
    }
}
