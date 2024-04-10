using LAB5_DS.LABA5DataSetTableAdapters;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LAB5_DS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LoginsTableAdapter adapter = new LoginsTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
                var allLogins = adapter.GetData().Rows;
                for (int i = 0; i < allLogins.Count; i++)
                {
                    if (allLogins[i][1].ToString() == LoginTbx.Text && allLogins[i][2].ToString() == PasswdTbx.Password)
                    {
                        int Role_ID = (int)allLogins[i][3];
                        if (Role_ID == 1)
                        {
                            Window1 pokup = new Window1();
                            pokup.Show();
                            this.Close();
                            break;
                        }
                        if (Role_ID == 2)
                        {
                            Window2 adm = new Window2();
                            adm.Show();
                            this.Close();
                            break;
                        }
                        if (Role_ID == 3)
                        {
                            Window3 kass = new Window3();
                            kass.Show();
                            this.Close();
                            break;
                        }

                    }
                }
            

            
        }
    }
}
