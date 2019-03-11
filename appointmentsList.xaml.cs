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
        string regexTime = @"[0-9]";
        string time, dateTime;

        public appointmentsList()
        {
            InitializeComponent();
            appointment = new appointements();
        }
        // Afficher la liste
        private void ListRdvDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            listRdvDataGrid.ItemsSource = db.appointements.ToList();
        }
        // Fermer fenêtre modification (cacher la grid)
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            EditRdv.Visibility = Visibility.Hidden;
        }
        // ComboBox Clients
        private void RdvCustomers_Loaded(object sender, RoutedEventArgs e)
        {
            rdvCustomers.ItemsSource = db.customers.ToList();
        }
        // ComboBox Courtiers
        private void RdvBrokers_Loaded(object sender, RoutedEventArgs e)
        {
            rdvBrokers.ItemsSource = db.brokers.ToList();
        }
        // Selection d'un RDV
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
            EditRdv.Visibility = Visibility.Visible;
        }
        
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // booleen pour vérification
            bool isValid = true;
            // Enregistrement du client et du courtier concerné par le RDV
            appointment.idCustomer = Convert.ToInt32(rdvCustomers.SelectedValue);
            appointment.idBroker = Convert.ToInt32(rdvBrokers.SelectedValue);

            // Vérification Date
            if (String.IsNullOrEmpty(rdvDate.Text))
            {
                MessageBox.Show("Date manquante", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                isValid = false;
            }
            
            // Verification Heures et minutes
            if ((!String.IsNullOrEmpty(rdvHours.Text)) && (!String.IsNullOrEmpty(rdvMinutes.Text)))
            {
                // Vérif heures
                if (!Regex.IsMatch(rdvHours.Text, regexTime))
                {
                    MessageBox.Show("Ecrire une heure valide");
                    isValid = false;
                }
                // Vérif minutes
                else if (!Regex.IsMatch(rdvMinutes.Text, regexTime))
                {
                    MessageBox.Show("Ecrire des minutes valides");
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
                MessageBox.Show("Horaire non valide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                isValid = false;
            }

            //// Faire en sorte qu'un courtier n'ai pas 2 rendez-vous en même temps (même jour et même heure)
            //var brokerAlreadyUsed = db.appointements.Where(rdv => rdv.idBroker == appointment.idBroker && rdv.dateHour == appointment.dateHour).SingleOrDefault();
            //if (brokerAlreadyUsed != null)
            //{
            //    MessageBox.Show("Un RDV existe déja avec ce Courtier à cette plage horaire", "Erreur", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //    isValid = false;
            //}
            //var customerAlreadyUsed = db.appointements.Where(rdv => rdv.idCustomer == appointment.idCustomer && rdv.dateHour == appointment.dateHour).SingleOrDefault();
            //if (customerAlreadyUsed != null)
            //{
            //    MessageBox.Show("Un RDV existe déja avec ce Client à cette plage horaire", "Erreur", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //    isValid = false;
            //}

            if (isValid == true)
            {
                dateTime = rdvDate.Text + " " + time;
                appointment.dateHour = Convert.ToDateTime(dateTime);
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                MessageBox.Show("Rendez-vous modifié avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                listRdvDataGrid.Items.Refresh();
            } 
        }

        // Confirmation suppression
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

        // Suppression RDV
        private void DeleteRdv()
        {
            db.appointements.Remove(appointment);
            db.SaveChanges();
            MessageBox.Show("Rendez-vous supprimé avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            EditRdv.Visibility = Visibility.Hidden;
            listRdvDataGrid.ItemsSource = null;
            listRdvDataGrid.ItemsSource = db.appointements.ToList();
        }
        // Main.NavigationService.Navigate(new MainWindow());
    }
}
