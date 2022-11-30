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
    //Order tracking utility
    //For an order tracking screen, which will contain:
    public class OrderTracking
    {
        public int OrderId { get; set; }
        public OrderStatus? Status { get; set; }
        public List<Order?>? Items { get; set; }

        public override string ToString() => $@"
        Product ID={ID}: {Name}, 
        category - {MyCategory}
    	Price: {Price}
    	Amount in stock: {InStock}
";
    }
}
