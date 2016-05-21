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
    public class ClienteRepository : IClienteRepository
    {
        private SqlTransaction sqlTran;
        private SqlConnection sqlCon;

        public ClienteRepository(SqlConnection sqlCon, SqlTransaction sqlTran)
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

        public int GetId(Cliente c)
        {
            return c.Id;
        }

        public ICollection<Cliente> GetAll()
        {
            ICollection<Cliente> clientes = new List<Cliente>();
            using (SqlCommand sql = this.CreateCommand())
            {
                if (sql != null)
                {
                    sql.CommandText = "SELECT * FROM Clientes";
                    SqlDataReader reader = sql.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Cliente c = new Cliente(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetBoolean(4));
                            clientes.Add(c);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No hay datos");
                    }
                    reader.Close();
                }
            }
            return clientes;
        }

        public Cliente GetById(int id)
        {
            Cliente c = null;
            using (SqlCommand sql = this.CreateCommand())
            {
                if (sql != null)
                {
                    sql.CommandText = "SELECT * FROM Clientes WHERE Id=" + id;
                    SqlDataReader reader = sql.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            c = new Cliente(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetBoolean(4));
                        }
                    }
                    else
                    {
                        Console.WriteLine("No hay datos");
                    }
                    reader.Close();
                }
            }
            return c;
        }

        public void Add(Cliente t)
        {
            using (SqlCommand sql = this.CreateCommand())
            {
                if (sql != null)
                {
                    sql.CommandText = "INSERT INTO Clientes" +
                        "(Nombre,Apellidos,Telefono,VIP) Values (@nombre,@apellidos,@telefono,@vip);select @@IDENTITY";
                    sql.Parameters.AddWithValue("@nombre", t.Nombre);
                    sql.Parameters.AddWithValue("@apellidos", t.Apellidos);
                    sql.Parameters.AddWithValue("@telefono", t.Telefono);
                    sql.Parameters.AddWithValue("@vip", t.Vip);
                    t.Id = Convert.ToInt32(sql.ExecuteScalar());
                    //sql.ExecuteNonQuery();
                }
            }
        }

        public void Update(Cliente t)
        {
            using (SqlCommand sql = this.CreateCommand())
            {
                if (sql != null)
                {
                    sql.CommandText = "UPDATE Clientes SET" +
                        " Nombre = @nombre, Apellidos = @apellidos, Telefono = @telefono ,VIP = @vip WHERE Id = " + t.Id;
                    sql.Parameters.AddWithValue("@nombre", t.Nombre);
                    sql.Parameters.AddWithValue("@apellidos", t.Apellidos);
                    sql.Parameters.AddWithValue("@telefono", t.Telefono);
                    sql.Parameters.AddWithValue("@vip", t.Vip);
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
                    sql.CommandText = "DELETE FROM Clientes where Id=" + id;
                    sql.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Cliente t)
        {
            using (SqlCommand sql = this.CreateCommand())
            {
                if (sql != null)
                {
                    sql.CommandText = "DELETE FROM Clientes where Id=" + t.Id;
                    sql.ExecuteNonQuery();
                }
            }
        }
    }
}
