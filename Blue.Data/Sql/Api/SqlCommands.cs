
namespace Blue.Data.Sql.Api
{
    public sealed class SqlCommands
    {
        public static string InsertApiHealthRecordSql = @"insert into ApiHealth (Domain, Status, Message, Token, QueryTimeMs, Code, Hostname, RequestId) values ( @0, @1, @2, @3, @4, @5, @6, @7 )";
    }
}
