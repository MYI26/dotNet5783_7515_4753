using DO;
using System;
using System.Diagnostics;

namespace Dal;

public class DalOrderItem
{

    public int AddOrderItem(OrderItem p1)
    {

        for (int i = 0; i < 100; i++)
        {
            if (DataSource.tabOrderItem[i].ProductID == p1.OrderItemID)
            {
                throw new Exception("the OrderItem already exist");



            }
        }

        int index = DataSource.tabOrderItem.Length;
        DataSource.tabOrderItem[index] = p1;

        return p1.OrderItemID;


    }

    public void DeletOrderItem(int id)
    {

        for (int i = 0; i < 40; i++)
        {
            if (DataSource.tabOrderItem[i].OrderItemID == id)
            {

                DataSource.tabOrderItem[i] = null;
           

            }
        }

    }

    public void UpdateOrderItem(OrderItem P1)
    {

        for (int i = 0; i < 100; i++)
        {
            if (DataSource.tabOrderItem[i].ProductID == P1.OrderItemID)
            {

                DataSource.tabOrderItem[i] = P1;

            }
        }

    }

    public Order GetOrderItem(int id)
    {
        int temps = 0;
        for (int i = 0; i < 100; i++)
        {
            if (DataSource.tabOrderItem[i].OrderItemID == id)
            {

                temps = i;

            }
        }
      return DataSource.tabOrderItem[temps];
    }

    public void GetOrderItem() {

        for (int i = 0; i < 100; i++)


            DataSource.tabOrderItem[i].ToString();
    }

}
