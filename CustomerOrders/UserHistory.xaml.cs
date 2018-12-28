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
    /// Interaction logic for UserHistory.xaml
    /// </summary>
    public partial class UserHistory : Window
    {
        public UserHistory()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';

        }

        private void MeniuButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow meniu = new MainWindow();
            meniu.Show();
            this.Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=LoginUserDB; Integrated Security=True;");



            try
            {

                sqlCon.Open();
                String query = "SELECT o.OrderDate, p.ProductName, p.Price, l.Surname, l.Aftername FROM Orders o inner join Products p on o.ProductID=p.Id inner join LoginData l on o.CustomerID=l.Id WHERE Username=@UserName AND Password = @Password";
                SqlCommand sqlComd = new SqlCommand(query, sqlCon);
                sqlComd.CommandType = System.Data.CommandType.Text;
                sqlComd.Parameters.AddWithValue("@UserName", txtUsername.Text);
                sqlComd.Parameters.AddWithValue("@Password", txtPassword.Password);
                sqlComd.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(sqlComd);

                DataTable dt = new DataTable("Your_Orders");
                dataAdp.Fill(dt);
                UsersHistory.ItemsSource = dt.DefaultView;
                dataAdp.Update(dt);
                sqlCon.Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
