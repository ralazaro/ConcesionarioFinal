﻿using DomainModel;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WForms
{
    public partial class Inicio : Form
    {
        IClienteService cService;
        IPresupuestoService pService;
        IVehiculoService vService;

        private System.ComponentModel.IContainer components = null;

        public Inicio()
        {
            InitializeComponent();
        }

        public Inicio(IClienteService cs, IPresupuestoService ps, IVehiculoService vs)
        {
            InitializeComponent();
            cService = cs;
            pService = ps;
            vService = vs;
        }

        private void altaClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCliente_Click(sender, e);
        }
        
        private void btnCliente_Click(object sender, EventArgs e)
        {

            //Creamos un nuevo cliente con el constructor
            Cliente nuevo = new Cliente(1, "Raul", "Lazaro Lopez", "123456789", true);
            //Damos de alta un nuevo cliente con el constructor creado
            cService.Add(nuevo);            
            Console.WriteLine("Damos de alta al primer cliente:" + nuevo.Id + "," + nuevo.Nombre + "," + nuevo.Apellidos + "," + nuevo.Telefono + "," + nuevo.Vip);            
            Console.WriteLine("Datos del nuevo cliente añadido con toString:"+nuevo.ToString());
            //Damos de alta a otro cliente directamente
            Cliente nuevo2 = new Cliente(2, "Paula", "Lazaro Casado", "987654321", false);
            cService.Add(nuevo2);
            //Console.WriteLine("Damos de alta al segundo cliente:" + nuevo2.Id + "," + nuevo2.Nombre + "," + nuevo2.Apellidos + "," + nuevo2.Telefono + "," + nuevo2.Vip);
            Console.WriteLine("Datos del segundo cliente dado de alta con toString:" + nuevo2.ToString());
            //listo todos los clientes
            ICollection<Cliente> listadoClientes = new List<Cliente>();
            listadoClientes = cService.GetAll();
            Console.WriteLine("el listado de clientes totales son:");
            foreach (Cliente cliente in listadoClientes)
            {
                //Console.WriteLine(cliente.Id + "," + cliente.Nombre + "," + cliente.Apellidos + "," + cliente.Telefono + "," + cliente.Vip);
                Console.WriteLine("Datos de cada cliente toString:" + cliente.ToString());
            }

            //Creo un presupuesto y se lo añado al cliente nuevo
            Presupuesto pre = new Presupuesto(1,"empezado",12.05,nuevo,null);
  
            //listo todos los presupuesto del cliente nuevo
            ICollection<Presupuesto> listadoPresupuestoCliente = new List<Presupuesto>();
            listadoPresupuestoCliente = cService.PresupuestosPorCliente(nuevo2);
            Console.WriteLine("el listado de presupuestos del cliente con id " + nuevo2.Id + " son:");
            foreach (Presupuesto presupuesto in listadoPresupuestoCliente)
            {                
                //Console.WriteLine(presupuesto.Id + "," + presupuesto.Estado + "," + presupuesto.Importe + "," + presupuesto.Cliente.Id + "," + presupuesto.Vehiculo.Id);
                Console.WriteLine("Datos de cada presupuesto del cliente toString:" + presupuesto.ToString());
            }

            //buscamos el cliente nuevo.Id
            Console.WriteLine("Buscamos el cliente con Id=" + nuevo.Id);
            Cliente miCliente = cService.Get(nuevo.Id);
            //Console.WriteLine("El cliente encontrado con Id=" + miCliente.Id + " es: " + miCliente.Id + "," + miCliente.Nombre + "," + miCliente.Apellidos + "," + miCliente.Telefono + "," + miCliente.Vip);
            Console.WriteLine("El cliente buscado y encontrado con toString es:" + miCliente.ToString());

            //modificamos el telefono del cliente nuevo2.Id
            cService.ModificarTelefono(nuevo2, "567894321");
            Console.WriteLine("Hemos modificado el telefono del segundo cliente introducido con Id=" + nuevo2.Id + " es: " + nuevo2.Telefono );

            //borramos el cliente modificado
            cService.Remove(nuevo2);
            Console.WriteLine("Hemos borramos el cliente modificado:" + nuevo2.ToString());

        }


        private void btnVehiculo_Click(object sender, EventArgs e)
        {

            //Creamos un nuevo vehiculo con el constructor
            Vehiculo nuevo = new Vehiculo(1, "Audi", "A5", 150);
            //Damos de alta un nuevo vehiculo con el constructor creado
            vService.Add(nuevo);
            //Console.WriteLine("Damos de alta al primer Vehiculo:" + nuevo.Id + "," + nuevo.Marca + "," + nuevo.Modelo + "," + nuevo.Potencia);
            Console.WriteLine("Datos del primer vehiculo añadido con toString:" + nuevo.ToString());
            //Damos de alta a otro Vehiculo directamente
            Vehiculo nuevo2 = new Vehiculo(2, "mercedes", "B-180", 130);
            vService.Add(nuevo2);            
            //Console.WriteLine("Damos de alta al segundo Vehiculo:" + nuevo2.Id + "," + nuevo2.Marca + "," + nuevo2.Modelo + "," + nuevo2.Potencia);
            Console.WriteLine("Datos del segundo vehiculo añadido con toString:" + nuevo2.ToString());
            //listo todos los Vehiculos
            ICollection<Vehiculo> listadoVehiculos = new List<Vehiculo>();
            listadoVehiculos = vService.GetAll();
            Console.WriteLine("el listado de Vehiculos totales son:");
            foreach (Vehiculo vehiculo in listadoVehiculos)
            {
                //Console.WriteLine(vehiculo.Id + "," + vehiculo.Marca + "," + vehiculo.Modelo + "," + vehiculo.Potencia);
                Console.WriteLine("Datos de cada vehiculo:" + vehiculo.ToString());
            }

            //Creo un presupuesto y se lo añado al Vehiculo nuevo
            Presupuesto pre = new Presupuesto(1, "empezado", 12.05, null, nuevo);
            //listo todos los presupuesto del Vehiculo nuevo
            ICollection<Presupuesto> listadoPresupuestoVehiculo = new List<Presupuesto>();
            listadoPresupuestoVehiculo = vService.PresupuestosPorVehiculo(nuevo2);
            Console.WriteLine("el listado de presupuesto del Vehiculo con id " + nuevo2.Id + " son:");
            foreach (Presupuesto presupuesto in listadoPresupuestoVehiculo)
            {               
                //Console.WriteLine(presupuesto.Id + "," + presupuesto.Estado + "," + presupuesto.Importe + "," + presupuesto.Cliente.Id + "," + presupuesto.Vehiculo.Id);
                Console.WriteLine("Datos de cada presupuesto del Vehiculo toString:" + presupuesto.ToString());
            }
            //buscamos el Vehiculo nuevo.Id
            Console.WriteLine("Buscamos el Vehiculo con Id=" + nuevo.Id);
            Vehiculo miVehiculo = vService.Get(nuevo.Id);
            //Console.WriteLine("El Vehiculo encontrado con Id=" + miVehiculo.Id + " es: " + miVehiculo.Marca + "," + miVehiculo.Modelo + "," + miVehiculo.Potencia);
            Console.WriteLine("El Vehiculo buscado y encontrado con toString es:" + miVehiculo.ToString());

            //borramos el Vehiculo modificado
            vService.Remove(nuevo2);
            Console.WriteLine("Hemos borramos el vehiculo modificado:" + nuevo2.ToString());
        }

        private void btnPresupuesto_Click(object sender, EventArgs e)
        {
            //creamos un nuevo cliente
            Cliente miCliente = new Cliente(1, "cliente", "presupuesto", "15267447", true);
            //Damos de alta un nuevo cliente con el constructor creado
            cService.Add(miCliente);
            //Creamos un nuevo vehiculo con el constructor
            Vehiculo miVehiculo = new Vehiculo(1, "Seat", "Ibiza", 90);
            //Damos de alta un nuevo vehiculo con el constructor creado
            vService.Add(miVehiculo);
            //Cliente miCliente = servicioCliente.buscarCliente(28);
            //Vehiculo miVehiculo = servicioVehiculo.buscarVehiculo(10);

            //Creamos un nuevo Presupuesto con el constructor
            Presupuesto nuevo = new Presupuesto(1, "terminado", 100, miCliente, miVehiculo);
            //Damos de alta un nuevo Presupuesto con el constructor creado
            pService.Add(nuevo);
            Console.WriteLine("Damos de alta el primer Presupuesto:" + nuevo.Id + "," + nuevo.Estado + "," + nuevo.Importe + "," + nuevo.Cliente.Id + "," + nuevo.Vehiculo.Id);
            //Damos de alta a otro Presupuesto
            Presupuesto nuevo2 = new Presupuesto(2, "empezado", 200, miCliente, miVehiculo);
            pService.Add(nuevo2);
            //Console.WriteLine("Damos de alta al segundo Presupuesto:" + nuevo2.Id + "," + nuevo2.Estado + "," + nuevo2.Importe + "," + nuevo2.Cliente.Id + "," + nuevo2.Vehiculo.Id);
            Console.WriteLine("Damos de alta al segundo Presupuesto con toString:" + nuevo2.ToString());
            
            //listo todos los Presupuestos
            ICollection<Presupuesto> listadoPresupuestos = new List<Presupuesto>();
            listadoPresupuestos = pService.GetAll();
            Console.WriteLine("el listado de Presupuestos totales son:");
            foreach (Presupuesto presupuesto in listadoPresupuestos)
            {
                //Console.WriteLine(presupuesto.Id + "," + presupuesto.Estado + "," + presupuesto.Importe + "," + presupuesto.Cliente.Id + "," + presupuesto.Vehiculo.Id);
                Console.WriteLine("Datos de cada presupuesto con toString:" + presupuesto.ToString());
            }
            
            //listo todos los presupuesto del Vehiculo nuevo
            ICollection<Presupuesto> listadoPresupuestoVehiculo = new List<Presupuesto>();
            listadoPresupuestoVehiculo = vService.PresupuestosPorVehiculo(miVehiculo);
            Console.WriteLine("el listado de presupuesto del Vehiculo con id " + miVehiculo.Id + " son:");
            foreach (Presupuesto presupuesto in listadoPresupuestoVehiculo)
            {                
                //Console.WriteLine(presupuesto.Id + "," + presupuesto.Estado + "," + presupuesto.Importe + "," + presupuesto.Cliente.Id + "," + presupuesto.Vehiculo.Id);
                Console.WriteLine("Datos de cada presupuesto del Vehiculo toString:" + presupuesto.ToString());
            }

            //buscamos el Presupuesto nuevo.Id
            Console.WriteLine("Buscamos el Presupuesto con Id=" + nuevo.Id);
            Presupuesto miPresupuesto = pService.Get(nuevo.Id);
            //Console.WriteLine("El Vehiculo encontrado con Id=" + miPresupuesto.Id + " es: " + miPresupuesto.Id + "," + miPresupuesto.Estado + "," + miPresupuesto.Importe + "," + miPresupuesto.Cliente.Id + "," + miPresupuesto.Vehiculo.Id);
            Console.WriteLine("El Presupuesto buscado y encontrado con toString:" + miPresupuesto.ToString());                      

            //borramos el presupuesto
            Console.WriteLine("Borramos el Presupuesto con Id=" + nuevo2.Id);
            pService.Remove(nuevo2);
            Console.WriteLine("El Presupuesto borrado con toString:" + nuevo2.ToString());           
        }

        private void bajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCliente_Click(sender, e);
        }

        private void modificarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCliente_Click(sender, e);
        }

        private void listadoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCliente_Click(sender, e);
        }

        private void altaVehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnVehiculo_Click(sender, e);
        }

        private void bajaVehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnVehiculo_Click(sender, e);
        }

        private void modificarVehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnVehiculo_Click(sender, e);
        }

        private void listadoVehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnVehiculo_Click(sender, e);
        }

        private void altaPresupuestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnPresupuesto_Click(sender, e);
        }

        private void bajaPresupuestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnPresupuesto_Click(sender, e);
        }

        private void modificarPresupuestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnPresupuesto_Click(sender, e);
        }

        private void listadoPresupuestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnPresupuesto_Click(sender, e);
        }

    }
}
