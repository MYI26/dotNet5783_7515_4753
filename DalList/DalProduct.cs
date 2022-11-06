using DO;
using System;

namespace Dal;

public class DalProduct
{

    public int add(Product p1)
    {

        for (int i = 0; i < 10; i++)
        {
            if (DataSource.tabProduct[i].ID == p1.ID)
            {
                throw new Execution("the product already exist")
                return 0;

            }
        }

        else {

            int i = 10;
            DataSource.tabProduct[i] = p1;
            i++;


            return p1.ID;
        }
    }

    public void delet(int id)
    {

        for (int i = 0; i < 50; i++)
        {
            if (DataSource.tabProduct[i].ID == id)
            {

                DataSource.tabProduct[i] = null;

            }
        }


    }

    public void update(Product P1)
    {

        for (int i = 0; i < 10; i++)
        {
            if (DataSource.tabProduct[i].ID == P1.ID)
            {

                DataSource.tabProduct[i] = P1;

            }
        }

    }

    public Product get(int id)
    {
        for (int i = 0; i < 50; i++)
        {
            if (DataSource.tabProduct[i].ID == id)
            {

                return DataSource.tabProduct[i];

            }
        }

    }

    public void get() {

        for (int i = 0; i < 50; i++) {




              public override string ToString() => $@"
        Product ID={DataSource.tabProduct[i].ID}: {DataSource.tabProduct[i].Name}, 
        category - {DataSource.tabProduct[i].Category}
    	Price: {DataSource.tabProduct[i].Price}
    	Amount in stock: {DataSource.tabProduct[i].InStock} ";

                 }


}
        

     









