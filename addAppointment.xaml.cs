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
using ClientLourd_Agenda;

namespace ClientLourd_Agenda
{
    /// <summary>
    /// Logique d'interaction pour addAppointment.xaml
    /// </summary>
    public partial class addAppointment : Page
    {
        private agenda_DB db = new agenda_DB();

        public addAppointment()
        {
            InitializeComponent();
        }

        // Afficher Choix Clients dans Combobox
        private void RdvCustomers_Loaded(object sender, RoutedEventArgs e)
        {
            rdvCustomers.ItemsSource = db.customers.ToList();
        }
        // Afficher Choix Courtiers dans Combobox
        private void RdvBrokers_Loaded(object sender, RoutedEventArgs e)
        {
            rdvBrokers.ItemsSource = db.brokers.ToList();
        }
        // RegEx Heures
        private void RdvHours_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]{2}$");
            e.Handled = regex.IsMatch(e.Text);
        }
        // RegEx Minutes
        private void RdvMinutes_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]{2}$");
            e.Handled = regex.IsMatch(e.Text);
        }

        // Enregistrer
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            appointements rdvToAdd = new appointements();

            bool isValid = true;

            rdvToAdd.idCustomer = Convert.ToInt32(rdvCustomers.SelectedValue);
            rdvToAdd.idBroker = Convert.ToInt32(rdvBrokers.SelectedValue);

            string time = rdvHours.Text + ":" + rdvMinutes.Text;
            string dateTime = rdvDate.Text + " " + time;
            rdvToAdd.dateHour = Convert.ToDateTime(dateTime);
            // Vérification Date et Horaire
            if (String.IsNullOrEmpty(rdvDate.Text))
            {
                MessageBox.Show("Date manquante", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                isValid = false;
            }
            if (String.IsNullOrEmpty(rdvHours.Text))
            {
                MessageBox.Show("Heure manquante", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                isValid = false;
            }
            if (String.IsNullOrEmpty(rdvMinutes.Text))
            {
                MessageBox.Show("Minutes manquantes", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                isValid = false;
            }
            if (String.IsNullOrEmpty(time))
            {
                MessageBox.Show("Horaire manquant", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                isValid = false;
            }
            // Faire en sorte qu'un courtier n'ai pas 2 rendez-vous en même temps (même jour et même heure)
            var brokerAlreadyUsed = db.appointements.Where(rdv => rdv.idBroker == rdvToAdd.idBroker && rdv.dateHour == rdvToAdd.dateHour).SingleOrDefault();
            if (brokerAlreadyUsed != null)
            {
                MessageBox.Show("Un RDV existe déja avec ce Courtier à cette plage horaire", "Erreur", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                isValid = false;
            }
            var customerAlreadyUsed = db.appointements.Where(rdv => rdv.idCustomer == rdvToAdd.idCustomer && rdv.dateHour == rdvToAdd.dateHour).SingleOrDefault();
            if (customerAlreadyUsed != null)
            {
                MessageBox.Show("Un RDV existe déja avec ce Client à cette plage horaire", "Erreur", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                isValid = false;
            }
            if (isValid == true)
            {
                db.appointements.Add(rdvToAdd);
                db.SaveChanges();
                MessageBox.Show("Rendez-vous ajouté avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new System.Uri("appointmentsList.xaml", UriKind.RelativeOrAbsolute));
            }
        }

        // Revenir à la liste
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new System.Uri("appointmentsList.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
