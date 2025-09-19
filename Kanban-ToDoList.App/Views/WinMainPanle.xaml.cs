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
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreatedTask_Click(object sender, RoutedEventArgs e)
        {
            WinCreateTask addTask = new WinCreateTask();
            addTask.ShowDialog();
        }
    }
}
