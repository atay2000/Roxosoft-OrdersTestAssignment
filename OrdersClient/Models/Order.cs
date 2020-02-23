using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersClient.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string OrderNumber { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
