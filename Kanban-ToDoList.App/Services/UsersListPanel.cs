// System
using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

// Internal
using Kanban_ToDoList.DataLayer.Context;


namespace Kanban_ToDoList.App.Services
{
    public class UsersListPanel
    {
        /// <summary>
        /// Add LoadUsers method to load users and buttons
        /// </summary>
        /// <param name="panelUser"></param>
        public void LoadUsers(StackPanel panelUser)
        {   
            using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
            {
                var getUsers = db.UsersRepository.GetAllUsers();
                foreach (var user in getUsers)
                {
                    AddUsernameLabel(panelUser, user.UserName , user.ID);
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
            panelUser.Children.Add(btn); // Add the button to the

        }//End


    }
}
