using DO;
using DalApi;
using static Dal.DataSource;

namespace Dal;

internal class DalOrderItem : IOrderItem
{

    public int Add(OrderItem p1)
    {

        // p1.OrderID = DataSource.Config.NextSerialNumber;

        foreach (OrderItem p in listOrderItem)
        {
            if (p.OrderItemID == p1.OrderItemID)
            {
                ExeptionAlreadyExist();
            }
        }

        listOrderItem.Add(p1);

        return p1.OrderItemID;
    }

    public void Delet(int id)
    {

        foreach (OrderItem p in listOrderItem)
        {
            if (p.OrderItemID == id)
            {

                listOrderItem.Remove(p);
                //for (int j = i; j < Config.startIndexTabOrderItem; j++)
                //{
                //    DataSource.tabOrderItem[j].OrderItemID = DataSource.tabOrderItem[j + 1].OrderItemID;
                //}
                //Config.startIndexTabOrderItem--;
                break;
            }
        }
    }

    public void Update(OrderItem P1)
    {

        foreach (OrderItem p in listOrderItem)
        {
            if (p.OrderItemID == P1.OrderItemID)
            {
                listOrderItem[listOrderItem.IndexOf(p)] = P1;
                break;
            }
        }

        ExeptionDontExist();
    }

    public OrderItem Ask(int id)
    {
       // OrderItem p2 = new OrderItem();
        foreach (OrderItem p in listOrderItem)
        {
            if (p.OrderItemID == id)
            {
                return p;
                
            }
        }
        //   return p2;
        ExeptionDontExist();
    }

    //public OrderItem[] AskOrderItem() 
    //{
    //    OrderItem[] orderItem = new OrderItem[Config.startIndexTabOrderItem];
    //    for (int i = 0; i < Config.startIndexTabOrderItem; i++)
    //    {
    //        orderItem[i] = DataSource.tabOrderItem[i];
    //    }
    //    return orderItem;
    //}

}
