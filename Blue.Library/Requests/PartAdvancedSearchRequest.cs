using System.Collections.Specialized;
using Blue.Data.Extentions;
using Helix.Infra.Peta;

namespace Blue.Library.Requests
{
    public sealed class PartAdvancedSearchRequest
    {
        private readonly Sql _sql;

        public string Sql => _sql == null ? "" : _sql.SQL;
        public string Description { get; set; }
        public int Status { get; set; }
        public float Amount { get; set;  }

        public PartAdvancedSearchRequest(int ID=0, string descr="", int status = 0, float amount = 0f, int invoiceStatus = 0)
        {
            _sql = new Sql();
            Description = descr;
            Status = status;
            Amount = amount;

            var sql = _sql.Select("parts.ID, parts.descr, parts.amount, parts.status")
                .From("Parts")
                .InnerJoin("Invoices")
                .On("invoices.partId=parts.Id");

            if (!string.IsNullOrEmpty(descr))
                sql.Where($"parts.descr like '%{descr}%'");

            if (status >= 0)
                sql.Where($"parts.[status] >= {status}");

            if (amount >= 0f)
                sql.Where($"parts.[amount] >= {amount}");

            if (ID > 0)
                sql.Where($"ID >= {ID}");

            if (invoiceStatus > 0)
                sql.Where($"invoices.status >= {invoiceStatus}");

        }

        public PartAdvancedSearchRequest(NameValueCollection c) : this(c["ID"].ToInt32(), c["descr"], c["status"].ToInt16(), c["amount"].ToSingle())
        {

        }

    }
}
