using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IClienteService : IService<Cliente>
    {
        void AñadirPresupuesto(Cliente c, Presupuesto p);
        ICollection<Presupuesto> PresupuestosPorCliente(Cliente c);
        void ModificarTelefono(Cliente c, string telefono);
    }
}
