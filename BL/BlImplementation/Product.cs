using BlApi;
using DalApi;
namespace BlImplementation;

internal class Product : IProduct
{

   // private static readonly IDal? Dal = Factory.Get();


    IEnumerable<BO.ProductForList?> GetProduct() { }

    Product GetById(int id) {  }

  
    Product GetByid(int id, Cart cart1) { }

   
    public void Add(Product product) { }

  
    public void Delete(int id) { }

    public void Update(Product product) { }

}