using System;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using DalApi.DO;
using static Dal.DataSource;
using DalApi;
using DO;

namespace Dal;

public class DalOrderItem : IOrderItem //attention ici on nous demander du internal
{

    public int Add(OrderItem oI1)
    {

        foreach (OrderItem oI in listOrderItem)
        {
            if (oI.OrderItemID == oI1.OrderItemID)
            {
              throw new AlreadyExistException($"the order item whith ID: {oI1.OrderItemID} already exist");
            }
        }

        listOrderItem.Add(oI1);

        return oI1.OrderItemID;
    }

    public void Delete(int id)
    {

        bool found = false;

        foreach (OrderItem oI in listOrderItem)
        {
            if (oI.OrderItemID == id)
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
            if (oI.OrderItemID == oI1.OrderItemID)
            {
                listOrderItem[listOrderItem.IndexOf(oI)] = oI1;
                break;
            }
        }
    if (found = !true)
            throw new DontExistException("the order item dont exist");
    }

    public OrderItem Ask(int id)
    {
     
        foreach (OrderItem oI in listOrderItem)
        {
            if (oI.OrderItemID == id)
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

    public IEnumerable<OrderItem> AskAll(Func<OrderItem, bool> filter = null) { IEnumerable<OrderItem> orderitem = listOrderItem; return orderitem; }

}
