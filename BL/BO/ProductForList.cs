using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BO.Enums;

namespace BO
{
    //A product reference entity in the list
    //For the product list screen and catalog screen, which will contain:
    public class ProductForList
    {
        public int ProductID { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public Category? Category { get; set; }

        public override string ToString() => $@"
        Product ID={ProductID}: {Name},
    	Price: {Price}
        category - {Category}
";
    }
}
