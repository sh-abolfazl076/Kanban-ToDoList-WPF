// System
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
        /// 
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
                        if (existing == false)
                        {
                            UserPermission access = new UserPermission
                            {
                                UserId = UserId,
                                PermissionId = getPermissionId,
                                CreatedAt = System.DateTime.Now,
                            };
                            db.UsersRepository.AddUser(access);
                            db.Save();
                        }
                    }
                    else
                    {
                        if(existing == true)
                        {
                            //db.PermissionsRepository.RemovePermission(existing);
                        }
                    }

                }
            }

        }//End
    }
}
