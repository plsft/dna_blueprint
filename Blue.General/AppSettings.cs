using System;
using Helix.Utility;

namespace Blue.General
{
    public sealed class AppSettings
    {
        public static string ApplicationName => "Blueprint";

        public static string Culture => Settings.Get("culture_lang").DefaultValue("en-US");

        public static string MailServer => Settings.Get("mail_server").DefaultValue("localhost");

        public static bool MailUseAuthFlag => Settings.Get("mail_use_auth_flag").DefaultValue("true") == "true";

        public static string MailServerUsername => Settings.Get("mail_username").DefaultValue("mailer");

        public static string MailServerPwd => Settings.Get("mail_username").DefaultValue("mailer");

        public static int MailServerPort => Convert.ToInt16(Settings.Get("mail_port"));

        public static string DefaultFromEmail => Settings.Get("default_email");

        public static bool ApiHealthLogging => Settings.Get("api_health_logging").DefaultValue("0") == "1";

        public static bool GranularAudit => Settings.Get("granular_audit_level").DefaultValue("1") == "1";

        public static int RecordLockExpirationInMin => int.Parse(Settings.Get("record_lock_expiration_min").DefaultValue("20"));

        public static string ApplicationUrl => Settings.Get("application_url").DefaultValue("http://localhost:50142/");
    }
}
