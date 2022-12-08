using BlApi;
using Dal;


namespace BlImplementation;

internal class Product : IProduct
{

    // private static readonly IDal? Dal = Factory.Get();
    private static DalList Dal = new DalList();
    public void Add(BO.Product product)
    {

        DO.Product? product1;
        if (product.ProductID <= 0) throw new BO.ErrorIdException("Produt ID is not a positive number");
        try
        {
            product1 = new() // creat new product
            {
                ID = product.ProductID,
                Name = product.Name,
                Price = product.Price,
                MyCategory = product.MyCategory,
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

        catch(DalApi.DO.DontExistException) {throw new BO.DontExistException("the product dont exist") }

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
                MyCategory = product?.MyCategory ?? throw new BO.MissingException("MyCartegory missing"),
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
        throw new NotImplementedException();
    }

    public IEnumerable<BO.ProductForList?> GetProduct()
    {
       return  Dal.Product.AskAll(); 
    }


    public void Update(BO.Product product)
    {
        throw new NotImplementedException();
    }
}