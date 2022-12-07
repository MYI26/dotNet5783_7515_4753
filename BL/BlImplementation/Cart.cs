using BlApi;
using Dal;
using DalApi;
using DalApi.DO;
using System.Data;

namespace BlImplementation;

internal class Cart : ICart
{

   private static DalList Dal = new DalList();
    public BO.Cart AddProduct(BO.Cart cart, int productId) // place product with productid in the list orderitem of the cart
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
        BO.OrderItem item = cart.Items?.FirstOrDefault(item => item.ProductID == productId)!; // we place in item the fist orderitem of the list orderitem of the cart and place productId in the ProductId of orderitem of item
        bool newItem = item == null;  // newItem == true if item == null

        if(newItem)// if newItem == null 
        {
            item = new() // creat new orderitem
            {
                Id = 0,
                NameProduct = product.Name,
                Price = product.Price,
                QuantityInCart = 0,
                PriceOfAll = product.Price,
                ProductID = productId
            };
        }
        if (item.QuantityInCart > product.InStock) { throw new BO.NotEnought("ther is no enough product items in stock"); }// if the consomer want to take mor product that exist

        try
        {
            if (newItem) cart.Items?.Add(item);
        }
        catch (AlreadyExistException) {

            throw new BO.AlreExist("the order item already exist");//the product already exist
        }

        return cart;
    }
 
    public void ConfirmationCard(BO.Cart cart)
    {
        throw new NotImplementedException();
    }
    
    public void UpdateTotalSum(BO.Cart cart)
    {
        throw new NotImplementedException();
    }
}
   