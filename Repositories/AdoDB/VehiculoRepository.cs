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
    public class VehiculoRepository : IVehiculoRepository
    {
        private SqlTransaction sqlTran;
        private SqlConnection sqlCon;

        public VehiculoRepository(SqlConnection sqlCon, SqlTransaction sqlTran)
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

        public int GetId(Vehiculo v)
        {
            return v.Id;
        }

        public ICollection<Vehiculo> GetAll()
        {
            ICollection<Vehiculo> vehiculos = new List<Vehiculo>();
            using (SqlCommand sql = this.CreateCommand())
            {
                if (sql != null)
                {
                    sql.CommandText = "SELECT * FROM Vehiculos";
                    SqlDataReader reader = sql.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Vehiculo v = new Vehiculo(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
                            vehiculos.Add(v);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No hay datos");
                    }
                    reader.Close();
                }
            }
            return vehiculos;
        }

        public Vehiculo GetById(int id)
        {
            Vehiculo v = null;
            using (SqlCommand sql = this.CreateCommand())
            {
                if (sql != null)
                {
                    sql.CommandText = "SELECT * FROM Vehiculos WHERE Id=" + id;
                    SqlDataReader reader = sql.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            v = new Vehiculo(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
                        }
                    }
                    else
                    {
                        Console.WriteLine("No hay datos");
                    }
                    reader.Close();
                }
            }
            return v;
        }

        public void Add(Vehiculo v)
        {
            using (SqlCommand sql = this.CreateCommand())
            {
                if (sql != null)
                {
                    sql.CommandText = "INSERT INTO Vehiculos" +
                        "(Marca,Modelo,Potencia) Values (@marca,@modelo,@potencia);select @@IDENTITY";
                    sql.Parameters.AddWithValue("@marca", v.Marca);
                    sql.Parameters.AddWithValue("@modelo", v.Modelo);
                    sql.Parameters.AddWithValue("@potencia", v.Potencia);
                    v.Id = Convert.ToInt32(sql.ExecuteScalar());
                    //sql.ExecuteNonQuery();
                }
            }
        }

        public void Update(Vehiculo v)
        {
            using (SqlCommand sql = this.CreateCommand())
            {
                if (sql != null)
                {
                    sql.CommandText = "UPDATE Vehiculos SET" +
                        " Marca = @marca, Modelo = @modelo, Potencia = @potencia WHERE Id = " + v.Id;
                    sql.Parameters.AddWithValue("@marca", v.Marca);
                    sql.Parameters.AddWithValue("@modelo", v.Modelo);
                    sql.Parameters.AddWithValue("@potencia", v.Potencia);

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
                    sql.CommandText = "DELETE FROM Vehiculos where Id=" + id;
                    sql.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Vehiculo v)
        {
            using (SqlCommand sql = this.CreateCommand())
            {
                if (sql != null)
                {
                    sql.CommandText = "DELETE FROM Vehiculos where Id=" + v.Id;
                    sql.ExecuteNonQuery();
                }
            }
        }
    }
}
