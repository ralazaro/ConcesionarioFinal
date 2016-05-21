using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IService<T>
    {
        T Get(int id);
        void Add(T t);
        void Remove(T t);
        ICollection<T> GetAll();
    }
}
