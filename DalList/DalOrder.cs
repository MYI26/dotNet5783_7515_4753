
using System;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using DalApi.DO;
using static Dal.DataSource;
using DalApi;
using DO;
using System.Collections.Generic;

namespace Dal;


/// <summary>
///the implementation of functions for the Order entity
/// </summary>
internal class DalOrder : IOrder 
{

    public int Add(Order o1)
    {

    //    foreach (Order o in listOrder)
    //    {
    //        if (o.ID == o1.ID)
    //        {
    //           throw new AlreadyExistException($"the order whith ID: {o1.ID} already exist");
    //        }
    //    }
        o1.ID = Config.NextSerialNumber;

        listOrder.Add(o1);

        return o1.ID;
    }

    public void Delete(int id)
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
           throw new DontExistException("the order dont exist");
    }

    public void Update(Order o1)
    {

        bool found = false;

        foreach (Order o in listOrder)
        {
            if (o.ID == o1.ID)
            {
              listOrder[listOrder.IndexOf(o)] = (Order)o1;
              found = true;
               break;
            }
        }
        if (found = ! true)
            throw new DontExistException("the order dont exist");

    }

    public Order Get(int id)
    {
       
        foreach (Order o in listOrder)
        {
            if (o.ID == id)
            {
                return o;
            }
        }

        throw new DontExistException("the order dont exist");
    }

    //public IEnumerable<Order> Ask()
    //{
    //    List<Order> order = new List<Order>(listOrder.Count());// creat new list with size of the actualy list

    //    foreach (Order oI in listOrder)
    //    {
    //        order.Add(oI);
    //    }

    //    IEnumerable<Order> enumerable = order;

    //    return enumerable; //return IEnumerator
    //}

    public IEnumerable<Order> GetAll(Func<Order, bool> filter = null) { IEnumerable<Order> order = listOrder; return order; }

}
