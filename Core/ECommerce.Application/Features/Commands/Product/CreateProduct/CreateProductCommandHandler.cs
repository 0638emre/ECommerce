using ECommerce.Application.Repositories.ProductRepository;
using MediatR;
using System.Net;
using ECommerce.Application.Abstractions.Hubs;

namespace ECommerce.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest,CreateProductCommandResponse>
    {
        readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductHubService _productHubService;
        public CreateProductCommandHandler(IProductWriteRepository productWriteRepository, IProductHubService hubService)
        {
            _productWriteRepository = productWriteRepository;
            _productHubService = hubService;
        }
        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _productWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock
            });
            await _productWriteRepository.SaveAsync();
            await _productHubService.ProductAddedMessageAsync($"{request.Name} isminde ürün eklenmiştir.");
            return new();
        }
    }
}
