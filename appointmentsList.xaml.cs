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
using System.Text.RegularExpressions;

namespace ClientLourd_Agenda
{
    /// <summary>
    /// Logique d'interaction pour appointmentsList.xaml
    /// </summary>
    public partial class appointmentsList : Page
    {
        private agenda_DB db = new agenda_DB();
        appointements appointment;

        public appointmentsList()
        {
            InitializeComponent();
            appointment = new appointements();
        }

        private void ListRdvDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            listRdvDataGrid.ItemsSource = db.appointements.ToList();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            EditRdv.Visibility = Visibility.Hidden;
        }

        private void ListRdvDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listRdvDataGrid.SelectedItem == null) return;
            appointment = listRdvDataGrid.SelectedItem as appointements;

            rdvCustomers.SelectedValue = appointment.idCustomer;
            rdvBrokers.SelectedValue = appointment.idBroker;
            rdvDate.Text = appointment.dateHour.ToShortDateString();
            string dateTime = appointment.dateHour.ToShortTimeString();
            string hour = dateTime.Substring(0, dateTime.Length - 3);
            rdvHours.Text = hour;
            string min = dateTime.Substring(3);
            rdvMinutes.Text = min;
            //rdvMinutes = dateTime.TrimStart();
            // essayer avec methode string.Trim([]), trimEnd ou trimStart ou split

            //BrokerFirstName.Text = broker.firstname;
            //BrokerMail.Text = broker.mail;
            //BrokerPhone.Text = broker.phoneNumber;
            EditRdv.Visibility = Visibility.Visible;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //broker.lastname = BrokerLastName.Text;
            //broker.firstname = BrokerFirstName.Text;
            //broker.mail = BrokerMail.Text;
            //broker.phoneNumber = BrokerPhone.Text;
            //db.Entry(appointment).State = EntityState.Modified;
            //db.SaveChanges();
            MessageBox.Show("Rendez-vous modifié avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            listRdvDataGrid.Items.Refresh();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Etes-vous sûr de supprimer ce rdv ?", "Suppression", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.OK:
                    DeleteRdv();
                    break;
                case MessageBoxResult.Cancel:
                    // retour à modification
                    break;
            }
        }

        private void DeleteRdv()
        {
            db.appointements.Remove(appointment);
            db.SaveChanges();
            MessageBox.Show("Rendez-vous supprimé avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            EditRdv.Visibility = Visibility.Hidden;
            listRdvDataGrid.ItemsSource = null;
            listRdvDataGrid.ItemsSource = db.appointements.ToList();
        }

        private void RdvCustomers_Loaded(object sender, RoutedEventArgs e)
        {
            rdvCustomers.ItemsSource = db.customers.ToList();
        }

        private void RdvBrokers_Loaded(object sender, RoutedEventArgs e)
        {
            rdvBrokers.ItemsSource = db.brokers.ToList();
        }
        // Main.NavigationService.Navigate(new MainWindow());
    }
}
