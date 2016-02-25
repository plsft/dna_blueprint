using System.Collections.Generic;
using Helix.Infra.Peta;

namespace Blue.Data.Controllers
{
    public interface IController<T> where T : class
    {
        int Save(T item, bool validateEntity = false, string endPoint = "", string transID = "");
        int Add(T item, bool validateEntity = false, string endPoint = "", string transID = "");
        int Update(object o, int id, string primaryKeyName, string tableName);
        bool Destroy(int id);
        bool Destroy(string domainSql, params object[] args);
        T Select(int id);
        IEnumerable<T> Select(string sql, params object[] args);
        IEnumerable<T> All();
        Page<T> Paged(long page, long items, string sql, params object[] args);
    }
}
