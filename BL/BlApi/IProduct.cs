using BO;
namespace BlApi;
using Dal;

/// <summary>
///  interface IProduct
/// </summary>
public interface IProduct
{
    /// <summary>
    /// return product of list of product
    /// </summary>
    /// <returns></returns> // for director application
    IEnumerable<ProductForList?>? GetProductList(Func<DO.Product?,bool>? filter);

    /// <summary>
    /// return product of list of product
    /// </summary>
    /// <returns></returns>
    IEnumerable<ProductItem?>? GetProductCatalog();

    /// <summary>
    /// return product of id specific for admin screen and for
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    BO.Product? Get(int id); 

    /// <summary>
    /// For a buyer screen - from the catalog
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cart1"></param>
    /// <returns></returns>
    BO.ProductItem? Get(int id,BO.Cart cart1);

    // <summary>
    /// add product. specific for admin screen and for
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public void Add(BO.Product product);

    /// <summary>
    /// delete product. specific for admin screen and for
    /// </summary>
    /// <param name="product"></param>
    public void Delete(int id);

    /// <summary>
    /// Update product. specific for admin screen and for
    /// </summary>
    /// <param name="product"></param>
    public void Update(BO.Product product);

}
