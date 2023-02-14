
using BO;

namespace BlTest
{
    class program
    {


        static BlApi.IBl bl = BlApi.Factory.Get();
        //private static DalProduct DalProduct = new DalProduct();
        //private static DalOrderItem DalOrderItemt = new DalOrderItem();
        //private static DalOrder DalOrder = new DalOrder();

        static void Main(string[] args)
        {

            int choice = 5;

            while (choice != 0)
            {

                Console.WriteLine(

 @"Enter:

0) exit
1) Product
2) Cart
3) Order");

                string s = Console.ReadLine();
                choice = int.Parse(s);
                try
                {
                    switch (choice)
                    {

                        case 1:
                            fonctionProduct();
                            break;
                        case 2:
                            fonctionCart();
                            break;
                        case 3:
                            fonctionOrder();
                            break;
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                Console.WriteLine("\n");
            }
        }




        private static void fonctionProduct()
        {
            int chart = 1;
            while (chart != 0)
            {
                Console.WriteLine(

@"
Enter:

a) Add Product
b) Product list request
c) Product details request
d) Update Product
e) Delete Product
f) Catalog of all Product
g) Product details in cart request
h) exit");

                string choice2 = Console.ReadLine();

                try
                {
                    switch (choice2)
                    {

                        case "a":
                            Product p1 = new Product();
                            p1 = fonctionDataProduct();

                            bl.Product.Add(p1);
                            break;

                        case "b":
                            IEnumerable<BO.ProductForList?> tabProduct = bl.Product.GetProductList(null);

                            foreach (ProductForList p in tabProduct)
                                Console.WriteLine(p);

                            break;


                        case "c":
                            Console.WriteLine(
         @"Enter ID of the product:");

                            string idOfTheProduct = Console.ReadLine();
                            int id1 = int.Parse(idOfTheProduct);

                            Console.WriteLine(bl.Product.Get(id1));
                            break;

                        case "d":
                            Product p2 = new Product();
                            p2 = fonctionDataProduct();

                            bl.Product.Update(p2);

                            break;

                        case "e":
                            Console.WriteLine(
        @"Enter ID of the product:");

                            string idOfTheProduct2 = Console.ReadLine();
                            int id2 = int.Parse(idOfTheProduct2);

                            bl.Product.Delete(id2);

                            break;

                        case "f":
                            IEnumerable<BO.ProductItem?> tabProduct1 = bl.Product.GetProductCatalog();

                            foreach (ProductItem p in tabProduct1)
                                Console.WriteLine(p);

                            break;


                        case "g":
                            Console.WriteLine(
         @"Enter ID of the product:");

                            string idOfTheProduct3 = Console.ReadLine();
                            int id3 = int.Parse(idOfTheProduct3);

                            Console.WriteLine(
        @"Enter details of cart:");

                            Cart OI1 = new Cart();
                            OI1 = fonctionDataCart();

                            Console.WriteLine(bl.Product.Get(id3, OI1));
                            break;

                        case "h": chart = 0; break;
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                Console.WriteLine("\n");

            }

        }



        private static void fonctionCart()
        {
            int chart = 1;
            Cart OI1 = new Cart();
            OI1 = fonctionDataCart();
            while (chart != 0)
            {
                Console.WriteLine(

@"
Enter:

a) Add Product Cart
b) Details cart
c) Confirmation Card
d) exit"); // cart == chario

                string choice2 = Console.ReadLine();
                try
                {
                    switch (choice2)
                    {

                        case "a":

                            Console.WriteLine(
        @"Enter ID of the product to add to cart:");

                            string idOfTheOrder = Console.ReadLine();
                            int id = int.Parse(idOfTheOrder);

                            bl.Cart.AddProduct(OI1, id);
                            break;

                        case "b":

                            Console.WriteLine(OI1);

                            foreach (OrderItem oi in OI1.Items)
                            {
                                Console.WriteLine(oi);
                            }

                            break;

                        case "c":
                            bl.Cart.ConfirmationCard(OI1);
                            break;

                        case "d": chart = 0; break;

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                Console.WriteLine("\n");
            }


        }



        private static void fonctionOrder()
        {

            int chart = 1;
            while (chart != 0)
            {
                Console.WriteLine(

@"

Enter:

a) Order list request
b) Order details request
c) Order shipping update
d) Order delivery update
e) Order Tracking
f) exit ");

                string choice2 = Console.ReadLine();
                try
                {
                    switch (choice2)
                    {

                        case "a":

                            IEnumerable<BO.OrderForList?> enume = bl.Order.GetOrders(null);

                            foreach (OrderForList p in enume)
                                Console.WriteLine(p);

                            break;

                        case "b":

                            Console.WriteLine(
        @"Enter ID of the order:");

                            string idOfTheOrder = Console.ReadLine();
                            int id1 = int.Parse(idOfTheOrder);

                            Console.WriteLine(bl.Order.Get(id1));

                            foreach (OrderItem oi in bl.Order.Get(id1).Items)
                            {
                                Console.WriteLine(oi);
                            }
                            break;

                        case "c":
                            Console.WriteLine(
        @"Enter ID of the order:");

                            string idOfTheOrder1 = Console.ReadLine();
                            int id2 = int.Parse(idOfTheOrder1);

                            bl.Order.update(id2);

                            break;

                        case "d":

                            Console.WriteLine(
        @"Enter ID of the order:");
                            string idOfTheOrder2 = Console.ReadLine(); // il n'y a pas de delete dans bl
                            int id3 = int.Parse(idOfTheOrder2);

                            bl.Order.updateDelivrery(id3);

                            break;

                        case "e":
                            Console.WriteLine(
        @"Enter ID of the order:");

                            string idOfTheOrder3 = Console.ReadLine(); // il n'y a pas de delete dans bl
                            int id4 = int.Parse(idOfTheOrder3);
                           Console.WriteLine(bl.Order.Tracking(id4));
                            //bl.Order.Delete(id2);

                            break;

                        case "f": chart = 0; break;

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                Console.WriteLine("\n");
            }
        }



        private static Product fonctionDataProduct()
        {
            int ID;
            string Name;
            int Price;
            BO.Enums.Category Category1;
            Category1 = new Enums.Category();
            int InStock;

            Console.WriteLine("\nadd ID:");
            string id = Console.ReadLine();
            ID = int.Parse(id);

            Console.WriteLine("add Name:");
            Name = Console.ReadLine();

            Console.WriteLine("add Price:");
            string price = Console.ReadLine();
            Price = int.Parse(price);

            Console.WriteLine(
                "add Category:\n" +
                "1: Guitar\n" +
                "2: Violin\n" +
                "3: Flute\n" +
                "4: piano\n" +
                "5: musicBrochures");
            string category = Console.ReadLine();
            Category1 = (Enums.Category)int.Parse(category);

            Console.WriteLine("add InStock:");
            string inStock = Console.ReadLine();
            InStock = int.Parse(inStock);

            BO.Product product1 = new BO.Product();
            product1.ProductID = ID;
            product1.Name = Name;
            product1.Price = Price;
            product1.MyCategory = Category1;
            product1.InStock = InStock;

            return product1;
        }



        private static Cart fonctionDataCart()
        {
            string customerName;
            string customerEmail;
            string customerAdress;

            Console.WriteLine("\nCustomerName:");
             customerName = Console.ReadLine();
            
            Console.WriteLine("\nCustomerEmail:");
             customerEmail = Console.ReadLine();
            
            Console.WriteLine("\nCustomerAdress:");
            customerAdress = Console.ReadLine();
            
            Cart cart1 = new Cart();
            cart1.CustomerName = customerName;
            cart1.CustomerEmail = customerEmail;
            cart1.CustomerAddress = customerAdress;
            cart1.Items = new List<OrderItem?>();      

            return cart1;
        }

        private static Order fonctionDataOrder()
        {
            int ID;
            string CustomerName;
            string CustomerEmail;
            string CustomerAdress;
            DateTime OrderDate;
            DateTime ShipDate;
            DateTime DeliveryDate;

            Console.WriteLine("\nadd ID:");
            string id = Console.ReadLine();
            ID = int.Parse(id);

            Console.WriteLine("\nadd CustomerName:");
            CustomerName = Console.ReadLine();

            Console.WriteLine("\nadd CustomerEmail:");
            CustomerEmail = Console.ReadLine();

            Console.WriteLine("\nadd CustomerAdress:");
            CustomerAdress = Console.ReadLine();

            OrderDate = DateTime.Today;
            ShipDate = OrderDate.AddDays(1);
            DeliveryDate = ShipDate.AddDays(1);

            Order order1 = new Order();
            order1.OrderID = ID;
            order1.CustomerName = CustomerName;
            order1.CustomerEmail = CustomerEmail;
            order1.CustomerAddress = CustomerAdress;
            order1.OrderDate = OrderDate;
            order1.ShipDate = ShipDate;
            order1.DeliveryDate = DeliveryDate;

            return order1;

        }
    }

}