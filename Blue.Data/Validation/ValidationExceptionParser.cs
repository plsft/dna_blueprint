using System.Data.SqlClient;

namespace Blue.Data.Validation
{
    public sealed class ValidationExceptionParser
    {
        public string ValidationErrorMessage { get; set; }

        public ValidationExceptionParser(string tableName, SqlException ex)
        {
            foreach (SqlError e in ex.Errors)
            {
                switch (e.Number)
                {
                    case 2627: ValidationErrorMessage += $" {e.Number}: data must be unique in table {tableName}"; break;
                    case 3621:
                        continue;
                }
               
            }
        }
    }
}
