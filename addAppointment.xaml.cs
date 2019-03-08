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
        string regexTime = @"[0-9]";
        string time, dateTime;

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

        // Enregistrer
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Vider les champs d'erreurs
            ErrorCustomer.Text = "";
            ErrorBroker.Text = "";
            ErrorDate.Text = "";
            ErrorTime.Text = "";
            appointements rdvToAdd = new appointements();
            // booleen pour vérification
            bool isValid = true;
            // Vérification comboboxes
            if (rdvCustomers.SelectedValue == null)
            {
                ErrorCustomer.Text = "Sélectionnez un Client";
                isValid = false;
            }
            if (rdvBrokers.SelectedValue == null)
            {
                ErrorBroker.Text = "Sélectionnez un Courtier";
                isValid = false;
            }

            // Enregistrement du client et du courtier concerné par le RDV
            rdvToAdd.idCustomer = Convert.ToInt32(rdvCustomers.SelectedValue);
            rdvToAdd.idBroker = Convert.ToInt32(rdvBrokers.SelectedValue);

            // Vérification Date
            if (String.IsNullOrEmpty(rdvDate.Text))
            {
                ErrorDate.Text = "Date manquante";
                isValid = false;
            }

            // Verification Heures et minutes
            if ((!String.IsNullOrEmpty(rdvHours.Text)) && (!String.IsNullOrEmpty(rdvMinutes.Text)))
            {
                // Vérif heures
                if (!Regex.IsMatch(rdvHours.Text, regexTime))
                {
                    ErrorTime.Text = "Ecrire une heure valide";
                    isValid = false;
                }
                // Vérif minutes
                else if (!Regex.IsMatch(rdvMinutes.Text, regexTime))
                {
                    ErrorTime.Text = "Ecrire des minutes valides";
                    isValid = false;
                }
                // Vérif OK
                else
                {
                    time = rdvHours.Text + ":" + rdvMinutes.Text;
                }
            }
            else
            {
                ErrorTime.Text = "Horaire non valide";
                isValid = false;
            }
            
            
            // Faire en sorte qu'un courtier n'ai pas 2 rendez-vous en même temps (même jour et même heure)
            var brokerAlreadyUsed = db.appointements.Where(rdv => rdv.idBroker == rdvToAdd.idBroker && rdv.dateHour == rdvToAdd.dateHour).SingleOrDefault();
            if (brokerAlreadyUsed != null)
            {
                ErrorCustomer.Text = "Un RDV existe déja avec ce Courtier à cette plage horaire";
                isValid = false;
            }
            var customerAlreadyUsed = db.appointements.Where(rdv => rdv.idCustomer == rdvToAdd.idCustomer && rdv.dateHour == rdvToAdd.dateHour).SingleOrDefault();
            if (customerAlreadyUsed != null)
            {
                ErrorBroker.Text = "Un RDV existe déja avec ce Client à cette plage horaire";
                isValid = false;
            }

            if (isValid == true)
            {
                dateTime = rdvDate.Text + " " + time;
                rdvToAdd.dateHour = Convert.ToDateTime(dateTime);
                db.appointements.Add(rdvToAdd);
                db.SaveChanges();
                ErrorCustomer.Text = "";
                ErrorBroker.Text = "";
                ErrorDate.Text = "";
                ErrorTime.Text = "";
                MessageBox.Show("Rendez-vous ajouté avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new System.Uri("appointmentsList.xaml", UriKind.RelativeOrAbsolute));
            }
        }

        private void RdvHours_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 8; i < 20; i++)
            {
                rdvHours.Items.Add(i.ToString());
            }
        }

        private void RdvMinutes_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 60; i++)
            {
                if (i % 5 == 0)
                {
                    rdvMinutes.Items.Add(i.ToString());
                }
            }
        }

        // Revenir à la liste
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new System.Uri("appointmentsList.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
