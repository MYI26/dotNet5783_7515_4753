using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace BO
{
    public class Cart
    {
        public string? CustomerName { set; get; }
        public string? CustomerEmail { set; get; }
        public string? CustomerAdress { set; get; }
        public List<OrderItem?>? Cart.Items { set; get; }
    }
}
