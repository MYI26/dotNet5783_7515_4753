//
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

    //List<Order> GetByOrderId(int id);
    //void Update(Order order);

}

