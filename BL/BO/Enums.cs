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
        public enum Category { None = 0 , guitar = 1, violin, flute, piano, musicBrochures }

        public enum OrderStatus {ordered = 1, sent, delivered }
    }
}
