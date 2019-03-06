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
    /// Logique d'interaction pour addAppointment.xaml
    /// </summary>
    public partial class addAppointment : Page
    {
        private agenda_DB db = new agenda_DB();

        public addAppointment()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            appointements rdvToAdd = new appointements();

            //rdvToAdd.lastname = rdvCustomers.Text;
            //rdvToAdd.firstname = rdvBrokers.Text;
            //rdvToAdd.dateHour = rdvDate.Text;
            //rdvToAdd.phoneNumber = rdvHours.Text;
            //rdvToAdd.phoneNumber = rdvMinutes.Text;

            //db.appointements.Add(rdvToAdd);
            //db.SaveChanges();
            //MessageBox.Show("Courtier ajouté avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            //NavigationService.Navigate(new System.Uri("brokersList.xaml", UriKind.RelativeOrAbsolute));

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new System.Uri("brokersList.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
