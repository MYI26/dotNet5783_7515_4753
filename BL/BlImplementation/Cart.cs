using BlApi;
using System;
using System.Diagnostics;

namespace BlImplementation;

internal class Cart : ICart
{
    DalApi.IDal? Dal = DalApi.Factory.Get();

    //BlApi.IBl? bl = BlApi.Factory.Get();

    static readonly Random random = new Random();

    public BO.Cart? AddProduct(BO.Cart cart, int productId) // place product with productid in the list orderitem of the cart
    {
        try
        {
            if (productId <= 0)
                throw new BO.ErrorIdException("Produt ID is not a positive number");

            if (cart == null)
                throw new BO.ErrorDontExist("Cart dont exist");
        }

        catch (BO.ErrorIdException ex) // the Exeption that ask can return 
        {
            throw new BO.DontExist( /*"the Id dont valid",*/ ex); // the exeption if the id of productid dont ewist
        }

        DO.Product product; // creation of new product Product in DO

        try { product = Dal.Product.Get(productId) ?? throw new BO.MissingException("product dont exist"); }
              // place the product with id productId in the new product

       catch( BO.MissingException ex) // the Exeption that ask can return 
        {
            throw new BO.DontExist(/*"the Id dont valid",*/ ex); // the exeption if the id of productid dont ewist
        }

        if (cart.Items == null)
            cart.Items = new();  // creat new List<OrderItem?>

        BO.OrderItem item = new() // creat new orderitem
        {
                Id = random.Next(100000, 1000000),//ce nest pas orderid don pas Dal.OrderItem.GetAll().Count()+1000
                NameProduct = product.Name,
                Price = product.Price,
                QuantityInCart = 1,
                PriceOfAll = product.Price * 1,
                ProductID = productId
        };

        //DO.OrderItem item1 = new() // creat new orderitem            on les met seumlment dans le cart.items pui lors de la validtion on les mettra dans la base de donner
        //{
        //    ID = item.Id,//ce nest pas orderid don pas Dal.OrderItem.GetAll().Count()+1000
        //    OrderID = 0,           
        //    Price = product.Price,
        //    Amount = 1,            
        //    ProductID = productId
        //};

        //Dal.OrderItem.Add(item1);

      cart.Items.Add(item);
      
                  
        UpdateTotalSum(cart);
        //BO.OrderItem item = cart.Items?.FirstOrDefault(item => item.ProductID == productId)!; // we place in item the fist orderitem of the list orderitem of the cart and place productId in the ProductId of orderitem of item
        //bool newItem = item == null;  // newItem == true if item == null

        //if (newItem)// if newItem == null 
        //{
        //    item = new() // creat new orderitem
        //    {
        //        Id = 0,
        //        NameProduct = product.Name,
        //        Price = product.Price,
        //        QuantityInCart = 0,
        //        PriceOfAll = product.Price,
        //        ProductID = productId
        //    };
        //}
        //if (item.QuantityInCart > product.InStock) { throw new BO.NotEnought("ther is no enough product items in stock"); }// if the consomer want to take mor product that exist

        return cart;
    }

   
    public void UpdateTotalSum(BO.Cart cart)
    {
        cart.TotalPrice = 0;
        foreach (BO.OrderItem? oi in cart.Items!)
            cart.TotalPrice += (double)(oi?.Price * oi?.QuantityInCart)!;
    }


    public int ConfirmationCard(BO.Cart cart)
    {
        //we check what the user has enterred
        try
        {
            if (cart == null) throw new BO.ErrorDontExist("your card don't exist");
            if (cart.CustomerName == null) throw new BO.ErrorDontExist("you must enter a name");
            if (cart.CustomerAddress == "") throw new BO.ErrorDontExist("you must enter an address");
            if (cart.CustomerEmail == null) throw new BO.ErrorDontExist("you must enter a mail");
            if (!cart.CustomerEmail.Contains("@gmail.com")) throw new BO.ErrorDontExist("your mail don'tt valid");
            if (cart.Items != null)
            foreach (BO.OrderItem? oi in cart.Items)
                {
                    if (oi?.ProductID <= 0) throw new BO.ErrorDontExist("Id not valid");
                    //il reste à vérifier ici si on a assez de produits en stock
                    //if (oi?.QuantityInCart > bl?.Product?.Get(oi!.Id)?.InStock)
                    //{ throw new BO.ErrorDontExist("We don't have enought in stock"); }
                }
            else throw new BO.ErrorDontExist("you haven't products in your cart");
        }

        catch (BO.ErrorDontExist ex) { throw ex; }


        //the cart becomes an order for the DO database
        DO.Order orderdo = new DO.Order();
        orderdo.CustomerName = cart.CustomerName;
        orderdo.CustomerEmail = cart.CustomerEmail;
        orderdo.CustomerAddress = cart.CustomerAddress;
        orderdo.OrderDate = DateTime.Now;
        orderdo.ShipDate = null;
        orderdo.DeliveryDate = null;
       
        int OrderId = Dal!.Order.Add(orderdo);

        foreach (BO.OrderItem? oI in cart.Items)
        {
            DO.OrderItem orderItemDo = new DO.OrderItem();
            orderItemDo.ID = (int)oI!.Id;
            orderItemDo.ProductID = (int)oI.ProductID;
            orderItemDo.OrderID = OrderId;
            orderItemDo.Price = oI.Price;
            orderItemDo.Amount = oI.QuantityInCart;
            Dal.OrderItem.Add(orderItemDo);
            //il reste à modifier la qté de prduit en stock apres la commande
            //dans la base de donnée DO
        }
        return OrderId;
    }
}
