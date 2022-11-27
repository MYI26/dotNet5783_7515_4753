using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logicalLayer.logical_Entities
{
    internal class Cart
    {
    }

    public interface ICart : ICrud<Cart>
    {

        // List<Order> GetByOrderId(int id);

    }
}
