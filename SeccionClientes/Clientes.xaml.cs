using GymApp.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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

namespace GymApp.SeccionClientes
{
    public partial class Clientes : Page
    {
        RepositorioCliente repositorioCliente = new RepositorioCliente();
        private FichaMedica _ventanaMedica;

        public Clientes()
        {
            InitializeComponent();
            LoadCliente();
        }

        public class InformacionCliente
        {
            public string nombre { get; set; }
            public string apellido { get; set; }
            public int edad { get; set; }
            public int dni { get; set; }
            public string sexo { get; set; }
            public DateTime? fechaNacimiento { get; set; }
            public string direccion { get; set; }
            public string localidad { get; set; }
            public int codigoPostal { get; set; }
            public string grupoSanguineo { get; set; }
            public int telefono { get; set; }
            public int telefonoEmergencia { get; set; }
            public string correo { get; set; }
            public DateTime? fechaInscripcion { get; set; }
            public string metodoDePago { get; set; }
            public int valorDeCuota { get; set; }
        }

        public void LoadCliente()
        {
            if (ClientesDataGrid == null)
            {
                throw new NullReferenceException("La grid no esta inicializada.");
            }

            var datosPersonales = repositorioCliente.ObtenerClientes();
            ClientesDataGrid.ItemsSource = datosPersonales;
        }

        private void BtnBorrarCliente_Click(object sender, RoutedEventArgs e)
        {
            if (ClientesDataGrid.SelectedItem is DatosPersonales selectedClient)
            {
                repositorioCliente.BorrarUsuario(selectedClient.ClienteId);
                LoadCliente();
            }
            else
            {
                MessageBox.Show("Selecciona un cliente para eliminar.");
            }
        } 

        private void BtnEditarCliente_Click(object sender, RoutedEventArgs e)
        {
            if (ClientesDataGrid.SelectedItem is DatosPersonales selectedClient)
            {
                selectedClient.nombre = "";
                selectedClient.apellido = "";
                selectedClient.edad = 0;
                selectedClient.dni = 0;
                selectedClient.sexo = "";
                selectedClient.fechaNacimiento = new DateTime();
                selectedClient.direccion = "";
                selectedClient.localidad = "";
                selectedClient.codigoPostal = 0;
                selectedClient.grupoSanguineo = "";
                selectedClient.telefono = 0;
                selectedClient.telefonoEmergencia = 0;
                selectedClient.correo = "";
                selectedClient.fechaInscripcion = DateTime.Now;
                selectedClient.metodoDePago = "";
                selectedClient.valorDeCuota = 0;

                repositorioCliente.EditarUsuario(selectedClient);
                LoadCliente();
            }
            else
            {
                MessageBox.Show("Selecciona un cliente para editar.");
            }
        }

        private void BtnFichaMedica_Click(object sender, RoutedEventArgs e)
        {
            if (_ventanaMedica == null || !_ventanaMedica.IsVisible)
            {
                _ventanaMedica = new FichaMedica();

                _ventanaMedica.Closed += (s, args) => _ventanaMedica = null; 
                _ventanaMedica.Show();
            }
            else
            {
                _ventanaMedica.Focus(); 
            }
        }
    }
}
