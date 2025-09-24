// System
using System.Windows;



// Internal
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
            panelUsers.LoadUsers(PanelUsers, PanelRemove, PanelEdit, PanelPermission);
        }//End

        /// <summary>
        /// Opens the SignUp form when called from the UserList.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            int typeAddUser = 0;
            bool backToUserList = true;
            WinEditOrAddUser frm = new WinEditOrAddUser();
            frm.type = typeAddUser;
            frm.backToUserList = backToUserList;
            frm.ShowDialog();
        }//End
    }
}
