using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi.DO;

 internal class ExeptionAlreadyExist
{
    static void Main(string[] args)
    {
        Console.WriteLine("the product already exist");
    }
    
}


 internal class ExeptionDontExist
{
    static void Main(string[] args)
    {
        Console.WriteLine("the product dont exist");
    }
}