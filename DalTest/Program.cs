using DO;
using Dal;
using System;
using System.Net.WebSockets;
using System.Diagnostics;

namespace Program
{
    class program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"
            Enter:
            1) Product
            2) Order Item
            3) Order    
            0) exite
            ");

            int choises = 0;

            string s = Console.Readline();
            int b = int.Parse(s);
            choises = b;

            while (choises != 0)
            {
                if (choises == 1)
                {

                    Console.WriteLine(@"
            Enter:
            a) Add Product
            b) Print Product
            c) Print All Product 
            d) Update Product
            e) delete Product
                    ");
                }
                if (choises == 2)
                {

                    Console.WriteLine(@"
            Enter:
            a) Add Order Item
            b) Print Order Item
            c) Print All Order Item 
            d) Update Order Item
            e) delete Order Item
                    ");
                }

                if (choises == 3)
                {

                    Console.WriteLine(@"
            Enter:
            a) Add Order
            b) Print Order
            c) Print All Order 
            d) Update Order
            e) delete Order
                    ");


                }
            }
        }
    }   
}