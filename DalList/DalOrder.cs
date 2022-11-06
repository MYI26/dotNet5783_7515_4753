using DO;
using System;

namespace Dal;

public class DalOrder
{

    public int add(Order p1)
    {

        for (int i = 0; i < 40; i++)
        {
            if (DataSource.tabOrderItem[i].ProductID == p1.ID)
            {
                throw new Execution("the OrderItem already exist")
                return 0;

            }
        }

        else
        {

            int i = 40;
            DataSource.tabOrderItem[i] = p1;
            i++;


            return p1.ProductID;
        }
    }

    public void delet(int id)
    {

        for (int i = 0; i < 40; i++)
        {
            if (DataSource.tabOrderItem[i].ProcuctID == id)
            {

                DataSource.tabOrderItem[i] = null;

            }
        }


    }

    public void update(Order P1)
    {

        for (int i = 0; i < 40; i++)
        {
            if (DataSource.tabOrderItem[i].ProductID == P1.ID)
            {

                DataSource.tabOrderItem[i] = P1;

            }
        }

    }

    public Order get(int id)
    {
        for (int i = 0; i < 40; i++)
        {
            if (DataSource.tabOrderItem[i].ProductID == id)
            {

                return DataSource.tabOrderItem[i];

            }
        }

    }

    public void get()
    {

        for (int i = 0; i < 40; i++)
        {




              public override string ToString() => $@"
        Product ID={DataSource.tabOrderItem[i].ProductID}: {DataSource.tabOrderItem[i].OrderID}, 
    	Price: {DataSource.tabProduct[i].Price}
    	Amount in stock: {DataSource.tabProduct[i].InStock} ";


}
