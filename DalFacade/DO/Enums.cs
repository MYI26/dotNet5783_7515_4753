
using System.Diagnostics;
using System.Xml.Linq;

namespace DO;

/// <summary>
/// Structure for ...
/// </summary>
public struct Enums
{
    public enum Category { guitar, violin, flute, piano, musicBrochures }
    public enum Names
    {
        Eliaou_Madar, Nethanel_Assouline, Jeremy_Torjdman, Elie_Goetta,
        Nahoum_Perez, Joana_Perez, David_Cohen, Salomon_Hamelekh,
        Ouriel_Gourion, Dan_Meimoun, Samuel_Marciano
    }
}



///// <summary>
///// Unique ID of ...
///// </summary>
//public int ID { get; set; }
//public string Name { get; set; }
//public Category Category { get; set; }
//public int Price { get; set; }
//public int InStock { get; set; }
//public override string ToString() => $@"
//        Product ID={ID}: {Name}, 
//        category - {Category}
//    	Price: {Price}
//    	Amount in stock: {InStock}
//";