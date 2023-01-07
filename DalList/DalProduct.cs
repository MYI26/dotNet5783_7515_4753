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

   //public List<Product> GetByOrderId(int id) { return new List<Product>(); }                                                               ??
    //add a product in the list of products and returns his Id
    public int Add(Product p1)
    {
        
        foreach(Product p in listProduct)
        {
            if(p.ID == p1.ID)
            {
                throw new AlreadyExistException($"the product whith ID: {p1.ID} already exist");                                                                                                     //
            }
        }

        listProduct.Add(p1);
        

        return p1.ID;      
    }

    //delete a product in the list of products
    public void Delete(int id)
    {

        bool found = false;
        foreach(Product p in listProduct) { if(p.ID == id) { listProduct.Remove(p); found = true; } }

        if (found == false)
            throw new DontExistException("the product dont exist");                                                                                        //
       
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

        foreach (Product p in listProduct)
        {
            if (p.ID == id)
            {
                return p;
            }
        }

        throw new DontExistException("the product dont exist");
    }

    //public IEnumerable<Product> Ask()
    //{
    //    List<Product> product = new List<Product>();

    //    foreach (Product oI in listProduct)
    //    {
    //        product.Add(oI);
    //    }

    //    IEnumerable<Product> enumerable = product;

    //    return enumerable;//return IEnumerator
    //}

    public IEnumerable<Product?> GetAll(Func<Product?, bool>? filter = null) {

         IEnumerable<Product?> listproduct = listProduct;

        if (filter == null)
        {
            

            return listproduct;
        }

        else//ici normalement on a pas le droit de creer une bouvelle liste seulement cree un enumerabele qui va trier le list
        {
         //-    List<Product?> newlistproduct = new List<Product?>();             

             IEnumerable<Product?> arr2 = listproduct.Where(p => filter(p) == true).Select(item => item);  //sans creer une nouvelle list (permis)

            return arr2;
         // -  foreach (Product p in listProduct) // en creant une nouvelle list (interdit)
         // -    {
         // -       if(filter(p))
         // -        {
         // -            newlistproduct.Add(p);

        //  -        }
         // -    }
         // -   IEnumerable<Product?> listproduct1 = newlistproduct;

            //return arr2;

         // -  return listproduct1;//from == a partir de, select new == new
                   //select new IEnumerable<Product?>
                   //  {


            // };*/
        }
    }        
}
        

     







 

