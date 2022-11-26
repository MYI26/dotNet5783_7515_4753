using System;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using DalApi.DO.Exceptions;

using static Dal.DataSource;
using DalApi;
using DO;

namespace Dal;

internal class DalOrder : IOrder
{

    public int Add(Order o1)
    {

        foreach (Order o in listOrder)
        {
            if (o.ID== o1.ID)
            {
                ExeptionAlreadyExist();
            }
        }

        listOrder.Add(o1);

        return o1.ID;
    }

    public void Delet(int id)
    {

        bool found = false;

        foreach (Order o in listOrder)
        {
            if (o.ID == id)
                listOrder.Remove(o);
            found = true;
            break;
        }
        if (found =! true)
            ExeptionDontExist();
    }

    public void Update(Order o1)
    {

        bool found = false;

        foreach (Order o in listOrder)
        {
            if (o.ID == o1.ID)
            {
              listOrder[listOrder.IndexOf(o)] = o1;
              found = true;
               break;
            }
        }
        if (found = ! true)
            ExeptionDontExist();

    }

    public Order Ask(int id)
    {
       
        foreach (Order o in listOrder)
        {
            if (o.ID == id)
            {
                return o;
            }
        }

        ExeptionDontExist();
    }

    public Order[] AskOrder()
    {
        Order[] order = new Order[listOrder.Count];
        int i = 0;

        foreach (Order o in listOrder)
        {
            order[i] = o;
            i++;
        }
        return order;
    }

}
