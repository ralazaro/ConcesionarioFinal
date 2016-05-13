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
    public class EFPresupuestoRepository : IPresupuestoRepository
    {
        private ConcesionarioEntities context;
        private bool disposed = false;

        public EFPresupuestoRepository(ConcesionarioEntities context)
        {
            this.context = context;
        }


        public int GetId(Presupuesto p)
        {
            return p.Id;
        }


        public ICollection<Presupuesto> GetAll()
        {
            ICollection<Presupuesto> presupuestos;
            presupuestos = context.Presupuestos.ToList();

            return presupuestos;
        }


        public Presupuesto GetById(int id)
        {
            Presupuesto p = context.Presupuestos.Find(id);
            return p;
        }


        public void Add(Presupuesto p)
        {
            context.Presupuestos.Add(p);
        }

        public void Update(Presupuesto p)
        {
            context.Entry(p).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Presupuesto p = GetById(id);
            Delete(p);
        }

        public void Delete(Presupuesto p)
        {
            context.Presupuestos.Remove(p);
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
