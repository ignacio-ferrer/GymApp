using GymApp.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace GymApp
{
    public partial class Clientes : Page
    {
        DatosPersonales datosPersonales = new DatosPersonales();
        RepositorioCliente repositorioCliente = new RepositorioCliente();

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
            public int telefono { get; set; }
            public int telefonoEmergencia { get; set; }
            public string correo { get; set; }
            public DateTime? fechaInscripcion { get; set; }
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
    }
}
