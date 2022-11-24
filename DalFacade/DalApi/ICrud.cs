using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;
using System.Reflection.Metadata.Ecma335;
using DalFacade;
namespace DalApi;


 public interface ICrud<T> {


    public int Add(T t)
    {
        var temp = new T;

        IEnumerable<T> e = temp;

        
            if (DataSource.tabProduct[i].ID == p1.ID)
            {
                throw new Exception("the product already exist");
            }
        }

        DataSource.tabProduct[Config.NextIndexTabProduct] = p1;

        return ;
    }

    public void Delet(int id)
    {
        for (int i = 0; i < Config.startIndexlTabProduct; i++)
        {
            if (DataSource.tabProduct[i].ID == id)
            {
                for (int j = i; j < Config.startIndexlTabProduct; j++)
                {
                    DataSource.tabProduct[j] = DataSource.tabProduct[j + 1];
                }
                Config.startIndexlTabProduct--;
                break;
            }
        }

    }

    public void Update(T t1)
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

    public T Ask(int id)
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

    public T[] Ask()
    {
        T[] product = new T[Config.startIndexlTabProduct];
        for (int i = 0; i < Config.startIndexlTabProduct; i++)
        {
            product[i] = DataSource.tabProduct[i];
        }
        return product;
    }
}


