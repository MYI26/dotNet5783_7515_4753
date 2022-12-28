using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    //Main logical entity of the shopping cart
    //For the shopping cart management and order confirmation screen,
    //which will contain:
    public class Cart
    {
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerAddress { get; set; }
        public List<OrderItem?>? Items { get; set; }
        public double TotalPrice { get; set; }


        public override string ToString() => $@"
        Name of customer: {CustomerName}
        Adress of customer: {CustomerAddress}
        Email of customer: {CustomerEmail}
        Items: {Items.Count}
        Total Price: {TotalPrice}
        ";
    }
}
