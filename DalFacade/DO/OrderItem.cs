using System.Diagnostics;
using System.Xml.Linq;

namespace DO;

public override string ToString() => $@"
        Product ID={ID}: {Name}, 
        category - {Category}
    	Price: {Price}
    	Amount in stock: {InStock}
";