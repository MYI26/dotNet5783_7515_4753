using BlApi;
using Dal;
using System.ComponentModel;

namespace BlImplementation;

internal class Cart : ICart
{

   private static DalList Dal = new DalList();
    public BO.Cart? AddProduct(BO.Cart cart, int productId) // place product with productid in the list orderitem of the cart
    {
        if (productId <= 0) throw new BO.ErrorIdException("Produt ID is not a positive number");
        if (cart == null) throw new BO.ErrorDontExist("Cart dont exist");
        if (cart.Items == null) cart.Items = new();  // creat new List<OrderItem?>
        DO.Product product; // creation of new product Product in DO
        try { product = Dal.Product.Get(productId) ?? throw new BO.MissingException("product dont exist"); } // place the product with id productId in the new product
        catch (DalApi.DO.DontExistException) // the Exeption that ask can return 
        {
            throw new BO.DontExist("the Id dont valid"); // the exeption if the id of productid dont ewist
        }

        BO.OrderItem item = new() // creat new orderitem
            {
                Id = 0,
                NameProduct = product.Name,
                Price = product.Price,
                QuantityInCart = 1,
                PriceOfAll = product.Price,
                ProductID = productId
            };

        

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

        //try
        //{
        //    if (newItem) cart.Items?.Add(item);
        //}
        //catch (DalApi.DO.AlreadyExistException)
        //{

        //    throw new BO.AlreadyExistException("the order item already exist");//the product already exist
        //}

        return cart;
    }
 
   
    public void UpdateTotalSum(BO.Cart cart)
    {
        foreach (BO.OrderItem oi in cart.Items)
            cart.TotalPrice = (double)(oi.Price * oi.QuantityInCart);

        //cart.TotalPrice = cart.Items?.Sum(c => c?.Price * c?.QuantityInCart) ?? 0; // the same line that the top
    }
 

    public void ConfirmationCard(BO.Cart cart)
    {

        try
        {
            DO.Product product;
            if (cart == null) throw new BO.ErrorDontExist("Cart dont exist");
            if (cart.CustomerName == null) throw new BO.ErrorDontExist("Cart dont exist");
            if (cart.CustomerAddress == null) throw new BO.ErrorDontExist("Cart dont exist");
            if (cart.CustomerEmail == null) throw new BO.ErrorDontExist("Cart dont exist");
            if (cart.CustomerEmail != cart.CustomerName + "@gmail.com") throw new BO.ErrorDontExist("Cart dont exist");


            foreach (BO.OrderItem oi in cart.Items)
                if (oi.ProductID <= 0) throw new BO.DontExist("the Id dont valid");

            // if (cart.Items.QuantityInCart > product.InStock) { throw new BO.NotEnought("ther is no enough product items in stock"); }

        }

        catch (BO.DontExist) { throw new BO.DontExist("the Id dont valid"); }
        catch (BO.ErrorDontExist) { throw new BO.DontExist("Cart dont exist"); }


        DO.Order orderdo = new DO.Order();

        orderdo.CustomerName = cart.CustomerName;
        orderdo.CustomerEmail = cart.CustomerEmail;
        orderdo.CustomerAddress = cart.CustomerAddress;
        orderdo.OrderDate = DateTime.Now;
        orderdo.ShipDate = null;
        orderdo.DeliveryDate = null;
        

        int temp = Dal.Order.Add(orderdo);


        foreach (BO.OrderItem oi in cart.Items)
        {
            DO.Product product = new DO.Product();
            //int index = 0;
            // BO.OrderItem o = new BO.OrderItem();
            DO.OrderItem orderitemdo = new DO.OrderItem();
            // oi = cart.Items[index++];
            orderitemdo.OrderID = temp;
            orderitemdo.ID = (int)oi.Id;
            orderitemdo.ProductID = (int)oi.ProductID;
            product = Dal.Product?.Get(orderitemdo.ProductID) ?? throw new BO.MissingException("product dont exist");
            product.InStock--;
            Dal.Product.Update(product);
            orderitemdo.Price = 0;
            orderitemdo.Amount = cart.Items.Count;


            Dal.OrderItem.Add(orderitemdo);
            //enlever le produit en stock instock--


        }



    }

}
