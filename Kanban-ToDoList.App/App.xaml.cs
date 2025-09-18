// System
using System.Windows;


// Internal
using Kanban_ToDoList.App.Views;
using Kanban_ToDoList.DataLayer.Context;
using Kanban_ToDoList.App.Properties;

namespace Kanban_ToDoList.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ApplicationStore.Instance.SetConnectionInfo(
                Settings.Default.ServerName,
                Settings.Default.DatabaseName,
                Settings.Default.DbUsername,
                Settings.Default.DbPassword
            );

            if (ApplicationStore.Instance.TestConnection())
            {
                WinLogin connect = new WinLogin();
                connect.ShowDialog();
            }
            else
            {
                ConnectionWindow connection = new ConnectionWindow();
                connection.Show();
            }
        }//End
    }
}
