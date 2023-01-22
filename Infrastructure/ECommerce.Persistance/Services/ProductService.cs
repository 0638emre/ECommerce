using ECommerce.Application.Abstractions.Services;
using ECommerce.Application.Exceptions;
using ECommerce.Application.Repositories.ProductRepository;
using ECommerce.Domain.Entities;
using ECommerce.Persistance.Repositories.ProductRepository;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace ECommerce.Persistance.Services
{
    public class ProductService : IProductService 
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IQRCodeService _qRCodeService;
        readonly IProductWriteRepository _productWriteRepository;

        public ProductService(IProductReadRepository productReadRepository, IQRCodeService qRCodeService, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _qRCodeService = qRCodeService;
            _productWriteRepository = productWriteRepository;
        }

        public async Task<byte[]> QrCodeToProductAsync(string productId)
        {
            Product product = await _productReadRepository.GetByIdAsync(productId);

            if (product == null)
            {
                throw new ProductNotFoundException();
            }

            var plaintObject = new
            {
                product.Id,
                product.Name,
                product.Price,
                product.Stock,
                product.CreatedDate
            };

            string plaintText = JsonSerializer.Serialize(plaintObject);    
            
            return _qRCodeService.GenerateQRCode(plaintText);
        }

        public async Task StockUpdateToProductAsync(string productId, int stock)
        {
            Product product = await _productReadRepository.GetByIdAsync(productId);
            if (product == null)
                throw new Exception("Product not found");

            product.Stock = stock;
            await _productWriteRepository.SaveAsync();
        }
    }
}
