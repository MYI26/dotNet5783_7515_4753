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
public class DalProduct : IProduct //attention ici on nous demander du internal
{

   //public List<Product> GetByOrderId(int id) { return new List<Product>(); }                                                               ??
    //add a product in the list of products and returns his Id
    public int Add(Product p1)
    {
        Exception1 E = new Exception1();
        foreach(Product p in listProduct)
        {
            if(p.ID == p1.ID)
            {
                E.ExeptionAlreadyExist();                                                                                                     //
            }
        }

        listProduct.Add(p1);

        return p1.ID;      
    }

    //delete a product in the list of products
    public void Delet(int id)
    {

        bool found = false;

        foreach (Product p in listProduct)
        {
            if (p.ID == id)
              listProduct.Remove(p);
            found = true;
            break;
        }
        if (found = !true)
            ExeptionDontExist();                                                                                        //
       
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
        if (found = !true)
            ExeptionDontExist();

    }


    public Product Ask(int id)
    {

        foreach (Product p in listProduct)
        {
            if (p.ID == id)
            {
                return p;
            }
        }

        ExeptionDontExist();
    }

    public List<Product> Ask()
    {
        List<Product> product = new List<Product>();

        foreach (Product oI in listProduct)
        {
            product.Add(oI);
        }
        return product;
    }

    IEnumerable<Product> AskAll(Func<Product, bool> filter = null) {  }                                //??

}
        

     









