// System
using Kanban_ToDoList.DataLayer.Context;
using Kanban_ToDoList.DataLayer.Model;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;



// Internal
using Task = Kanban_ToDoList.DataLayer.Model.Task;


namespace Kanban_ToDoList.App.Views
{
    /// <summary>
    /// Interaction logic for WinCreateTask.xaml
    /// </summary>
    public partial class WinCreateTask : Window
    {
        public WinCreateTask()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load and set usernames from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
                {
                    dgvGetUsers.ItemsSource = db.UsersRepository.GetAllUsers();
                }
            }
            catch 
            {
                MessageBox.Show("ِDatabes Error.");
            }
        }//End

        /// <summary>
        /// Filter GridView by username
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
            {
                dgvGetUsers.ItemsSource = db.UsersRepository.FilterUserByUsername(txtSearch.Text).ToList();
            }
        }//End


        /// <summary>
        /// Add task: validate form, check user, save to database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTask_Click(object sender, RoutedEventArgs e)
        {
            int stageToDo = 1;
            bool IsCreateTaskFormValid = Context.Validation.IsCreateTaskFormValid(txtTitle.Text, txtInfo.Text,txtDuration.Text);

            var selectedUser = dgvGetUsers.SelectedItem as User;
            if (selectedUser == null)
            {
                MessageBox.Show("Please select a user.");
                return;
            }

            int userId = selectedUser.ID;

            if (IsCreateTaskFormValid)
            {
                try
                {
                    using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
                    {
                        Task task = new Task()
                        {
                            Title = txtTitle.Text,
                            Description = txtInfo.Text,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                            Duration = Convert.ToInt32(txtDuration.Text),
                            StageId = stageToDo,
                            UserId = userId,
                        };
                        db.TasksRepository.AddTask(task);
                        db.Save();
                        this.DialogResult = true;
                        this.Close();

                    }
                }
                catch
                {
                    MessageBox.Show("Database Error");
                }
            }
        }//End
    }


}
