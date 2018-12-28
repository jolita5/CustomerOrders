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

        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=LoginUserDB; Integrated Security=True;");
            SqlCommand sqlComd;
            SqlDataAdapter da;
            DataTable dt;
            LoginWindow login = new LoginWindow();
            DataSet ds = new DataSet();

            try
            {


                sqlCon.Open();
                sqlComd = new SqlCommand("SELECT * FROM LoginData WHERE Username='" + txtUsername.Text + "'", sqlCon);
                da = new SqlDataAdapter(sqlComd);
                dt = new DataTable("Account");
                da.Fill(dt);
                UsersInfo.ItemsSource = dt.DefaultView;
                sqlCon.Close();


            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
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
    }
}
