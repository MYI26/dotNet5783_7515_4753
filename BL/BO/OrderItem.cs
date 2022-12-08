using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DO.Enums;

namespace BO
{
    //Auxiliary entity of an order item (represents a line in the order)
    //For a list of items on the shopping basket screen
    //and on the order details screen, which will contain:

    public class OrderItem
    {
        public int? Id{ get; set; }
        public int? ProductID { get; set; }
        public string? NameProduct { get; set; }
        public int? Price { get; set; }
        public int? QuantityInCart { get; set; }
        public int? PriceOfAll { get; set; }

        public override string ToString() => $@"
        Order Id={Id}
        Product ID={ProductID}
        Name of product:{NameProduct}
        Price:{Price}
        Quantity in the cart:{QuantityInCart}
        Total Price:{PriceOfAll}
        ";
    }
}
