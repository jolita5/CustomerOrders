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


        private void MakeOrderButton_Click(object sender, RoutedEventArgs e)
        {
            MakeOrder orderTabel = new MakeOrder();
            orderTabel.Show();
            this.Close();
        }

        private void HistoryButton_Click(object sender, RoutedEventArgs e)
        {
            UserHistory history = new UserHistory();
            history.Show();
            this.Close();
        }

        private void Your_AccountButton_Click(object sender, RoutedEventArgs e)
        {
            UsersAccount account = new UsersAccount();
            account.Show();
            this.Close();
        }

    }
}
