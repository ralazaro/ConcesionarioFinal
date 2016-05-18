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
    /// Lógica de interacción para AltaEdicionVehiculo.xaml
    /// </summary>
    public partial class AltaEdicionVehiculo : Window
    {
        bool nueva;
        Vehiculo _vehiculo;
        EntityUoW _unitOfWork;
        public AltaEdicionVehiculo(EntityUoW unitOfWork)
        {
            InitializeComponent();
            nueva = true;
            _unitOfWork = unitOfWork;
        }

        public AltaEdicionVehiculo(EntityUoW unitOfWork, Vehiculo vehiculo)
            : this(unitOfWork)
        {
            _vehiculo = vehiculo;
            nueva = false;            
            CargarDatos();
        }

        private void CargarDatos()
        {
            txtMarca.Text = _vehiculo.Marca;
            txtModelo.Text = _vehiculo.Modelo;
            txtPotencia.Text =  Convert.ToString(_vehiculo.Potencia);
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if(nueva)
            {
                _unitOfWork.RVehiculos.Add(new Vehiculo()
                {
                    Marca = txtMarca.Text,
                    Modelo = txtModelo.Text,
                    Potencia = Convert.ToInt32(txtPotencia.Text),
                });
            }
            else
            {
                _vehiculo.Marca = txtMarca.Text;
                _vehiculo.Modelo = txtModelo.Text;
                _vehiculo.Potencia = Convert.ToInt32(txtPotencia.Text);
                _unitOfWork.RVehiculos.Update(_vehiculo);
            }
            
            _unitOfWork.SaveChanges();
            Close();
        }
        /*
        private void txtPotencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !(e.KeyChar == ('.')))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        */
    }

}
