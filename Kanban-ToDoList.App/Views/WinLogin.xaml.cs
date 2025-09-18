// System
using System;
using System.Windows;



// Internal
using Kanban_ToDoList.DataLayer.Context;
using Kanban_ToDoList.DataLayer.Model;


namespace Kanban_ToDoList.App.Views
{
    /// <summary>
    /// Interaction logic for WinLogin.xaml
    /// </summary>
    public partial class WinLogin : Window
    {
        public WinLogin()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Open Connection Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWinConnection_Click(object sender, RoutedEventArgs e)
        {
            ConnectionWindow connect = new ConnectionWindow();
            this.Close();
            connect.ShowDialog();
        }// End


        /// <summary>
        /// Open Register form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWinRegister_Click(object sender, RoutedEventArgs e)
        {
            WinRegister singUp = new WinRegister();
            this.Close();
            singUp.ShowDialog();
        }// End

        /// <summary>
        /// Validate the textboxes
        /// Check if the user already exists
        /// Send the information to the ApplicationStore class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            bool isUsernameAndPasswordValid = Context.Validation.IsUsernameAndPasswordValid(txtUsernameLogin.Text, txtPasswordLogin.Text);
            if (isUsernameAndPasswordValid)
            {
                try
                {
                    using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
                    {
                        var existingUser = db.UsersRepository.GetUserByUsernameAndPassword(txtUsernameLogin.Text, txtPasswordLogin.Text);

                        if (existingUser == null)
                        {
                            MessageBox.Show("User is not existion");
                        }
                        else
                        {

                            int userId = existingUser.ID;
                            string username = existingUser.UserName;
                            MessageBox.Show(username + " successfully logged in.");

                            //WinLogin mainPanle = new WinLogin();
                            //this.Close();
                            //mainPanle.ShowDialog();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ِDatabes Error :\n" + ex);
                }
            }
        }//End

    }
}
