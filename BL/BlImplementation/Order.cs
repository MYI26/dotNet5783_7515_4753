using BlApi;
namespace BlImplementation;

internal class Order : IOrder
{
    public BO.Order GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<BO.OrderForList?> GetOrder()
    {
        throw new NotImplementedException();
    }

    public BO.OrderTracking Tracking(int id)
    {
        throw new NotImplementedException();
    }

    public BO.Order update(int id)
    {
        throw new NotImplementedException();
    }

    public BO.Order updateDelivrery(int id)
    {
        throw new NotImplementedException();
    }
}
