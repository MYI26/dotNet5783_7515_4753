using System;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using DalApi.DO;
using static Dal.DataSource;
using DalApi;
using DO;
using System.Security.Cryptography;

namespace Dal;

internal class DalOrderItem : IOrderItem 
{

    public int Add(OrderItem oI1)
    {

        //foreach (OrderItem oI in listOrderItem)
        //{
        //    if (oI.ID == oI1.ID)
        //    {
        //      throw new AlreadyExistException($"the order item whith ID: {oI1.ID} already exist");
        //    }
        //}

        //listOrderItem.Add(oI1);

        //return oI1.ID;

        IEnumerable<OrderItem> listorderitem1 =       // il select oi si il a le meme id  : on a donc cree une liste toute petite qui contien au max un menbre
            from oi in listOrderItem
            where oi?.ID == oI1.ID
            select oI1;

        foreach (var Oi in listorderitem1)
        {
            throw new AlreadyExistException($"the  order item whith ID: {oI1.ID} already exist");
        }

        listOrderItem.Add(oI1);//si le foreach ne sais pas executer
        return oI1.ID;
    }

    public void Delete(int id)
    {

        //bool found = false;

        //foreach (OrderItem oI in listOrderItem)
        //{
        //    if (oI.ID == id)
        //        listOrderItem.Remove(oI);
        //    found = true;
        //    break;
        //}
        //if (found = !true)
        //    c

        IEnumerable<OrderItem?> listorderitem1 =       // il select oi si il a le meme id  : on a donc cree une liste toute petite qui contien au max un menbre
        from oi in listOrderItem
            where oi?.ID == id
            select oi;


        if (listorderitem1 != null)
        {
            foreach (var Oi in listorderitem1)
            {
                listOrderItem.Remove(Oi);
            }
        }

        else throw new DontExistException("the order item dont exist");


    }

    public void Update(OrderItem oI1)
    {

    bool found = false;

    foreach (OrderItem oI in listOrderItem)
        {
            if (oI.ID == oI1.ID)
            {
                listOrderItem[listOrderItem.IndexOf(oI)] = oI1;
                break;
            }
        }
    if (found = !true)
            throw new DontExistException("the order item dont exist");
    }

    public OrderItem? Get(int id)
    {

        //foreach (OrderItem oI in listOrderItem)
        //{
        //    if (oI.ID == id)
        //    {
        //        return oI;
        //    }
        //}

        //throw new DontExistException("the order item dont exist");

        IEnumerable<OrderItem?> listorderitem1 =       // il select oi si il a le meme id  : on a donc cree une liste toute petite qui contien au max un menbre
        from oi in listOrderItem
        where oi?.ID == id
        select oi;


        if (listorderitem1 != null)
        {
            foreach (var Oi in listorderitem1)
            {
                return Oi;
            }
        }

         throw new DontExistException("the order item dont exist");
    }

    //public IEnumerable<OrderItem> Ask()
    //{
    //    List<OrderItem> orderItem = new List<OrderItem>();

    //    foreach (OrderItem oI in listOrderItem)
    //    {
    //        orderItem.Add(oI);
    //    }
    //    IEnumerable<OrderItem> enumerable = orderItem;

    //    return enumerable;//return IEnumerator
    //}

    public IEnumerable<OrderItem?> GetAll(Func<OrderItem?, bool>? filter = null) { IEnumerable<OrderItem?> orderitem = listOrderItem; return orderitem; }

}
