using Contracts;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class AdoUnitOfWork : IUnitOfWork
    {
        string cadenaConexion;
        SqlConnection cn;
        public SqlConnection Cn { get; set; }
        public SqlTransaction T { get; set; }
        SqlTransaction t;
        //IClienteRepository rClientes = null;
        public IClienteRepository RClientes { get; set; }
        //IVehiculoRepository rVehiculos;
        public IVehiculoRepository RVehiculos { get; set; }
        //IPresupuestoRepository rPresupuestos;
        public IPresupuestoRepository RPresupuestos { get; set; }

        public AdoUnitOfWork(string cadenaConexion)
        {
            this.cadenaConexion = cadenaConexion;
            this.cn = new SqlConnection(this.cadenaConexion);
        }

        public void Comenzar()
        {
            this.cn.Open();
            this.t = cn.BeginTransaction();
            this.RClientes = new ClienteRepository(cn, t);
            this.RVehiculos = new VehiculoRepository(cn, t);
            this.RPresupuestos = new PresupuestoRepository(cn, t);
        }

        public void RollBack()
        {
            if (t != null)
            {
                t.Rollback();
            }
        }

        public void SaveChanges()
        {
            if (t != null)
                t.Commit();
        }

        public void Terminar()
        {
            cn.Close();
        }
    }
}
