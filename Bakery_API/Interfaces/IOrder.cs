using Bakery_API.DTO;
using Bakery_API.Models;
using Bakery_API.Services;


namespace Bakery_API.Interfaces
{
    public interface IOrder


    {
        List<Order>GetOrdersByDate(DateTime date);

    }
}
