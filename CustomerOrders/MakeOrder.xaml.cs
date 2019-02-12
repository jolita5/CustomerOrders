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
        private int _productId;
        private int _customerId;

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



                    _productId = ConcertToProductID(this.Your_ChoiceText.Text);
                    _customerId = Int32.Parse(this.UserIDText.Text);

                    string query = "INSERT INTO Orders (CustomerID, OrderDate, ProductID) VALUES('" + _customerId + "', '" + this.Calendar.SelectedDate + "', '" + _productId + "')";
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

        private int ConcertToProductID(string product)
        {


            if (TennisCheckbox.IsChecked == true)
            {
                return 1;
            }
            else if (Tennis2Checkbox.IsChecked == true)
            {
                return 2005;
            }
            else if (BasketballCheckbox.IsChecked == true)
            {
                return 2;
            }
            else if (Basketball2Checkbox.IsChecked == true)
            {
                return 2006;
            }
            else if (VolleyballCheckbox.IsChecked == true)
            {
                return 3;
            }
            else if (Volleyball2Checkbox.IsChecked == true)
            {
                return 2007;
            }
            else if (YogaCheckbox.IsChecked == true)
            {
                return 4;
            }
            else if (Yoga2Checkbox.IsChecked == true)
            {
                return 2008;
            }
            else if (FitnessCheckbox.IsChecked == true)
            {
                return 5;
            }
            else if (Fitness2Checkbox.IsChecked == true)
            {
                return 2009;
            }


            return 0;
        }

    }
}
