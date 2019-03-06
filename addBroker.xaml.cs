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
using System.Text.RegularExpressions;

namespace ClientLourd_Agenda
{
    /// <summary>
    /// Logique d'interaction pour addBroker.xaml
    /// </summary>
    public partial class addBroker : Page
    {
        private agenda_DB db = new agenda_DB();

        public addBroker()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            brokers brokerToAdd = new brokers();

            brokerToAdd.lastname = BrokerLastName.Text;
            brokerToAdd.firstname = BrokerFirstName.Text;
            brokerToAdd.mail = BrokerMail.Text;
            brokerToAdd.phoneNumber = BrokerPhone.Text;

            db.brokers.Add(brokerToAdd);
            db.SaveChanges();
            MessageBox.Show("Courtier ajouté avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.Navigate(new System.Uri("brokersList.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new System.Uri("brokersList.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
