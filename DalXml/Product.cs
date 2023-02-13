using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

using DalApi;
using DO;
namespace Dal;

public class Product : IProduct
{

    string productPath = @"Product";
    static XElement config = XMLTools.LoadConfig();

    [MethodImpl(MethodImplOptions.Synchronized)]
    static DO.Product? createProductfromXElement(XElement s)
    {
        return new DO.Product
        {
            ID = s.ToIntNullable("ID") ?? throw new FormatException("ID"),
            Name = (string?)s.Element("Name"),
            MyCategory = s.ToEnumNullable<Enums.Category>("Category"),
            Price = (double)s.Element("Price"),
            InStock = (int)s.Element("InStock")
        };
    }

    [MethodImpl(MethodImplOptions.Synchronized)]

    public int Add(DO.Product product)
    {
        XElement product_root = XMLTools.LoadListFromXMLElement(productPath);
        if (product.ID == 0)
        {
            product.ID = int.Parse(config.Element("ProductId")!.Value) + 1;
            XMLTools.SaveConfigXElement("ProductId", product.ID);
        }
        XElement? stud = (from st in product_root.Elements()
                          where st.ToIntNullable("ID") == product.ID
                          select st).FirstOrDefault();
        if (stud != null)
            throw new Exception("ID already exist");


        product_root.Add(new XElement("Product",
                                   new XElement("ID", product.ID),
                                   new XElement("Name", product.Name),
                                   new XElement("Category", product.MyCategory),
                                   new XElement("Price", product.Price),
                                   new XElement("InStock", product.InStock)
                                   ));

        XMLTools.SaveListToXMLElement(product_root, productPath);

        return product.ID; ;

    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void Delete(int id)
    {
        XElement product_root = XMLTools.LoadListFromXMLElement(productPath);

        XElement? prod = (from st in product_root.Elements()
                          where (int?)st.Element("ID") == id
                          select st).FirstOrDefault() ?? throw new Exception("Missing ID");

        prod.Remove(); //<==>   Remove stud from studentsRootElem

        XMLTools.SaveListToXMLElement(product_root, productPath);


    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public IEnumerable<DO.Product?> GetAll(Func<DO.Product?, bool>? function = null)
    {
        XElement? product_root = XMLTools.LoadListFromXMLElement(productPath);


        if (function != null)
        {
            return from s in product_root.Elements()
                   let prod = createProductfromXElement(s)
                   where function(prod)
                   select (DO.Product?)prod;
        }
        else
        {
            return from s in product_root.Elements()
                   select createProductfromXElement(s);
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public DO.Product? Get(int id)
    {
        XElement product_root = XMLTools.LoadListFromXMLElement(productPath);
        return ((from p in product_root.Elements()
                 where p.ConvertProduct_Xml_to_D0().ID==id
                 select p.ConvertProduct_Xml_to_D0()).FirstOrDefault());

    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void Update(DO.Product product)
    {
        Delete(product.ID);
        Add(product);
    }
}