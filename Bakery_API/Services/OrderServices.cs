using Bakery_API.Models;
using Bakery_API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bakery_API.Services
{
    public class OrderServices : IOrder
    {
        private readonly BakeryShopContext _bakerySqlContext;

        public OrderServices(BakeryShopContext bakerySqlContext)
        {
            _bakerySqlContext = bakerySqlContext;
        }

        // Lấy thông tin đơn hàng theo ngày
        public List<Order> GetOrdersByDate(DateTime date)
        {
            // Truy vấn tất cả các đơn hàng trong ngày
            var orders = _bakerySqlContext.Orders
                .Where(order => order.OrderDate == DateOnly.FromDateTime(date))
                .Include(order => order.User) // Bao gồm thông tin người dùng 
                .Include(order => order.Payment) // Bao gồm thông tin thanh toán 
                .Include(order => order.Delivery) // Bao gồm thông tin giao hàng 
                .ToList();

            return orders;
        }
    }
}
    

