using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ClientLourd_Agenda;
using System.Data.Entity;
using System.Text.RegularExpressions;

namespace ClientLourd_Agenda
{
    /// <summary>
    /// Logique d'interaction pour customersList.xaml
    /// </summary>
    public partial class customersList : Page
    {
        private agenda_DB db = new agenda_DB();
        string regexName = @"^[A-Za-zéèàêâôûùïüç\-]+$";
        string regexMail = @"[0-9a-zA-Z\.\-]+@[0-9a-zA-Z\.\-]+.[a-zA-Z]{2,4}";
        string regexPhone = @"^[0][0-9]{9}";
        string regexSubject = @"^[A-Za-zéèêëâäàçîïôö&-.,'\ ]+$";
        string regexBudget = @"[0-9]+$";
        customers customer;

        public customersList()
        {
            InitializeComponent();
            customer = new customers();
        }
        // Liste des clients
        private void ListCusDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            listCusDataGrid.ItemsSource = db.customers.ToList();
        }
        // Fermer la fenêtre (grid) de modification
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            EditCustomer.Visibility = Visibility.Hidden;
        }
        // Selection d'un client à modifier
        private void ListCusDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listCusDataGrid.SelectedItem == null) return;  
            customer = listCusDataGrid.SelectedItem as customers;

            CustomerLastName.Text = customer.lastname;
            CustomerFirstName.Text = customer.firstname;
            CustomerMail.Text = customer.mail;
            CustomerPhone.Text = customer.phoneNumber;
            CustomerBudget.Text = customer.budget.ToString();
            CustomerSubject.Text = customer.subject;
            EditCustomer.Visibility = Visibility.Visible;
        }
        // Enregistrer Modification
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true; //Permet de Vérifier les erreurs potentielles
            // Vérification lastname
            if (!String.IsNullOrEmpty(CustomerLastName.Text))
            {
                // Vérif de la validité de l'entrée
                if (!Regex.IsMatch(CustomerLastName.Text, regexName))
                {
                    MessageBox.Show("Ecrire un nom valide");
                    isValid = false;
                }
                else
                {
                    customer.lastname = CustomerLastName.Text;
                }
            }
            else
            {
                MessageBox.Show("Ecrire un nom");
                isValid = false;
            }
            // Vérification firstname
            if (!String.IsNullOrEmpty(CustomerFirstName.Text))
            {
                // Vérif de la validité de l'entrée
                if (!Regex.IsMatch(CustomerFirstName.Text, regexName))
                {
                    MessageBox.Show("Ecrire un prénom valide");
                    isValid = false;
                }
                else
                {
                    customer.firstname = CustomerFirstName.Text;
                }
            }
            else
            {
                MessageBox.Show("Ecrire un prénom");
                isValid = false;
            }
            // Vérification mail
            if (!String.IsNullOrEmpty(CustomerMail.Text))
            {
                // Vérification de la validité de l'entrée
                if (!Regex.IsMatch(CustomerMail.Text, regexMail))
                {
                    // Message d'erreur
                    MessageBox.Show("Ecrire un mail valide");
                    isValid = false;
                }

                else
                {
                    customer.mail = CustomerMail.Text;
                }
            }
            else
            {
                MessageBox.Show("Ecrire un email");
                isValid = false;
            }
            // Vérification phoneNumber
            if (!String.IsNullOrEmpty(CustomerPhone.Text))
            {
                // Vérif de la validité de l'entrée
                if (!Regex.IsMatch(CustomerPhone.Text, regexPhone))
                {
                    MessageBox.Show("Ecrire un numéro de téléphone valide");
                    isValid = false;
                }
                else
                {
                    customer.phoneNumber = CustomerPhone.Text;
                }
            }
            else
            {
                MessageBox.Show("Ecrire un numéro de téléphone");
                isValid = false;
            }

            // vérification du champ budget
            if (!String.IsNullOrEmpty(CustomerBudget.Text))
            {
                if (!Regex.IsMatch(CustomerBudget.Text, regexBudget))
                {
                    MessageBox.Show("Budget non valide");
                    isValid = false;
                }
                else
                {
                    customer.budget = int.Parse(CustomerBudget.Text);
                }
            }
            else
            {
                MessageBox.Show("Ecrire un budget");
                isValid = false;
            }

            // vérification pour le champ subject
            if (!String.IsNullOrEmpty(CustomerSubject.Text))
            {
                // Vérif de la validité de l'entrée
                if (!Regex.IsMatch(CustomerSubject.Text, regexSubject))
                {
                    MessageBox.Show("Ecrire un sujet valide");
                    isValid = false;
                }
                else
                {
                    customer.subject = CustomerSubject.Text;
                }
            }
            else
            {
                MessageBox.Show("Ecrire un sujet");
                isValid = false;
            }
            //SAUVEGARDE ET RESET
            if (isValid == true)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                MessageBox.Show("Client modifié avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                listCusDataGrid.Items.Refresh();
            }
            // Autre façon de rafraichir la page :
            //listCusDataGrid.ItemsSource = null;
            //listCusDataGrid.ItemsSource = db.customers.ToList();
        }
        // Confirmation suppression
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // Demande de confirmation
            MessageBoxResult result = MessageBox.Show("Etes-vous sûr de supprimer ce client ?", "Suppression", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.OK:
                    // Si OK appeler la méthode DeleteCustomer
                    DeleteCustomer();
                    break;
                case MessageBoxResult.Cancel:
                    // Sinon, retour à modification
                    break;
            }
        }
        // Suppression du client
        private void DeleteCustomer()
        {
            // Suppression dans la database
            db.customers.Remove(customer);
            // Sauvegarde des changements
            db.SaveChanges();
            // Message de succès :
            MessageBox.Show("Client supprimé avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            // Fermer la fenêtre (cacher la grid) de modification
            EditCustomer.Visibility = Visibility.Hidden;
            // Rafraichir la liste :
            listCusDataGrid.ItemsSource = null;
            listCusDataGrid.ItemsSource = db.customers.ToList();
        }
    }
}
