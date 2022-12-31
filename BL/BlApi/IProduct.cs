using BO;
namespace BlApi;

/// <summary>
///  interface IProduct
/// </summary>
public interface IProduct
{
    /// <summary>
    /// return product of list of product
    /// </summary>
    /// <returns></returns> // for director application
    IEnumerable<ProductForList?> GetProductList();

    /// <summary>
    /// return product of list of product
    /// </summary>
    /// <returns></returns>
    IEnumerable<ProductItem?> GetProductCatalog();

    /// <summary>
    /// return product of id specific for admin screen and for
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Product Get(int id); 

    /// <summary>
    /// For a buyer screen - from the catalog
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cart1"></param>
    /// <returns></returns>
    ProductItem Get(int id,Cart cart1);

    // <summary>
    /// add product. specific for admin screen and for
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public void Add(Product product);

    /// <summary>
    /// delete product. specific for admin screen and for
    /// </summary>
    /// <param name="product"></param>
    public void Delete(int id);

    /// <summary>
    /// Update product. specific for admin screen and for
    /// </summary>
    /// <param name="product"></param>
    public void Update(Product product);





}
