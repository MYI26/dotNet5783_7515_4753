using BlApi;
using System.Security.Cryptography;
using static BO.Enums;
namespace BlImplementation;

internal class Order : IOrder
{
    DalApi.IDal Dal = DalApi.Factory.Get() ?? throw new BO.DontExistException("dal invalid");

    public BO.Order? Get(int id)
    {
        try
        {
            if (id > 999)
            {
                DO.Order? doOrder = Dal?.Order.Get(id);
                BO.Order result = new BO.Order
                {
                    OrderID = doOrder?.ID ?? throw new BO.MissingException("ID missing"),
                    CustomerName = doOrder?.CustomerName ?? throw new BO.MissingException("Name missing"),
                    CustomerEmail = doOrder?.CustomerEmail ?? throw new BO.MissingException("Email missing"),

                    CustomerAddress = doOrder?.CustomerAddress ?? throw new BO.MissingException("Address missing"),

                    Status = (BO.Enums.OrderStatus)Dal?.Order.GetNumStatus(id)!,

                    OrderDate = doOrder?.OrderDate ?? null,

                    ShipDate = doOrder?.ShipDate ?? null,

                    DeliveryDate = doOrder?.DeliveryDate ?? null,
                    Items = GetListOrderItem(id)
                };

                result.TotalPrice = (from item in Dal?.OrderItem.GetAll()
                                     where item?.OrderID == id
                                     select item?.Amount * item?.Price).Sum() ?? 0.0;

                return result;
            }
            else throw new BO.ErrorDontExist("Id of Order no valid");
        }
        catch (BO.MissingException)
        {
            throw new BO.Missing("Entity missing");
        }
    }

    public List<BO.OrderItem?>? GetListOrderItem(int id) // exemple id == 1020
    {
        List<BO.OrderItem?> ListOrderItemBo = new List<BO.OrderItem?>();

        foreach (DO.OrderItem oi in Dal?.OrderItem.GetAll()!)
        {
            if (oi.OrderID == id)
            {
                BO.OrderItem BoOrderItem = new BO.OrderItem();
                BoOrderItem.Id = oi.ID;
                BoOrderItem.ProductID = oi.ProductID;
                BoOrderItem.NameProduct = Dal?.Product.Get(oi.ProductID)?.Name;
                BoOrderItem.Price = oi.Price;
                BoOrderItem.QuantityInCart = oi.Amount;
                BoOrderItem.PriceOfAll = oi.Amount * oi.Price;

                ListOrderItemBo.Add(BoOrderItem);
            }
        }

        return ListOrderItemBo;
    }

    public IEnumerable<BO.OrderForList?>? GetOrders(Func<BO.Enums.OrderStatus, bool>? filter)
    {
        if (filter == null)
        {

            return from order in Dal?.Order.GetAll()
                   orderby order?.OrderDate!, order?.ShipDate, order?.DeliveryDate
                   let ord = (DO.Order)order
                   select new BO.OrderForList
                   {
                       OrderID = ord.ID,
                       CustomerName = ord.CustomerName,
                       Status = (BO.Enums.OrderStatus)Dal.Order.GetNumStatus(ord.ID),
                       Amount = Dal?.Order.GetAmoutOrderItem(ord.ID) ?? throw new BO.MissingException("Quantity InCart missing"),
                       TotalPrice = Get(ord.ID)?.TotalPrice ?? 0.0
                   };

        }

        else
        {

            return from order in Dal?.Order.GetAll()
                   orderby order?.OrderDate!, order?.ShipDate, order?.DeliveryDate
                   let ord = (DO.Order)order
                   where (filter((BO.Enums.OrderStatus)Dal.Order.GetNumStatus(ord.ID)) == true)
                   select new BO.OrderForList
                   {
                       OrderID = ord.ID,
                       CustomerName = ord.CustomerName,
                       Status = (BO.Enums.OrderStatus)Dal.Order.GetNumStatus(ord.ID),
                       Amount = Dal?.Order.GetAmoutOrderItem(ord.ID) ?? throw new BO.MissingException("Quantity InCart missing"),
                       TotalPrice = Get(ord.ID)?.TotalPrice ?? 0.0
                   };
        }
    }

