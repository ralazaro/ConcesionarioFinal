using Contracts;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class VehiculoService : IVehiculoService
    {
        IUnitOfWork uow;

        public VehiculoService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public Vehiculo Get(int id)
        {
            Vehiculo v = null;
            try
            {
                uow.Comenzar();
                v = uow.RVehiculos.GetById(id);
                uow.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                uow.RollBack();
            }
            finally
            {
                uow.Terminar();
            }
            return v;
        }

        public void AñadirPresupuesto(Vehiculo v, Presupuesto p)
        {
            try
            {
                uow.Comenzar();
                v.AddPresupuesto(p);
                uow.RVehiculos.Update(v);
                uow.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                uow.RollBack();
            }
            finally
            {
                uow.Terminar();
            }
        }

        public ICollection<Presupuesto> PresupuestosPorVehiculo(Vehiculo v)
        {
            ICollection<Presupuesto> presupuestos = null;
            try
            {
                uow.Comenzar();
                presupuestos = v.Presupuestos;
                uow.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                uow.RollBack();
            }
            finally
            {
                uow.Terminar();
            }

            return presupuestos;
        }

        public void Add(Vehiculo t)
        {
            try
            {
                uow.Comenzar();
                uow.RVehiculos.Add(t);
                uow.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                uow.RollBack();
            }
            finally
            {
                uow.Terminar();
            }
        }

        public void Remove(Vehiculo t)
        {
            try
            {
                uow.Comenzar();
                uow.RVehiculos.Delete(t);
                uow.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                uow.RollBack();
            }
            finally
            {
                uow.Terminar();
            }
        }

        public ICollection<Vehiculo> GetAll()
        {
            ICollection<Vehiculo> vehiculos = null;
            try
            {
                uow.Comenzar();
                vehiculos = uow.RVehiculos.GetAll();
                uow.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                uow.RollBack();
            }
            finally
            {
                uow.Terminar();
            }
            return vehiculos;
        }
    }
}
