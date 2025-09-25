// System
using Kanban_ToDoList.App.Context;
using Kanban_ToDoList.DataLayer.Context;
// Internal
using Kanban_ToDoList.DataLayer.Model;
using System;
using System.Windows;


namespace Kanban_ToDoList.App.Views
{
    /// <summary>
    /// Interaction logic for WinEditOrAddUser.xaml
    /// </summary>
    public partial class WinEditOrAddUser : Window
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public int userId { get; set; }
        public int type { get; set; }

        public bool backToUserList = false;
        private int typeEditUser = 1;
        
       

        public WinEditOrAddUser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the window title and lables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(type == typeEditUser)
            {
                this.Title = "Edit User";
                btnColseOrBack.Content = "Close";
                txtTitle.Text = "Edit User";
            }
            else
            {
                this.Title = "Add User";
                btnColseOrBack.Content = "Back";
                txtTitle.Text = "Sing up User";
            }
        }

        /// <summary>
        /// Handles the Close/Back button:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnColseOrBack_Click(object sender, RoutedEventArgs e)
        {
            if (type == typeEditUser || backToUserList == true)
            {
                this.Close();
            }
            else
            {
                WinLogin login = new WinLogin();
                this.Close();
                login.ShowDialog();
            }


        }//End

        /// <summary>
        /// Handles the Add/Edit button click:
        /// Validates input and confirms password
        /// If in edit mode, updates the user
        /// If in add mode, creates a new user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddOrEditUser_Click(object sender, RoutedEventArgs e)
        {
            bool isUsernameAndPasswordValid = Context.Validation.IsUsernameAndPasswordValid(txtUsername.Text, txtPassWord.Password);
            bool isPasswordConfirmed = Context.Validation.IsPasswordConfirmed(txtPassWord.Password, txtPassWordCeck.Password);


            if (type == typeEditUser)
            {

                if (isUsernameAndPasswordValid && isPasswordConfirmed)
                {
                    try
                    {
                        using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
                        {


                            var edit = db.UsersRepository.GetUserById(userId);
                            var existingUser = db.UsersRepository.GetUserByUsername(txtUsername.Text);

                            if (existingUser != null)
                            {
                                MessageBox.Show("A User with this name exists, please choose another.");
                            }
                            else
                            {
                                if (edit != null)
                                {
                                    edit.UserName = txtUsername.Text;
                                    edit.PassWord = txtPassWord.Password;
                                    edit.UpdatedAt = DateTime.Now;


                                    db.UsersRepository.UpdataUser(edit);
                                    db.Save();
                                    MessageBox.Show("User Updated");
                                    this.Close();
                                }
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("ِDatabese Error !");
                    }
                }
            }
            else
            {
                if (isUsernameAndPasswordValid && isPasswordConfirmed)
                {
                    try
                    {
                        using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
                        {
                            var existingUser = db.UsersRepository.GetUserByUsername(txtUsername.Text);

                            if (existingUser != null)
                            {
                                MessageBox.Show("A User with this name exists, please choose another.");
                            }
                            else
                            {
                                User user = new User()
                                {
                                    UserName = txtUsername.Text,
                                    PassWord = txtPassWord.Password,
                                    CreatedAt = DateTime.Now,
                                    UpdatedAt = DateTime.Now
                                };

                                db.UsersRepository.AddUser(user);
                                db.Save();

                                MessageBox.Show("User added successfully.");

                                if(backToUserList == true)
                                {
                                    this.DialogResult = true;
                                    this.Close();
                                }
                                else
                                {
                                    WinLogin backLogin = new WinLogin();
                                    this.Close();
                                    backLogin.ShowDialog();
                                }
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ِDatabes Error :\n" + ex);
                    }
                }
            }

        }//End

    }
}
