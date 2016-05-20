using DomainModel;
using Repositories;
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
using System.Windows.Shapes;

namespace WpfApplication
{
    /// <summary>
    /// Lógica de interacción para ListadoVehiculo.xaml
    /// </summary>
    public partial class ListadoVehiculo : Window
    {
        EntityUoW _unitOfWork;
        public ListadoVehiculo()
        {
            InitializeComponent();

            _unitOfWork = new EntityUoW();
            _unitOfWork.Comenzar();
            ActualizaGrid();
        }

        private void btnEliminarVehiculo_Click(object sender, RoutedEventArgs e)
        {
            if(dgVehiculos.SelectedItem== null)
            {
                MessageBox.Show("Seleccione un vehiculo", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            Vehiculo vehiculoAEliminar = (Vehiculo)dgVehiculos.SelectedItem;
            _unitOfWork.RVehiculos.Delete(vehiculoAEliminar);
            _unitOfWork.SaveChanges();

            ActualizaGrid();
        }

        private void btnEditarVehiculo_Click(object sender, RoutedEventArgs e)
        {
            if (dgVehiculos.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un vehiculo", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            Vehiculo vehiculo = (Vehiculo)dgVehiculos.SelectedItem;
            AltaEdicionVehiculo altaEdicionVehiculo = new AltaEdicionVehiculo(_unitOfWork, vehiculo);
            altaEdicionVehiculo.ShowDialog();

            ActualizaGrid();
        }

        private void ActualizaGrid()
        {
            var query = _unitOfWork.RVehiculos.GetAll();            
            if (!string.IsNullOrEmpty(txtFiltroId.Text))
            {
                var id = Convert.ToInt32(txtFiltroId.Text);
                query = query.Where(q => q.Id == id).ToList();
            }
            if (!string.IsNullOrEmpty(txtFiltroMarca.Text))
                query = query.Where(q => q.Marca.Contains(txtFiltroMarca.Text)).ToList();            
            dgVehiculos.ItemsSource = query.ToList();
        }

        private void btnAltaVehiculo_Click(object sender, RoutedEventArgs e)
        {            
            AltaEdicionVehiculo altaEdicionVehiculo = new AltaEdicionVehiculo(_unitOfWork);
            altaEdicionVehiculo.ShowDialog();

            ActualizaGrid();
        }

        private void btnFiltro_Click(object sender, RoutedEventArgs e)
        {
            ActualizaGrid();
        }
    }
}
