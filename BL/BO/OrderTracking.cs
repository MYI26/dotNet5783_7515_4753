using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BO.Enums;
using static DO.Enums;

namespace BO
{
    //Order tracking utility
    //For an order tracking screen, which will contain:
    public class OrderTracking
    {
        public int OrderID { get; set; }
        public OrderStatus? Status { get; set; }
        public List<Order?>? Items { get; set; } // list of all order

        public override string ToString() => $@"
        Order Id: {OrderID}
        Status: {Status}
        Items: {Items}
        ";
    }
}
