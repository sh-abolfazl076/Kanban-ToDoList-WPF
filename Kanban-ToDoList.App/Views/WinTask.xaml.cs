// System
using Kanban_ToDoList.App.Context;
using Kanban_ToDoList.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


// Internal
//using Task = Kanban_ToDoList.DataLayer.Model.Task;



namespace Kanban_ToDoList.App.Views
{
    /// <summary>
    /// Interaction logic for WinTask.xaml
    /// </summary>
    public partial class WinTask : Window
    {
        // Properties to set from main window
        public string TitleText { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int TaskId { get; set; }
        public int StageId { get; set; }

        public WinTask()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loading information into WinTask
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
            {
                txtTitle.Text = Title;
                txtInfo.Text = Description;
                comboBoxStage.SelectedIndex = StageId - 1;

                if (db.UserPermissionsRepository.CheckPermission(ApplicationStore.Instance.UserId, PermissionId.ModifyTask) == null)
                {
                    btnSaveChange.Visibility = Visibility.Collapsed;
                    txtTitle.IsReadOnly = true;
                    txtInfo.IsReadOnly = true;
                    comboBoxStage.IsEnabled = false;
                }
            }
        }//End


        /// <summary>
        /// Save changes of task
        /// </summary>
        /// <param name="sender">The button click event<</param>
        /// <param name="e"></param>
        private void btnSaveChange_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = comboBoxStage.SelectedIndex;
            bool IsTaskFormValid = Context.Validation.IsTaskFormValid(txtTitle.Text, txtInfo.Text, comboBoxStage.SelectedIndex);
            if (IsTaskFormValid)
            {
                try
                {
                    using (UnitOfWork db = new UnitOfWork(ApplicationStore.Instance.EfConnectionString))
                    {
                        var task = db.TasksRepository.GetTaskById(TaskId);
                        if (task != null)
                        {
                            task.Title = txtTitle.Text;
                            task.Description = txtInfo.Text;
                            //task.Description = Description;
                            task.UpdatedAt = DateTime.Now;
                            task.StageId = selectedIndex + 1;
                            db.TasksRepository.UpdateTask(task);
                            db.Save();

                            this.Close();

                        }
                    }
                }
                catch
                {

                    MessageBox.Show("Database Error");
                }
            }
        }//End

        /// <summary>
        /// Open Main Panlel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }//End
    }
}
