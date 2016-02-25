using Blue.Data.Models;
using Blue.Data.Repositories;

namespace Blue.Data.Controllers
{
    public partial class ControllerContainer
    {
        public sealed partial class CustomerController : GenericControllerBase<Customer>, IController<Customer>
        {
            public CustomerController()
                : base(new RepositoryContainer.CustomerRepository(), "Customers")
            {
            }
        }

        public sealed partial class PartController : GenericControllerBase<Part>, IController<Part>
        {
            public PartController()
                : base(new RepositoryContainer.PartRepository(), "Parts")
            {
            }
        }

        public sealed partial class PartHistoryController : GenericControllerBase<PartHistory>, IController<PartHistory>
        {
            public PartHistoryController()
                : base(new RepositoryContainer.PartHistoryRepository(), "History")
            {
            }
        }

        public sealed partial class StockController : GenericControllerBase<Stock>, IController<Stock>
        {
            public StockController()
                : base(new RepositoryContainer.StockRepository(), "Stock")
            {
            }
        }

        public sealed partial class InvoiceController : GenericControllerBase<Invoice>, IController<Invoice>
        {
            public InvoiceController()
                : base(new RepositoryContainer.InvoiceRepository(), "Invoices")
            {
            }
        }

        public sealed partial class UserObjectController : GenericControllerBase<UserObject>, IController<UserObject>
        {
            public UserObjectController()
                : base(new RepositoryContainer.UserObjectRepository(), "UserObject")
            {
            }
        }

        public sealed partial class RolesController : GenericControllerBase<Role>, IController<Role>
        {
            public RolesController()
                : base(new RepositoryContainer.RolesRepository(), "Roles")
            {
            }
        }

        public sealed partial class UserRolesController : GenericControllerBase<UserRoles>, IController<UserRoles>
        {
            public UserRolesController()
                : base(new RepositoryContainer.UserRolesRepository(), "UserRoles")
            {
            }
        }

        public sealed partial class OrderHeaderController : GenericControllerBase<OrderHeader>, IController<OrderHeader>
        {
            public OrderHeaderController()
                : base(new RepositoryContainer.OrderHeaderRepository(), "OrderHeader")
            {
            }
        }

        public sealed partial class OrderDetailController : GenericControllerBase<OrderDetail>, IController<OrderDetail>
        {
            public OrderDetailController()
                : base(new RepositoryContainer.OrderDetailRepository(), "OrderDetail")
            {
            }
        }

        public sealed partial class SessionController : GenericControllerBase<Session>, IController<Session>
        {
            public SessionController()
                : base(new RepositoryContainer.OrderDetailRepository(), "Sessions")
            {
            }
        }

        public sealed partial class AuditController : GenericControllerBase<Audit>, IController<Audit>
        {
            public AuditController()
                : base(new RepositoryContainer.AuditRepository(), "Audit")
            {
            }
        }

        public sealed partial class LockController : GenericControllerBase<Lock>, IController<Lock>
        {
            public LockController()
                : base(new RepositoryContainer.LockRepository(), "Locks")
            {
            }
        }
    }
}
