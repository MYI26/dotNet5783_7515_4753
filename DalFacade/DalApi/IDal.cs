namespace DalApi;


/// <summary>
/// general interface for the first data layer, it contains the three interfaces of the three entities
/// </summary>
public interface IDal
{

    IProduct Product { get; }

    IOrder Order { get; }

    IOrderItem OrderItem { get; }

}
