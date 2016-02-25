
namespace Blue.Data.Sql.Customers
{
    public sealed class SqlCommands
    {
        public static string GetCustomersWithInvoices = @"select Firstname, Lastname, Phone, Email, Invoices.ID, Parts.Descr [Part], Parts.Created [Created],
            from Customers 
            inner join invoices on Invoices.CustomerId = Customers.ID 
            inner join Parts on Parts.ID = Invoices.PartId
            where customers.ID=@0";
    }
}
