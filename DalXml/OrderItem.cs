using DalApi;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Dal;

internal class OrderItem : IOrderItem
{
    const string orderItemPath = "OrderItem";
    static XElement config = XMLTools.LoadConfig();

    [MethodImpl(MethodImplOptions.Synchronized)]
    public int Add(DO.OrderItem entity)
    {

        List<DO.OrderItem?> listOrderItem = XMLTools.LoadListFromXMLSerializer<DO.OrderItem>(orderItemPath);

        if (listOrderItem.FirstOrDefault(orderItem => orderItem?.ID == entity.ID) != null)
            throw new Exception("id already exist");

        entity.ID = int.Parse(config.Element("OrderItemId")!.Value) + 1;
        listOrderItem.Add(entity);

        XMLTools.SaveListToXMLSerializer(listOrderItem, orderItemPath);

        return entity.ID;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void Delete(int id)
    {
        List<DO.OrderItem?> listOrderItem = XMLTools.LoadListFromXMLSerializer<DO.OrderItem>(orderItemPath);

        if (listOrderItem.RemoveAll(lec => lec?.ID == id) == 0)
            throw new Exception("missing id");

        XMLTools.SaveListToXMLSerializer(listOrderItem, orderItemPath);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public IEnumerable<DO.OrderItem?> GetAll(Func<DO.OrderItem?, bool>? function = null)
    {
        List<DO.OrderItem?> listOrderItem = XMLTools.LoadListFromXMLSerializer<DO.OrderItem>(orderItemPath);

        if (function == null)
            return listOrderItem.Select(lec => lec).OrderBy(lec => lec?.ID);
        else
            return listOrderItem.Where(function).OrderBy(lec => lec?.ID);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public DO.OrderItem? Get(int id)
    {
        List<DO.OrderItem?> listOrder = XMLTools.LoadListFromXMLSerializer<DO.OrderItem>(orderItemPath);

        return (from item in listOrder
                where item?.ID==id
                select item).FirstOrDefault();

    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void Update(DO.OrderItem entity)
    {
        Delete(entity.ID);
        Add(entity);
    }
}