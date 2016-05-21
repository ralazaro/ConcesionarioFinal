using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace DomainModel
{
    public class Presupuesto
    {
        public int Id { get; set; }
        public string Estado { get; private set; }
        public double Importe { get; private set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        
        [ForeignKey("Vehiculo")]
        public int VehiculoId { get; set; }
        
        public virtual Cliente cliente { get; set; }
        public virtual Vehiculo vehiculo { get; set; }

        public Vehiculo Vehiculo
        {
            get { return vehiculo; }
            set
            {
                vehiculo = value;

                if (vehiculo != null)
                    vehiculo.AddPresupuesto(this);
            }
        }

        public Cliente Cliente
        {
            get { return cliente; }
            set
            {
                cliente = value;
                if (cliente != null)
                    cliente.AddPresupuesto(this);
            }
        }

        public Presupuesto(int Id, string Estado, double Importe, Cliente Cliente, Vehiculo Vehiculo)
        {
            this.Id = Id;
            this.Estado = Estado;
            this.Importe = Importe;
            this.Vehiculo = Vehiculo;
            this.Cliente = Cliente;

            if (this.Cliente != null)
                this.Cliente.Presupuestos.Add(this);

            if (this.Vehiculo != null)
                this.Vehiculo.Presupuestos.Add(this);
        }

        public Presupuesto()
        {
            this.Vehiculo = new Vehiculo();
            this.Cliente = new Cliente();
        }

        public override string ToString()
        {
            string pre = "";
            pre = Id + "|" + Estado + "|" + Importe + ":\r\n\t|" + Cliente + "\r\n\t|" + Vehiculo;
            return pre;
        }
    }
}
