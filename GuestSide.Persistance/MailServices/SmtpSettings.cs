namespace Core.Persistance.MailServices
{
    public class SmtpSettings
    {
        public string SenderEmail { get; set; }

        public string Password { get; set; }

        public string SmtpAddress { get; set; }

        public int PortNumber { get; set; }
    }
}
