using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace BlApi;

/// <summary>
/// interface IOrder
/// </summary>
public interface IOrder
{
    /// <summary>
    /// return order of list of order
    /// </summary>
    /// <returns></returns>
    IEnumerable<OrderForList?>? GetOrder();

    /// <summary>
    /// return order of id specific for admin screen and for
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Order? Get(int id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Order? update(int id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    //Order updateDelivrery(int id);   // je ne sais pas comment la faire
    ///// <summary>
    ///// 
    ///// </summary>
    ///// <param name="id"></param>
    ///// <returns></returns>

    OrderTracking? Tracking(int id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    public Order? updateDelivrery(int id);  // je ne sais pas ce quil faut faire



}