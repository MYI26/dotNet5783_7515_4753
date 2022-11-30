using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    //Main logical entity of the shopping cart
    //For the shopping cart management and order confirmation screen,
    //which will contain:
    public class Cart
    {
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerAdress { get; set; }
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
