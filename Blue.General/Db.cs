using System.Collections.Generic;
using System.Linq;
using Helix.Infra.Peta;

namespace Blue.General
{
    public class Db
    {
        private static readonly Database _db;
        private static readonly object o;

        static Db()
        {
            _db = new Database(Config.DbConnectionStringName);
            o = new object();
        }

        public static IEnumerable<dynamic> Fetch(string query, params object[] args)
        {
            lock (o)
            {
                return _db.Fetch<dynamic>(query, args).ToList();
            }
        }

        public static IEnumerable<string> FetchString(string query, params object[] args)
        {
            lock (o)
            {
                return _db.Fetch<string>(query, args).ToList();
            }
        }

        public static IEnumerable<int> FetchInt(string query, params object[] args)
        {
            lock (o)
            {
                return _db.Fetch<int>(query, args).ToList();
            }
        }


        public static int ExecuteSql(string query, params object[] args)
        {
            lock (o)
            {
                return _db.Execute(query, args);
            }
        }

        public static T ExecuteScalar<T>(string q, params object[] args)
        {
            lock (o)
            {
                try
                {
                    return _db.ExecuteScalar<T>(q, args);
                }
                catch
                {
                    return default(T);
                }
            }
        }
    }
}
