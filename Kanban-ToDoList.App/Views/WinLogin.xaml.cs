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
    /// Interaction logic for WinLogin.xaml
    /// </summary>
    public partial class WinLogin : Window
    {
        public WinLogin()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Open Connection Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWinConnection_Click(object sender, RoutedEventArgs e)
        {
            ConnectionWindow connect = new ConnectionWindow();
            this.Close();
            connect.ShowDialog();
        }// End


        /// <summary>
        /// Open Register form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWinRegister_Click(object sender, RoutedEventArgs e)
        {
            WinRegister singUp = new WinRegister();
            this.Close();
            singUp.ShowDialog();
        }// End

    }
}
