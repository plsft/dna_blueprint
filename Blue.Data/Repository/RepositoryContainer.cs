
using System.Net.Sockets;
using Helix.Infra.Peta;
using Blue.Data.Infra;

namespace Blue.Data.Repositories
{
   public sealed class RepositoryContainer
    {
        [TableName("Customers")]
        public sealed class CustomerRepository : AppRepository, IRepository
        {
        }

        [TableName("Parts")]
        public sealed class PartRepository : AppRepository, IRepository
        {
        }

        [TableName("History")]
        public sealed class PartHistoryRepository : AppRepository, IRepository
        {
        }

        [TableName("Invoices")]
        public sealed class InvoiceRepository : AppRepository, IRepository
        {
        }

        [TableName("UserObject")]
        public sealed class UserObjectRepository : AppUserRepository, IRepository
        {
        }

        [TableName("Roles")]
        public sealed class RolesRepository : AppUserRepository, IRepository
        {
        }

        [TableName("UserRoles")]
        public sealed class UserRolesRepository : AppUserRepository, IRepository
        {
        }

        [TableName("Sessions")]
        public sealed class SessionRepository : AppRepository, IRepository
        {
        }

        [TableName("Stock")]
        public sealed class StockRepository : AppRepository, IRepository
        {
        }

        [TableName("OrderHeader")]
        public sealed class OrderHeaderRepository : AppRepository, IRepository
        {
        }

        [TableName("OrderDetail")]
        public sealed class OrderDetailRepository : AppRepository, IRepository
        {
        }

        //This is currently pointing to the "blueprint" database table "audit" but can be moved to another server/database but adjusting connection string in app|web.config
       [TableName("Audit")]
       public sealed class AuditRepository : AppAuditRepository, IRepository
       {
       }

        [TableName("Locks")]
        public sealed class LockRepository : AppRepository, IRepository
        {
        }
    }
}
