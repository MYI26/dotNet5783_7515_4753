using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BO.Enums;

namespace BO
{
    //ProductItem helper entity (representing a product for the catalog)
    //For the catalog screen -
    //with the list of products shown to the buyer, which will contain:
    public class ProductItem
    {
        public int ProductID { get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; }
        public Category? Category { get; set; }
        public bool Availability { get; set; } // disponibilite
        public int? QuantityInCart { get; set; }

        public override string ToString() => $@"
        Product ID: {ProductID}: {Name}, 
    	Price: {Price}
        category - {Category}
    	Availability: {Availability}
        Quantity in the cart: {QuantityInCart}
";
    }
}
