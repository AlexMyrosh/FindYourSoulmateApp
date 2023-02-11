using System.Threading.Tasks;
using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using MimeKit;
using MailKit.Net.Smtp;

namespace Business_Logic_Layer.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(UserModel user, string subject, string message)
        {
            using var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Твій Миколай від ХНЕУ", "hneu.valentine@gmail.com"));
            emailMessage.To.Add(new MailboxAddress(user.Name, user.Email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 465, true);
                await client.AuthenticateAsync("hneu.valentine@gmail.com", "pzhitzidwafkjmkq");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}
