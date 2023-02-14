using System;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using DalApi.DO;
using static Dal.DataSource;
using DalApi;
using DO;

namespace Dal;

//We will add a declaration of the corresponding entity interface implementation
//as defined in DalApi
internal class DalProduct : IProduct
{
    //add a product in the list of products and returns his Id
    public int Add(Product p1)
    {

        IEnumerable<Product> listproduct3 =     
            from p in listProduct
            where p?.ID == p1.ID
            select p1;

        foreach (var p3 in listproduct3)
        {
            throw new AlreadyExistException($"the product whith ID: {p1.ID} already exist");
        }

        listProduct.Add(p1);
        return p1.ID;
    }

    //delete a product in the list of products
    public void Delete(int id)
    {

        IEnumerable<Product?> listproduct4 =     
            from p in listProduct
            where p?.ID == id
            select p;

        if (listproduct4 != null)
        {
            foreach (var p3 in listproduct4.ToList())
            {
                listProduct.Remove(p3);
            }
        }

        else
        {
            throw new DontExistException("the product dont exist");
        }
    }

    public void Update(Product P1)
    {

        bool found = false;

        foreach (Product p in listProduct)
        {
            if (p.ID == P1.ID)
            {
                listProduct[listProduct.IndexOf(p)] = P1;
                found = true;
                break;
            }
        }

        if (found != true)
            throw new DontExistException("the product dont exist");

    }

    public Product? Get(int id)
    {

        IEnumerable<Product?> listproduct4 =      
            from p in listProduct
            where p?.ID == id
            select p;

        if (listproduct4 != null)
        {
            foreach (var p3 in listproduct4)
            {
                return p3;
            }
        }

        return null;
    }

    public IEnumerable<Product?> GetAll(Func<Product?, bool>? filter = null)
    {

        IEnumerable<Product?> listproduct = listProduct;

        if (filter == null)
        {
            return listproduct;
        }

        else
        {
            IEnumerable<Product?> arr2 = listproduct.Where(p => filter(p) == true).Select(item => item);  

            return arr2;
        }
    }
}












