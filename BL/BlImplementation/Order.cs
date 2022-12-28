using BlApi;
using Dal;
namespace BlImplementation;

internal class Order : IOrder
{

    private static DalList Dal = new DalList();
    public BO.Order Ask(int id) // je recois un ID BO et je veut retourner un BO seulement la base de donner et les fontion sont dans DO 
    {
        try
        {
            DO.Order? order = Dal?.Order.Ask(id); //je recher dans la base de donner les order associer

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

    public IEnumerable<BO.OrderForList?> GetOrder()=>
    
        from order in Dal?.Order.AskAll() //from == a partir de, select new == new
        select new BO.OrderForList
        {
            OrderID = order.ID,
            CustomerName = order.CustomerName,
            Status = 0,
            Amount = 0,
            TotalPrice = 0, 

        };
    

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

    public BO.Order update(int id) // est ce que je recois le id d,un order deja modifier ou pas ?
    {

        DO.Order? order = Dal?.Order.Ask(id);
        if (id <= 0) throw new BO.ErrorIdException("Produt ID is not a positive number");
        try
        {
            order = new() // creat new order
            {
                ID = order?.ID ?? throw new BO.MissingException("ID missing"),

                CustomerName = order?.CustomerName ?? throw new BO.MissingException("Name missing"),

                CustomerEmail = order?.CustomerEmail ?? throw new BO.MissingException("Email missing"),

                CustomerAddress = order?.CustomerAddress ?? throw new BO.MissingException("Address missing"),

                OrderDate = order?.OrderDate ?? throw new BO.MissingException("OrderDate missing"),

                ShipDate = order?.ShipDate ?? throw new BO.MissingException("ShipDate missing"),

                DeliveryDate = order?.DeliveryDate ?? throw new BO.MissingException("DeliveryDate missing"),

               
            };

            DO.Order order1 = (DO.Order)order;
            Dal?.Order.Update(order1);
        }

        catch (DalApi.DO.AlreadyExistException) { throw new BO.AlreadyExistException("the product dont exist"); }

        return Ask(id);
    }

    public BO.Order updateDelivrery(int id)  // je ne sais pas ce quil faut faire
    {
        DO.Order? order = Dal?.Order.Ask(id);
        if (id <= 0) throw new BO.ErrorIdException("Produt ID is not a positive number");
        try
        {
            order = new() // creat new order
            {
                ID = order?.ID ?? throw new BO.MissingException("ID missing"),

                CustomerName = order?.CustomerName ?? throw new BO.MissingException("Name missing"),

                CustomerEmail = order?.CustomerEmail ?? throw new BO.MissingException("Email missing"),

                CustomerAddress = order?.CustomerAddress ?? throw new BO.MissingException("Address missing"),

                OrderDate = order?.OrderDate ?? throw new BO.MissingException("OrderDate missing"),

                ShipDate = order?.ShipDate ?? throw new BO.MissingException("ShipDate missing"),

                DeliveryDate = order?.DeliveryDate ?? throw new BO.MissingException("DeliveryDate missing"),


            };

            DO.Order order1 = (DO.Order)order;
            Dal?.Order.Update(order1);
        }

        catch (DalApi.DO.AlreadyExistException) { throw new BO.AlreadyExistException("the product dont exist"); }

        return Ask(id);
    }



}
