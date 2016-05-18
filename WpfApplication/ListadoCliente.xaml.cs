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
    /// Lógica de interacción para ListadoCliente.xaml
    /// </summary>
    public partial class ListadoCliente : Window
    {
        EntityUoW _unitOfWork;
        public ListadoCliente()
        {
            InitializeComponent();

            _unitOfWork = new EntityUoW();
            ActualizaGrid();
        }

        private void btnEliminarCliente_Click(object sender, RoutedEventArgs e)
        {
            if(dgClientes.SelectedItem== null)
            {
                MessageBox.Show("Seleccione un cliente", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            Cliente clienteAEliminar = (Cliente)dgClientes.SelectedItem;
            _unitOfWork.RClientes.Delete(clienteAEliminar);
            _unitOfWork.SaveChanges();

            ActualizaGrid();
        }

        private void btnEditarCliente_Click(object sender, RoutedEventArgs e)
        {
            if (dgClientes.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un cliente", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            Cliente cliente = (Cliente)dgClientes.SelectedItem;
            AltaEdicionCliente altaEdicionCliente = new AltaEdicionCliente(_unitOfWork, cliente);
            altaEdicionCliente.ShowDialog();

            ActualizaGrid();
        }

        private void ActualizaGrid()
        {
            var query = _unitOfWork.RClientes.GetAll();            
            if (!string.IsNullOrEmpty(txtFiltroId.Text))
            {
                var id = Convert.ToInt32(txtFiltroId.Text);
                query = query.Where(q => q.Id == id);
            }
            if (!string.IsNullOrEmpty(txtFiltroNombre.Text))
                query = query.Where(q => q.Nombre.Contains(txtFiltroNombre.Text));            
            dgClientes.ItemsSource = query.ToList();
        }

        private void btnAltaCliente_Click(object sender, RoutedEventArgs e)
        {            
            AltaEdicionCliente altaEdicionCliente = new AltaEdicionCliente(_unitOfWork);
            altaEdicionCliente.ShowDialog();

            ActualizaGrid();
        }

        private void btnFiltro_Click(object sender, RoutedEventArgs e)
        {
            ActualizaGrid();
        }
    }
}
