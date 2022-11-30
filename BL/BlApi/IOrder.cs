using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi;

public interface IOrder
{
    /// <summary>
    /// return order of list of order
    /// </summary>
    /// <returns></returns>
    IEnumerable<OrderForList?> GetOrder();

    /// <summary>
    /// return order of id specific for admin screen and for
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Order GetById(int id);

    Order update(int id);

    //Order update(int id);  // je ne comprend pas ce qui veulent dans le tiour aclali

    OrderTracking Tracking(int id);

}
