// System
using Kanban_ToDoList.DataLayer.Context;
using Kanban_ToDoList.DataLayer.Model;
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTask_Click(object sender, RoutedEventArgs e)
        {

        }//End
    }


}
