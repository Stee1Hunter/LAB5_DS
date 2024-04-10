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
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class User : Page
    {
        UsersTableAdapter user = new UsersTableAdapter();
        LoginsTableAdapter login = new LoginsTableAdapter();
        public User()
        {
            InitializeComponent();
            UsersDrg.ItemsSource = user.GetData();
            LoginCbx.ItemsSource = login.GetData();
            LoginCbx.DisplayMemberPath = "Logins";
        }

        private void Dob_Click(object sender, RoutedEventArgs e)
        {
            
                user.InsertQuery(SurTbx.Text, NameTbx.Text, MiddleTbx.Text, (int)(LoginCbx.SelectedItem as DataRowView).Row[0]);
                UsersDrg.ItemsSource = user.GetData();
            
           
        }

        private void Obn_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDrg.SelectedItem != null)
            {
                object ID_user = (UsersDrg.SelectedItem as DataRowView).Row[0];
                user.UpdateQuery(SurTbx.Text, NameTbx.Text, MiddleTbx.Text, (int)(LoginCbx.SelectedItem as DataRowView).Row[0], Convert.ToInt32(ID_user));
                UsersDrg.ItemsSource = user.GetData();
            }
            
        }

        private void UD_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDrg.SelectedItem != null)
            {
                object ID_user = (UsersDrg.SelectedItem as DataRowView).Row[0];
                user.DeleteQuery(Convert.ToInt32(ID_user));
                UsersDrg.ItemsSource = user.GetData();
            }
            
        }
        private void UsersDrg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UsersDrg.SelectedItem != null)
            {
                SurTbx.Text = (UsersDrg.SelectedItem as DataRowView).Row[1].ToString();
                NameTbx.Text = (UsersDrg.SelectedItem as DataRowView).Row[2].ToString();
                MiddleTbx.Text = (UsersDrg.SelectedItem as DataRowView).Row[3].ToString();
            }
            
        }
    }
}
