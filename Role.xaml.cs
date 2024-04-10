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
    /// Логика взаимодействия для Role.xaml
    /// </summary>
    public partial class Role : Page
    {
        RolesTableAdapter role = new RolesTableAdapter();
        public Role()
        {
            InitializeComponent();
            RolesDrg.ItemsSource = role.GetData();
        }

        private void Dob_Click(object sender, RoutedEventArgs e)
        {
            
                role.InsertQuery(RoleTb.Text);
                RolesDrg.ItemsSource = role.GetData();
            
            
        }

        private void Obn_Click(object sender, RoutedEventArgs e)
        {
            if (RolesDrg.SelectedItem != null)
            {
                object ID_Role = (RolesDrg.SelectedItem as DataRowView).Row[0];
                role.UpdateQuery(RoleTb.Text, Convert.ToInt32(ID_Role));
                RolesDrg.ItemsSource = role.GetData();
            }
            
        }

        private void UD_Click(object sender, RoutedEventArgs e)
        {
            if (RolesDrg.SelectedItem != null)
            {
                object ID_Role = (RolesDrg.SelectedItem as DataRowView).Row[0];
                role.DeleteQuery(Convert.ToInt32(ID_Role));
                RolesDrg.ItemsSource = role.GetData();
            }
            

        }

        private void RolesDrg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RolesDrg.SelectedItem != null)
            {
                RoleTb.Text = (RolesDrg.SelectedItem as DataRowView).Row[1].ToString();
            }
            
        }
    }
}