    public BO.OrderTracking? Tracking(int id)
    {
        try
        {
            bool found = false;

            foreach (DO.Order? o in Dal.Order.GetAll())
            {
                if (o?.ID == id)
                {
                    found = true;
                }
            }
            if (found)
            {
                List<BO.OrderItem?> ListOrderItemBo = new List<BO.OrderItem?>();
                BO.OrderItem BoOrderItem = new BO.OrderItem();

                foreach (DO.OrderItem oi in Dal?.OrderItem.GetAll()!)
                {
                    if (oi.OrderID == id)
                    {

                        BoOrderItem = new BO.OrderItem();
                        BoOrderItem.Id = oi.ID;
                        BoOrderItem.ProductID = oi.ProductID;
                        BoOrderItem.NameProduct = Dal?.Product.Get(oi.ProductID)?.Name;
                        BoOrderItem.Price = oi.Price;
                        BoOrderItem.QuantityInCart = oi.Amount;
                        BoOrderItem.PriceOfAll = oi.Amount * oi.Price;

                        ListOrderItemBo.Add(BoOrderItem);
                    }
                }

                return new BO.OrderTracking()
                {
                    OrderID = id,
                    Status = (BO.Enums.OrderStatus)Dal.Order.GetNumStatus(id),
                    Items = ListOrderItemBo,
                };
            }
            else throw new BO.DontExistException("the order dont exist");
        }

        catch (BO.DontExistException) { throw new BO.DontExistException("the order dont exist"); }
    }

    public BO.Order? update(int id)
    {
        try
        {
            DO.Order? order = Dal.Order.Get(id);

            bool flag = false;
            foreach (DO.Order? o in Dal.Order.GetAll())
            {
                if (o?.ID == id)
                {
                    flag = true;
                }
            }
            if (flag)
            {
                DO.Order? newOrder;
                newOrder = new() // create new order
                {
                    ID = order?.ID ?? throw new BO.MissingException("ID missing"),

                    CustomerName = order?.CustomerName ?? throw new BO.MissingException("Name missing"),

                    CustomerEmail = order?.CustomerEmail ?? throw new BO.MissingException("Email missing"),

                    CustomerAddress = order?.CustomerAddress ?? throw new BO.MissingException("Address missing"),

                    OrderDate = order?.OrderDate ?? throw new BO.MissingException("OrderDate missing"),

                    ShipDate = DateTime.Now,
                };

                Dal.Order.Update((DO.Order)newOrder);
            }

            else throw new BO.DontExistException("the order dont exist");
        }
        catch (DalApi.DO.AlreadyExistException) { throw new BO.AlreadyExistException("the product dont exist"); }

        return Get(id);
    }

    public BO.Order? updateDelivrery(int id)
    {
        try
        {
            DO.Order? order = Dal.Order.Get(id);

            bool flag = false;
            foreach (DO.Order? o in Dal.Order.GetAll())
            {
                if (o?.ID == id)
                {
                    flag = true;
                }
            }

            if (flag)
            {

                order = new() // create new order
                {
                    ID = order?.ID ?? throw new BO.MissingException("ID missing"),

                    CustomerName = order?.CustomerName ?? throw new BO.MissingException("Name missing"),

                    CustomerEmail = order?.CustomerEmail ?? throw new BO.MissingException("Email missing"),

                    CustomerAddress = order?.CustomerAddress ?? throw new BO.MissingException("Address missing"),

                    OrderDate = order?.OrderDate ?? throw new BO.MissingException("OrderDate missing"),

                    ShipDate = order?.ShipDate ?? throw new BO.MissingException("DeliveryDate missing"),

                    DeliveryDate = DateTime.Now,

                };

                Dal?.Order.Update((DO.Order)order);
                //}
                //else throw new BO.ErrorDontExist("Id of Order no valid");
            }
            else throw new BO.DontExistException("the order dont exist");
        }

        catch (DalApi.DO.AlreadyExistException) { throw new BO.AlreadyExistException("the product dont exist"); }

        return Get(id);
    }
}
