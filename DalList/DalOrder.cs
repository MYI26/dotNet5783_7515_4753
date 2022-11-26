using DO;
using System;
using DalApi;
using static Dal.DataSource;

namespace Dal;

internal class DalOrder : IOrder
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

    //public Order[] AskOrder()
    //{
    //    Order[] order = new Order[Config.startIndexTabOrder];
    //    for (int i = 0; i < Config.startIndexTabOrder; i++)
    //    {
    //        order[i] = DataSource.tabOrder[i];
    //    }
    //    return order;
    //}

}
