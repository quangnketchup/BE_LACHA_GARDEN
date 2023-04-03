using BussinessLayer.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LachaGarden.Models.Mail;
using System.Net.Mail;
using MimeKit;
using MailKit.Security;

namespace LachaGarden.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendMail(string body)
        {
            MailAddress mailAddressmail;
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("lachagarden@gmail.com"));
            email.To.Add(MailboxAddress.Parse("dangkhoahoang39@gmail.com"));
            email.Subject = "Chào anh iu";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            Console.WriteLine(SecureSocketOptions.Auto);
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("lachagarden@gmail.com", "jvqfbnngetoqbtbw");
            smtp.Send(email);
            smtp.Disconnect(true);
            return Ok();
        }
    }
}