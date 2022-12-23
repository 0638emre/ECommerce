using ECommerce.Domain.Entities.Common;
using ECommerce.Domain.Entities.Identity;

namespace ECommerce.Domain.Entities
{
    public class Basket : BaseEntity
    {
        public string UserId { get; set; }
        public Guid OrderId { get; set; }
        public AppUser User { get; set; }
        public Order Order { get; set; }
        public BasketItem BasketItems { get; set; }
    }
}
