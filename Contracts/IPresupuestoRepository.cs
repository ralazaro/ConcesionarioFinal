using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPresupuestoRepository : IRepository<Presupuesto>
    {
        int GetId(Presupuesto p);
    }
}
