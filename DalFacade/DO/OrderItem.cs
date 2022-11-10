
namespace DO;

/// <summary>
/// Structure for Order Item
/// </summary>

public struct OrderItem
{
    /// <summary>
    /// Order Item ID
    /// </summary>

    public int OrderItemID { get; set; }


    /// <summary>
    /// Product ID
    /// </summary>


    public int ProductID { get; set; }


    /// <summary>
    /// ID of the Order the same in the struct Order
    /// </summary>

    public int OrderID { get; set; }


    /// <summary>
    /// Price
    /// </summary>

    public double Price { get; set; }


    /// <summary>
    /// Amount
    /// </summary>

    public int Amount { get; set; }


    /// <summary>
    /// Order Item ToString
    /// </summary>

    public override string ToString() => $@"
        Order Item ID={OrderItemID} 
        Product ID={ProductID}
        Order ID= {OrderID}
    	Price: {Price}
    	Amount: {Amount}
";

}
