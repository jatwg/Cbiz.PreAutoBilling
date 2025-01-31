namespace Cbiz.PreAutoBilling.Core.Models
{
    public class EmailSettings
    {
        public required string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public required string FromEmail { get; set; }
        public required string Password { get; set; }
    }
} 