using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    //class enum which contains the enumeration of the different categories
    //and the different statuses that the command can take
    public class Enums
    {
        //when we need to print also all the products(for the combo-box)
        public enum CategoryForCatalog { All_Product = 0, guitar = 1, violin, flute, piano, musicBrochures }

        //when we need only to print the categories of the store(in the combo-box)
        public enum Category { guitar = 1, violin, flute, piano, musicBrochures }

        //we add All_Statuts for the combo-box
        public enum OrderStatus { All_Status = 0, ordered = 1, shipped, delivered }
    }
}
