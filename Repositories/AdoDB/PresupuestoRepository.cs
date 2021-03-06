﻿using System;
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
                    if (p.Vehiculo!=null)
                        sql.Parameters.AddWithValue(@"vehiculoId", p.Vehiculo.Id);
                    else
                        sql.Parameters.AddWithValue(@"vehiculoId", null);
                    p.Id = Convert.ToInt32(sql.ExecuteScalar());
                    //sql.ExecuteNonQuery();
                }
                else
                {
                    Console.WriteLine("No hay datos que añadir");
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
                            Vehiculo v = new Vehiculo(reader.GetInt32(2), "", "", 0);
                            Cliente cl = new Cliente(reader.GetInt32(1), "", "", "", false);
                            double importe = reader.GetFloat(4);
                            string estado = reader.GetString(3);
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
                            /*
                            Console.WriteLine("reader.GetInt32(0):" + reader.GetInt32(0));
                            Console.WriteLine("reader.GetInt32(1):" + reader.GetInt32(1));
                            Console.WriteLine("reader.GetInt32(2):" + reader.GetInt32(2));
                            Console.WriteLine("reader.GetString(3):" + reader.GetString(3));
                            Console.WriteLine("reader.GetDouble(4):" + reader.GetDouble(4));
                            */
                            Cliente c= rc.GetById(reader.GetInt32(1));
                            VehiculoRepository rv = new VehiculoRepository(sqlCon, sqlTran);
                            Vehiculo v = rv.GetById(reader.GetInt32(2));//cambiar esa numeracion esta mal es lo de terminado este 3
                            //Console.WriteLine("cliente toString:" + c.ToString());
                            //Console.WriteLine("vehiculo toString:" + v.ToString());
                            Presupuesto p = new Presupuesto(reader.GetInt32(0), reader.GetString(3), reader.GetFloat (4), c,v);
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
    }
}
