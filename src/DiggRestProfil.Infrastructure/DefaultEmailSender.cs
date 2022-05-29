using DiggRestProfil.Core.Interfaces;

namespace DiggRestProfil.Infrastructure
{
    public class DefaultEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string to, string from, string subject, string body)
        {
            return Task.CompletedTask;
        }
    }
}
