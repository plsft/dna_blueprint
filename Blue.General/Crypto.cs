
namespace Blue.General
{
    public sealed class Crypto
    {
        private static object o;

        static Crypto()
        {
            o = new object();
        }

        public static string HashString(string value)
        {
            lock (o)
            {
                return Helix.Security.Crypto.HashString(value);
            }
        }
    }
}