using DO;
using static DO.Enums;

namespace Dal;

 internal static class DataSource
{

    /// <summary>
    /// initialisation of all arry
    /// </summary>
    internal static Product[] tabProduct = new Product[50];// array of Products
    internal static OrderItem[] tabOrderItem = new OrderItem[100];// array of OrderItem
    internal static Order[] tabOrder = new Order[200];// array of Order
    /// <summary>
    /// static readonly variable
    /// </summary>
    /// 
    static readonly Random random = new Random();
    /// <summary>
    /// constructor of DataSource
    /// </summary>
    static DataSource() 
    {
        s_Initialize();
    }

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
        private static int startSerialNumber = 1000;
        internal static int NextSerialNumber { get => startSerialNumber++; }
    }


    //array of Products
    internal static Product[] tabProduct = new Product[10];

    //fonction that add Product in the array of Product
    private static void InitializeProduct()
    {
        for(int i = 0; i < 5; i++)
        {
            tabProduct[i].ID = random.Next(1000, 10000);
            tabProduct[i].Name = Convert.ToString((Names)i);
            tabProduct[i].Price = random.Next(50,100);
            tabProduct[i].MyCategory = (Category)0;  // quest ce que ca veut dire ?
            tabProduct[i].InStock = random.Next(5,10);
        }
        
        for(int i = 5; i < 10; i++)
        {
            tabProduct[i].ID = random.Next(1000, 10000);
            tabProduct[i].Name = Convert.ToString((Names)i);
            tabProduct[i].Price = random.Next(60,100);
            tabProduct[i].Category = (Category)1;
            tabProduct[i].InStock = random.Next(3,6);
        }
    }


    //array of OrderItem
    internal static OrderItem[] tabOrderItem = new OrderItem[40];

    //fonction that add OrderItem in the array of OrderItem
    private static void InitializeOrderItem(OrderItem orderItem)
    {
        for (int i = 0; i < 20; i++)
        {
            tabOrderItem[i].ProductID = random.Next(1000,10000);
            tabOrderItem[i].OrderItemID = random.Next(1000, 10000);
            tabOrderItem[i].OrderID = random.Next(1000,1000);
            tabOrderItem[i].Price = random.Next(50,100);
            tabOrderItem[i].Amount = random.Next(3,10);
        }
    }


    //array of Order
    internal static Order[] tabOrder = new Order[20];

    //fonction that add Order in the array of Order
    private static void InitializeOrder()
    {
        for(int i = 0; i < 40; i++)
        {
            tabOrder[i].ID = Config.NextSerialNumber;
            tabOrder[i].CustomerName = Convert.ToString((CustomerName)i);
            tabOrder[i].CustomerEmail = Convert.ToString((CustomerName)i) + "@gmail.com";
            tabOrder[i].CustomerAddress = Convert.ToString((CustomerAdress)i);
            tabOrder[i].OrderDate = DateTime.Now.AddMinutes(-random.Next(455, 500));
            tabOrder[i].ShipDate = DateTime.Now.AddMinutes(-random.Next(455, 600));
            tabOrder[i].DeliveryDate = DateTime.Now.AddMinutes(-random.Next(400, 700);
        }
    }


    private static void s_Initialize()
    {
        InitializeProduct();
        InitializeOrderItem();
        InitializeOrder();    
    }

}

// ? null