using GymApp.Data;
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
using System.Data.SqlClient;
using System.Windows.Forms;
using GymApp.API;

namespace GymApp
{
    public partial class MainWindow : Window
    {
        private ConsumirApi _apiClient;

        public MainWindow()
        {
            InitializeComponent();
            _apiClient = new ConsumirApi();
        }

        private void BtnInscripciones_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("SeccionInscripciones/Inscripciones.xaml", UriKind.Relative));
        }

        private void BtnClientes_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("SeccionClientes/Clientes.xaml", UriKind.Relative));
        }

        private void BtnRutinas_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("SeccionRutina/Rutinas.xaml", UriKind.Relative));
        }

        private void BtnContadorCalorias_Click(object sender, RoutedEventArgs e)
        {
           MainFrame.Navigate(new Uri("SeccionCalorias/ContadorCalorias.xaml", UriKind.Relative));
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
