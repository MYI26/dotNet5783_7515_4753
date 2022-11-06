using DO;
namespace Dal;

 internal static  class DataSource
{

    //constructor of DataSource
    static DataSource() 
    {
        s_Initialize();
    }


    //static readonly variable;
    static readonly Random random = new Random();


    //class Config
    internal static class Config
    {
        internal const int s_startOrderNumber = 1000;
        private static int s_nextOrderNumber = s_startOrderNumber;
        internal static int NextOrderNumber { get => s_nextOrderNumber++; }
    }


    //array of Products
    internal static Product[] tabProduct = new Product[10];

    //fonction that add Product in the array of Product
    private static void InitializeProduct()
    {
        for(int i = 0; i < 10; i++)
        {
            tabProduct[i].ID = random.Next(100000000);
            tabProduct[i].Name = random.Enums;
            tabProduct[i].Price = random.Next();
            tabProduct[i].Category = random.Enums;
            tabProduct[i].InStock = random.Next();
        }
    }


    //array of OrderItem
    internal static OrderItem[] tabOrderItem = new OrderItem[40];

    //fonction that add OrderItem in the array of OrderItem
    private static void InitializeOrderItem(OrderItem orderItem)
    {
        for (int i = 0; i < 40; i++)
        {
            tabOrderItem[i].ProductID = random.Next();
            tabOrderItem[i].OrderID = random.Next();
            tabOrderItem[i].Price = random.Next();
            tabOrderItem[i].Amount = random.Next();
        }
    }


    //array of Order
    internal static Order[] _tabOrder = new Order[20];

    //fonction that add Order in the array of Order
    private static void InitializeOrder()
    {
        _tabOrder[0].OrderDate = DateTime.Now.AddMinutes(- random.Next(455, 500));
    }


    private static void s_Initialize()
    {
        InitializeProduct();
        InitializeOrderItem();
        InitializeOrder();    
    }





}
