   M S B A M L   `   `   `  ����M  IClientLourd_Agenda, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ClientLourd_AgendaClientLourd_Agenda  5      )    #ClientLourd_Agenda.appointmentsList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:ClientLourd_Agenda     5        N� Title$  appointmentsList��5	       N� 
Background 5
      �� 5   
    �� EndPoint$ 0.5,1&�6    � MappingMode$ RelativeToBoundingBox=�6/    �� 
StartPoint$ 0.5,0&�6S   .��5      �  � Color$ White��6   � 5      $ 	#FF98D1A5��6    � Offset$ 1Q�6-   5      .��5      � .+�5   
   �� ���	#FF4B6AA2$
��Bold"�6+   $��18(�6=   $��	30,10,0,0q�6K   Liste des Rendez-Vous6u   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ listRdvDataGrid��5   3      AutoGenerateColumns .  	   AlternatingRowBackground	 �	#FFEEEEEE
 �� AlternationCount$
 2��5   8      CanUserAddRows .     CanUserResizeRows .  $	��Top=�5      $
��Left=�6+   $��	30,50,0,0q�6F      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Client��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *customers.lastname+  5      $ Courtier��6%    67   �� *brokers.lastname+  5      $ Date et Horaire��6%    6>   �� *
dateHour+ �� StringFormat$ dd/MM/yyyy HH:mm��5      � 5   
   -   5         �Name$ EditRdv��5      $	��Top=�6    $��Right=�68   $��0,0,20,0q�6T   $y�Hidden=�6f   ��5       �� 5!      $ 0.5,1&�6&   $ 0.5,0&�67   .��5"      � $ 	#FFE2E2E2��6#   $ 1Q�65   � 5#      $ White��6#   5$      .+�5&      �� ���	#FF4B6AA2$��4q�6-   ._�5'      �� $	��250��6   $��20q�6)   .+�5(      �� -   5         ��Name$ Cancel��5(      $��30��6-   
�������$��Right=�6`   ��5)      �� 5*       �� Color$ 	#FFD81E1E��6.   .��5+   -   X5,      �� 5-      ���	#FF4B6AA2$
��Bold"�67   $��18(�6I   $��0,0,0,10q�6W   Modifier un RDV6z   �� 5.      $
��Bold"�6   ���	#FF4B6AA2$��Clients��6E   �� 5/      -   5         ��Name$ rdvCustomers��5/       �� DisplayMemberPath$ lastname��65    �� SelectedValuePath$ 
idCustomer��6R    �� SelectedValue 6q   �� *
idCustomer+6�   �� 50      $
��Bold"�6   ���	#FF4B6AA2$��	Courtiers��6E   �� 51      -   5        $ 
rdvBrokers��51      $ lastname��63   $ idBroker��6P   6m   �� 52      $
��Bold"�6   ���	#FF4B6AA2$��Date du RDV��6E   (  "System.Windows.Controls.DatePicker  53      -   5          Name$ rdvDate��53   !   64   ]� 54      .+�55      �� $
��Bold"�6    ���	#FF4B6AA2$��Heures / Minutes��6I   56      ]� 57      $
��Left=�6    $��3,0,0,0q�6;   .+�58      �� -   5         ��Name$ rdvHours��58   "   $��40��64   �� 59      $��5,0,5,0q�6$   :69   �� 5:      -   5        $ 
rdvMinutes��5:   "   $��40��66   5;      �� 5<      -	   5        $
 Save��5<      $	��100��6+   ���	#FF4B6AA2
�������$��0,20,0,5q�6a   .��6�   Enregistrer6�   �� 5=      -
   5        $ Delete��5=      $	��100��6-   ���	#FFD81E1E
�������.��6x   	Supprimer6�   5>      5?      5@      5A      5B      