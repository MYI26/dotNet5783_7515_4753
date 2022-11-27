using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logicalLayer.logical_Entities
{
    internal class Product
    {
    }

    public interface IProduct : ICrud<Product>
    {
        // List<Product> GetByOrderId(int id);

    }
}
