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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LAB5_DS
{
    /// <summary>
    /// Логика взаимодействия для Logins.xaml
    /// </summary>
    public partial class Logins : Page
    {
        LoginsTableAdapter login = new LoginsTableAdapter();
        RolesTableAdapter role = new RolesTableAdapter();
        public Logins()
        {
            InitializeComponent();
            LodinsDrg.ItemsSource = login.GetData();
            RoleCbx.ItemsSource = role.GetData();
            RoleCbx.DisplayMemberPath = "Roles";
        }

        private void Dob_Click(object sender, RoutedEventArgs e)
        {
            
                login.InsertQuery(LoginTB.Text, passwdTB.Text, (int)(RoleCbx.SelectedItem as DataRowView).Row[0]);
                LodinsDrg.ItemsSource = login.GetData();
            
            

        }

        private void Obn_Click(object sender, RoutedEventArgs e)
        {
            if (LodinsDrg.SelectedItem != null)
            {
                object ID_Logins = (LodinsDrg.SelectedItem as DataRowView).Row[0];
                login.UpdateQuery(LoginTB.Text, passwdTB.Text, (int)(RoleCbx.SelectedItem as DataRowView).Row[0], Convert.ToInt32(ID_Logins));
                LodinsDrg.ItemsSource = login.GetData();
            }
            
        }

        private void UD_Click(object sender, RoutedEventArgs e)
        {
            if (LodinsDrg.SelectedItem != null)
            {
                object ID_Logins = (LodinsDrg.SelectedItem as DataRowView).Row[0];
                login.DeleteQuery(Convert.ToInt32(ID_Logins));
                LodinsDrg.ItemsSource = login.GetData();
            }
           
        }

        private void RoleCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RoleCbx.SelectedItem != null)
            {
                var ID_Role = (int)(RoleCbx.SelectedItem as DataRowView).Row[0];
            }
        }

        private void LodinsDrg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LodinsDrg.SelectedItem != null)
            {
                LoginTB.Text = (LodinsDrg.SelectedItem as DataRowView).Row[1].ToString();
                passwdTB.Text = (LodinsDrg.SelectedItem as DataRowView).Row[2].ToString();
            }
            
            
        }
    }
}
