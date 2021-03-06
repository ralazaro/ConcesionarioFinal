﻿using System;
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
        static void Main()
        {
            string cadCon = "Data Source=RulesMan;Initial Catalog=Concesionario;Integrated Security=True;MultipleActiveResultSets=True";
            AdoUnitOfWork auow = new AdoUnitOfWork(cadCon);
            Application.Run(new Inicio(new ClienteService(auow), new PresupuestoService(auow), new VehiculoService(auow)));
        }
    }
}
