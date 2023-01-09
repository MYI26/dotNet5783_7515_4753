using BlApi;
namespace BlImplementation;

internal class Order : IOrder
{

    // private static DalList Dal = new DalList();
    DalApi.IDal?Dal = DalApi.Factory.Get();

    public BO.Order? Get(int id) // 
    {
        try
        {

            if (id > 999)
            {
                DO.Order? order = Dal?.Order.Get(id); //je recher dans la base de donner les order associer


                BO.Order temp = new BO.Order();

                temp.OrderID = order?.ID ?? throw new BO.MissingException("ID missing");

                temp.CustomerName = order?.CustomerName ?? throw new BO.MissingException("Name missing");

                temp.CustomerEmail = order?.CustomerEmail ?? throw new BO.MissingException("Email missing");

                temp.CustomerAddress = order?.CustomerAddress ?? throw new BO.MissingException("Address missing");

                temp.Status = (BO.Enums.OrderStatus)Dal?.Order.GetNumStatus(id);

                temp.OrderDate = order?.OrderDate ?? throw new BO.MissingException("OrderDate missing");

                temp.ShipDate = order?.ShipDate ?? throw new BO.MissingException("ShipDate missing");

                temp.DeliveryDate = order?.DeliveryDate ?? throw new BO.MissingException("DeliveryDate missing");

                temp.Items = GetOrderItem(id);

               

                double temp1 = 0;
                foreach (DO.OrderItem oi in Dal?.OrderItem.GetAll())
                {
                    if (oi.OrderID == id)
                    {
                        temp1 += oi.Amount * oi.Price;

                    }
                }

                temp.TotalPrice = temp1;

                    return temp;

            }

            else throw new BO.ErrorDontExist("Id of Order no valid");
        }

        catch (BO.MissingException)
        {

            throw new BO.Missing("Entity missing");
        }
    }

    public List<BO.OrderItem?>? GetOrderItem(int id) {

        List<BO.OrderItem?> ListOrderItemBo = new List<BO.OrderItem?>();

        BO.OrderItem BoOrderItem = new BO.OrderItem();

        foreach (DO.OrderItem oi in Dal?.OrderItem.GetAll()) {

            if (oi.OrderID == id) {

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


    public IEnumerable<BO.OrderForList?>? GetOrder()=>

    //IEnumerable<DO.Order> listorder = Dal?.Order.GetAll();

    //  foreach (Order p in listOrder){
        
    //    }
        from order in Dal?.Order.GetAll() //from == a partir de, select new == new
        select new BO.OrderForList
        {
            OrderID = order?.ID ?? throw new BO.MissingException("Quantity InCart missing"),
            CustomerName = order?.CustomerName,
            Status = (BO.Enums.OrderStatus)Dal?.Order.GetNumStatus((int)(order?.ID)),
            Amount = Dal?.Order.GetAmoutOrderItem((int)(order?.ID)) ?? throw new BO.MissingException("Quantity InCart missing"),
            TotalPrice = Get((int)(order?.ID)).TotalPrice,
        };

   

    public BO.OrderTracking? Tracking(int id)
    {
        try
        {
            bool flag = false;
            foreach (DO.Order o in Dal?.Order.GetAll())
            {
                if (o.ID == id)
                {
                    flag = true;
                    
                }
            }

            if (flag)
            {

                DO.Order? order = Dal?.Order.Get(id);

                if (order != null)
                {
                    return new BO.OrderTracking()
                    {
                        OrderID = id,
                        Status = (BO.Enums.OrderStatus)Dal?.Order.GetNumStatus(id),
                        Items = null,
                    };
                }
                else throw new BO.DontExistException("the order dont exist");
            }
            else throw new BO.DontExistException("the order dont exist");
        }
        
        catch (BO.DontExistException) { throw new BO.DontExistException("the order dont exist"); }
    }

    public BO.Order? update(int id)
    {


        try
        {
            DO.Order? order = Dal?.Order.Get(id);

            bool flag = false;
            foreach (DO.Order o in Dal?.Order.GetAll())
            {
                if (o.ID == id)
                {
                    flag = true;
                }
            }

            if (flag)
            {
                //if (order?.ShipDate == null)
                //{
                    

                    order = new() // creat new order
                    {
                        ID = order?.ID ?? throw new BO.MissingException("ID missing"),

                        CustomerName = order?.CustomerName ?? throw new BO.MissingException("Name missing"),

                        CustomerEmail = order?.CustomerEmail ?? throw new BO.MissingException("Email missing"),

                        CustomerAddress = order?.CustomerAddress ?? throw new BO.MissingException("Address missing"),

                        OrderDate = order?.OrderDate ?? throw new BO.MissingException("OrderDate missing"),

                        ShipDate = DateTime.Now,

                        DeliveryDate = order?.DeliveryDate ?? throw new BO.MissingException("DeliveryDate missing"),

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

    public BO.Order? updateDelivrery(int id)  // je ne sais pas ce quil faut faire
    {
        try
        {
            DO.Order? order = Dal?.Order.Get(id);

            bool flag = false;
            foreach (DO.Order o in Dal?.Order.GetAll())
            {
                if (o.ID == id)
                {
                    flag = true;
                }
            }

            if (flag)
            {
                //if (order?.DeliveryDate == null)
                //{

                    order = new() // creat new order
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
