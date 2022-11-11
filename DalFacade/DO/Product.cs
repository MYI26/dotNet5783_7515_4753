
namespace DO;
using static DO.Enums;


/// <summary>
/// Structure for Product on sale resource
/// </summary>

public struct Product
{

    /// <summary>
    /// Unique ID of product
    /// </summary>

    public int ID { get; set; }


    /// <summary>
    /// Descriptivename of product
    /// </summary>
 
    public string Name { get; set; }


    /// <summary>
    /// Current sell price of product
    /// </summary>

    public int Price { get; set; }


    /// <summary>
    /// Category of product in the store product list
    /// </summary>
  
    public Category MyCategory { get; set; }


    /// <summary>
    /// Number of product instock in the store 
    /// </summary>
 
    public int InStock { get; set; }


    /// <summary>
    /// Product ToString
    /// </summary>
   
    public override string ToString() => $@"
        Product ID={ID}: {Name}, 
        category - {MyCategory}
    	Price: {Price}
    	Amount in stock: {InStock}
";

}
