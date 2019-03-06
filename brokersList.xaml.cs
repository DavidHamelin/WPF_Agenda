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
using System.Data.Entity;

namespace ClientLourd_Agenda
{
    /// <summary>
    /// Logique d'interaction pour brokersList.xaml
    /// </summary>
    public partial class brokersList : Page
    {
        private agenda_DB db = new agenda_DB();
        brokers broker;

        public brokersList()
        {
            InitializeComponent();
            broker = new brokers();
        }

        private void ListBrokersDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            listBrokersDataGrid.ItemsSource = db.brokers.ToList();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            EditBroker.Visibility = Visibility.Hidden;
        }

        private void ListBrokersDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listBrokersDataGrid.SelectedItem == null) return;
            broker = listBrokersDataGrid.SelectedItem as brokers;

            BrokerLastName.Text = broker.lastname;
            BrokerFirstName.Text = broker.firstname;
            BrokerMail.Text = broker.mail;
            BrokerPhone.Text = broker.phoneNumber;
            EditBroker.Visibility = Visibility.Visible;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            broker.lastname = BrokerLastName.Text;
            broker.firstname = BrokerFirstName.Text;
            broker.mail = BrokerMail.Text;
            broker.phoneNumber = BrokerPhone.Text;
            db.Entry(broker).State = EntityState.Modified;
            db.SaveChanges();
            MessageBox.Show("Client modifié avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            listBrokersDataGrid.Items.Refresh();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Etes-vous sûr de supprimer ce courtier ?", "Suppression", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.OK:
                    DeleteBroker();
                    break;
                case MessageBoxResult.Cancel:
                    // retour à modification
                    break;
            }
        }
        private void DeleteBroker()
        {
            db.brokers.Remove(broker);
            db.SaveChanges();
            MessageBox.Show("Client supprimé avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            EditBroker.Visibility = Visibility.Hidden;
            listBrokersDataGrid.ItemsSource = null;
            listBrokersDataGrid.ItemsSource = db.brokers.ToList();
        }
        // Main.NavigationService.Navigate(new MainWindow());
    }
}
