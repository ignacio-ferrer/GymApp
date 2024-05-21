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

namespace GymApp
{

    public partial class Clientes : Page
    {
        DatosPersonales datosPersonales = new DatosPersonales();
        DatosMedicos datosMedicos = new DatosMedicos();

        public Clientes()
        {
            InitializeComponent();
            LoadData();
        }

        public class InformacionCliente
        {
            public string nombre { get; set; }
            public string apellido { get; set; }
            public int dni { get; set; }
            public DateTime? fechaInscripcion { get; set; }
        }

        private void LoadData()
        {
            List<InformacionCliente> clientes = new List<InformacionCliente>
            {
                new InformacionCliente {nombre="",apellido="",dni=0,fechaInscripcion=null}
            };
            
            dataGrid.ItemsSource = clientes;
        }

    }
}
