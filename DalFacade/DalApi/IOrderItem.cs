//
using DO;

namespace DalApi;


/// <summary>
/// the interface adapted to the OrderItem entity
/// inherits functions from ICrud
/// </summary>
public interface IOrderItem : ICrud<OrderItem>
{ 

   // List<OrderItem> GetByOrderId(int id);

}

