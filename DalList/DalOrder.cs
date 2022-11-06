using DO;
using System;

namespace Dal;

public class DalOrder
{

    public int add(Order p1)
    {

        for (int i = 0; i < 40; i++)
        {
            if (DataSource.tabOrder[i].ID == p1.ID)
            {
                throw new Execution("the OrderItem already exist")
                return 0;

            }
        }

        else
        {

            int i = 40;
            DataSource.tabOrder[i] = p1;
            i++;


            return p1.ID;
        }
    }

    public void delet(int id)
    {

        for (int i = 0; i < 40; i++)
        {
            if (DataSource.tabOrder[i].ID == id)
            {

                DataSource.tabOrder[i] = null;

            }
        }


    }

    public void update(Order P1)
    {

        for (int i = 0; i < 40; i++)
        {
            if (DataSource.tabOrder[i].ID == P1.ID)
            {

                DataSource.tabOrder[i] = P1;

            }
        }

    }

    public Order get(int id)
    {
        for (int i = 0; i < 40; i++)
        {
            if (DataSource.tabOrder[i].ID == id)
            {

                return DataSource.tabOrder[i];

            }
        }

    }

    public void get()
    {

        for (int i = 0; i < 40; i++)
        {




              public override string ToString() => $@"
        Customer ID: {DataSource.tabOrder[i].ID}
        Customer Name: {DataSource.tabOrder[i].CustomerName}
        Customer Email: {DataSource.tabOrder[i].CustomerEmail}
        Customer Address: {DataSource.tabOrder[i].CustomerAddress}
        OrderDate: {DataSource.tabOrder[i].OrderDate}
    	ShipDate: {DataSource.tabOrder[i].ShipDate}
    	DeliveryDate: {DataSource.tabOrder[i].DeliveryDate} ";
          }

}
