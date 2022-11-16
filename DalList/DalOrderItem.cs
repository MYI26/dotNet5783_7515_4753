using DO;
using static Dal.DataSource;

namespace Dal;

public class DalOrderItem
{

    public int AddOrderItem(OrderItem p1)
    {

       // p1.OrderID = DataSource.Config.NextSerialNumber;

        for (int i = 0; i < Config.startIndexTabOrderItem; i++)
        {
            if (DataSource.tabOrderItem[i].OrderItemID == p1.OrderItemID)
            {
                throw new Exception("the OrderItem already exist");
            }
        }

        DataSource.tabOrderItem[Config.NextIndexTabOrderItem]= p1;

        return p1.OrderItemID;
    }

    public void DeletOrderItem(int id)
    {

        for (int i = 0; i < Config.startIndexTabOrderItem; i++)
        {
            if (DataSource.tabOrderItem[i].OrderItemID == id)
            {
                for (int j = i; j < Config.startIndexTabOrderItem; j++)
                {
                    DataSource.tabOrderItem[j].OrderItemID = DataSource.tabOrderItem[j + 1].OrderItemID;
                }
                Config.startIndexTabOrderItem--;
                break;
            }
        }
    }

    public void UpdateOrderItem(OrderItem P1)
    {

        for (int i = 0; i < Config.startIndexTabOrderItem; i++)
        {
            if (DataSource.tabOrderItem[i].OrderItemID == P1.OrderItemID)
            {
                DataSource.tabOrderItem[i] = P1;
                return;
            }
        }

        throw new Exception("the OrderItem dont exist");
    }

    public OrderItem AskOrderItem(int id)
    {
        int temps = 0;
        for (int i = 0; i < Config.startIndexTabOrderItem; i++)
        {
            if (DataSource.tabOrderItem[i].OrderItemID == id)
            {
                temps = i;
            }
        }

      return DataSource.tabOrderItem[temps];
    }

    public OrderItem[] AskOrderItem() 
    {
        OrderItem[] orderItem = new OrderItem[Config.startIndexTabOrderItem];
        for (int i = 0; i < Config.startIndexTabOrderItem; i++)
        {
            orderItem[i] = DataSource.tabOrderItem[i];
        }
        return orderItem;
    }

}
