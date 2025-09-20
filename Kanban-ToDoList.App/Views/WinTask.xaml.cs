// System
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


// Internal




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
            try
            {
                txtTitle.Text = Title;
                txtInfo.Text = Description;
                comboBoxStage.SelectedIndex = StageId;
            }
            catch
            {
                MessageBox.Show("Error in Loading");
            }
        }//End

        private void btnSaveChange_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
