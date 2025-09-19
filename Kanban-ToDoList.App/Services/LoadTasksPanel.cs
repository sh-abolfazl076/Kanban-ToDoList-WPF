// System
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

// Internal
using Kanban_ToDoList.DataLayer.Context;



namespace Kanban_ToDoList.App.Services
{
    public class LoadTasksPanel
    {
        /// <summary>
        /// Loads task data from the database where the status is StageId and userId 
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="userId"></param>
        /// <param name="stageId"></param>
        public void LoadTask(StackPanel panel, int userId, int stageId)
        {
            using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
            {
                var getTasks = db.TasksRepository.GetAllTasksByUserIdAndStageId(userId, stageId);
                foreach (var item in getTasks)
                {
                    // Call CreateBtn method
                    CreateButton(panel, item.Title, item.ID, item.Description, userId, stageId); 
                }
            }
        }//End

        /// <summary>
        /// Create a button for each row based on its status and user
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="title"></param>
        /// <param name="id"></param>
        /// <param name="info"></param>
        /// <param name="value"></param>
        /// <param name="userId"></param>
        /// <param name="stageId"></param>
        private void CreateButton(StackPanel panel, string title, int idTask, object Description, int userId, int stageId)
        {
            Button btn = new Button
            {
                Content = title,
                Width = 125,
                Height = 45,
                Tag = idTask,
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E91E63")),
                Foreground = Brushes.White,
                Margin = new Thickness(5),
                FontSize = 12,
                FontWeight = FontWeights.Bold
            };

            panel.Children.Add(btn); // Add the button to the 

        }//End

    }
}
