using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;

namespace Serwer_TS_.Database
{
    class Connector : DbContext
    {
        private const string DEFAULT_DB_CONFIG_NAME = "Base";

        private static Connector m_oInstance;

        private Connector() : base (DEFAULT_DB_CONFIG_NAME)
        {
        }

        private Connector(string sConnectionString) : base(new SQLiteConnection() { ConnectionString = sConnectionString }, true)
        {
        }

        static public Connector GetInstance()
        {
            return ((m_oInstance == null) ? m_oInstance = new Connector() : m_oInstance);
        }

        public string GetPassword (string Login)
        {
            return Database.SqlQuery<string>(Query.GET_PASSWORD, Login).SingleOrDefault();
        }
    }
}
