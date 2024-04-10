using LAB5_DS.LABA5DataSetTableAdapters;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
    /// Логика взаимодействия для Check.xaml
    /// </summary>
    public partial class Check : Window
    {
        ChecksTableAdapter check = new ChecksTableAdapter();
        UsersTableAdapter users = new UsersTableAdapter();
        OrdersTableAdapter order = new OrdersTableAdapter();
        public Check()
        {
            InitializeComponent();
            CheckDrg.ItemsSource=check.GetData();
            UsersCbx.ItemsSource = users.GetData();
            UsersCbx.DisplayMemberPath = "SureName";
            OrderCbx.ItemsSource = order.GetData();
            OrderCbx.DisplayMemberPath = "priceWNDS";
        }

        private void CheckDrg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CheckDrg.SelectedItem != null)
            {
                dataTb.Text = (CheckDrg.SelectedItem as DataRowView).Row[1].ToString();
                priceTb.Text = (CheckDrg.SelectedItem as DataRowView).Row[2].ToString();
            }
        }
        private void dob_Click(object sender, RoutedEventArgs e)
        {
            
                check.InsertQuery(dataTb.Text, Convert.ToDecimal(priceTb.Text),(int)(OrderCbx.SelectedItem as DataRowView).Row[0], (int)(UsersCbx.SelectedItem as DataRowView).Row[0]);
                CheckDrg.ItemsSource = check.GetData();
            
        }

        private void Obn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckDrg.SelectedItem != null)
            {
                object ID_user = (CheckDrg.SelectedItem as DataRowView).Row[0];
                check.UpdateQuery(dataTb.Text, Convert.ToDecimal(priceTb.Text), (int)(OrderCbx.SelectedItem as DataRowView).Row[0], (int)(UsersCbx.SelectedItem as DataRowView).Row[0], Convert.ToInt32(ID_user));
                CheckDrg.ItemsSource = check.GetData();
            }
        }

        private void UD_Click(object sender, RoutedEventArgs e)
        {
            if (CheckDrg.SelectedItem != null)
            {
                object ID_user = (CheckDrg.SelectedItem as DataRowView).Row[0];
                check.DeleteQuery(Convert.ToInt32(ID_user));
                CheckDrg.ItemsSource = check.GetData();
            }
        }

        private void end_Click(object sender, RoutedEventArgs e)
        {
            Window3 mn = new Window3();
            mn.Show();
            this.Close();
        }

        private void UsersCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UsersCbx.SelectedItem != null)
            {
                var ID_car = (int)(UsersCbx.SelectedItem as DataRowView).Row[0];
            }
        }

        private void OrderCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrderCbx.SelectedItem != null)
            {
                var ID_car = (int)(OrderCbx.SelectedItem as DataRowView).Row[0];
            }
        }

        private void b_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
