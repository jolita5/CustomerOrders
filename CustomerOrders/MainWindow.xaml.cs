using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomerOrders
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       

        public MainWindow()
        {
            InitializeComponent();

        }


        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"You note is: {this.Your_notesText.Text}");

        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            this.TennisCheckbox.IsChecked = this.BasketballCheckbox.IsChecked = this.VolleyballCheckbox.IsChecked = this.YogaCheckbox.IsChecked = this.FitnessCheckbox.IsChecked = false;
        }

        private void Checkbox_Checked(object sender, RoutedEventArgs e)
        {
            this.Your_ChoiceText.Text += " " + (string)((CheckBox)sender).Content;
        }

        private void PaymentDropdown_SelectionChange(object sender, SelectionChangedEventArgs e)
        {
            if (this.NoteText == null)
                return;

            var combo = (ComboBox)sender;
            var value = (ComboBoxItem)combo.SelectedValue;
            this.NoteText.Text = (string)value.Content;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PaymentDropdown_SelectionChange(this.PaymentDropdown, null);

        }

      
    }
}
