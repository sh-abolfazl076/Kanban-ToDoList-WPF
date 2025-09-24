// System
using Kanban_ToDoList.DataLayer.Context;
using System;
using System.Windows;



// Internal




namespace Kanban_ToDoList.App.Views
{
    /// <summary>
    /// Interaction logic for WinEditUser.xaml
    /// </summary>
    public partial class WinEditUser : Window
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int userId { get; set; }

        public WinEditUser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The method closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnColse_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }//End

        /// <summary>
        /// Handles the Save button click: validates input, updates the user in the database, and closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveEditUser_Click(object sender, RoutedEventArgs e)
        {
            bool isUsernameAndPasswordValid = Context.Validation.IsUsernameAndPasswordValid(txtChangeUsernameSignup.Text, txtChangePassSignup.Password);
            bool isPasswordConfirmed = Context.Validation.IsPasswordConfirmed(txtChangePassSignup.Password, txtChangePassCeckSignup.Password);

            if (isUsernameAndPasswordValid && isPasswordConfirmed)
            {
                try
                {
                    using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
                    {
                        var edit = db.UsersRepository.GetUserById(userId);
                        if (edit != null)
                        {
                            edit.UserName = txtChangeUsernameSignup.Text;
                            edit.PassWord = txtChangePassSignup.Password;
                            edit.UpdatedAt = DateTime.Now;


                            db.UsersRepository.UpdataUser(edit);
                            db.Save();
                            MessageBox.Show("User Updated");
                            this.Close();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("ِDatabese Error !");
                }
            }

        }//End
    }
}
