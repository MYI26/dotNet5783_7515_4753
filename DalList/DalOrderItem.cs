using DO;
using System;
using System.Diagnostics;
using static Dal.DataSource;

namespace Dal;

public class DalOrderItem
{

    public int AddOrderItem(OrderItem p1)
    {

       // p1.OrderID = DataSource.Config.NextSerialNumber;

        for (int i = 0; i < 100; i++)
        {
            if (DataSource.tabOrderItem[i].OrderItemID == p1.OrderItemID)
            {
                throw new Exception("the OrderItem already exist");
            }
        }

        int index = DataSource.tabOrderItem.Length;
        DataSource.tabOrderItem[index] = p1;
        return p1.OrderItemID;

        // ajoute un produit dans un panie bien precie
    }

    public void DeletOrderItem(int id)
    {

        for (int i = 0; i < 40; i++)
        {
            if (DataSource.tabOrderItem[i].OrderItemID == id)
            {


                for (int j = i; j < 40; j++)
                {


                    DataSource.tabOrderItem[j].OrderItemID = DataSource.tabOrderItem[j + 1].OrderItemID;

                }

            }

        }

    }

    public void UpdateOrderItem(OrderItem P1)
    {

        for (int i = 0; i < 100; i++)
        {
            if (DataSource.tabOrderItem[i].OrderItemID == P1.OrderItemID)
            {

                DataSource.tabOrderItem[i] = P1;

            }

            //else
            // {
            //    throw new Exception("the product dont exist");
            //}
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
