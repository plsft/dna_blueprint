using System.Collections.Generic;
using Blue.Data.CustomModels;

namespace Blue.Data.ViewModels
{
    public sealed class CustomerInvociePartView : ViewModelBase
    {
        public IList<CustomerInvoicePartModel> View { get; set; }

        public CustomerInvociePartView(int customerId)
        {
            View = base.db.Fetch<CustomerInvoicePartModel>(Sql.Customers.SqlCommands.GetCustomersWithInvoices, customerId);
        }

        public CustomerInvociePartView(IList<CustomerInvoicePartModel> view)
        {
            View = view;
        }
    }
}
