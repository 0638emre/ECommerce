namespace ECommerce.Application.Abstractions.Services
{
    public interface IProductService
    {
        Task<Byte[]> QrCodeToProductAsync(string productId);
        Task StockUpdateToProductAsync(string productId, int stock);
    }
}
