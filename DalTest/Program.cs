using DO;
using Dal;
using static DO.Enums;
using System;
using System.Net.WebSockets;
using System.Diagnostics;

using DO;
using System.Net.Http.Headers;
using System.ComponentModel;
using static System.Collections.Specialized.BitVector32;
using System.Xml.Linq;

namespace Program
{
    class program
    {


        private static DalProduct DalProduct = new DalProduct();
        private static DalOrderItem DalOrderItemt = new DalOrderItem();
        private static DalOrder DalOrder = new DalOrder();

        static void Main(string[] args) { 
        
        int choice = 5;

            while (choice != 0)
            {

                Console.WriteLine(

 @"Enter:

0) exit
1) Product
2) Order Item
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
                            fonctionOrderItem();
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

            }
        }
       private static void fonctionProduct()
        {
            Console.WriteLine(

@"
Enter:

a) Add Product
b) Ask Product
c) Ask All Product 
d) Update Product
e) Delete Product");

            string choice2 = Console.ReadLine();

            switch (choice2)
            {

                case "a":
                    Product p1 = new Product();
                    p1 = fonctionDataProduct();
       
                    DalProduct.AddProduct(p1);
                    break;

                case "b":

                    Console.WriteLine(
@"Enter ID of the product:");

                    string idOfTheProduct = Console.ReadLine();
                    int id1 = int.Parse(idOfTheProduct);

                    DalProduct.AskProduct(id1).ToString();
                    break;

                case "c":
                    Product[] tabProduct = new Product[DalProduct.AskProduct().Length];
                    tabProduct = DalProduct.AskProduct();

                    for (int i = 0; i < tabProduct.Length; i++)
                    {
                        tabProduct[i].ToString();
                    }

                    break;

                case "d":
                    Product p2 = new Product();
                    p2 = fonctionDataProduct();

                    DalProduct.UpdateProduct(p2);

                    break;

                case "e":
                    Console.WriteLine(
@"Enter ID of the product:");

                    string idOfTheProduct2 = Console.ReadLine();
                    int id2 = int.Parse(idOfTheProduct2);
;
                    DalProduct.DeletProduct(id2);

                    break;

            }

        }
        private static void fonctionOrderItem()
        {

        }
        private static void fonctionOrder()
        {

        }

        private static Product fonctionDataProduct() 
        {
            int ID;
            string Name;
            int Price;
            Category Category1;
            Category1 = new Category();
            int InStock;

            Console.WriteLine("add ID:\n");
            string id = Console.ReadLine();
            ID = int.Parse(id);

            Console.WriteLine("add Name:\n");
            Name = Console.ReadLine();

            Console.WriteLine("add Price:\n");
            string price = Console.ReadLine();
            Price = int.Parse(price);

            Console.WriteLine(
                "add Category:\n" +
                "1: Guitar\n" +
                "2: Violin\n" +
                "3: Flute\n" +
                "4: piano\n" +
                "5: musicBrochures\n");
            string category = Console.ReadLine();
            Category1 = (Category)int.Parse(category);

            Console.WriteLine("add InStock:\n");
            string inStock = Console.ReadLine();
            InStock = int.Parse(inStock);

            Product product1 = new Product();
            product1.ID = ID;
            product1.Name = Name;
            product1.Price = Price;
            product1.MyCategory = Category1;
            product1.InStock = InStock;

            return product1;
        }

    }   
}