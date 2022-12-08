using BlApi;
using BO;
using Dal;
using DalApi;
using DO;

namespace BlImplementation;

internal class Order : IOrder
{

    private static DalList Dal = new DalList();
    public BO.Order Ask(int id)
    {
        try
        {
            DO.Order? order = Dal?.Order.Ask(id); //place the order id in new oroduct of DO

            return new BO.Order()
            {
                OrderID = order?.ID ?? throw new BO.MissingException("ID missing"),

                CustomerName = order?.CustomerName ?? throw new BO.MissingException("Name missing"),

                CustomerEmail = order?.CustomerEmail ?? throw new BO.MissingException("Email missing"),

                CustomerAddress = order?.CustomerAddress ?? throw new BO.MissingException("Address missing"),

                Status = (BO.Enums.OrderStatus)1,

                OrderDate = order?.OrderDate ?? throw new BO.MissingException("OrderDate missing"),

                ShipDate = order?.ShipDate ?? throw new BO.MissingException("ShipDate missing"),

                DeliveryDate = order?.DeliveryDate ?? throw new BO.MissingException("DeliveryDate missing"),

                Items = null,

                TotalPrice = 0,

            };

        }

        catch (BO.MissingException)
        {

            throw new BO.Missing("Entity missing");
        }
    }

    public IEnumerable<BO.OrderForList?> Ask()
    {
        IEnumerable<BO.OrderForList?> listorder = new List<OrderForList>(); return listorder;
    }

    public BO.OrderTracking Tracking(int id)
    {
        try
        {
            DO.Order? order = Dal?.Order.Ask(id);

            if (order != null)
            {
                return new BO.OrderTracking()
                { OrderID = id,
                   Status = (BO.Enums.OrderStatus)1,
                   Items = null,
                };
            }
            else throw new BO.DontExistException("the order dont exist");
        }
        catch (BO.DontExistException) { throw new BO.DontExistException("the order dont exist"); }
    }

    public BO.Order update(int id)
    {
        
        DO.Order? order = Dal?.Order.Ask(id);
        if (id <= 0) throw new BO.ErrorIdException("Produt ID is not a positive number");
        try
        {
            order = new() // creat new product
            {
                OrderID = order?.ID ?? throw new BO.MissingException("ID missing"),

                CustomerName = order?.CustomerName ?? throw new BO.MissingException("Name missing"),

                CustomerEmail = order?.CustomerEmail ?? throw new BO.MissingException("Email missing"),

                CustomerAddress = order?.CustomerAddress ?? throw new BO.MissingException("Address missing"),

                Status = (BO.Enums.OrderStatus)1,

                OrderDate = order?.OrderDate ?? throw new BO.MissingException("OrderDate missing"),

                ShipDate = order?.ShipDate ?? throw new BO.MissingException("ShipDate missing"),

                DeliveryDate = order?.DeliveryDate ?? throw new BO.MissingException("DeliveryDate missing"),

                Items = null,

                TotalPrice = 0,

            };


            Dal?.Product.Update(order);
        }

        return 

        catch (DalApi.DO.AlreadyExistException) { throw new BO.AlreadyExistException("the product dont exist"); }
    }

    public BO.Order updateDelivrery(int id)
    {
        throw new NotImplementedException();
    }
}
