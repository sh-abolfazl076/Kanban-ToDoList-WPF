// System
using Kanban_ToDoList.App.Views;
// Internal
using Kanban_ToDoList.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;



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
            using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
            {
                var getUsers = db.UsersRepository.GetAllUsers();
                foreach (var user in getUsers)
                {
                    AddUsernameLabel(panelUser, user.UserName , user.ID);
                    RemoveUser(PanelRemove, user.UserName, user.ID);
                    EditUser(PanelEdit, user.UserName, user.ID);
                }
            }
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
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E91E63")),
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
                WinEditUser edit = new WinEditUser();
                edit.ShowDialog();
            };
            

        }// end
    }
}
