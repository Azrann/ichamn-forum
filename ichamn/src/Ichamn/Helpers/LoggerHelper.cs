using System;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Ichamn.Helpers
{
    public class LoggerHelper
    {
        private SqlConnection m_connection;
        private const string SqlInsert = "EXEC InsertLogEntry '{0}','{1}'";
        public SqlConnection MyConnection
        {
            get { return m_connection ?? (m_connection = new SqlConnection(GetConnectionString())); }
        }

        public string GetConnectionString()
        {
            return WebConfigurationManager.ConnectionStrings["ichamn"].ConnectionString;
        }

        public void ExecuteNonQuery(string p_sql)
        {
            using (MyConnection)
            {
                var command = new SqlCommand(p_sql, MyConnection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void LogError(string p_message)
        {
            ExecuteNonQuery(String.Format(SqlInsert,"E",p_message));
        }

        public void LogInfo(string p_message)
        {
            ExecuteNonQuery(String.Format(SqlInsert, "I", p_message));
        }
    }
}