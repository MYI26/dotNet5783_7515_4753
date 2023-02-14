using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;
using System.Reflection.Metadata.Ecma335;

namespace DalApi;

/// <summary>
/// Generic interface which contains all functions that are common for all entities with one generic parameter T
/// </summary>
/// <typeparam name="T"></typeparam>
public interface ICrud<T> where T : struct
{
    public int Add(T t);

    public void Delete(int id);

    public void Update(T t1);

    public T? Get(int id1);

    public IEnumerable<T?> GetAll(Func<T?, bool>? filter = null);

}


