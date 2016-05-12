using Contracts;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PresupuestoService : IPresupuestoService
    {
        IUnitOfWork uow;

        public PresupuestoService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void Add(Presupuesto t)
        {
            try
            {
                uow.Comenzar();
                uow.RPresupuestos.Add(t);
                uow.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception en ADD de presupuesto:"+e.ToString());
                uow.RollBack();
            }
            finally
            {
                uow.Terminar();
            }
        }

        public void Remove(Presupuesto t)
        {
            try
            {
                uow.Comenzar();
                uow.RPresupuestos.Delete(t);
                uow.SaveChanges();
            }
            catch (Exception e)
            {
                uow.RollBack();
            }
            finally
            {
                uow.Terminar();
            }
        }

        public Presupuesto Get(int id)
        {
            Presupuesto p = null;
            try
            {
                uow.Comenzar();
                p = uow.RPresupuestos.GetById(id);
                uow.SaveChanges();
            }
            catch (Exception e)
            {
                uow.RollBack();
            }
            finally
            {
                uow.Terminar();
            }
            return p;
        }

        public ICollection<Presupuesto> GetAll()
        {
            ICollection<Presupuesto> presupuestos = null;
            try
            {
                uow.Comenzar();
                presupuestos = uow.RPresupuestos.GetAll();
                uow.SaveChanges();
            }
            catch (Exception e)
            {
                uow.RollBack();
            }
            finally
            {
                uow.Terminar();
            }
            return presupuestos;
        }

    }
}
