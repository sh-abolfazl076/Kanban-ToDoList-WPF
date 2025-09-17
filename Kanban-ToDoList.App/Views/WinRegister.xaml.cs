// System
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
using Kanban_ToDoList.DataLayer.Context;
using Kanban_ToDoList.DataLayer.Model;


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
        /// Add user to database after validation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            bool isUsernameAndPasswordValid = Context.Validation.IsUsernameAndPasswordValid(txtUsernameSignup.Text,txtPassSignup.Text);
            bool isPasswordConfirmed = Context.Validation.IsPasswordConfirmed(txtPassSignup.Text, txtPassCeckSignup.Text);

            if (isUsernameAndPasswordValid && isPasswordConfirmed)
            {
                try
                {
                    using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
                    {
                        var existingUser = db.UsersRepository.GetUserByUsername(txtUsernameSignup.Text);

                        if (existingUser != null)
                        {
                            MessageBox.Show("A User with this name exists, please choose another.");
                        }
                        else
                        {
                            User user = new User()
                            {
                                UserName = txtUsernameSignup.Text,
                                PassWord = txtPassSignup.Text,
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now
                            };

                            db.UsersRepository.AddUser(user);
                            db.Save();

                            MessageBox.Show("User added successfully.");

                            WinLogin backLogin = new WinLogin();
                            this.Close();
                            backLogin.ShowDialog();
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
