using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BO.Enums;
using static DO.Enums;

namespace BO
{
    //A product reference entity in the list
    //For the product list screen and catalog screen, which will contain:
    public class ProductForList
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public Category? Category { get; set; }

        public override string ToString() => $@"
        Product ID={ID}: {Name}, 
        category - {MyCategory}
    	Price: {Price}
    	Amount in stock: {InStock}
";
    }
}
