using DO;
using System;
using static DO.Enums;

namespace Dal;

 internal static class DataSource
{

    /// <summary>
    /// initialisation of all arry with their maximum sizes
    /// </summary>
    internal static Product[] tabProduct = new Product[50]; // array of Products
    internal static OrderItem[] tabOrderItem = new OrderItem[200];  // array of OrderItem
    internal static Order[] tabOrder = new Order[100];  // array of Order

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
        private static int startIndexlTabProduct = 0;
        internal static int NextIndexTabProduct { get => startIndexlTabProduct++; }

        private static int startIndexTabOrderItem = 0;
        internal static int NextIndexTabOrderItem { get => startIndexTabOrderItem++; }

        private static int startIndexTabOrder = 0;
        internal static int NextIndexTabOrder { get => startIndexTabOrder++; }

        private static int startSerialNumber = 1000;
        internal static int NextSerialNumber { get => startSerialNumber++; }
    }

    //fonction that add Product in the array of Product
    private static void InitializeProduct()
    {
        for(int i = 0; i < 5; i++)
        {
            
            tabProduct[Config.NextIndexTabProduct].ID = random.Next(100000, 1000000); //ca dt etre le mm que 
            tabProduct[i].Name = Convert.ToString((Names)i);
            tabProduct[i].Price = random.Next(50,100);
            tabProduct[i].MyCategory = (Category)0;  // quest ce que ca veut dire ?
            tabProduct[i].InStock = random.Next(5,10);
        }
        
        for(int i = 5; i < 10; i++)
        {
            tabProduct[Config.NextIndexTabProduct].ID = random.Next(100000, 1000000);
            tabProduct[i].Name = Convert.ToString((Names)i);
            tabProduct[i].Price = random.Next(50,100);
            tabProduct[i].MyCategory = (Category)1;
            tabProduct[i].InStock = random.Next(5,10);
        }
    }


    //fonction that add OrderItem in the array of OrderItem
    private static void InitializeOrderItem()
    {
        for (int i = 0; i < 40; i++)
        {
            int indexSpecificProduct = random.Next(1, 10);
            tabOrderItem[Config.NextIndexTabOrderItem].ProductID = tabProduct[indexSpecificProduct].ID;
            tabOrderItem[i].OrderItemID = random.Next(100000, 1000000);

            if (i % 2 == 0)
                tabOrderItem[i].OrderID = Config.NextSerialNumber;
            else
                tabOrderItem[i].OrderID = tabOrderItem[i - 1].OrderID;

            tabOrderItem[i].Price = tabProduct[indexSpecificProduct].Price;
            tabOrderItem[i].Amount = random.Next(5,10);
        }
    }


    //fonction that add Order in the array of Order
    private static void InitializeOrder()
    {

        int j = -1;
        for(int i = 0 ; i < 20; i++)
        {
            j++;
            if(i % 2 != 0)
                j++;
            tabOrderItem[i].OrderID = tabOrderItem[j].OrderID;

            tabOrder[Config.NextIndexTabOrder].ID = tabOrderItem[i].OrderID;
            tabOrder[i].CustomerName = Convert.ToString((CustomerName)i);
            tabOrder[i].CustomerEmail = Convert.ToString((CustomerName)i) + "@gmail.com";
            tabOrder[i].CustomerAddress = Convert.ToString((CustomerAdress)i);
            tabOrder[i].OrderDate = DateTime.Today.AddDays(-random.Next(10, 20)); // our clients ordered between 10 and 60 days ago
            tabOrder[i].ShipDate = DateTime.Today.AddDays(-random.Next(5, 10));
            tabOrder[i].DeliveryDate = DateTime.Today.AddDays(-random.Next(0,5));
        }
    }

}

