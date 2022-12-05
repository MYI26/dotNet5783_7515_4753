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
    //A helper entity of a list order
    //For an order list screen, which will contain:
    public class OrderForList
    {
        public int OrderID { get; set; }
        public string? CustomerName { get; set; }
        public OrderStatus? Status { get; set; }
        public int Amount { get; set; }
        public double TotalPrice { get; set; }

        public override string ToString() => $@"
        Order Id={OrderID}
        Name of customer{CustomerName}
        Status:{Status}
        Amount:{Amount}
        Total Price: {TotalPrice}
        ";
    }
}
