
using static DO.Enums;

namespace DO;


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
    /// Descriptive name of product
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Current sell price of product
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// The product category
    /// </summary>
    public Category? MyCategory { get; set; }

    /// <summary>
    /// Quantity of the product instock 
    /// </summary>
    public int InStock { get; set; }


    /// <summary>
    /// Product ToString
    /// we will use this function later in the DalTest to display all the characteristics of the product
    /// </summary>
    public override string ToString() => $@"
        Product ID={ID}: {Name}, 
        category - {MyCategory}
    	Price: {Price}
    	Amount in stock: {InStock}
";

}
