using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using System.Data.SqlClient;
using DomainModel;

namespace Repositories
{
    public class PresupuestoRepository : IPresupuestoRepository
    {
        private SqlTransaction sqlTran;
        private SqlConnection sqlCon;

        public PresupuestoRepository(SqlConnection sqlCon, SqlTransaction sqlTran)
        {
            this.sqlCon = sqlCon;
            this.sqlTran = sqlTran;
        }

        private SqlCommand CreateCommand()
        {
            SqlCommand comando = sqlCon.CreateCommand();
            if (sqlTran == null)
            {
                sqlTran = sqlCon.BeginTransaction();
            }
            comando.Transaction = sqlTran;
            return comando;
        }

        public int GetId(Presupuesto p)
        {
            return p.Id;
        }

        public void Add(Presupuesto p)
        {
            using (SqlCommand sql = this.CreateCommand())
            {
                if (sql != null)
                {
                    sql.CommandText = "INSERT INTO Presupuestos ( estado, importe, clienteId, vehiculoId) VALUES (@estado, @importe,@clienteId,@vehiculoId);select @@IDENTITY";
                    sql.Parameters.AddWithValue(@"estado", p.Estado);
                    sql.Parameters.AddWithValue(@"importe", p.Importe);
                    sql.Parameters.AddWithValue(@"clienteId", p.Cliente.Id);
                    Console.WriteLine("Llega aqui:");
                    if (p.Vehiculo!=null)
                        sql.Parameters.AddWithValue(@"vehiculoId", p.Vehiculo.Id);
                    else
                        sql.Parameters.AddWithValue(@"vehiculoId", null);
                    Console.WriteLine("Llega aqui2:");
                    p.Id = Convert.ToInt32(sql.ExecuteScalar());
                    Console.WriteLine("Añadido el presupuesto con id:"+p.Id);
           
                    //sql.ExecuteNonQuery();
                }
                else
                {
                    Console.WriteLine("No hay datos QUE AÑADIR");
                }
            }
        }





