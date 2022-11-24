using System;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using static Dal.DataSource;
using DalApi;
using DO;
namespace Dal;

//We will add a declaration of the corresponding entity interface implementation
//as defined in DalApi
internal class DalDoEntity : IDoEntity
{
}

//we must change the class to internal
internal class DalProduct
{

    //add a product in the list of products and returns his Id
    public int AddProduct(Product p1)
    {

        foreach(Product p in listProduct)
        {
            if(p.ID == p1.ID)
            {
                throw new Exception("the product already exist");
            }
        }

        listProduct.Add(p1);

        return p1.ID;      
    }

    //delete a product in the list of products
    public void DeleteProduct(int id)
    {

        Product p1 = new Product();

        foreach (Product p in listProduct)
        {
            if (p.ID == id)
                p1 = p;
        }
        if(p1.ID < 10000 || p1.ID > 100000)
            throw new Exception("the product dosn't exist");

        listProduct.Remove(p1);
    }

    public void UpdateProduct(Product P1)
    {

        for (int i = 0; i < Config.startIndexlTabProduct; i++)
        {
            if (DataSource.tabProduct[i].ID == P1.ID)
            {
                DataSource.tabProduct[i] = P1;
                return;
            }
        }
        throw new Exception("the product dont exist");
    }

    public Product AskProduct(int id)
    {
        for (int i = 0; i < Config.startIndexlTabProduct; i++)
        {
            if (DataSource.tabProduct[i].ID == id)
            {
                return DataSource.tabProduct[i];
            }
        }

        throw new Exception("the product dont exist");
    }

    public Product[] AskProduct()
    {
        Product[] product = new Product[Config.startIndexlTabProduct];
        for (int i = 0; i < Config.startIndexlTabProduct; i++)
        {
            product[i] = DataSource.tabProduct[i];
        }
        return product;
    }
}
        

     









