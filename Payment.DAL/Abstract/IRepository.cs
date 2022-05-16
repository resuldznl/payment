using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.DAL.Abstract
{
    public interface IRepository<T>
    {
        T Get(Func<T, bool> filter = null);
        List<T> GetAll();
        List<T> GetAll(Func<T, bool> filter);
        bool Add(T model);
        bool Update(T model);
    }
}
