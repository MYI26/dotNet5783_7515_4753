using System;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using DalApi.DO;
using static Dal.DataSource;
using DalApi;
using DO;

namespace Dal;

internal class DalOrderItem : IOrderItem 
{

    public int Add(OrderItem oI1)
    {

        foreach (OrderItem oI in listOrderItem)
        {
            if (oI.ID == oI1.ID)
            {
              throw new AlreadyExistException($"the order item whith ID: {oI1.ID} already exist");
            }
        }

        listOrderItem.Add(oI1);

        return oI1.ID;
    }

    public void Delete(int id)
    {

        bool found = false;

        foreach (OrderItem oI in listOrderItem)
        {
            if (oI.ID == id)
                listOrderItem.Remove(oI);
            found = true;
            break;
        }
        if (found = !true)
            throw new DontExistException("the order item dont exist");
    }

    public void Update(OrderItem oI1)
    {

    bool found = false;

    foreach (OrderItem oI in listOrderItem)
        {
            if (oI.ID == oI1.ID)
            {
                listOrderItem[listOrderItem.IndexOf(oI)] = oI1;
                break;
            }
        }
    if (found = !true)
            throw new DontExistException("the order item dont exist");
    }

    public OrderItem? Get(int id)
    {
     
        foreach (OrderItem oI in listOrderItem)
        {
            if (oI.ID == id)
            {
                return oI;
            }
        }

        throw new DontExistException("the order item dont exist");
    }

    //public IEnumerable<OrderItem> Ask()
    //{
    //    List<OrderItem> orderItem = new List<OrderItem>();

    //    foreach (OrderItem oI in listOrderItem)
    //    {
    //        orderItem.Add(oI);
    //    }
    //    IEnumerable<OrderItem> enumerable = orderItem;

    //    return enumerable;//return IEnumerator
    //}

    public IEnumerable<OrderItem?> GetAll(Func<OrderItem?, bool>? filter = null) { IEnumerable<OrderItem?> orderitem = listOrderItem; return orderitem; }

}
