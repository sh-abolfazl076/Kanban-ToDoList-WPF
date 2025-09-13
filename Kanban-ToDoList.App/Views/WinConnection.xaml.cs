// System
using System.Windows;


// Internal
using Kanban_ToDoList.DataLayer.Context;


namespace Kanban_ToDoList.App.Views
{
    /// <summary>
    /// Interaction logic for ConnectionWindow.xaml
    /// </summary>
    public partial class ConnectionWindow : Window
    {
        public ConnectionWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Geting information from Setting
        /// Set databese connetion information 
        /// Testing the Connetion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckDB_Click(object sender, RoutedEventArgs e)
        {
            string server = txtServer.Text;
            string db = txtDatabes.Text;
            string user = txtUser.Text;
            string pass = txtPass.Text;

            ApplicationStore.Instance.SetConnectionInfo(server, db, user, pass);

            if (ApplicationStore.Instance.TestConnection())
            {
                MessageBox.Show("Connection Was Successful");
            }
            else
            {
                MessageBox.Show("Connection Failed");
            }
        }
    }
}
