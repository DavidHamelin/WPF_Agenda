﻿#pragma checksum "..\..\appointmentsList.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F0BEB8AB316A95272BD9480DCA95979D26FE6FCF"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using ClientLourd_Agenda;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ClientLourd_Agenda {
    
    
    /// <summary>
    /// appointmentsList
    /// </summary>
    public partial class appointmentsList : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\appointmentsList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid listRdvDataGrid;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\appointmentsList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid EditRdv;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\appointmentsList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Cancel;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\appointmentsList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox rdvCustomers;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\appointmentsList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox rdvBrokers;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\appointmentsList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker rdvDate;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\appointmentsList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox rdvHours;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\appointmentsList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox rdvMinutes;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\appointmentsList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Save;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\appointmentsList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Delete;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ClientLourd_Agenda;component/appointmentslist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\appointmentsList.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.listRdvDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 13 "..\..\appointmentsList.xaml"
            this.listRdvDataGrid.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ListRdvDataGrid_MouseDoubleClick);
            
            #line default
            #line hidden
            
            #line 16 "..\..\appointmentsList.xaml"
            this.listRdvDataGrid.Loaded += new System.Windows.RoutedEventHandler(this.ListRdvDataGrid_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.EditRdv = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.Cancel = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\appointmentsList.xaml"
            this.Cancel.Click += new System.Windows.RoutedEventHandler(this.Cancel_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.rdvCustomers = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.rdvBrokers = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.rdvDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.rdvHours = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.rdvMinutes = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.Save = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\appointmentsList.xaml"
            this.Save.Click += new System.Windows.RoutedEventHandler(this.Save_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Delete = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\appointmentsList.xaml"
            this.Delete.Click += new System.Windows.RoutedEventHandler(this.Delete_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

