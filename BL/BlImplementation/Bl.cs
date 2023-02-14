using BlApi;
namespace BlImplementation;

sealed internal class Bl : IBl
{
    public Bl()
    {
        IOrder Order = new Order();
        IProduct Product = new Product();
        ICart Cart = new Cart();
    }
    public IOrder Order { get; } = new Order();
    public IProduct Product { get; } = new Product();
    public ICart Cart { get; } = new Cart();
}
