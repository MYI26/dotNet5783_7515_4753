using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;
using System.Reflection.Metadata.Ecma335;
namespace DalApi;


public interface ICrud<T> where T : struct
{
    public int Add(T t);
    public void Delete(int id);
    public void Update(T t1);
    public T Ask(int id1);
    public IEnumerable<T> AskAll(Func<T, bool> filter = null);

}


