using DO;
using System;

namespace Dal;

public class DalOrder
{

    public int AddOrder(Order p1)
    {

        for (int i = 0; i < 40; i++)
        {
            if (DataSource.tabOrder[i].ID == p1.ID)
            {
                throw new Exception("the OrderItem already exist");
              

            }
        }


            int b = 40;
            DataSource.tabOrder[b] = p1;
            b++;


            return p1.ID;
        
    }

    public void DeletOrder(int id)
    {

        for (int i = 0; i < 40; i++)
        {
            if (DataSource.tabOrder[i].ID == id)
            {

                DataSource.tabOrder[i] = null;

            }
        }


    }

    public void UpdateOrder(Order P1)
    {

        for (int i = 0; i < 40; i++)
        {
            if (DataSource.tabOrder[i].ID == P1.ID)
            {

                DataSource.tabOrder[i] = P1;

            }
        }

    }

    public Order GetOrder(int id)
    {
        for (int i = 0; i < 40; i++)
        {
            if (DataSource.tabOrder[i].ID == id)
            {

                return DataSource.tabOrder[i];

            }
        }

    }

    public void GetOrder()
    {

        for (int i = 0; i < 200; i++)
        {

            Console.WriteLine($@"
        Customer ID: {DataSource.tabOrder[i].ID}
        Customer Name: {DataSource.tabOrder[i].CustomerName}
        Customer Email: {DataSource.tabOrder[i].CustomerEmail}
        Customer Address: {DataSource.tabOrder[i].CustomerAddress}
        OrderDate: {DataSource.tabOrder[i].OrderDate}
    	ShipDate: {DataSource.tabOrder[i].ShipDate}
    	DeliveryDate: {DataSource.tabOrder[i].DeliveryDate} ");
        }
    }

}
