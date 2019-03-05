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

namespace ClientLourd_Agenda
{
    /// <summary>
    /// Logique d'interaction pour customersList.xaml
    /// </summary>
    public partial class customersList : Page
    {
        private agenda_DB db = new agenda_DB();
        //public ObservableCollection<agenda_DB> agenda { get; set; }
        public customersList()
        {
            InitializeComponent();
            //this.DataContext = this;
            //agenda = new ObservableCollection<agenda_DB>();
        }

        private void ListCusDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            //var listCustomers = db.customers;
            //List<customers> listcustomers = new List<customers>();
            //db.customers.ToList();
            //var grid = sender as DataGrid;
            listCusDataGrid.ItemsSource = db.customers.ToList();
            
        }
    }
}
