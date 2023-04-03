namespace LachaGarden.Models.Mail
{
    public class MailDTO
    {
        public string to { get; set; }
        public string subject { get; set; }
        public string body { get; set; }

        public MailDTO(string to, string subject, string body)
        {
            this.to = to;
            this.subject = subject;
            this.body = body;
        }
    }
}