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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;    

namespace GymApp.SeccionInscripciones
{
    public partial class Inscripciones : Page
    {
        DatosPersonales datosPersonales = new DatosPersonales();
        DatosMedicos datosMedicos = new DatosMedicos();
        RepositorioCliente repositorioCliente = new RepositorioCliente();

        public Inscripciones()
        {
            InitializeComponent();
        }
      
        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(BoxNombre.Text) ||
                    string.IsNullOrWhiteSpace(BoxApellido.Text) ||
                    string.IsNullOrWhiteSpace(BoxEdad.Text) ||
                    string.IsNullOrWhiteSpace(BoxDni.Text) ||
                    string.IsNullOrWhiteSpace(BoxSexo.Text) ||
                    string.IsNullOrWhiteSpace(BoxDirec.Text) ||
                    string.IsNullOrWhiteSpace(BoxLocalidad.Text) ||
                    string.IsNullOrWhiteSpace(BoxCodigoPostal.Text) ||
                    string.IsNullOrWhiteSpace(BoxGrupoSanguineo.Text) ||
                    string.IsNullOrWhiteSpace(BoxTel.Text) ||
                    string.IsNullOrWhiteSpace(BoxContactoEmergencia.Text) ||
                    string.IsNullOrWhiteSpace(BoxMail.Text) ||
                    string.IsNullOrWhiteSpace(BoxMetodoPago.Text)||
                    string.IsNullOrWhiteSpace(BoxValorCuota.Text)||
                    string.IsNullOrWhiteSpace(ComboBoxOsea.Text)||
                    string.IsNullOrWhiteSpace(ComboBoxMuscular.Text)||
                    string.IsNullOrWhiteSpace(ComboBoxCardio.Text)||
                    string.IsNullOrWhiteSpace(ComboBoxAfixia.Text)||
                    string.IsNullOrWhiteSpace(ComboBoxAsmatico.Text)||
                    string.IsNullOrWhiteSpace(ComboBoxDiabetico.Text)||
                    string.IsNullOrWhiteSpace(ComboBoxEpileptico.Text)||
                    string.IsNullOrWhiteSpace(ComboBoxFumador.Text)||
                    string.IsNullOrWhiteSpace(ComboBoxMareos.Text)||
                    string.IsNullOrWhiteSpace(ComboBoxDesmayos.Text)||
                    string.IsNullOrWhiteSpace(ComboBoxRespirar.Text)||
                    string.IsNullOrWhiteSpace(ComboBoxNauseas.Text)||
                    string.IsNullOrWhiteSpace(ComboBoxAnemia.Text)||
                    string.IsNullOrWhiteSpace(ComboBoxEmbarazada.Text))
                {
                    MessageBox.Show("Todos los campos son obligatorios.");
                    return;
                }

                int BoxDeEdad = int.Parse(BoxEdad.Text);
                int BoxDeDni = int.Parse(BoxDni.Text);
                int BoxDeCP = int.Parse(BoxCodigoPostal.Text);
                int BoxDeTelefono = int.Parse(BoxTel.Text);
                int BoxDeTelefonoEmergencia = int.Parse(BoxContactoEmergencia.Text);
                int BoxDeValorCuota = int.Parse(BoxValorCuota.Text);

                DateTime? FechaCumple = DateCumple.SelectedDate;
                if (FechaCumple == null)
                {
                    MessageBox.Show("Por favor, selecciona una fecha de nacimiento válida.");
                    return;
                }

                DateTime? FechaInscripcion = DateInscripcion.SelectedDate;
                if (FechaInscripcion == null)
                {
                    MessageBox.Show("Por favor, selecciona una fecha de inscripción válida.");
                    return;
                }

                //DATOS PERSONALES
                datosPersonales.nombre = BoxNombre.Text;
                datosPersonales.apellido = BoxApellido.Text;
                datosPersonales.edad = BoxDeEdad;
                datosPersonales.dni = BoxDeDni;
                datosPersonales.sexo = BoxSexo.Text;
                datosPersonales.fechaNacimiento = FechaCumple;
                datosPersonales.direccion = BoxDirec.Text;
                datosPersonales.localidad = BoxLocalidad.Text;
                datosPersonales.codigoPostal = BoxDeCP;
                datosPersonales.grupoSanguineo = BoxGrupoSanguineo.Text;
                datosPersonales.telefono = BoxDeTelefono;
                datosPersonales.telefonoEmergencia = BoxDeTelefonoEmergencia;
                datosPersonales.correo = BoxMail.Text;
                datosPersonales.fechaInscripcion = FechaInscripcion;
                datosPersonales.metodoDePago = BoxMetodoPago.Text;
                datosPersonales.valorDeCuota = BoxDeValorCuota;

                repositorioCliente.AgregarCliente(datosPersonales);

