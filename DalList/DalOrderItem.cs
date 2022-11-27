using System;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using DalApi.DO.Exceptions;

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
                ExeptionAlreadyExist();
            }
        }

        listOrderItem.Add(oI1);

        return oI1.OrderItemID;
    }

    public void Delet(int id)
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
            ExeptionDontExist();
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
        ExeptionDontExist();
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

        ExeptionDontExist();
    }

    public List<OrderItem> Ask()
    {
        List<OrderItem> orderItem = new List<OrderItem>();

        foreach (OrderItem oI in listOrderItem)
        {
            orderItem.Add(oI);
        }
        return orderItem;
    }

}
