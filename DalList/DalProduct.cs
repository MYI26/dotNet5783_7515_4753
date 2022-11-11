using DO;
using System;

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
                int index = DataSource.tabProduct.Length;
                DataSource.tabProduct[index] = p1;
                return p1.ID;
            
        
    }

    public void DeletProduct(int id)
    {

        for (int i = 0; i < 50; i++)
        {
            if (DataSource.tabProduct[i].ID == id)
            {

                DataSource.tabProduct[i] = 

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

            }
        }

    }

    public Product GetProduct(int id)
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

    public void get() {

        for (int i = 0; i < 50; i++) {


            DataSource.tabProduct[i].ToString();
        }
    }
}
        

     









