using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DO.Enums;

namespace BO;

//the product class represents all the criteria of the product,
//it therefore contains the different properties of the product
public class Product
{
    public int? ProductID { get; set; }
    public string? Name { get; set; }    
    public int? Price { get; set; }
    public Category? MyCategory { get; set; }
    public int? InStock { get; set; }

    public override string ToString() => $@"
        Product ID={ProductID}: {Name},
    	Price: {Price}
        category - {MyCategory}
    	Amount in stock: {InStock}
";
}
