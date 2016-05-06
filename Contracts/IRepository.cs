using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepository<T> where T : class
    {
        ICollection<T> GetAll();
        T GetById(int id);
        void Add(T t);
        void Update(T t);
        void Delete(int id);
        void Delete(T t);
    }
}
