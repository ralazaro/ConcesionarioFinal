using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Repositories;
using Services;

namespace WForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string cadCon = "Data Source=RulesMan;Initial Catalog=Concesionario;Integrated Security=True";

            AdoUnitOfWork auow = new AdoUnitOfWork(cadCon);

            Application.Run(new Inicio(new ClienteService(auow), new PresupuestoService(auow), new VehiculoService(auow)));
        }
    }
}
