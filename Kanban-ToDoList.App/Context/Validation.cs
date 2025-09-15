// System
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
        public static bool IsUsernameAndPasswordValid(string username , string password)
        {
            if (username == "" && password == "")
            {
                MessageBox.Show("UserName Connot be Empty.");
                return false;
            }
            if (username.Length > 100 && password.Length > 200)
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
        public static bool IsPasswordConfirmed(string password , string passwordChek)
        {
            if (password != passwordChek)
            {
                MessageBox.Show("The amount is not one..");
                return false;
            }
            return true ;
        }//End



    }
}
