using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BO;

//contains the exceptions that may occur during debugging


    public class ErrorIdException : Exception
    {
        public ErrorIdException(string? message) : base(message) { }
    }


    public class ErrorDontExist : Exception
    {
        public ErrorDontExist(string? message) : base(message) { }
    }

    public class DontExist : Exception
    {
        public DontExist(string? message,Exception e ) : base(message) { }
    public DontExist(Exception e) : base(e.Message) { }
}

public class NotEnought : Exception
{
    public NotEnought(string? message) : base(message) { }
}

public class AlreadyExistException : Exception
{
    public AlreadyExistException(string? message) : base(message) { }
}

public class MissingException : Exception
{
    public MissingException(string? message) : base(message) { }
}

[Serializable]
internal class Missing : Exception
{
    public Missing()
    {
    }

    public Missing(string? message) : base(message)
    {
    }

    public Missing(string? message, Exception? innerException) : base(message, innerException)
    {
    }
    protected Missing(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}


public class DontExistException : Exception
{
    public DontExistException(string? message) : base(message) { }
}





