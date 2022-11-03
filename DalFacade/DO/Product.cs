using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO;

/// <summary>
/// Structure for Product on sale resource
/// </summary>

public struct Product
{

    /// <summary>
    /// Unique ID of product
    /// </summary>

    public int ID { get; set; }


    /// <summary>
    /// Descriptivename of product
    /// </summary>

    public string Name { get; set; }


    /// <summary>
    /// Current sell price of product
    /// </summary>

    public int Price { get; set; }


    /// <summary>
    /// Category of product in the store product list
    /// </summary>

    public Category Category { get; set; }


    /// <summary>
    /// Category of product in the store product list
    /// </summary>

    public int InStock { get; set; }

}

