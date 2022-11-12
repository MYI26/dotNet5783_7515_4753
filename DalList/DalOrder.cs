using DO;
using System;
using static Dal.DataSource;

namespace Dal;

public class DalOrder
{

    public int AddOrder(Order p1)
    {
        p1.ID = DataSource.Config.NextSerialNumber;

        DataSource.tabOrder[Config.NextIndexTabOrder] = p1;
          
        return p1.ID;
    }

    public void DeletOrder(int id)
    {

        for (int i = 0; i < 100; i++)
        {
            if (DataSource.tabOrder[i].ID == id)
            {
                for (int j = i; j < 100; j++)
                {
                    DataSource.tabOrder[j].ID = DataSource.tabOrder[j + 1].ID;
                }
                break;
            }
        }
    }

    public void UpdateOrder(Order P1)
    {

        for (int i = 0; i < 100; i++)
        {
            if (DataSource.tabOrder[i].ID == P1.ID)
            {
                DataSource.tabOrder[i] = P1;
                return;
            }
        }
        throw new Exception("the order dont exist");
    }

    public Order AskOrder(int id)
    {
        int temps = 0;
        for (int i = 0; i < 100; i++)
        {
            if (DataSource.tabOrder[i].ID == id)
            {
                temps = i;
            }
        }

        return DataSource.tabOrder[temps];
    }

    public void AskOrder()
    {
        Order[] order = new Order[100];
        for (int i = 0; i < DataSource.tabOrder.Length; i++)
        {
            order[i] = DataSource.tabOrder[i];
        }
    }

}
