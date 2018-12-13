using System;
using System.Collections.Generic;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=LoginUserDB; Integrated Security=True;");

            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                    String query = "SELECT COUNT(1) FROM tbUserList WHERE Username=@Username AND Password=@Password";
                    SqlCommand sqlComd = new SqlCommand(query, sqlCon);
                    sqlComd.CommandType = System.Data.CommandType.Text;
                    sqlComd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    sqlComd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    int count = Convert.ToInt32(sqlComd.ExecuteScalar());

                    if(count == 1)
                    {
                        if(txtPassword.Text.Length >= 6)
                        {
                            MainWindow dashboard = new MainWindow();
                            dashboard.Show();
                            this.Close();
                        }
                       else
                        {
                            MessageBox.Show("Password must consists of 6 or more digits!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username or/and password is incorrect");
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}
