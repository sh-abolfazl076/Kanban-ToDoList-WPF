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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnSaveChange_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
