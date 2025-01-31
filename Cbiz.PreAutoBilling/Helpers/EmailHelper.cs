using System.Text.RegularExpressions;
using NLog;

namespace Cbiz.PreAutoBilling.Helpers
{
    public static class EmailHelper
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public static string SanitizeEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                Logger.Warn("Empty email address provided for sanitization");
                return string.Empty;
            }

            // Remove any trailing dots or semicolons
            email = email.TrimEnd('.', ';');

            // Split on semicolons or dots (in case there are multiple emails)
            var emails = email.Split(new[] { ';', '.' }, StringSplitOptions.RemoveEmptyEntries);

            // Take the first email and trim it
            var sanitizedEmail = emails[0].Trim();

            if (email != sanitizedEmail)
            {
                Logger.Debug($"Email sanitized from '{email}' to '{sanitizedEmail}'");
            }

            // Validate the email format
            if (!IsValidEmail(sanitizedEmail))
            {
                Logger.Warn($"Invalid email format after sanitization: '{sanitizedEmail}'");
                return string.Empty;
            }

            return sanitizedEmail;
        }

        private static bool IsValidEmail(string email)
        {
            // Basic email validation using regex
            var pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }
    }
} 