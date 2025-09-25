// System
using System;
using System.Windows;
using System.Windows.Threading;

// Internal
using Kanban_ToDoList.App.Context;
using Kanban_ToDoList.App.Services;
using Kanban_ToDoList.DataLayer.Context;



namespace Kanban_ToDoList.App.Views
{
    /// <summary>
    /// Interaction logic for WinMainPanle.xaml
    /// </summary>
    public partial class WinMainPanle : Window
    {
        private DispatcherTimer _timer;
        public WinMainPanle()
        {
            InitializeComponent();
            StartClock();
        }

        /// <summary>
        /// Initialize the timer
        /// </summary>
        private void StartClock()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }//End

        /// <summary>
        /// Update the TextBlock to show current time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            txtClock.Text = DateTime.Now.ToString("HH:mm:ss"); 
        }//End

        /// <summary>
        /// Permission for using the CreateTask form
        /// This event is used to open the "Add Task" window
        /// refresh main panel after closing Create task window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreatedTask_Click(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
            {
                if(db.UserPermissionsRepository.CheckPermission(ApplicationStore.Instance.UserId, PermissionId.AddTask) != null)
                {
                    WinCreateTask addTask = new WinCreateTask();
                    addTask.ShowDialog();

                    if (addTask.DialogResult == true)
                    {
                        ReloadTasks();
                    }
                }
                else
                {
                    MessageBox.Show("You do not have access.");
                }
            }
        }

        /// <summary>
        /// Run when the window opens
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ReloadTasks();
        }//End

        /// <summary>
        /// Load tasks for all panels by user and stage
        /// </summary>
        public void ReloadTasks()
        {
            int userId = ApplicationStore.Instance.UserId;

            LoadTasksPanel panelLoader = new LoadTasksPanel();
            panelLoader.LoadTask(PanelToDo, userId, TaskStages.ToDoStage);
            panelLoader.LoadTask(PanelDoing, userId, TaskStages.DoigStage);
            panelLoader.LoadTask(PanelReview, userId, TaskStages.ReviewStage);
            panelLoader.LoadTask(PanelDone, userId, TaskStages.DoneStage);
            panelLoader.LoadTask(PanelCancelled, userId, TaskStages.CanalledStage);
        }//End

        /// <summary>
        /// Permission for opening and using the UserList form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
            {
                if (db.UserPermissionsRepository.CheckPermission(ApplicationStore.Instance.UserId, PermissionId.AccessUsers) != null)
                {
                    WinUsersList panleUser = new WinUsersList();
                    panleUser.ShowDialog();
                }
                else
                {
                    MessageBox.Show("You do not have access.");
                }
            }    
        }//End

        /// <summary>
        /// Method to open the login form and close the current form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            WinLogin login = new WinLogin();
            this.Close();
            login.ShowDialog();
        }//End
    }
}