                //DATOS MEDICOS
                datosMedicos.lesionOsea = ComboBoxOsea.SelectedIndex.ToString();
                datosMedicos.lesionMuscular = ComboBoxMuscular.SelectedIndex.ToString();
                datosMedicos.enfermedadCardio = ComboBoxCardio.SelectedIndex.ToString();
                datosMedicos.afixia = ComboBoxAfixia.SelectedIndex.ToString();
                datosMedicos.asmatico = ComboBoxAsmatico.SelectedIndex.ToString();
                datosMedicos.diabetico = ComboBoxDiabetico.SelectedIndex.ToString();
                datosMedicos.epileptico = ComboBoxEpileptico.SelectedIndex.ToString();
                datosMedicos.fumador = ComboBoxFumador.SelectedIndex.ToString();
                datosMedicos.mareos = ComboBoxMareos.SelectedIndex.ToString();
                datosMedicos.desmayos = ComboBoxDesmayos.SelectedIndex.ToString();
                datosMedicos.respirar = ComboBoxRespirar.SelectedIndex.ToString();
                datosMedicos.nauseas = ComboBoxNauseas.SelectedIndex.ToString();
                datosMedicos.anemia = ComboBoxAnemia.SelectedIndex.ToString();
                datosMedicos.embarazada = ComboBoxEmbarazada.SelectedIndex.ToString();

                MessageBox.Show("Datos personales guardados correctamente.");

                BoxNombre.Clear();
                BoxApellido.Clear();
                BoxEdad.Clear();
                BoxDni.Clear();
                BoxSexo.SelectedItem = null;
                BoxDirec.Clear();
                BoxLocalidad.Clear();
                BoxCodigoPostal.Clear();
                BoxGrupoSanguineo.SelectedItem = null;
                BoxTel.Clear();
                BoxContactoEmergencia.Clear();
                BoxMail.Clear();
                DateInscripcion.SelectedDate = null;
                
                //PAGO
                BoxValorCuota.Clear();
                BoxMetodoPago.SelectedItem = null;

                //MEDICO
                ComboBoxOsea.SelectedItem = null;
                ComboBoxMuscular.SelectedItem = null;
                ComboBoxCardio.SelectedItem = null;
                ComboBoxAfixia.SelectedItem = null;
                ComboBoxAsmatico.SelectedItem = null;
                ComboBoxDiabetico.SelectedItem = null;
                ComboBoxEpileptico.SelectedItem = null;
                ComboBoxFumador.SelectedItem = null;
                ComboBoxMareos.SelectedItem = null;
                ComboBoxDesmayos.SelectedItem = null;
                ComboBoxRespirar.SelectedItem = null;
                ComboBoxNauseas.SelectedItem = null;
                ComboBoxAnemia.SelectedItem = null;
                ComboBoxEmbarazada.SelectedItem = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }        
       
        private void BoxNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!IsAllLetters(BoxNombre.Text))
            {
                MessageBox.Show("Por favor, introduce solo letras en el nombre.");
                BoxNombre.Text = new string(BoxNombre.Text.Where(char.IsLetter).ToArray());
                BoxNombre.CaretIndex = BoxNombre.Text.Length; 
            }
        }

        private void BoxApellido_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!IsAllLetters(BoxApellido.Text))
            {
                MessageBox.Show("Por favor, introduce solo letras en el apellido.");
                BoxApellido.Text = new string(BoxApellido.Text.Where(char.IsLetter).ToArray());
                BoxApellido.CaretIndex = BoxApellido.Text.Length;
            }
        }

        private void BoxLocalidad_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!IsAllLetters(BoxLocalidad.Text))
            {
                MessageBox.Show("Por favor, introduce solo letras en la localidad.");
                BoxLocalidad.Text = new string(BoxLocalidad.Text.Where(char.IsLetter).ToArray());
                BoxLocalidad.CaretIndex = BoxLocalidad.Text.Length; 
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

        private void BoxNumerico_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                MessageBox.Show("Por favor, introduce solo números.");
                e.Handled = true;
            }
        }

        private void BtnImprimir_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog imprimir = new PrintDialog();

            if (imprimir.ShowDialog() == true)
            {
                // Crear un contenedor para el documento fijo
                FixedDocument fixedDoc = new FixedDocument();
                PageContent pageContent = new PageContent();
                FixedPage fixedPage = new FixedPage();

                // Crear una copia visual del control
                Grid grid = new Grid
                {
                    Width = this.ActualWidth,
                    Height = this.ActualHeight
                };

                var brush = new VisualBrush(this);
                var rect = new Rectangle
                {
                    Width = grid.Width,
                    Height = grid.Height,
                    Fill = brush
                };

                grid.Children.Add(rect);
                fixedPage.Children.Add(grid);

                // Configurar el tamaño de la página
                fixedPage.Width = imprimir.PrintableAreaWidth;
                fixedPage.Height = imprimir.PrintableAreaHeight;

                // Ajustar el contenido a la página imprimible
                grid.Measure(new Size(imprimir.PrintableAreaWidth, imprimir.PrintableAreaHeight));
                grid.Arrange(new Rect(new Point(0, 0), new Size(imprimir.PrintableAreaWidth, imprimir.PrintableAreaHeight)));
                grid.UpdateLayout();

                ((IAddChild)pageContent).AddChild(fixedPage);
                fixedDoc.Pages.Add(pageContent);

                // Imprimir el documento fijo
                try
                {
                    imprimir.PrintDocument(((IDocumentPaginatorSource)fixedDoc).DocumentPaginator, "Formulario Inscripcion");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al imprimir documento: {ex.Message}", "Error de impresión", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
