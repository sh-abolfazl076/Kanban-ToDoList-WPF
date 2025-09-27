// System
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CommunityToolkit.WinUI.Notifications;
// Internal
using Kanban_ToDoList.App.Views;
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
            panel.Children.Clear();
            using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
            {
                var getTasks = db.TasksRepository.GetAllTasksByUserIdAndStageId(userId, stageId);
                foreach (var item in getTasks)
                {
                    // Call CreateBtn method
                    CreateButton(panel, item.Title, item.ID, item.Description, userId, stageId, item.Duration , (DateTime)item.CreatedAt);

                }
            }


        }//End

        /// <summary>
        /// Create a button for each row based on its status and user
        /// Check if task has a deadline
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="title"></param>
        /// <param name="id"></param>
        /// <param name="info"></param>
        /// <param name="value"></param>
        /// <param name="userId"></param>
        /// <param name="stageId"></param>
        private void CreateButton(StackPanel panel, string title, int idTask, string Description, int userId, int stageId, int? duration, DateTime createdAt)
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


            if (duration.HasValue)
            {
                DateTime deadLine = createdAt.Date.AddDays(duration.Value);
                DateTime today = DateTime.Now.Date;

                if (today >= deadLine)
                {
                    btn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9E9E9E"));

                    using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
                    {
                        var task = db.TasksRepository.GetTaskById(idTask);
                        if (task != null)
                        {
                            task.StageId = 5;
                            db.TasksRepository.UpdateTask(task);
                            db.Save(); 
                        }
                    }
                }

            }

            panel.Children.Add(btn); // Add the button to the 

            btn.Click += (s, e) =>
            {
                WinTask frm = new WinTask
                {
                    Title = title,
                    Description = Description,
                    UserId = userId,
                    TaskId = idTask,
                    StageId = stageId,
                };

                frm.Closed += (sender, args) =>
                {
                    var existing = Application.Current.Windows.OfType<WinMainPanle>().FirstOrDefault();
                    if (existing != null)
                    {
                        existing.ReloadTasks();
                    }
                };
                frm.ShowDialog();

            };

        }//End

    }
}
