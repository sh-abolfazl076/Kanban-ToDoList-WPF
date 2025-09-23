// System
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;



// Internal
using Kanban_ToDoList.DataLayer.Context;
using Kanban_ToDoList.App.Services;


namespace Kanban_ToDoList.App.Views
{
    /// <summary>
    /// Interaction logic for WinUsersList.xaml
    /// </summary>
    public partial class WinUsersList : Window
    {
        public WinUsersList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loaded Users in the WinUsersList form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadUsers();
        }//End


        /// <summary>
        /// Call UsersList class and Load Users
        /// </summary>
        public void LoadUsers()
        {
            UsersListPanel panelUsers = new UsersListPanel();
            panelUsers.LoadUsers(PanelUsers);
        }//End

    }
}