        public void Update(Presupuesto p)
        {
            using (SqlCommand sql = this.CreateCommand())
            {
                if (sql != null)
                {
                    sql.CommandText = "UPDATE Presupuestos set estado = @estado, importe=@importe,clienteId=@clienteId,vehiculoId=@vehiculoId where id="+p.Id;
                    sql.Parameters.AddWithValue(@"estado", p.Estado);
                    sql.Parameters.AddWithValue(@"importe", p.Importe);
                    sql.Parameters.AddWithValue(@"clienteId", p.Cliente.Id);
                    sql.Parameters.AddWithValue(@"vehiculoId", p.Vehiculo.Id);
                    //sql.Parameters.AddWithValue(@"id", p.Id);

                    sql.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlCommand sql = this.CreateCommand())
            {
                if (sql != null)
                {
                    sql.CommandText = "DELETE FROM Presupuestos where Id=" + id;
                    sql.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Presupuesto t)
        {
            using (SqlCommand sql = this.CreateCommand())
            {
                if (sql != null)
                {
                    sql.CommandText = "DELETE FROM Presupuestos where Id=" + t.Id;
                    sql.ExecuteNonQuery();
                }
            }
        }

        public Presupuesto GetById(int id)
        {
            Presupuesto p = null;
            using (SqlCommand sql = this.CreateCommand())
            {
                if (sql != null)
                {
                    sql.CommandText = "SELECT * FROM Presupuestos WHERE Id=" + id;
                    SqlDataReader reader = sql.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            /*
                            //AdoUnitOfWork
                            //deberia buscar el cliente y el vehiculo
                            Contracts.IClienteRepository repositorioCliente = new DataLayer.ClienteRepository();
                            Services.ClienteService servicioCliente = new Services.ClienteService(repositorioCliente);
                            Contracts.IVehiculoRepository repositorioVehiculo = new DataLayer.VehiculoRepository();
                            Services.VehiculoService servicioVehiculo = new Services.VehiculoService(repositorioVehiculo);

                            DomainModel.Cliente miCliente = servicioCliente.buscarCliente((int)rdr[3]);
                            DomainModel.Vehiculo miVehiculo = servicioVehiculo.buscarVehiculo((int)rdr[4]);


                            IClienteRepository a=new ClienteRepository();
                            */
                            //de antes  p = new Presupuesto(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
                            
                            
                            //p=new Presupuesto(reader.GetInt32(0), reader.GetString(1),reader.GetDecimal(2), miCliente, miVehiculo);

                            Vehiculo v = new Vehiculo(reader.GetInt32(3), "", "", 0);
                            Cliente cl = new Cliente(reader.GetInt32(4), "", "", "", false);
                            double importe = reader.GetDouble(2);
                            string estado = reader.GetString(1);
                            p = new Presupuesto(id, estado, importe,cl,v);


                        }
                        
                        ClienteRepository rc = new ClienteRepository(sqlCon, sqlTran);
                        p.Cliente = rc.GetById(p.Cliente.Id);
                        VehiculoRepository rv = new VehiculoRepository(sqlCon, sqlTran);
                        p.Vehiculo = rv.GetById(p.Vehiculo.Id);
                    }
                    else
                    {
                        Console.WriteLine("No hay datos");
                    }
                    reader.Close();
                }
            }
            return p;

            /*
            DomainModel.Presupuesto nuevo = null;
            SqlDataReader rdr = null;
            try
            {

                if (id != null)
                {
                    crearConexion();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from dbo.Presupuestoes where id=@id";
                    cmd.Parameters.AddWithValue(@"id", id);
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        //deberia buscar el cliente y el vehiculo
                        Contracts.IClienteRepository repositorioCliente = new DataLayer.ClienteRepository();
                        Services.ClienteService servicioCliente = new Services.ClienteService(repositorioCliente);
                        Contracts.IVehiculoRepository repositorioVehiculo = new DataLayer.VehiculoRepository();
                        Services.VehiculoService servicioVehiculo = new Services.VehiculoService(repositorioVehiculo);

                        DomainModel.Cliente miCliente = servicioCliente.buscarCliente((int)rdr[3]);
                        DomainModel.Vehiculo miVehiculo = servicioVehiculo.buscarVehiculo((int)rdr[4]);

                        nuevo = new DomainModel.Presupuesto((int)rdr[0], (string)rdr[1], (decimal)rdr[2], miCliente, miVehiculo);
                    }
                    cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
            finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                cerrarConexion();
            }
            return nuevo;*/
        }




        public ICollection<Presupuesto> GetAll()
        {
            ICollection<Presupuesto> presupuestos = new List<Presupuesto>();
            using (SqlCommand sql = this.CreateCommand())
            {
                if (sql != null)
                {
                    sql.CommandText = "SELECT * FROM Presupuestos";
                    SqlDataReader reader = sql.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {                            
                            IClienteRepository rc = new ClienteRepository(sqlCon, sqlTran);
                            Cliente c= rc.GetById(reader.GetInt32(3));
                            VehiculoRepository rv = new VehiculoRepository(sqlCon, sqlTran);
                            Vehiculo v = rv.GetById(reader.GetInt32(4));

                            Presupuesto p = new Presupuesto(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), c,v);
                            presupuestos.Add(p);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No hay datos");
                    }
                    reader.Close();
                }
            }
            return presupuestos;
        }

        /*
        public ICollection<DomainModel.Presupuesto> findByAll()
        {
            ICollection<DomainModel.Presupuesto> listado = new List<DomainModel.Presupuesto>();
            SqlDataReader rdr = null;
            try
            {
                crearConexion();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from dbo.Presupuestoes";
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //deberia buscar el cliente y el vehiculo
                    Contracts.IClienteRepository repositorioCliente = new DataLayer.ClienteRepository();
                    Services.ClienteService servicioCliente = new Services.ClienteService(repositorioCliente);
                    Contracts.IVehiculoRepository repositorioVehiculo = new DataLayer.VehiculoRepository();
                    Services.VehiculoService servicioVehiculo = new Services.VehiculoService(repositorioVehiculo);

                    DomainModel.Cliente miCliente = servicioCliente.buscarCliente((int)rdr[3]);
                    DomainModel.Vehiculo miVehiculo = servicioVehiculo.buscarVehiculo((int)rdr[4]);


                    DomainModel.Presupuesto nuevo = new DomainModel.Presupuesto((int)rdr[0], (string)rdr[1], (decimal)rdr[2], miCliente, miVehiculo);
                    listado.Add(nuevo);
                }
                cerrarConexion();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
            finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                cerrarConexion();
            }
            return listado;
        }
        */

    }
}
