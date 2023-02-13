using DalApi;
using System.Xml.Linq;
using System.Runtime.CompilerServices;

namespace Dal;

internal class Order : IOrder
{
    const string orderPath = "Order";
    static XElement config = XMLTools.LoadConfig();

    [MethodImpl(MethodImplOptions.Synchronized)]
    public int Add(DO.Order entity)
    {
        List<DO.Order?> listOrder = XMLTools.LoadListFromXMLSerializer<DO.Order>(orderPath);

        if (listOrder.FirstOrDefault(orderItem => orderItem?.ID == entity.ID) != null)
            throw new Exception("id already exist");
        if (entity.ID == 0)
            entity.ID = int.Parse(config.Element("OrderId")!.Value) + 1;

        listOrder.Add(entity);

        XMLTools.SaveListToXMLSerializer(listOrder, orderPath);

        return entity.ID;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]

    public void Delete(int id)
    {
        List<DO.Order?> listOrder = XMLTools.LoadListFromXMLSerializer<DO.Order>(orderPath);

        if (listOrder.RemoveAll(lec => lec?.ID == id) == 0)
            throw new Exception("missing id"); 

        XMLTools.SaveListToXMLSerializer(listOrder, orderPath);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public IEnumerable<DO.Order?> GetAll(Func<DO.Order?, bool>? function = null)
    {
        List<DO.Order?> listOrder = XMLTools.LoadListFromXMLSerializer<DO.Order>(orderPath);

        if (function == null)
            return listOrder.Select(lec => lec).OrderBy(lec => lec?.ID);
        else
            return listOrder.Where(function).OrderBy(lec => lec?.ID);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public DO.Order? Get(int id)
    {
        List<DO.Order?> listOrder = XMLTools.LoadListFromXMLSerializer<DO.Order>(orderPath);

        return (from item in listOrder
                where item?.ID ==id
                select item).FirstOrDefault();
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void Update(DO.Order entity)
    {
        Delete(entity.ID);
        Add(entity);
    }
}