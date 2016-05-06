using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IService<T>
    {
        void Add(T t);
        void Remove(T t);
        T Get(int id);
        ICollection<T> GetAll();

    }
}
