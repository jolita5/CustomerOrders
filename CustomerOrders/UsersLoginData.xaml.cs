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
            this.TennisCheckbox.IsChecked = this.BasketballCheckbox.IsChecked = this.VolleyballCheckbox.IsChecked = this.YogaCheckbox.IsChecked
                = this.Cost1Checkbox.IsChecked = this.Cost2Checkbox.IsChecked = this.Cost3Checkbox.IsChecked = this.Cost4Checkbox.IsChecked = this.Cost5Checkbox.IsChecked
                = this.Cost12Checkbox.IsChecked = this.Cost22Checkbox.IsChecked = this.Cost32Checkbox.IsChecked = this.Cost42Checkbox.IsChecked = this.Cost52Checkbox.IsChecked = false;

            this.Your_ChoiceText.Text = null;
        }



        private void Save_Click(object sender, RoutedEventArgs e)
        {
            EndWindow end = new EndWindow(); // todo: doesn't work

            if (this.Your_ChoiceText.Text != null)
            {
                end.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("The order is not full! Please, check your order.");
            }


        }

        private void CalendarText_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Calendar date = new Calendar();
            date.DisplayDateStart = DateTime.Now;
        }


    }
}
