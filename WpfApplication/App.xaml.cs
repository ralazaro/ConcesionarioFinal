using Repositories;
using Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            EntityUoW auow = new EntityUoW();
            Window mw = new MainWindow(new ClienteService(auow), new VehiculoService(auow), new PresupuestoService(auow));
            mw.Show();
        }
    }
}
