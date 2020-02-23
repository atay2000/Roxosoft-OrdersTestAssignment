using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrdersWebAPI.Data;
using OrdersWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWebAPI.Services
{
    class OrdersDBService : IOrdersService
    {
        public OrdersDBService()
        {
            using (var context = new OrdersDBContext())
            {
                context.Database.EnsureCreated();
            }            
        }

        public List<Order> GetAllOrders()
        {
            using (var context = new OrdersDBContext())
            {
                return context.Orders.Include(x => x.OrderStatus).ToList();
            }
        }

        public Order GetOrderDetail(int orderId)
        {
            using (var context = new OrdersDBContext())
            {
                Order detOrder = context.Orders.Include(o => o.OrderStatus).Include(o => o.ProductOrders)
                    .ThenInclude(po => po.Product).FirstOrDefault(o => o.Id == orderId);

                return detOrder;
                //List<ProductOrder> details = context.ProductOrders.Include(x => x.Order).Include(x => x.Order.OrderStatus)
                //    .Include(x => x.Product).Where(x => x.OrderId == orderId).ToList();

                //return details;
            }
        }
    }
}
