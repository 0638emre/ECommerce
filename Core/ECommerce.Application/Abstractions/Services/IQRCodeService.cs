namespace ECommerce.Application.Abstractions.Services
{
    public interface IQRCodeService
    {
        Byte[] GenerateQRCode(string text);
    }
}
