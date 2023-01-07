namespace ECommerce.Application.Abstractions.Services
{
    public interface IMailService
    {
        Task SendMessageAsync(string to,string subject, string body, bool isBodtHtml = true);
        Task SendMessageAsync(string[] to, string subject, string body, bool isBodyHtml = true);

    }
}
