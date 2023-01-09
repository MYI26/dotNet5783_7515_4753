using BO;
namespace BlApi;
using Dal;

/// <summary>
/// interface ICart
/// </summary>
public interface ICart
{
    /// <summary>
    /// Adding a product to the shopping cart (for catalog screen, product details screen)
    /// </summary>
    /// <param name="cart"></param>
    /// <param name="productId"></param>
    /// <returns></returns>
    Cart? AddProduct(Cart cart,int productId);

    /// <summary>
    /// Updating the quantity of a product in the shopping cart (for the shopping cart screen)
    /// </summary>
    /// <param name="cart"></param>
    public void UpdateTotalSum(Cart cart);

    ///// <summary>
    ///// Basket confirmation for order \ placing order (for shopping basket screen or order completion screen)
    ///// </summary>
    ///// <param name = "cart" ></ param >
    ///
    public void ConfirmationCard(Cart cart);


}
