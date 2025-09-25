// System
using Kanban_ToDoList.DataLayer.Context;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

// Internal



namespace Kanban_ToDoList.App.Views
{
    /// <summary>
    /// Interaction logic for WinPermissionUser.xaml
    /// </summary>
    public partial class WinPermissionUser : Window
    {
        public int UserId { get; set; } 
        public string UserName { get; set; }
        public WinPermissionUser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPermssionUser_Click(object sender, RoutedEventArgs e)
        {

        }//End
    }
}
