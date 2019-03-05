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
using ClientLourd_Agenda;
using System.Text.RegularExpressions;

namespace ClientLourd_Agenda
{
    /// <summary>
    /// Logique d'interaction pour addCustomer.xaml
    /// </summary>
    public partial class addCustomer : Page
    {
        private agenda_DB db = new agenda_DB();
        string regexName = @"^[A-Za-zéèàêâôûùïüç\-]+$";
        string regexMail = @"[0-9a-zA-Z\.\-]+@[0-9a-zA-Z\.\-]+.[a-zA-Z]{2,4}";
        string regexPhone = @"^[0][0-9]{9}";
        string regexSubject = @"^[A-Za-zéèêëâäàçîïôö&-.,'\ ]+$";

        public addCustomer()
        {
            InitializeComponent();
        }

    private void Save_Click(object sender, RoutedEventArgs e)
        {
            customers customerToAdd = new customers();

            //if (!String.IsNullOrEmpty(customerToAdd.lastname))
            //{
            //    // Vérif de la validité de l'entrée
            //    if (!Regex.IsMatch(customerToAdd.lastname, regexName))
            //    {
            //        MessageBox.Show("Ecrire un nom valide");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Ecrire un nom");
            //}
            //// vérification que le champ firstname n'est pas null ou vide
            //if (!String.IsNullOrEmpty(customerToAdd.firstname))
            //{
            //    // Vérif de la validité de l'entrée
            //    if (!Regex.IsMatch(customerToAdd.firstname, regexName))
            //    {
            //        MessageBox.Show("Ecrire un prénom valide");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Ecrire un prénom");
            //}
            //// Vérification que le champs mail n'est pas null, vide ou identique au mail d'un autre client
            //if (!String.IsNullOrEmpty(customerToAdd.mail))
            //{
            //    // Vérification de la validité de l'entrée
            //    var isAlreadyUsed = db.customers.Where(cus => cus.mail == customerToAdd.mail).SingleOrDefault(); // valeur null par defaut
            //    if (!Regex.IsMatch(customerToAdd.mail, regexMail))
            //    {
            //        // Message d'erreur
            //        MessageBox.Show("Ecrire un mail valide");
            //    }
            //    // Vérifie si ce mail est déjà utilisé
            //    else if (isAlreadyUsed != null)
            //    {
            //        MessageBox.Show("Un client existant porte cette adresse mail");
            //    }
            //}
            //else
            //{
            //    // Message d'erreur
            //    MessageBox.Show("Ecrire un email");
            //}
            //// vérification que le champ phoneNumber n'est pas null ou vide
            //if (!String.IsNullOrEmpty(customerToAdd.phoneNumber))
            //{
            //    // Vérif de la validité de l'entrée
            //    if (!Regex.IsMatch(customerToAdd.phoneNumber, regexPhone))
            //    {
            //        MessageBox.Show("Ecrire un numéro de téléphone valide");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Ecrire un numéro de téléphone");
            //}
            //// vérification du champ budget
            //if (customerToAdd.budget <= 0)
            //{
            //    MessageBox.Show("budget non valide");
            //}
            //// vérification pour le champ subject
            //if (!String.IsNullOrEmpty(customerToAdd.subject))
            //{
            //    // Vérif de la validité de l'entrée
            //    if (!Regex.IsMatch(customerToAdd.subject, regexSubject))
            //    {
            //        MessageBox.Show("Ecrire un sujet valide");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Ecrire un sujet");
            //}
            
            customerToAdd.lastname = CustomerLastName.Text;
            customerToAdd.firstname = CustomerFirstName.Text;
            customerToAdd.mail = CustomerMail.Text;
            customerToAdd.phoneNumber = CustomerPhone.Text;
            customerToAdd.budget = int.Parse(CustomerBudget.Text);
            customerToAdd.subject = CustomerSubject.Text;

            db.customers.Add(customerToAdd); // insertion dans la bdd avec .Add
            db.SaveChanges(); // enregistrer les changements
            MessageBox.Show("Client ajouté avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
