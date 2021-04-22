using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinalProgramacionAvanzada.Utility
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<SendGridOptions> options)
        {
            _options = options.Value;
        }
        readonly SendGridOptions _options;
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(email, subject, message);
        }
        async Task Execute(string email, string subject, string message)
        {
            var client = new SendGridClient(_options.Key);
            var from = new EmailAddress(_options.Correo, _options.Nombre);
            var to = new EmailAddress(email, "End User");
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", message);
            await client.SendEmailAsync(msg);
        }
    }
}
