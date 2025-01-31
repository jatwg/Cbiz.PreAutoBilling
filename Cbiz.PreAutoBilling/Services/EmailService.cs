using System.Threading.Tasks;
using NLog;
using Cbiz.PreAutoBilling.Helpers;

namespace Cbiz.PreAutoBilling.Services
{
    public class EmailService
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public void SendEmail(string to, string subject, string body)
        {
            var sanitizedEmail = EmailHelper.SanitizeEmail(to);
            
            if (string.IsNullOrEmpty(sanitizedEmail))
            {
                Logger.Error($"Invalid email address after sanitization: '{to}'");
                return;
            }

            // Proceed with sending email using sanitizedEmail
            // ... rest of your email sending code ...
        }
    }
} 