using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logicalLayer.logical_Entities
{
    internal class Order
    {
    }

    public interface IOrder : ICrud<Order>
    {

        // List<Order> GetByOrderId(int id);

    }
}
