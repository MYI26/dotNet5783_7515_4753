using DO;
using static DO.Enums;

namespace Dal;

internal static class DataSource
{

    // <summary>
    // initialisation of all lists
    // </summary>
    internal static List<Product> listProduct = new List<Product>(50);    // list of Product
    internal static List<OrderItem> listOrderItem = new List<OrderItem>(200);      // list of OrderItem
    internal static List<Order> listOrder = new List<Order>(100);      //list of Order

    /// <summary>
    /// static readonly variable
    /// </summary>
    static readonly Random random = new Random();

    /// <summary>
    /// constructor of DataSource
    /// </summary>
    static DataSource() 
    {
        s_Initialize();
    }

    /// <summary>
    /// fonction of initialization
    /// </summary>
    private static void s_Initialize()
    {
        InitializeProduct();
        InitializeOrderItem();
        InitializeOrder();    
    }

    /// <summary>
    /// class Config
    /// </summary>
    internal static class Config
    {
        internal static int startSerialNumber = 1000;
        internal static int NextSerialNumber { get => startSerialNumber++; }
    }

    //fonction that add Product in the list of Product
    private static void InitializeProduct()
    {
        Product p = new Product();

        for (int i = 0; i < 5; i++)
        {
            p.ID = random.Next(100000, 1000000);    // it has 6 digits at least
            p.Name = Convert.ToString((Names)i);    // all names of the first products are saved in the enums
            p.Price = random.Next(50, 100);
            p.MyCategory = (Category)1;     // the first 5 products minimum in the database are guitars
            p.InStock = random.Next(5, 10);

            listProduct.Add(p);
        }
        
        for(int i = 5; i < 10; i++)
        {
            p.ID = random.Next(100000, 1000000);
            p.Name = Convert.ToString((Names)i);
            p.Price = random.Next(50,100);
            p.MyCategory = (Category)2;     // the last 5 products minimum in the database are violins
            p.InStock = random.Next(5,10);

            listProduct.Add(p);
        }
    }


    //fonction that add OrderItem in the list of OrderItem
    private static void InitializeOrderItem()
    {
        OrderItem oI = new OrderItem();

        for (int i = 0; i < 40; i++)
        {
            int indexSpecificProduct = random.Next(1, 10);

            oI.ProductID = listProduct[indexSpecificProduct].ID;        //ProductId = ID of the product in the orderItem
            oI.ID = random.Next(100000, 1000000);      // it has 6 digits at least

            if (i % 2 == 0)                                  //we will have a database where customers will all have to start ordering two products in their baskets
                oI.OrderID = Config.NextSerialNumber;        //so if the i is even, we change to the next basket number
            else                                             // else if i is odd then we stay in the same basket
                oI.OrderID = listOrderItem[i - 1].OrderID;   //and therefore the basket number does not change

            oI.Price = (int)listProduct[indexSpecificProduct].Price;     //the price corresponds to the product that has been chosen
            oI.Amount = random.Next(5,10);      //it does not depend on what we have left in stock for each product in the database

            listOrderItem.Add(oI);
        }
    }


    //fonction that add Order in the list of Order
    private static void InitializeOrder()
    {
        int j = -1;
        Order o = new Order();

        for(int i = 0 ; i < 20; i++)
        {
            j = j + 2;      //we go from one basket number to the next each time
            o.ID = listOrderItem[j].OrderID;

            o.CustomerName = Convert.ToString((CustomerName)i);      //all the names of our customers are registered in the enum
            o.CustomerEmail = Convert.ToString((CustomerName)i) + "@gmail.com";     //all our registered customers use gmail
            o.CustomerAddress = Convert.ToString((CustomerAdress)i);        //all the address of our customers are registered in the enum
            o.OrderDate = DateTime.Today.AddDays(-random.Next(10, 20));     // our clients ordered between 10 and 20 days ago
            o.ShipDate = DateTime.Today.AddDays(-random.Next(5, 10));       //all orders were sent between 5 and 10 days ago
            o.DeliveryDate = DateTime.Today.AddDays(-random.Next(0, 5));     //they were all delivered within the last 5 days
           
            listOrder.Add(o);
        }
    }
}

