using DO;
using Dal;
using System;
using System.Net.WebSockets;
using System.Diagnostics;

using DO;
using System.Net.Http.Headers;

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
            choice  = int.Parse(s);
                try
                {
                    switch (choice)
                    {

                        case 1:

                            Console.WriteLine(

@"
Enter:

a) Add Product
b) Ask Product
c) Ask All Product 
d) Update Product
e) Delete Product");

                            string choice2 = Console.ReadLine();

                            switch (choice2) {

                                case "a":
                                    Product p1;
                                    p1 = new Product();

                                    DalProduct.AddProduct(p1);
                                    break;

                                case "b":
                                    int id1 = 0;
                                    DalProduct.AskProduct(id1);
                                    break;

                                case "c":
                                    DalProduct.AskProduct();
                                    break;

                                case "d":
                                    Product p2;
                                    p2 = new Product();
                                    DalProduct.UpdateProduct(p2);
                                    break;

                                case "e":
                                    int id2 = 0;
                                    DalProduct.DeletProduct(id2);
                                    break;

                            }

                            break;

                        case 2:

                            Console.WriteLine(
@"
Enter:

a) Add Order Item
b) Ask Order Item
c) Ask All Order Item 
d) Update Order Item
e) Delete Order Item");

                            break;

                        case 3:


                            Console.WriteLine(
@"
Enter:

a) Add Order
b) Ask Order
c) Ask All Order 
d) Update Order
e) Delete Order");

                            break;
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e);

                }
            
            }
        }
    }   
}