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

namespace ClientLourd_Agenda
{
    /// <summary>
    /// Logique d'interaction pour customersList.xaml
    /// </summary>
    public partial class customersList : Page
    {
        private agenda_DB db = new agenda_DB();
        customers customer;

        public customersList()
        {
            InitializeComponent();
            customer = new customers();
        }
        // liste des clients
        private void ListCusDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            listCusDataGrid.ItemsSource = db.customers.ToList();
        }

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

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            customer.lastname = CustomerLastName.Text;
            customer.firstname = CustomerFirstName.Text;
            customer.mail = CustomerMail.Text;
            customer.phoneNumber = CustomerPhone.Text;
            customer.budget = int.Parse(CustomerBudget.Text);
            customer.subject = CustomerSubject.Text;
            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();
            MessageBox.Show("Client modifié avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            listCusDataGrid.Items.Refresh();
            //listCusDataGrid.ItemsSource = null;
            //listCusDataGrid.ItemsSource = db.customers.ToList();

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            EditCustomer.Visibility = Visibility.Hidden;
        }
    }
}
