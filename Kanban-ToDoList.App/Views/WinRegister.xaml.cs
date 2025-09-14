// System
using Kanban_ToDoList.DataLayer.Context;
using Kanban_ToDoList.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

// Internal



namespace Kanban_ToDoList.App.Views
{
    /// <summary>
    /// Interaction logic for WinRegister.xaml
    /// </summary>
    public partial class WinRegister : Window
    {
        public WinRegister()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Event for Back to login form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBackWinLogin_Click(object sender, RoutedEventArgs e)
        {
            WinLogin login = new WinLogin();
            this.Close();
            login.ShowDialog();
        }// End

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            using(UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
            {
                User user = new User()
                {
                    UserName = txtUsernameSignup.Text,
                    PassWord = txtPassSignup.Text,
                };
                db.UsersRepository.AddUser(user);
                db.Save();
                MessageBox.Show("Added User");
                WinLogin Backlogin = new WinLogin();
                this.Close();
                Backlogin.ShowDialog();
            }
        }
    }
}
