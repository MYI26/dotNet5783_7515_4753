
namespace DO;


/// <summary>
/// Structure for Order Item
/// </summary>
public struct OrderItem
{

    /// <summary>
    /// Order Item ID
    /// </summary>
    public int ID { get; set; }


    /// <summary>
    /// Product ID
    /// it corresponds to the ID of the Product structure
    /// </summary>
    public int ProductID { get; set; }


    /// <summary>
    /// ID of the Order
    /// it corresponds to the ID of the Order structure
    /// </summary>
    public int OrderID { get; set; }

    /// <summary>
    /// Price of the orderitem
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// Amount of the orderitem
    /// </summary>
    public int Amount { get; set; }


    /// <summary>
    /// OrderItem ToString
    /// </summary>
    public override string ToString() => $@"
        Order Item ID={ID} 
        Product ID={ProductID}
        Order ID= {OrderID}
    	Price: {Price}
    	Amount: {Amount}
";

}
