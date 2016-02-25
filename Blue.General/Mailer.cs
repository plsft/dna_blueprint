using System;
 
using System.Net;
using System.Net.Mail;
using System.Text;
 
using Helix.Utility;
using RazorTemplates.Core;

namespace Blue.General
{
    public sealed class Mailer
    {
        private static readonly object o;

        static Mailer()
        {
            o = new object();
        }

        public static bool SendEmail(string to, string subject, string body, dynamic model, int sev = 0, string from = "defaultEmail")
        {
            lock (o)
            {
                try
                {
                    var defaultFrom = from == "defaultEmail" ? AppSettings.DefaultFromEmail : from;

                    var compiledBodyTemplate = Template.Compile(body);
                    var compiledSubjectTemplate = Template.Compile(subject);

                    var msg = new MailMessage(defaultFrom, to)
                    {
                        Body = model == null ? body : compiledBodyTemplate.Render(model),
                        Subject = model == null ? subject : compiledSubjectTemplate.Render(model),
                        Priority = GetMailPriority(sev), 
                        IsBodyHtml = body.Contains("DOCTYPE HTML") || body.Contains("DOCTYPE html"),
                        BodyEncoding = Encoding.UTF8
                    };


                    using (var smtp = new SmtpClient())
                    {
                        smtp.Host = AppSettings.MailServer;
                        smtp.UseDefaultCredentials = false;
                        smtp.Timeout = 30000;
                        smtp.EnableSsl = false;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Credentials = AppSettings.MailUseAuthFlag ? new NetworkCredential(AppSettings.MailServerUsername, AppSettings.MailServerPwd) : null;
                        smtp.Port = AppSettings.MailServerPort;
                        smtp.Send(msg);
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    Logger.Log("Unable to send email", "Exception=[{0}]", Logger.LogType.Error, ex);
                    throw;
                }
            }

        }
        private static MailPriority GetMailPriority(int sev)
        {
            switch (sev)
            {
                case 0:
                    return MailPriority.Low;
                case 1:
                    return MailPriority.Normal;
                case 2:
                    return MailPriority.High;

                default:
                    return MailPriority.Normal;
            }
        }
    }
}
