using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi.DO;


public class AlreadyExistException : Exception
{
    public AlreadyExistException(string? message) : base(message) { }
}


public class DontExistException : Exception
{
    public DontExistException(string? message) : base(message) { }
}
