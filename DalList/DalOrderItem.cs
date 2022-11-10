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

                int b = 100;
                DataSource.tabOrderItem[b] = p1;
                b++;
                return p1.ProductID;
            
        
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

            Console.WriteLine($@"
        Order Item ID={DataSource.tabOrderItem[i].OrderItemID} 
        Product ID={DataSource.tabOrderItem[i].ProductID}
        Order ID= {DataSource.tabOrderItem[i].OrderID}
    	Price: {DataSource.tabOrderItem[i].Price}
    	Amount: {DataSource.tabOrderItem[i].Amount}
          ");
    }

}
