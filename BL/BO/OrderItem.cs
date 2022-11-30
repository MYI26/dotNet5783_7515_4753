using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    //Auxiliary entity of an order item (represents a line in the order)
    //For a list of items on the shopping basket screen
    //and on the order details screen, which will contain:

    public class OrderItem
    {
        public int Id{ get; set; }
        public int IdProduct { get; set; }
        public string? NameProduct { get; set; }
        public double Price { get; set; }
        public int QuantityInCart { get; set; }
        public double PriceOfAll { get; set; }

        public override string ToString() => $@"
        Product ID={ID}: {Name}, 
        category - {MyCategory}
    	Price: {Price}
    	Amount in stock: {InStock}
";
    }
}
