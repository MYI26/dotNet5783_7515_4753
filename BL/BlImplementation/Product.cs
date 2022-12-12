using BlApi;
using Dal;

namespace BlImplementation;

internal class Product : IProduct
{

    // private static readonly IDal? Dal = Factory.Get();
    private static DalList Dal = new DalList();
    public void Add(BO.Product product)
    {

        DO.Product product1;
        if (product.ProductID <= 0) throw new BO.ErrorIdException("Produt ID is not a positive number");
        try
        {
            product1 = new() // creat new product
            {
                ID = product.ProductID,
                Name = product.Name,
                Price = product.Price,
                MyCategory = (DO.Enums.Category?)product.MyCategory,
                InStock = product.InStock,

            };


            Dal?.Product.Add(product1);
        }

        catch (DalApi.DO.AlreadyExistException) { throw new BO.AlreadyExistException("the product dont exist"); } 

    }

    public void Delete(int id)
    {
        try
        {
            Dal?.Product.Delete(id);
        }

        catch(DalApi.DO.DontExistException) { throw new BO.DontExistException("the product dont exist"); }

    }

    public BO.Product Ask(int id)
    {
        try
        {
            DO.Product? product = Dal?.Product.Ask(id); //place the product id in new product of DO
            return new BO.Product()
            {
                ProductID = product?.ID ?? throw new BO.MissingException("ID missing"),
                Name = product?.Name ?? throw new BO.MissingException("Name missing"),
                Price = product?.Price ?? throw new BO.MissingException("Price missing"),
                MyCategory = (BO.Enums.Category?)(product?.MyCategory ?? throw new BO.MissingException("MyCartegory missing")),
                InStock = product?.InStock ?? throw new BO.MissingException("quantity in stock missing"),

            };

        }

        catch (BO.MissingException)
        {

            throw new BO.Missing("Entity missing");
        }

     
    }

    public BO.Product Ask(int id, BO.Cart cart1)
    {
        try {
            bool flag = false;
            DO.Product? product = Dal?.Product.Ask(id); //place the product id in new product of DO
            if (id <= 0) throw new BO.ErrorIdException("Produt ID is not a positive number");
            if (cart1 == null) throw new BO.ErrorDontExist("Cart dont exist");

            IEnumerable<BO.OrderItem?> listorderitem = cart1.Items;

            foreach (BO.OrderItem? orderitem in listorderitem)       
               if(orderitem.ProductID == id) {  flag = true; break; }


            if (flag == true)
            {
                return new BO.Product()
                {
                    ProductID = product?.ID ?? throw new BO.MissingException("ID missing"),
                    Name = product?.Name ?? throw new BO.MissingException("Name missing"),
                    Price = product?.Price ?? throw new BO.MissingException("Price missing"),
                    MyCategory = (BO.Enums.Category?)(product?.MyCategory ?? throw new BO.MissingException("MyCartegory missing")),
                    InStock = product?.InStock ?? throw new BO.MissingException("quantity in stock missing"),
                };
            }

            else { throw new BO.ErrorIdException("Produt ID dont exist in the cart"); }
        }
        catch (BO.MissingException)
        {

            throw new BO.Missing("Entity missing");
        }
    }

    public IEnumerable<BO.ProductForList?> GetProduct()=>
    
        from product in Dal?.Product.AskAll() //from == a partir de, select new == new
        select new BO.ProductForList
        {
            ProductID = product.ID,
            Name = product.Name,
            Price = product.Price,
            Category = (BO.Enums.Category?)product.MyCategory,

        };
        


    public void Update(BO.Product product)
    {
        DO.Product product1;
        if (product.ProductID <= 0) throw new BO.ErrorIdException("Produt ID is not a positive number");
        try
        {
            product1 = new() // creat new product
            {
                ID = product.ProductID,
                Name = product.Name,
                Price = product.Price,
                MyCategory = (DO.Enums.Category?)product.MyCategory,
                InStock = product.InStock,

            };


            Dal?.Product.Update(product1);
        }

        catch (DalApi.DO.AlreadyExistException) { throw new BO.AlreadyExistException("the product dont exist"); }
    }
}