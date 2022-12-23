using ECommerce.Application.ViewModels.Basket;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Abstraction.Services
{
    public interface IBasketService
    {
        public Task<List<BasketItem>> GetBasketItemsAsync();
        public Task AddItemToBasketAsync(VM_Create_BasketItem basketItem);
        public Task UpdateQuantityAsync(VM_Update_BasketItem basketItem);
        public Task RemoveBasketItemAsync(string basketItemId);
    }
}
