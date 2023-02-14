using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace DalApi;

/// <summary>
/// the interface adapted to the Order entity
/// inherits functions from ICrud
/// </summary>
public interface IOrder : ICrud<Order>
{
    public int GetAmoutOrderItem(int id);
    public double GetTotalPrice(int id);
    public int GetNumStatus(int id);
}
    
