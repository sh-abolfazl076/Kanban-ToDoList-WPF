using Kanban_ToDoList.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kanban_ToDoList.DataLayer.Context
{
    public class ApplicationStore
    {
        private static readonly Lazy<ApplicationStore> _instance =
            new Lazy<ApplicationStore>(() => new ApplicationStore());

        public static ApplicationStore Instance => _instance.Value;
        private ApplicationStore() { }

        public string ServerName { get; private set; }
        public string DatabaseName { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        /// <summary>
        /// Get Info from form connetion
        /// </summary>
        /// <param name="server"></param>
        /// <param name="database"></param>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        public void SetConnectionInfo(string server, string database, string user, string pass)
        {
            ServerName = server;
            DatabaseName = database;
            Username = user;
            Password = pass;
        }// End

        // make connection
        public string EfConnectionString =>
            $@"metadata=res://*/Model.KanbanModel.csdl|
        res://*/Model.KanbanModel.ssdl|
        res://*/Model.KanbanModel.msl;
        provider=System.Data.SqlClient;
        provider connection string=""Data Source={ServerName};Initial Catalog={DatabaseName};User ID={Username};Password={Password};MultipleActiveResultSets=True;App=EntityFramework""";


        /// <summary>
        /// Text connetion
        /// </summary>
        /// <returns></returns>
        public bool TestConnection()
        {
            try
            {
                using (var ctx = new KanbanToDoListWPFEntities(EfConnectionString))
                {
                    ctx.Database.Connection.Open();
                    ctx.Database.Connection.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }// End
    }
}
