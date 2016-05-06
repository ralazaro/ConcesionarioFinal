using Contracts;
using DomainModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ClienteService : IClienteService
    {
        IUnitOfWork uow;

        public ClienteService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void ModificarTelefono(Cliente c, string telefono)
        {
            try
            {
                uow.Comenzar();
                c.Telefono = telefono;
                uow.RClientes.Update(c);
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

        public void AñadirPresupuesto(Cliente c, Presupuesto p)
        {
            try
            {
                uow.Comenzar();
                c.AddPresupuesto(p);
                uow.RClientes.Update(c);
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

        public ICollection<Presupuesto> PresupuestosPorCliente(Cliente c)
        {
            ICollection<Presupuesto> presupuestos = null;
            try
            {
                uow.Comenzar();
                presupuestos = c.Presupuestos;
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

        public void Add(Cliente t)
        {
            try
            {
                uow.Comenzar();
                uow.RClientes.Add(t);
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

        public void Remove(Cliente t)
        {
            try
            {
                uow.Comenzar();
                uow.RClientes.Delete(t);
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

        public Cliente Get(int id)
        {
            Cliente c = null;
            try
            {
                uow.Comenzar();
                c = uow.RClientes.GetById(id);
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
            return c;
        }

        public ICollection<Cliente> GetAll()
        {
            ICollection<Cliente> clientes = null;
            try
            {
                uow.Comenzar();
                clientes = uow.RClientes.GetAll();
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
            return clientes;
        }
    }
}
