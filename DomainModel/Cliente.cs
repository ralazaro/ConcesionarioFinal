using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public bool Vip { get; set; }

        public virtual ICollection<Presupuesto> Presupuestos { get; private set; }

        public Cliente(int id, string nombre, string apellidos, string telefono, bool vip)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Telefono = telefono;
            this.Vip = vip;
            this.Presupuestos = new List<Presupuesto>();
        }

        public Cliente()
        {
            this.Presupuestos = new List<Presupuesto>();
        }

        public void AddPresupuesto(Presupuesto presupuesto)
        {
            Presupuestos.Add(presupuesto);
        }

        public override String ToString()
        {
            string cli = Id + "|" + Nombre + "|" + Apellidos + "|" + Telefono + "|" + Vip+":";
            if (this.Presupuestos != null)
                foreach (Presupuesto p in this.Presupuestos)
                {
                    cli = cli + "\r\n\t" + p.Id + " | " + p.Estado + " | " + p.Importe;
                }

            return cli;

        }

    }
}
