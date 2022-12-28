using BO;

namespace BlApi;

/// <summary>
/// 
/// </summary>
public interface IBl
{
    public IProduct Product { get; }   
    public IOrder Order { get; }
    public ICart Cart { get; }

}

