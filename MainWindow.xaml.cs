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

namespace ClientLourd_Agenda
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            FrameContent.Navigate(new System.Uri("addCustomer.xaml", UriKind.RelativeOrAbsolute));
        }

        private void ListCustomers_Click(object sender, RoutedEventArgs e)
        {
            FrameContent.Navigate(new System.Uri("customersList.xaml", UriKind.RelativeOrAbsolute));
            
        }
        //private void Menu_AddCustomer(object sender, RoutedEventArgs e)
        //{
        //    FrameContent.Content = new addCustomer();
        //}
    }
}
