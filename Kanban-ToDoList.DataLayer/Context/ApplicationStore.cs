// System
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


// Internal



namespace Kanban_ToDoList.App.Context
{
    public class ApplicationStore
    {
        private static readonly Lazy<ApplicationStore> _instance =
            new Lazy<ApplicationStore>(() => new ApplicationStore());

        private ApplicationStore() { }

        public static ApplicationStore Instance => _instance.Value;

        public string ServerName { get; private set; }
        public string DatabaseName { get; private set; }
        public string DbUsername { get; private set; }
        public string DbPassword { get; private set; }

        public void SetConnectionInfo(string server, string database, string username, string password)
        {
            ServerName = server;
            DatabaseName = database;
            DbUsername = username;
            DbPassword = password;
        }

        public string RawConnectionString =>
            $"Data Source={ServerName};Initial Catalog={DatabaseName};User ID={DbUsername};Password={DbPassword};Encrypt=False;";

        public string EfConnectionString =>
            $@"metadata=res://*/Model.KanbanModel.csdl|
               res://*/Model.KanbanModel.ssdl|
               res://*/Model.KanbanModel.msl;
               provider=System.Data.SqlClient;
               provider connection string=""{RawConnectionString};
               MultipleActiveResultSets=True;
               App=EntityFramework""";

        public DbCompiledModel ConnectionString { get; internal set; }

        public bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(RawConnectionString))
                {
                    conn.Open();
                    MessageBox.Show(EfConnectionString);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
