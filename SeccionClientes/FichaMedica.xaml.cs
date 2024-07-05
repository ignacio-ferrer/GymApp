using GymApp.Data;
using GymApp.SeccionInscripciones;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace GymApp.SeccionClientes
{
    /// <summary>
    /// Lógica de interacción para FichaMedica.xaml
    /// </summary>
    public partial class FichaMedica : Window
    {
        RepositorioMedico repositorioMedico = new RepositorioMedico();
        RepositorioCliente repositorioCliente = new RepositorioCliente();
        private string connectionString = "Server=DESKTOP-E2O57T0\\MSSQLSERVER01;Database=AppGymDB;Trusted_Connection=True;";

        public FichaMedica()
        {
            InitializeComponent();
            CargarCliente();
        }

        public class InformacionMedica
        {
            //Primera fila
            public string lesionOsea { get; set; }
            public string lesionMuscular { get; set; }
            public string enfermedadCardiovascular { get; set; }
            public string afixia { get; set; }
            public string asmatico { get; set; }
            public string diabetico { get; set; }
            public string epileptico { get; set; }
            public string fumador { get; set; }

            //Segunda fila
            public string mareos { get; set; }
            public string desmayos { get; set; }
            public string respirar { get; set; }
            public string nauseas { get; set; }
            public string anemia { get; set; }
            public string embarazada { get; set; }
        }

        public void CargarCliente()
        {
            if (DataGridMedico == null)
            {
                throw new NullReferenceException("La grid no esta inicializada.");
            }

            var datosMedicos = repositorioMedico.ObtenerFichaMedica();
            DataGridMedico.ItemsSource = datosMedicos;
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBoxNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!IsAllLetters(TextBoxNombre.Text))
            {
                MessageBox.Show("Por favor, introduce solo letras en el nombre.");
                TextBoxNombre.Text = new string(TextBoxNombre.Text.Where(char.IsLetter).ToArray());
                TextBoxNombre.CaretIndex = TextBoxNombre.Text.Length;
            }
        }

        private void TextBoxID_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                MessageBox.Show("Por favor, introduce solo números.");
                e.Handled = true;
            }
        }

        private bool IsAllLetters(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }


        private void BtnAplicar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = TextBoxNombre.Text;

            /*string.IsNullOrWhiteSpace(TextBoxID.Text))*/

            try
            {
                if (string.IsNullOrWhiteSpace(TextBoxNombre.Text))
                {
                    MessageBox.Show("Todos los campos son obligatorios.");
                    return;
                }

                TextBoxNombre.Clear();
                TextBoxID.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            BuscarPersona(nombre);
        }

        private void BuscarPersona(string nombre)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Cliente WHERE nombre = @nombre";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombre", nombre);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        DataGridMedico.ItemsSource = dataTable.DefaultView;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar la persona: " + ex.Message);
            }
        }
    }
}
