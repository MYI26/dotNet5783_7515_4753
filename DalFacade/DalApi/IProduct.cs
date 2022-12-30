
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DO;

namespace DalApi;


/// <summary>
/// the interface adapted to the Product entity
/// inherits functions from ICrud
/// </summary>
public interface IProduct : ICrud<Product> 
{

    // List<Product> GetByOrderId(int id);

}

