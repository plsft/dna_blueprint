using System;
using System.Collections.Generic;
using System.Linq;

using Blue.Data.Controllers;
using Blue.Data.Extentions;
using Blue.Data.Models;

namespace Blue.Data.Infra
{
    public sealed class Auditor
    {
        public sealed class AuditAction
        {
            public string Endpoint { get; set; }
            public string Operation { get; set; }
            public int UserId { get; set; }
            public string TransactionID { get; set; }
        }

        private static object o;

        static Auditor()
        {
            o = new object();
        }

        public static bool Add<T>(AuditAction action, T self, T to, params string[] ignored) where T : class
        {
            lock (o)
            {
                var auditController = new ControllerContainer.AuditController();

                if (self == null || to == null)
                    return false;

                var type = typeof (T);
                var ignoreList = new List<string>(ignored).ConvertAll(i => i.ToLower());

                foreach (var p in type.GetProperties().Where(p => !ignoreList.Contains(p.Name.ToLower())))
                {
                    var newValue = Convert.ToString(type.GetProperty(p.Name).GetValue(to, null));
                    var oldValue = Convert.ToString(type.GetProperty(p.Name).GetValue(self, null));

                    if (!newValue.Equals(oldValue, StringComparison.CurrentCultureIgnoreCase))
                    {
                        var audit = new Audit
                        {
                            Column = p.Name,
                            Endpoint = action.Endpoint,
                            NewValue = newValue,
                            OldValue = oldValue,
                            Operation = action.Operation,
                            Table = typeof (T).Name.Pluralize(),
                            UserId = action.UserId,
                            TransactionID = action.TransactionID
                        };

                        auditController.Save(audit);
                    }
                }

                return true;
            }
        }
    }
}
