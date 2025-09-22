// System
using System.Windows;

// Internal
using Kanban_ToDoList.App.Services;
using Kanban_ToDoList.DataLayer.Context;
using Kanban_ToDoList.App.Context;


namespace Kanban_ToDoList.App.Views
{
    /// <summary>
    /// Interaction logic for WinMainPanle.xaml
    /// </summary>
    public partial class WinMainPanle : Window
    {
        public WinMainPanle()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This event is used to open the "Add Task" window
        /// refresh main panel after closing Create task window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreatedTask_Click(object sender, RoutedEventArgs e)
        {
            WinCreateTask addTask = new WinCreateTask();
            addTask.ShowDialog();

            if (addTask.DialogResult == true) 
            {
                ReloadTasks();
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

    }
}
