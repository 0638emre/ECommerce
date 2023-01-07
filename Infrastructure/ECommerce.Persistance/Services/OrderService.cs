using ECommerce.Application.Abstractions.Services;
using ECommerce.Application.DTOs.Order;
using ECommerce.Application.Repositories.OrderRepository;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistance.Services
{
    public class OrderService : IOrderService
    {
        readonly IOrderWriteRepository _orderWriteRepository;
        readonly IOrderReadRepository _orderReadRepository;


        public OrderService(IOrderWriteRepository orderWriteRepository)
        {
            _orderWriteRepository = orderWriteRepository;
        }

        public async Task CreateOrderAsync(CreateOrder createOrder)
        {
            var orderCode = (new Random().NextDouble() * 10000).ToString();
            orderCode = orderCode.Substring(orderCode.IndexOf(".") + 1, orderCode.Length - orderCode.IndexOf(".") - 1);


            await _orderWriteRepository.AddAsync(new()
            {
                Address= createOrder.Address,
                Id = Guid.Parse(createOrder.BasketId),
                Description = createOrder.Description,
                OrderCode = orderCode
                //TODO: !! burada unique bir değer istiyoruz ordercode için fakat denk gelirse patlar. bunun bir çaresini bul.
            });

            await _orderWriteRepository.SaveAsync();
        }

        public async Task<ListOrder> GetAllOrdersAsync(int page, int size)
        {
            var query = _orderReadRepository.Table.Include(o => o.Basket)
                      .ThenInclude(b => b.User)
                      .Include(o => o.Basket)
                      .ThenInclude(b => b.BasketItems)
                      .ThenInclude(bi => bi.Product);



            var data = query.Skip(page * size).Take(size);
            /*.Take((page * size)..size);*/


            //var data2 = from order in data
            //            join completedOrder in _completedOrderReadRepository.Table
            //               on order.Id equals completedOrder.OrderId into co
            //            from _co in co.DefaultIfEmpty()
            //            select new
            //            {
            //                Id = order.Id,
            //                CreatedDate = order.CreatedDate,
            //                OrderCode = order.OrderCode,
            //                Basket = order.Basket,
            //                Completed = _co != null ? true : false
            //            };

            return new()
            {
                TotalOrderCount = await query.CountAsync(),
                Orders = await data.ToListAsync()
                
                //2.Select(o => new
                //{
                //    Id = o.Id,
                //    CreatedDate = o.CreatedDate,
                //    OrderCode = o.OrderCode,
                //    TotalPrice = o.Basket.BasketItems.Sum(bi => bi.Product.Price * bi.Quantity),
                //    UserName = o.Basket.User.UserName,
                //    o.Completed
                //}).ToListAsync()
            };
        }

    }
}
