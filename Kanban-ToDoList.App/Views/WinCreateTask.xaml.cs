// System
using Kanban_ToDoList.DataLayer.Context;
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
        }
    }

}
