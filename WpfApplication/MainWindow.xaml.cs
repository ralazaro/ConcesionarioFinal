using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IClienteService cService;
        IVehiculoService vService;
        IPresupuestoService pService;

        public MainWindow(ClienteService cs, VehiculoService vs, PresupuestoService ps)
        {
            this.cService = cs;
            this.vService = vs;
            this.pService = ps;
            InitializeComponent();
        }

        private void mnClientes_Click(object sender, RoutedEventArgs e)
        {
            ListadoCliente listadoCliente = new ListadoCliente();
            listadoCliente.ShowDialog();
        }

        private void btnClientes_Click(object sender, RoutedEventArgs e)
        {
            ListadoCliente listadoCliente = new ListadoCliente();
            listadoCliente.ShowDialog();
        }

        private void mnVehiculos_Click(object sender, RoutedEventArgs e)
        {
            ListadoVehiculo listadoVehiculo = new ListadoVehiculo();
            listadoVehiculo.ShowDialog();
        }

        private void btnVehiculos_Click(object sender, RoutedEventArgs e)
        {
            ListadoVehiculo listadoVehiculo = new ListadoVehiculo();
            listadoVehiculo.ShowDialog();
        }

        private void mnPresupuestosAlta_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void mnPresupuestosBaja_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnPresupuestosModificar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnPresupuestosListado_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
