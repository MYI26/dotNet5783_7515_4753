
namespace DO;

/// <summary>
/// Structure for Order information
/// </summary>

public struct Order
{
    /// <summary>
    /// ID of the Order
    /// </summary>
  
    public int ID { get; set; }


    /// <summary>
    /// Custoler Name
    /// </summary>
   
    public string? CustomerName { get; set; }


    /// <summary>
    /// Customer Email
    /// </summary>

    public string? CustomerEmail { get; set; }


    /// <summary>
    /// Customer Address
    /// </summary>

    public string? CustomerAddress { get; set; }


    /// <summary>
    /// Order Date
    /// </summary>

    public DateTime? OrderDate { get; set; }


    /// <summary>
    /// Ship Date
    /// </summary>

    public DateTime? ShipDate { get; set; }


    /// <summary>
    /// Delivery Date
    /// </summary>

    public DateTime? DeliveryDate { get; set; }


    /// <summary>
    /// Order ToString
    /// </summary>
    /// <returns></returns>
   
    public override string ToString() => $@"
        Customer ID: {ID}
        Customer Name: {CustomerName}
        Customer Email: {CustomerEmail}
        Customer Address: {CustomerAddress}
        OrderDate: {OrderDate}
    	ShipDate: {ShipDate}
    	DeliveryDate: {DeliveryDate}
       ";

}