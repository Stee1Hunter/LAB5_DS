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

namespace LAB5_DS
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        

        private void Vihod_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            AddUsers au = new AddUsers();
            au.Show();
        }

        private void ColorDrg_Click(object sender, RoutedEventArgs e)
        {
            Color color = new Color();
            color.Show();
            this.Close();
        }

        private void FuelDrg_Click(object sender, RoutedEventArgs e)
        {
            Fuel fuel = new Fuel();
            fuel.Show();
            this.Close();
        }

        private void ColoringDrg_Click(object sender, RoutedEventArgs e)
        {
            Coloring coloring = new Coloring();
            coloring.Show();
            this.Close();
        }

        private void CTDrg_Click(object sender, RoutedEventArgs e)
        {
            CarType car = new CarType();
            car.Show(); 
            this.Close();
        }

        private void BrandDrg_Click(object sender, RoutedEventArgs e)
        {
            Brand brand = new Brand();
            brand.Show();
            this.Close();
        }

        private void Eng_Click(object sender, RoutedEventArgs e)
        {
            Engine engine = new Engine();
            engine.Show();
            this.Close();
        }

        private void car_Click(object sender, RoutedEventArgs e)
        {
            CarP carP = new CarP();
            carP.Show();
            this.Close();
        }
    }
}
