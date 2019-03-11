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
        string regexName = @"^[A-Za-zéèàêâôûùïüç\-]+$";
        string regexMail = @"[0-9a-zA-Z\.\-]+@[0-9a-zA-Z\.\-]+.[a-zA-Z]{2,4}";
        string regexPhone = @"^[0][0-9]{9}";

        public addBroker()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            brokers brokerToAdd = new brokers();

            bool isValid = true; //Permet de Vérifier les erreurs potentielles
            int error = 0; //Compte d'erreur(s)

            // Vérification lastname
            if (!String.IsNullOrEmpty(BrokerLastName.Text))
            {
                // Vérif de la validité de l'entrée
                if (!Regex.IsMatch(BrokerLastName.Text, regexName))
                {
                    MessageBox.Show("Ecrire un nom valide");
                    isValid = false;
                    error++;
                }
                else
                {
                    brokerToAdd.lastname = BrokerLastName.Text;
                }
            }
            else
            {
                MessageBox.Show("Ecrire un nom");
                isValid = false;
                error++;
            }
            // Vérification firstname
            if (!String.IsNullOrEmpty(BrokerFirstName.Text))
            {
                // Vérif de la validité de l'entrée
                if (!Regex.IsMatch(BrokerFirstName.Text, regexName))
                {
                    MessageBox.Show("Ecrire un prénom valide");
                    isValid = false;
                    error++;
                }
                else
                {
                    brokerToAdd.firstname = BrokerFirstName.Text;
                }
            }
            else
            {
                MessageBox.Show("Ecrire un prénom");
                isValid = false;
                error++;
            }
            // Vérification mail
            if (!String.IsNullOrEmpty(BrokerMail.Text))
            {
                // Vérification de la validité de l'entrée
                if (!Regex.IsMatch(BrokerMail.Text, regexMail))
                {
                    // Message d'erreur
                    MessageBox.Show("Ecrire un mail valide");
                    isValid = false;
                    error++;
                }

                else
                {
                    brokerToAdd.mail = BrokerMail.Text;
                }
            }
            else
            {
                MessageBox.Show("Ecrire un email");
                isValid = false;
                error++;
            }
            // Vérification phoneNumber
            if (!String.IsNullOrEmpty(BrokerPhone.Text))
            {
                // Vérif de la validité de l'entrée
                if (!Regex.IsMatch(BrokerPhone.Text, regexPhone))
                {
                    MessageBox.Show("Ecrire un numéro de téléphone valide");
                    isValid = false;
                    error++;
                }
                else
                {
                    brokerToAdd.phoneNumber = BrokerPhone.Text;
                }
            }
            else
            {
                MessageBox.Show("Ecrire un numéro de téléphone");
                isValid = false;
                error++;
            }
            //SAUVEGARDE ET RESET
            if (isValid == true)
            {
                db.brokers.Add(brokerToAdd);
                db.SaveChanges();
                MessageBox.Show("Courtier ajouté avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new System.Uri("brokersList.xaml", UriKind.RelativeOrAbsolute));
            }
            else
            {
                MessageBox.Show("Vous avez fait " + error + " Erreur(s)");
            }
        }
        // Retour à la liste
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new System.Uri("brokersList.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
