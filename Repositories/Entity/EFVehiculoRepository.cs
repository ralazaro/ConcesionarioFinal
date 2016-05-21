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
    public class EFVehiculoRepository : IVehiculoRepository
    {
        private ConcesionarioEntities context;
        private bool disposed = false;

        public EFVehiculoRepository(ConcesionarioEntities context)
        {
            this.context = context;
        }

        public Vehiculo GetById(int id)
        {
            Vehiculo v = context.Vehiculos.Find(id);
            return v;
        }

        public int GetId(Vehiculo v)
        {
            return v.Id;
        }

        public ICollection<Vehiculo> GetAll()
        {
            ICollection<Vehiculo> vehiculos;
            vehiculos = context.Vehiculos.ToList();

            return vehiculos;
        }

        public void Add(Vehiculo v)
        {
            context.Vehiculos.Add(v);
        }

        public void Update(Vehiculo v)
        {
            context.Entry(v).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Vehiculo v = GetById(id);
            Delete(v);
        }

        public void Delete(Vehiculo v)
        {
            context.Vehiculos.Remove(v);
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
