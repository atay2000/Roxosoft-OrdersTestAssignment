using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrdersWebAPI.Models;

namespace OrdersWebAPI.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Product #1", Price = 100 },
                new Product { Id = 2, Name = "Product #2", Price = 10 },
                new Product { Id = 3, Name = "Product #3", Price = 5 },
                new Product { Id = 4, Name = "Product #4", Price = 10 },
                new Product { Id = 5, Name = "Product #5", Price = 25 }
                );

            modelBuilder.Entity<OrderStatus>().HasData(
                new OrderStatus { Id = 1, Name = "In Progress" },
                new OrderStatus { Id = 2, Name = "Complete" }
                );

            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, OrderNumber = "Order #1", CreationDate = DateTime.Parse("2020-02-19 09:47:47"), OrderStatusId = 2 },
                new Order { Id = 2, OrderNumber = "Order #2", CreationDate = DateTime.Parse("2020-02-20 11:05:58"), OrderStatusId = 1 },
                new Order { Id = 3, OrderNumber = "Order #3", CreationDate = DateTime.Parse("2020-02-21 05:48:24"), OrderStatusId = 2 }
                );

            modelBuilder.Entity<ProductOrder>().HasData(
                new ProductOrder { OrderId = 1, ProductId = 1, Qty = 3 },
                new ProductOrder { OrderId = 1, ProductId = 3, Qty = 1 },
                new ProductOrder { OrderId = 1, ProductId = 4, Qty = 2 },
                new ProductOrder { OrderId = 2, ProductId = 1, Qty = 1 },
                new ProductOrder { OrderId = 2, ProductId = 2, Qty = 5 },
                new ProductOrder { OrderId = 2, ProductId = 3, Qty = 1 },
                new ProductOrder { OrderId = 2, ProductId = 4, Qty = 2 },
                new ProductOrder { OrderId = 3, ProductId = 2, Qty = 3 },
                new ProductOrder { OrderId = 3, ProductId = 3, Qty = 1 },
                new ProductOrder { OrderId = 3, ProductId = 4, Qty = 7 },
                new ProductOrder { OrderId = 3, ProductId = 5, Qty = 2 }
                );
        }
    }
}
