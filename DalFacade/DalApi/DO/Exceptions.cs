using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi.DO;

 internal class Exeption1
{
    public string ExeptionAlreadyExist()
    {
        return "the Item already exist";
    }
    
}


 internal class Exeption2
{
    public string ExeptionDontExist()
    {
        return "the Item dont exist";
    }
}