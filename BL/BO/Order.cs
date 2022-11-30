using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BO.Enums;
using static DO.Enums;

namespace BO
{
    //Primary logical entity of an order
    //For an order details screen and actions on an order, which will contain:
    public class Order
    {
        public int OrderId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerAddress { get; set; }
        public OrderStatus? Status { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public List<OrderItem?>? Items { get; set; }
        public double TotalPrice { get; set; }

        public override string ToString() => $@"
        Product ID={ID}: {Name}, 
        category - {MyCategory}
    	Price: {Price}
    	Amount in stock: {InStock}
";
    }
}
