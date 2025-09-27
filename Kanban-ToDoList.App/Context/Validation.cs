// System
using System.Windows;


// Internal



namespace Kanban_ToDoList.App.Context
{
    public static class Validation
    {

        /// <summary>
        /// This method checks that username and password are not empty and have valid length.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool IsUsernameAndPasswordValid(string username, string password)
        {
            if (username == "" || password == "")
            {
                MessageBox.Show("UserName Connot be Empty.");
                return false;
            }
            if (username.Length > 100 || password.Length > 200)
            {
                MessageBox.Show("Username or password exceeds the allowed limit.");
                return false;
            }
            return true;
        }//End


        /// <summary>
        /// This method checks two passwords.
        /// Password and confirm password are the same
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordChek"></param>
        /// <returns></returns>
        public static bool IsPasswordConfirmed(string password, string passwordChek)
        {
            if (password != passwordChek)
            {
                MessageBox.Show("The amount is not one..");
                return false;
            }
            return true;
        }//End


        /// <summary>
        /// This method checks that username and password are not empty and have valid length.
        /// Checks that duration is current and values ​​are numeric.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool IsCreateTaskFormValid(string title, string Info, string duration)
        {
            if (title == "" || Info == "")
            {
                MessageBox.Show("UserName Connot be Empty.");
                return false;
            }
            if (title.Length > 200 || Info.Length > 900)
            {
                MessageBox.Show("Title or Info exceeds the allowed limit.");
                return false;
            }
            if (!string.IsNullOrEmpty(duration) && (!int.TryParse(duration, out int d) || d <= 0))
            {
                MessageBox.Show("Duration must be a number.");
                return false;
            }
            return true;
        }//End

        public static bool IsTaskFormValid(string title, string Info, int comboBoxStage)
        {
            if (title == "" || Info == "")
            {
                MessageBox.Show("UserName Connot be Empty.");
                return false;
            }
            if (title.Length > 200 || Info.Length > 900)
            {
                MessageBox.Show("Title or Info exceeds the allowed limit.");
                return false;
            }
            if (comboBoxStage < 0)
            {
                MessageBox.Show("Duration must be a number.");
                return false;
            }
            return true;
        }//End

    }
}
