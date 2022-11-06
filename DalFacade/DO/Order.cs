
namespace DO;

/// <summary>
/// Structure for Product on sale resource
/// </summary>

public struct Order
{
    /// <summary>
    /// Structure for Product on sale resource
    /// </summary>
  
    public int ID { get; set; }


    /// <summary>
    /// Structure for Product on sale resource
    /// </summary>
   
    public string? CustomerName { get; set; }


    /// <summary>
    /// Structure for Product on sale resource
    /// </summary>
    
    public string? CustomerEmail { get; set; }


    /// <summary>
    /// Structure for Product on sale resource
    /// </summary>
  
    public string? CustomerAddress { get; set; }


    /// <summary>
    /// Structure for Product on sale resource
    /// </summary>
    
    public DateTime? OrderDate { get; set; }


    /// <summary>
    /// Structure for Product on sale resource
    /// </summary>
   
    public DateTime? ShipDate { get; set; }


    /// <summary>
    /// Structure for Product on sale resource
    /// </summary>
    
    public DateTime? DeliveryDate { get; set; }


    /// <summary>
    /// Structure for Product on sale resource
    /// </summary>
   
    public override string ToString() => $@"
        Product ID={ID}: {Name}, 
        category - {Category}
    	Price: {Price}
    	Amount in stock: {InStock}
";

}