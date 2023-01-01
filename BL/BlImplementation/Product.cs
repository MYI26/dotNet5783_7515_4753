using BlApi;
using BO;
using Dal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
                MyCategory = (DO.Enums.Category)product.MyCategory,
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

        catch(Exception e) { throw e; }

    }

    public BO.Product Get(int id)
    {
        try
        {
            if (id <= 0) throw new BO.ErrorIdException("Produt ID is not a positive number");
            DO.Product? product = Dal?.Product.Get(id); //place the product id in new product of DO
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

        catch (BO.ErrorIdException)
        {
            throw new BO.ErrorIdException("ERROR ID");
        }
    }



    public BO.ProductItem Get(int id, BO.Cart cart1)
    {
        try
        {
            bool flag = false;
            int compt = 0;
            if (id <= 0) throw new BO.ErrorIdException("Produt ID is not a positive number");
            IEnumerable<DO.Product> listproduct = Dal?.Product.GetAll();
            foreach (DO.Product p in listproduct)
                if (p.ID == id) { compt++; }
            if (compt != 1)
            {
                throw new BO.ErrorIdException("Produt Dont exist");
            }

            if (cart1 == null) throw new BO.ErrorDontExist("Cart dont exist");

                DO.Product? product = Dal?.Product.Get(id); //place the product id in new product of DO

            if (cart1.Items == null) cart1.Items = new();  // creat new List<OrderItem?>

            IEnumerable<BO.OrderItem?> listorderitem = cart1.Items;

                foreach (BO.OrderItem? orderitem in listorderitem)
                    if (orderitem.ProductID == id) { flag = true; break; }
                //we check that this product our cart

                if (flag == true)
                {
                    return new BO.ProductItem()
                    {
                        ProductID = product?.ID ?? throw new BO.MissingException("ID missing"),
                        Name = product?.Name ?? throw new BO.MissingException("Name missing"),
                        Price = product?.Price ?? throw new BO.MissingException("Price missing"),
                        Category = (BO.Enums.Category?)(product?.MyCategory ?? throw new BO.MissingException("MyCartegory missing")),
                        Availability = true,
                        QuantityInCart = product?.InStock,
                    };
                }

                else { throw new BO.DontExistException("Product ID dont exist in the cart"); }
            
        }
        
        catch (BO.MissingException)
        {

            throw new BO.Missing("Entity missing");
        }

        catch (BO.ErrorIdException)
        {

            throw new BO.ErrorIdException("Product Dont exist");
        }

        catch (BO.DontExistException)
        {

            throw new BO.ErrorIdException("Product ID dont exist in the cart");
        }

    }

    public IEnumerable<BO.ProductForList?> GetProductList() { 
    
        return from product in Dal?.Product.GetAll() //from == a partir de, select new == new
        select new BO.ProductForList
        {
            ProductID = product.ID,
            Name = product.Name,
            Price = product.Price,
            Category = (BO.Enums.Category?)product.MyCategory,

        };
    }
    public IEnumerable<BO.ProductItem?> GetProductCatalog() =>

        from product in Dal?.Product.GetAll() //from == a partir de, select new == new
        select new BO.ProductItem
        {
            ProductID = product.ID,
            Name = product.Name,
            Price = product.Price,
            Category = (BO.Enums.Category?)product.MyCategory,
            Availability = true,
            QuantityInCart = product.InStock,
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
                MyCategory = (DO.Enums.Category)product.MyCategory,
                InStock = product.InStock,

            };


            Dal?.Product.Update(product1);
        }

        catch (DalApi.DO.AlreadyExistException) { throw new BO.AlreadyExistException("the product dont exist"); }
    }
}