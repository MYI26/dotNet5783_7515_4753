using BO;
namespace BlApi;

public interface ICart
{
    public void UpdateTotalSum(Cart cart);
    Cart AddProduct(Cart cart,int productId);


}
