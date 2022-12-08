using BlApi;
using BO;
using Dal;

namespace BlImplementation;

internal class Product : IProduct
{

    // private static readonly IDal? Dal = Factory.Get();
    private static DalList Dal = new DalList();
    public void Add(BO.Product product)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
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

        catch(BO.MissingException) {
        
        throw new BO.Missing("Entity missing");
        }
     
    }

    public BO.Product GetByid(int id, BO.Cart cart1)
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