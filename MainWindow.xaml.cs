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
    public partial class MainWindow : Window
    {
        private Clientes _clientesPage;
        private Inscripciones _inscripcionesPage;

        public MainWindow()
        {
            InitializeComponent();
            _clientesPage = new Clientes();
            _inscripcionesPage = new Inscripciones();
            _inscripcionesPage.SetClientesCollection(_clientesPage.ClientesCollection);
        }

        private void BtnInscripciones_Click(object sender, RoutedEventArgs e)
        {
            frameInscripciones.Navigate(_inscripcionesPage);
        }

        private void BtnClientes_Click(object sender, RoutedEventArgs e)
        {
            frameInscripciones.Navigate(_clientesPage);
        }

        private void BtnRutinas_Click(object sender, RoutedEventArgs e)
        {
            frameInscripciones.Navigate(new Uri("Rutinas.xaml", UriKind.Relative));
        }
    }
}
