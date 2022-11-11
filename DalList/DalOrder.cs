using DO;
using System;

namespace Dal;

public class DalOrder
{

    public int AddOrder(Order p1)
    {
        // p1.OrderID = DataSource.Config.NextSerialNumber;

        for (int i = 0; i < 200; i++)
        {
            if (DataSource.tabOrder[i].ID == p1.ID)
            {
                throw new Exception("the OrderItem already exist");
              

            }
        }


            int index = DataSource.tabOrder.Length;
            DataSource.tabOrder[index] = p1;
          
        return p1.ID;
        
    }

    public void DeletOrder(int id)
    {

        for (int i = 0; i < 200; i++)
        {
            if (DataSource.tabOrder[i].ID == id)
            {


                for (int j = i; j < 200; j++)
                {


                    DataSource.tabOrder[j].ID = DataSource.tabOrder[j + 1].ID;

                }

            }

        }


    }

    public void UpdateOrder(Order P1)
    {

        for (int i = 0; i < 200; i++)
        {
            if (DataSource.tabOrder[i].ID == P1.ID)
            {

                DataSource.tabOrder[i] = P1;

            }

            //else
            // {
            //    throw new Exception("the product dont exist");
            //}
        }

    }

    public Order GetOrder(int id)
    {
        int temps = 0;
        for (int i = 0; i < 200; i++)
        {
            if (DataSource.tabOrder[i].ID == id)
            {

                temps = i;


            }
        }

        return DataSource.tabOrder[temps];

    }

    public void GetOrder()
    {

        for (int i = 0; i < 200; i++)
        {

            DataSource.tabOrder[i].ToString();
        }
    }

}
