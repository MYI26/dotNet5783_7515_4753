using System;
using System.Collections.Generic;
using System.Linq;
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
        public DontExist(string? message) : base(message) { }
    }

public class NotEnought : Exception
{
    public NotEnought(string? message) : base(message) { }
}

public class AlreExist : Exception
{
    public AlreExist(string? message) : base(message) { }
}

public class MissingException : Exception
{
    public MissingException(string? message) : base(message) { }
}

public class Missing : Exception
{
    public Missing(string? message) : base(message) { }
}

