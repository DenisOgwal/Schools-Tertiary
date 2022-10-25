using System.Configuration;

namespace College_Management_System
{
    class ConnectionString
    {
        public static string userconnection = Properties.Settings.Default.realcon;
        public string DBConn = userconnection;
        public string MysqlDBConn = "Server=localhost;Database=bs;Uid=root;Password=''";
        public string branchname = ConfigurationManager.AppSettings.Get("branches");
    }
}
