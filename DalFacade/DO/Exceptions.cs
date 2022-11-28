using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi.DO;


public class ExceptionAlreadyExist : Exception
{
    public ExceptionAlreadyExist(string? message) : base(message) { }
}


public class ExceptionDontExist : Exception
{
    public ExceptionDontExist(string? message) : base(message) { }
}
