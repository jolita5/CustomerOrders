using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace CustomerOrders
{
    /// <summary>
    /// Interaction logic for UsersLoginData.xaml
    /// </summary>
    public partial class UsersLoginData : Window
    {

        TableFromSQLDataContext dc = new TableFromSQLDataContext(Properties.Settings.Default.LoginUserDBConnectionString);
            

        public UsersLoginData()
        {

            InitializeComponent();
           
          
            if (dc.DatabaseExists())
            {

                UsersList.ItemsSource = dc.Products;

            }
        }


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            dc.SubmitChanges();
        }



    }
}
