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
        int temps = 0;
        for (int i = 0; i < 50; i++)
        {
            if (DataSource.tabProduct[i].ID == id)
            { 
                temps = i;
            }
        }

        return DataSource.tabProduct[temps];
    }

    public void AskProduct()
    {
        Product[] order = new Product[100];
        for (int i = 0; i < DataSource.tabProduct.Length; i++)
        {
            order[i] = DataSource.tabProduct[i];
        }
    }
}
        

     









