using BussinessLayer.IRepository;
using DataAccessLayer.Models;
using MailKit.Security;
using MimeKit;
using System.IO;
using System.Net.Mail;

namespace LachaGarden.Models.Mail
{
    public class MailGarden
    {
        private IUserRepository _userRepository;

        public void sendMail(string name, string emailCus, string namePack)
        {
            string body = "<h3>Gửi bạn " + name + "," +
                "<h5>Bạn đã mua thành công gói " + namePack + " của chúng mình </h5>" +
                "<h5>Cảm ơn bạn vì đã chọn chúng tôi. Hy vọng bạn sẽ có trải nghiệm tuyệt vời khi sử dụng sản phẩm/dịch vụ của chúng tôi. Rất mong sẽ tiếp tục nhận được sự ủng hộ của bạn trong thời gian tới.<h5>" +
                "<h4>Thanks,</h4>" +
                "<h4>lachagarden</h4>";

            MailAddress mailAddressmail;
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("lachagarden@gmail.com"));
            email.To.Add(MailboxAddress.Parse(emailCus));
            email.Date = DateTime.Now;
            email.Subject = "Thanh Toán Thành Công";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = body,
            };

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            Console.WriteLine(SecureSocketOptions.Auto);
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("lachagarden@gmail.com", "jvqfbnngetoqbtbw");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}