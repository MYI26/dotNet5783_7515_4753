//
using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Dal;


//que ft IDal pr la premiere ligne
/// <summary>
/// 
/// inherits of IDal and therefore of the interfaces of the three entities
/// sealed, disallow inheriting from class
/// </summary>
sealed public class DalList : IDal 
{

    //que ft cette fleche et à quoi ca sert
    public IProduct Product => new DalProduct();

    public IOrder Order => new DalOrder();

    public IOrderItem OrderItem => new DalOrderItem();

}
