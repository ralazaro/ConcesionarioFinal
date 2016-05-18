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
    /// Lógica de interacción para AltaEdicionCliente.xaml
    /// </summary>
    public partial class AltaEdicionCliente : Window
    {
        bool nueva;
        Cliente _cliente;
        EntityUoW _unitOfWork;
        public AltaEdicionCliente(EntityUoW unitOfWork)
        {
            InitializeComponent();
            nueva = true;
            _unitOfWork = unitOfWork;
        }

        public AltaEdicionCliente(EntityUoW unitOfWork, Cliente cliente)
            : this(unitOfWork)
        {
            _cliente = cliente;
            nueva = false;            
            CargarDatos();
        }

        private void CargarDatos()
        {
            txtNombre.Text = _cliente.Nombre;
            txtApellidos.Text = _cliente.Apellidos;
            txtTelefono.Text = _cliente.Telefono;
            chkVip.IsChecked = _cliente.Vip;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if(nueva)
            {
                _unitOfWork.RClientes.Add(new Cliente()
                {
                    Nombre = txtNombre.Text,
                    Apellidos = txtApellidos.Text,
                    Telefono = txtTelefono.Text,
                    Vip = chkVip.IsChecked.Value
                });
            }
            else
            {
                _cliente.Nombre = txtNombre.Text;
                _cliente.Apellidos = txtApellidos.Text;
                _cliente.Telefono = txtTelefono.Text;
                _cliente.Vip = chkVip.IsChecked.Value;
                _unitOfWork.RClientes.Update(_cliente);
            }
            
            _unitOfWork.SaveChanges();
            Close();
        }

    }
}
