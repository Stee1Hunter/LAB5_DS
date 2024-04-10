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
    /// Логика взаимодействия для Orders.xaml
    /// </summary>
    public partial class Orders : Window
    {
        OrdersTableAdapter order = new OrdersTableAdapter();
        UsersTableAdapter users = new UsersTableAdapter();
        CarsTableAdapter car = new CarsTableAdapter();
        public Orders()
        {
            InitializeComponent();
            OrdersDrg.ItemsSource = order.GetData();
            UsersCbx.ItemsSource = users.GetData();
            UsersCbx.DisplayMemberPath = "SureName";
            CarCbx.ItemsSource = car.GetData();
            CarCbx.DisplayMemberPath = "Namess";

        }

        private void OrdersDrg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(OrdersDrg.SelectedItem != null)
            {
                OrderTb.Text = (OrdersDrg.SelectedItem as DataRowView).Row[3].ToString();
                CarCbx.SelectedItem=car.GetData().ToList().Any(item => item.ID_Car== (int)(OrdersDrg.SelectedItem as DataRowView).Row[2]);
            }
            
        }

        private void CarCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CarCbx.SelectedItem != null)
            {
                var ID_car = (int)(CarCbx.SelectedItem as DataRowView).Row[0];
            }
        }

        private void UsersCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UsersCbx.SelectedItem != null)
            {
                var ID_user = (int)(UsersCbx.SelectedItem as DataRowView).Row[0];
            }
        }

        private void dob_Click(object sender, RoutedEventArgs e)
        {
            order.InsertQuery((int)(UsersCbx.SelectedItem as DataRowView).Row[0], (int)(CarCbx.SelectedItem as DataRowView).Row[0], Convert.ToDecimal(OrderTb.Text));
            OrdersDrg.ItemsSource = order.GetData();
        }

        private void Obn_Click(object sender, RoutedEventArgs e)
        {
            if (UsersCbx.SelectedItem != null)
            {
                object ID_user = (OrdersDrg.SelectedItem as DataRowView).Row[0];
                order.UpdateQuery((int)(UsersCbx.SelectedItem as DataRowView).Row[0], (int)(CarCbx.SelectedItem as DataRowView).Row[0], Convert.ToDecimal(OrderTb.Text), Convert.ToInt32(ID_user));
                OrdersDrg.ItemsSource = order.GetData();
            }
        }

        private void UD_Click(object sender, RoutedEventArgs e)
        {
            if(UsersCbx.SelectedItem != null)
            {
                object ID_user = (OrdersDrg.SelectedItem as DataRowView).Row[0];
                order.DeleteQuery(Convert.ToInt32(ID_user));
                OrdersDrg.ItemsSource = order.GetData();
            }
            
        }

        private void end_Click(object sender, RoutedEventArgs e)
        {
            Window3 mn = new Window3();
            mn.Show();
            this.Close();
        }
    }
}
