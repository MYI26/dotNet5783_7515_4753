
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi.DO;


/// <summary>
/// exception in the case where the product already exists in the database
/// </summary>
public class AlreadyExistException : Exception
{
    public AlreadyExistException(string? message) : base(message) { }
}


/// <summary>
/// exception in case the product does not exist in the database
/// </summary>
public class DontExistException : Exception
{
    public DontExistException(string? message) : base(message) { }
}




