// System
using System.Windows;
using System.Collections.Generic;
using System.Windows.Controls;

// Internal
using Kanban_ToDoList.DataLayer.Model;
using Kanban_ToDoList.DataLayer.Context;



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
        /// Handles the Permission button click in PermissionUser form
        /// Adds the selected permissions for the user if they don't exist,
        /// and removes unchecked permissions if they already exist.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPermssionUser_Click(object sender, RoutedEventArgs e)
        {
            var permissions = new List<(CheckBox CheckBox, string Permission)>
            {
                (chkAddTask, "AddTask"),
                (chkDelete, "RemoveTask"),
                (chkUpdateTask, "ModifyTask"),
                (chkUserAccess, "AccessUsers")
            };

            using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
            {
                foreach (var (checkbox, permissionName) in permissions)
                {
                    int getPermissionId = db.PermissionsRepository.GetPermissionIdByTitle(permissionName);
                    var existing = db.UserPermissionsRepository.CheckPermission(UserId, getPermissionId);
                    
                    if (checkbox.IsChecked == true) 
                    {
                        if (existing == null)
                        {
                            UserPermission access = new UserPermission
                            {
                                UserId = UserId,
                                PermissionId = getPermissionId,
                                CreatedAt = System.DateTime.Now,
                            };
                            db.UserPermissionsRepository.AddUserPermission(access);
                            db.Save();
                        }
                    }
                    else
                    {
                        if(existing != null)
                        {
                            db.UserPermissionsRepository.RemoveUserPermission(existing.ID);
                            db.Save();
                        }
                    }

                }
                this.Close();
            }

        }//End

        /// <summary>
        /// Loads the user's current permissions when the window is opened.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var permissions = new List<(CheckBox CheckBox, string Permission)>
            {
                (chkAddTask, "AddTask"),
                (chkDelete, "RemoveTask"),
                (chkUpdateTask, "ModifyTask"),
                (chkUserAccess, "AccessUsers")
            };
            try
            {
                foreach (var (checkbox, permissionName) in permissions)
                {
                    using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
                    {
                        int getPermissionId = db.PermissionsRepository.GetPermissionIdByTitle(permissionName);
                        var existing = db.UserPermissionsRepository.CheckPermission(UserId, getPermissionId);

                        if (existing != null)
                        {
                            checkbox.IsChecked = true;
                        }
                    }
                }
            }

            catch
            {
                MessageBox.Show("Databes Error!");
            }
        }//End

    }
}
