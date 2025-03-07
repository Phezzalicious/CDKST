
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using dotenv.net;
namespace CDKST.Services
{
    public class EmailSender : IEmailSender
    {
        private string ApiKey {get; set;}
         private string ApiUser {get; set;}
        public EmailSender()
        {
             //dotenv
            DotEnv.Config();
            ApiKey = Environment.GetEnvironmentVariable("SEND_GRID_KEY");
            ApiUser = Environment.GetEnvironmentVariable("SEND_GRID_USER");
            //Options = optionsAccessor.Value;
        }
       
        //public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
        {
            Console.WriteLine("     SendEmailAsync");
            return Execute(ApiKey, subject, message, email);
        }

        public Task Execute(string apiKey, string subject, string message, string email)
        {
            Console.WriteLine("Execute");
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("starfish206@gmail.com", ApiUser),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }
    }
}


//dotnet user-secrets set SendGridUser phezzalicious
//dotnet user-secrets set SendGridKey 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