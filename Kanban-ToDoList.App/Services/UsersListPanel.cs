// System
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

// Internal
using Kanban_ToDoList.App.Views;
using Kanban_ToDoList.DataLayer.Context;





namespace Kanban_ToDoList.App.Services
{
    public class UsersListPanel
    {
        /// <summary>
        /// Add LoadUsers method to load users and buttons
        /// </summary>
        /// <param name="panelUser"></param>
        public void LoadUsers(StackPanel panelUser , StackPanel PanelRemove , StackPanel PanelEdit , StackPanel PanelPermission)
        {   
            panelUser.Children.Clear();
            PanelRemove.Children.Clear();
            PanelEdit.Children.Clear();
            PanelPermission.Children.Clear();

            using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
            {
                var getUsers = db.UsersRepository.GetAllUsers();
                foreach (var user in getUsers)
                {
                    AddUsernameLabel(panelUser, user.UserName , user.ID);
                    RemoveUser(PanelRemove, user.UserName, user.ID);
                    EditUser(PanelEdit, user.UserName, user.ID);
                    Permission(PanelPermission, user.UserName, user.ID);
                }
            }
        }//End

        /// <summary>
        /// Adds a button to the UserList form. 
        /// When clicked, it opens the WinPermissionUser form.
        /// </summary>
        /// <param name="panelPermission"></param>
        /// <param name="username"></param>
        /// <param name="idUser"></param>
        private void Permission(StackPanel panelPermission, string username, int idUser)
        {
            Button btn = new Button
            {
                Content = "Permission",
                Tag = idUser,
                Width = 80,
                Height = 45,
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#28A745")),
                Foreground = Brushes.White,
                Margin = new Thickness(5),
                FontSize = 12,
                FontWeight = FontWeights.Bold
            };
            panelPermission.Children.Add(btn);

            btn.Click += (s, e) =>
            {
                WinPermissionUser access = new WinPermissionUser
                {
                    UserId = idUser,
                    UserName = username,
                };

                access.Closed += (sender, args) =>
                {
                    var existing = Application.Current.Windows.OfType<WinUsersList>().FirstOrDefault();
                    if (existing != null)
                    {
                        existing.LoadUsers();
                    }
                };
                access.ShowDialog();

            };

        }//End

        /// <summary>
        /// Add code to create user name label 
        /// </summary>
        /// <param name="panelUser"></param>
        /// <param name="username"></param>
        /// <param name="idUser"></param>
        public void AddUsernameLabel(StackPanel panelUser ,string username , int idUser) 
        {
            Button btn = new Button
            {
                Content = username,
                Tag = idUser,
                Width = 125,
                Height = 45,
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#17A2B8")),
                Foreground = Brushes.White,
                Margin = new Thickness(5),
                FontSize = 12,
                FontWeight = FontWeights.Bold
            };
            panelUser.Children.Add(btn); // Add the button to the panelUser

        }//End


        /// <summary>
        /// This method adds a "Remove" button to delete a user 
        /// The user will not be deleted if there is a turnover.
        /// </summary>
        /// <param name="PanelRemove"></param>
        /// <param name="usernaem"></param>
        /// <param name="idUser"></param>
        public void RemoveUser(StackPanel PanelRemove, string usernaem , int idUser)
        {
            string username = usernaem;
            Button btn = new Button
            {
                Content = "Remove",
                Tag = idUser,
                Width = 80,
                Height = 45,
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E91E63")),
                Foreground = Brushes.White,
                Margin = new Thickness(5),
                FontSize = 12,
                FontWeight = FontWeights.Bold
            };
            PanelRemove.Children.Add(btn); // Add the button to the PanelRemove

            btn.Click += (s, e) =>
            {
                if (MessageBox.Show($"Are you sure you want to remove user '{username}'?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
                        {
                            db.UsersRepository.RemoveUserById(idUser);
                            db.Save();

                            var existing = Application.Current.Windows.OfType<WinUsersList>().FirstOrDefault();
                            if (existing != null)
                            {
                                existing.LoadUsers();
                            }
                        }
                    }
                    catch 
                    {
                        MessageBox.Show($"The user has a record and cannot be deleted.");
                    }

                }
            };

        }//End

        /// <summary>
        /// When clicked, it should open a new form to edit the user.
        /// </summary>
        /// <param name="panelEdit"></param>
        /// <param name="usernaem"></param>
        /// <param name="idUser"></param>
        public void EditUser(StackPanel panelEdit, string usernaem, int idUser)
        {
            int typeEditUser = 1;
            string username = usernaem;
            Button btn = new Button
            {
                Content = "Edit",
                Tag = idUser,
                Width = 80,
                Height = 45,
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC107")),
                Foreground = Brushes.White,
                Margin = new Thickness(5),
                FontSize = 12,
                FontWeight = FontWeights.Bold
            };
            panelEdit.Children.Add(btn);

            btn.Click += (s, e) =>
            {
                WinEditOrAddUser frm = new WinEditOrAddUser
                {
                    Username = usernaem,
                    userId = idUser,
                    type = typeEditUser
                };


                frm.Closed += (sender, args) =>
                {
                    var existing = Application.Current.Windows.OfType<WinUsersList>().FirstOrDefault();
                    if (existing != null)
                    {
                        existing.LoadUsers();
                    }
                };
                frm.ShowDialog();

            };
            

        }// end
    }
}
