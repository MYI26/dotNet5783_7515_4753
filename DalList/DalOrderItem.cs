using DO;
using DalApi;
using static Dal.DataSource;

namespace Dal;

public class DalOrderItem : IOrderItem //attention ici on nous demander du internal
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

    public List<OrderItem> Ask()
    {
        List<OrderItem> orderitem = new List<OrderItem>();
        foreach (OrderItem p in listOrderItem)
        {
            listOrderItem.Add(p);
        }
        return orderitem;
    }

}
