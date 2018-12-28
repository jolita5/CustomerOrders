﻿using System;
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


    }
}
