using DO;
using System;
using System.Runtime.CompilerServices;
using static Dal.DataSource;

namespace Dal;

public class DalProduct
{

    public int AddProduct(Product p1)
    {

        for (int i = 0; i < 50; i++)
        {
            if (DataSource.tabProduct[i].ID == p1.ID)
            {
                throw new Exception("the product already exist");
            }
        }
            
        DataSource.tabProduct[Config.NextIndexTabProduct] = p1;

        return p1.ID;      
    }

    public void DeletProduct(int id)
    {
        
        for (int i = 0; i < 50; i++)
        {
            if (DataSource.tabProduct[i].ID == id)
            {
                for ( int j =i; j < 50; j++) 
                {
                    DataSource.tabProduct[j] = DataSource.tabProduct[j + 1];
                }
                break;
            }
        }
    }

    public void UpdateProduct(Product P1)
    {

        for (int i = 0; i < 50; i++)
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
        for (int i = 0; i < 50; i++)
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
        Product[] product = new Product[50];
        for (int i = 0; i < DataSource.tabProduct.Length; i++)
        {
            product[i] = DataSource.tabProduct[i];
        }
        return product;
    }
}
        

     









