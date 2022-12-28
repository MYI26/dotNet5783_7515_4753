using BlApi;
namespace BlImplementation;

internal class Cart : ICart
{
    public BO.Cart AddProduct(BO.Cart cart, int productId)
    {
        if (productId <= 0) throw new BO.ErrorIdException("Produt ID is not a positive number");
        if (cart == null) throw new BO.ErrorDontExist("Cart dont exist");
        if (cart.Items == null) cart.Items = new();  // creat new List<OrderItem?>
        DO.Product product; // creation of new product Product in DO
        try { product = Dal.Product.Ask(productId); } // place the product with id productId in the new product
        catch (DalApi.DO.DontExistException) // the Exeption that ask can return 
        {
            throw new BO.DontExist("the Id dont valid"); // the exeption if the id of productid dont ewist
        }
        BO.OrderItem item = cart.Items?.FirstOrDefault(item => item.ProductID == productId)!; // we place in item the first orderitem of the list orderitem of the cart and place productId in the ProductId of orderitem of item
        bool newItem = item == null;  // newItem == true if item == null

    public void ConfirmationCard(BO.Cart cart)
    {
        throw new NotImplementedException();
    }
 
   
    public void UpdateTotalSum(BO.Cart cart)//update totale summ of product
    {
        foreach (OrderItem? oi in cart?.Items)
            cart.TotalPrice = cart.TotalPrice + (oi.Price * oi.QuantityInCart);

        //cart.TotalPrice = cart.Items?.Sum(c => c?.Price * c?.QuantityInCart) ?? 0; // the same line that the top
    }

    public void ConfirmationCard(BO.Cart cart)
    {
       
        try
        {
            DO.Product product;
            if (cart == null) throw new BO.ErrorDontExist("Cart dont exist");
            if(cart.CustomerName == null) throw new BO.ErrorDontExist("Cart dont exist");
            if (cart.CustomerAddress == null) throw new BO.ErrorDontExist("Cart dont exist");
            if (cart.CustomerEmail == null) throw new BO.ErrorDontExist("Cart dont exist");
            if (cart.CustomerEmail != cart.CustomerAddress + "@gmail.com") throw new BO.ErrorDontExist("Cart dont exist");
            foreach (BO.OrderItem oi in cart.Items)
                if(oi.ProductID <= 0 || oi.Id <= 0) throw new BO.DontExist("the Id dont valid");

           // if (cart.Items.QuantityInCart > product.InStock) { throw new BO.NotEnought("ther is no enough product items in stock"); }

        }

        catch(DontExist) { throw new BO.DontExist("the Id dont valid"); }



        DO.Order orderdo = new DO.Order();
        
        orderdo.ID = 0;
        orderdo.CustomerName = cart.CustomerName;
        orderdo.CustomerEmail = cart.CustomerEmail;
        orderdo.CustomerAddress = cart.CustomerAddress;
        orderdo.OrderDate = DateTime.Today.AddDays(0);//mettre a 00:00:00
        orderdo.ShipDate = DateTime.Now;
        orderdo.DeliveryDate = DateTime.Today.AddDays(0);//mettre a 00:00:00


        foreach (BO.OrderItem oi in cart.Items)
        {
            int index = 0;
            BO.OrderItem o = new BO.OrderItem();
            DO.OrderItem orderitemdo = new DO.OrderItem();
            o = cart.Items[index++];
            orderitemdo.OrderID = Dal.Order.Add(orderdo);
            orderitemdo.OrderItemID = (int)oi.Id;
            orderitemdo.ProductID = (int)oi.ProductID;
            orderitemdo.Price = (int)cart.TotalPrice;
            orderitemdo.Amount = cart.Items.Count;
            Dal.OrderItem.Add(orderitemdo);
           //enlever le produit en stock instock--
        }


    }
}
