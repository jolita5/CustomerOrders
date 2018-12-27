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



        public UsersLoginData()
        {
            InitializeComponent();

            SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=LoginUserDB; Integrated Security=True;");

            LoginWindow login = new LoginWindow();
            try
            {

               // sqlCon.Open();
                //String query = "SELECT o.OrderDate, p.ProductName, p.Price_1h, p.Price_2h, l.* FROM Orders o inner join Products p on o.ProductID=p.Id inner join LoginData l on o.CustomerID=l.Id WHERE Username=@UserName AND Password=@Password";
                //SqlCommand sqlComd = new SqlCommand(query, sqlCon);
                //sqlComd.CommandType = System.Data.CommandType.Text;
                //sqlComd.Parameters.AddWithValue("@UserName", login.txtUsername.Text);
                //sqlComd.Parameters.AddWithValue("@Password", login.txtPassword.Password);
                //sqlComd.ExecuteNonQuery();

                //SqlDataAdapter dataAdp = new SqlDataAdapter(sqlComd);
                
                //DataTable dt = new DataTable("Info");
                //dataAdp.Fill(dt);
                //UsersList.ItemsSource = dt.DefaultView;
                //dataAdp.Update(dt);



                SqlCommand com = sqlCon.CreateCommand();
                com.CommandText = "SELECT o.OrderDate, p.ProductName, p.Price_1h, p.Price_2h, l.* FROM Orders o inner join Products p on o.ProductID=p.Id inner join LoginData l on o.CustomerID=l.Id WHERE Username=@UserName AND Password=@Password";
                com.CommandType = CommandType.Text;
                com.Parameters.AddWithValue("@UserName", login.txtUsername.Text);
                com.Parameters.AddWithValue("@Password", login.txtPassword.Password);
                SqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                UsersList.ItemsSource = dt.DefaultView;
                dr.Close();
              //  sqlCon.Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }



        private void MakeOrderButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow orderTabel = new MainWindow();
            orderTabel.Show();
            this.Close();
        }
    }
}
