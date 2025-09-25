// System
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

// Internal



namespace Kanban_ToDoList.App.Views
{
    /// <summary>
    /// Interaction logic for WinPermissionUser.xaml
    /// </summary>
    public partial class WinPermissionUser : Window
    {
        public int UserId { get; set; } 
        public string UserName { get; set; }
        public WinPermissionUser()
        {
            InitializeComponent();
        }
    }
}
