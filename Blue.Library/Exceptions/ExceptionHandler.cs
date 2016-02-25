using System;

namespace Blue.Library.Exceptions
{
    public sealed class ExceptionsHandler
    {
        private static readonly object o;

        static ExceptionsHandler()
        {
            o = new object();
        }

        public static void Process(Exception ex)
        {
            lock (o)
            {
                if (ex.Message.Contains("Validation"))
                    ex.Data["Type"] = "validation"; 

                switch (ex.Data["Type"]?.ToString().ToLower())
                {
                    case "validation": throw new ValidationException(ex.Message, ex);
                    case "app": throw new BlueprintAppException(ex.Message, ex);
                    case "token": throw new InvalidTokenException(ex.Message, ex);

                    default: throw new Exception(ex.Message, ex);
                }
            }
        }

    }
}
