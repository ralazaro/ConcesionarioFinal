using Contracts;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Repositories
{
    public class EFClienteRepository : IClienteRepository
    {
        private ConcesionarioEntities context;
        private bool disposed = false;

        public EFClienteRepository(ConcesionarioEntities context)
        {
            this.context = context;
        }

        public int GetId(Cliente c)
        {
            return c.Id;
        }

        public ICollection<Cliente> GetAll()
        {
            ICollection<Cliente> clientes;
            clientes = context.Clientes.ToList();

            return clientes;
        }


        public Cliente GetById(int id)
        {
            Cliente c = context.Clientes.Find(id);
            return c;
        }


        public void Add(Cliente c)
        {
            context.Clientes.Add(c);
        }

        public void Update(Cliente c)
        {
            context.Entry(c).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Cliente c = GetById(id);
            Delete(c);
        }

        public void Delete(Cliente c)
        {
            context.Clientes.Remove(c);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
