using OrdersWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWebAPI.Services
{
    public interface IOrdersService
    {
        List<Order> GetAllOrders();
        Order GetOrderDetail(int orderId);
    }
}
