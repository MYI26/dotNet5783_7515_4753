using DO;
using System;
using DalApi;
using static Dal.DataSource;

namespace Dal;

public class DalOrder : IOrder //attention ici on nous demander du internal
{

    public int Add(Order p1)
    {

        foreach (Order p in listOrder)
        {
            if (p.ID== p1.ID)
            {
                ExeptionAlreadyExist();
            }
        }
       // p1.ID = Config.NextSerialNumber;

        listOrder.Add(p1);

        return p1.ID;
    }

    public void Delet(int id)
    {

        foreach (Order p in listOrder)
        {
            if (p.ID == id)
                listOrder.Remove(p);
            break;
        }
    }

    public void Update(Order P1)
    {
        
        foreach (Order p in listOrder)
        {
            if (p.ID == P1.ID)
            {
              listOrder[listOrder.IndexOf(p)] = P1;
               break;
            }
        }

        ExeptionDontExist();
    }

    public Order Ask(int id)
    {
       
        foreach (Order p in listOrder)
        {
            if (p.ID == id)
            {
                return p;
            }
        }

        ExeptionDontExist();
    }

    public List<Order> Ask()
    {
        List<Order> order = new List<Order>();
        foreach (Order p in listOrder)
        {
            listOrder.Add(p);
        }
        return order;
    }

}
