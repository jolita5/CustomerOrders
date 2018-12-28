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
    /// Interaction logic for UsersAccount.xaml
    /// </summary>
    public partial class UsersAccount : Window
    {
        public UsersAccount()
        {
            InitializeComponent();

            SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=LoginUserDB; Integrated Security=True;");

            LoginWindow login = new LoginWindow();
            UsersAccount account = new UsersAccount();

            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {

                    sqlCon.Open();
                    String query = "SELECT COUNT(1) FROM LoginData WHERE Username=@UserName AND Password=@Password";
                    SqlCommand sqlComd = new SqlCommand(query, sqlCon);
                    sqlComd.CommandType = System.Data.CommandType.Text;
                    sqlComd.Parameters.AddWithValue("@UserName", login.txtUsername.Text);
                    sqlComd.Parameters.AddWithValue("@Password", login.txtPassword.Password);
                    sqlComd.ExecuteNonQuery();

                    SqlDataAdapter dataAdp = new SqlDataAdapter(sqlComd);



                    int count = Convert.ToInt32(sqlComd.ExecuteScalar());

                    if (count >= 1)
                    {
                        DataTable dt = new DataTable("Account");
                        dataAdp.Fill(dt);
                        account.UsersInfo.ItemsSource = dt.DefaultView;
                        dataAdp.Update(dt);
                        sqlCon.Close();
                        this.Close();
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
        }
    }
}
