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
    public partial class MakeOrder : Window
    {

       string _order;

        public MakeOrder()
        {
            InitializeComponent();

          

        }


        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Your order is: {this.Your_ChoiceText.Text}, time: {this.Calendar.SelectedDate}, payment: {this.PaymentText.Text}, note: {this.NoteText.Text}");


        }



        private void Checkbox_Checked(object sender, RoutedEventArgs e)
        {

            this.Your_ChoiceText.Text += " " + (string)((CheckBox)sender).Content;

            

        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            this.TennisCheckbox.IsChecked = this.BasketballCheckbox.IsChecked = this.VolleyballCheckbox.IsChecked = this.YogaCheckbox.IsChecked = this.FitnessCheckbox.IsChecked
                = this.Tennis2Checkbox.IsChecked = this.Basketball2Checkbox.IsChecked = this.Volleyball2Checkbox.IsChecked = this.Yoga2Checkbox.IsChecked = this.Fitness2Checkbox.IsChecked = false;

            this.Your_ChoiceText.Text = null;
        }



        private void Save_Click(object sender, RoutedEventArgs e)
        {
            EndWindow end = new EndWindow();

            SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=LoginUserDB; Integrated Security=True;");
           
           


            try
            {
                if (Your_ChoiceText.Text != "" && PaymentText.Text != "" && Calendar.SelectedDate != null)
                {
                    sqlCon.Open();

                    
                  // _order = ConcertToProductID(this.Your_ChoiceText.Text);

                    

                    string query = "INSERT INTO Orders (OrderDate) VALUES('" + this.Calendar.SelectedDate + "')";
                    SqlCommand createCommand = new SqlCommand(query, sqlCon);
                    createCommand.ExecuteNonQuery();
                    MessageBox.Show("Saved");
                    end.Show();
                    this.Close();
                    sqlCon.Close();
                }
                else
                {
                    MessageBox.Show("The order is not full! Please, check your order.");
                }



            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private string ConcertToProductID(string product)
        {


            switch (product)
            {
                case "Tennis_1h, 10,5 Eur": return "1";

                case "Basketball_1h, 12,4 Eur": return "2";

                case "Volleyball_1h, 15,5 Eur": return "3";

                case "Yoga_1h, 8,7Eur": return "4";

                case "Fitness_1h, 24,5 Eur": return "5";

                case "Tennis_2h, 20 Eur": return "2005";

                case "Basketball_2h, 24 Eur": return "2006";

                case "Volleyball_2h, 30 Eur": return "2007";

                case "Yoga_2h, 16 Eur": return "2008";

                case "Fitness_2h, 28 Eur": return "2009";

            }

            return null;
        }

    }
}
