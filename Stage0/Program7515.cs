using System;

namespace Stage0
{
    partial class Program
    {
        //public string {0};
        static void Main(string[] args)
        {
            Welcome9715();
            Welcome4753();
            Console.ReadKey();
        }

        static partial void Welcome4753();
        private static void Welcome9715()
        {
            Console.WriteLine("Enter your name: ");
            string username = Console.ReadLine();
            Console.WriteLine("{0}, welcome to my first console application", username);
        }
    }
}