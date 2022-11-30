using BO;
namespace BlApi;

public interface IProduct
{
    /// <summary>
    /// return product of list of product
    /// </summary>
    /// <returns></returns>
    IEnumerable<ProductForList?> GetProduct();

    /// <summary>
    /// return product of id specific
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Product GetById(int id);

}
