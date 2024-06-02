﻿using GymApp.Data;
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
    public partial class Inscripciones : Page
    {
        DatosPersonales datosPersonales = new DatosPersonales();
        DatosMedicos datosMedicos = new DatosMedicos();
        RepositorioCliente repositorioCliente = new RepositorioCliente();

        public Inscripciones()
        {
            InitializeComponent();
            repositorioCliente.ObtenerClientes();
        }
      
        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(BoxNombre.Text) ||
                    string.IsNullOrWhiteSpace(BoxApellido.Text) ||
                    string.IsNullOrWhiteSpace(BoxEdad.Text) ||
                    string.IsNullOrWhiteSpace(BoxDni.Text) ||
                    string.IsNullOrWhiteSpace(BoxDirec.Text) ||
                    string.IsNullOrWhiteSpace(BoxLocalidad.Text) ||
                    string.IsNullOrWhiteSpace(BoxCodigoPostal.Text) ||
                    string.IsNullOrWhiteSpace(BoxTel.Text) ||
                    string.IsNullOrWhiteSpace(BoxContactoEmergencia.Text) ||
                    string.IsNullOrWhiteSpace(BoxMail.Text) ||
                    string.IsNullOrWhiteSpace(BoxMedicoUno.Text) ||
                    string.IsNullOrWhiteSpace(BoxMedicoDos.Text) ||
                    string.IsNullOrWhiteSpace(BoxMedicoTres.Text))
                {
                    MessageBox.Show("Todos los campos son obligatorios.");
                    return;
                }

                int BoxDeEdad = int.Parse(BoxEdad.Text);
                int BoxDeDni = int.Parse(BoxDni.Text);
                bool BoxDeSexo = BtnHombre.IsChecked == true;                
                int BoxDeCP = int.Parse(BoxCodigoPostal.Text);
                int BoxDeTelefono = int.Parse(BoxTel.Text);
                int BoxDeTelefonoEmergencia = int.Parse(BoxContactoEmergencia.Text);

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
              
                // Guardando todas las variables de la ficha: Datos Personales
                datosPersonales.nombre = BoxNombre.Text;
                datosPersonales.apellido = BoxApellido.Text;
                datosPersonales.edad = BoxDeEdad;
                datosPersonales.dni = BoxDeDni;
                datosPersonales.sexo = BoxDeSexo;
                datosPersonales.fechaNacimiento = FechaCumple;
                datosPersonales.direccion = BoxDirec.Text;
                datosPersonales.localidad = BoxLocalidad.Text;
                datosPersonales.codigoPostal = BoxDeCP;
                datosPersonales.telefono = BoxDeTelefono;
                datosPersonales.telefonoEmergencia = BoxDeTelefonoEmergencia;
                datosPersonales.correo = BoxMail.Text;
                datosPersonales.fechaInscripcion = FechaInscripcion;

                // Guardando todas las variables de la ficha: Datos Medicos
                datosMedicos.lesionOsea = BoxMedicoUno.Text;
                datosMedicos.lesionMuscular = BoxMedicoDos.Text;
                datosMedicos.enfermedadCardio = BoxMedicoTres.Text;

                //bools
                datosMedicos.preguntaUno = BtnSiUno.IsChecked == true;
                datosMedicos.preguntaDos = BtnSiDos.IsChecked == true;
                datosMedicos.preguntaTres = BtnSiTres.IsChecked == true;
                datosMedicos.preguntaCuatro = BtnSiCuatro.IsChecked == true;
                
                //bool 5:
                datosMedicos.preguntaAsmatico = BtnAsmatico.IsChecked == true;
                datosMedicos.preguntaEpileptico = BtnEpileptico.IsChecked == true;
                datosMedicos.preguntaDiabetico = BtnDiabetico.IsChecked == true;
                datosMedicos.preguntaFumador = BtnFumador.IsChecked == true;

                //bool 6
                datosMedicos.preguntaMareos = BtnMareos.IsChecked == true;
                datosMedicos.preguntaDesmayos = BtnDesmayos.IsChecked == true;  
                datosMedicos.preguntaRespirar = BtnRespirar.IsChecked == true;
                datosMedicos.preguntaNauseas = BtnNauseas.IsChecked == true;

                datosMedicos.preguntaSiete = BtnSiSiete.IsChecked == true;
                datosMedicos.preguntaOcho = BtnSiOcho.IsChecked == true;
                datosMedicos.preguntaNueve = BtnSiNueve.IsChecked == true;

                MessageBox.Show("Datos personales guardados correctamente.");

                // Limpiar los TextBox después de guardar los datos
                BoxNombre.Clear();
                BoxApellido.Clear();
                BoxEdad.Clear();
                BoxDni.Clear();
                BoxDirec.Clear();
                BoxLocalidad.Clear();
                BoxCodigoPostal.Clear();
                BoxTel.Clear();
                BoxContactoEmergencia.Clear();
                BoxMail.Clear();
                BoxMedicoUno.Clear();
                BoxMedicoDos.Clear();
                BoxMedicoTres.Clear();
                DateInscripcion.SelectedDate = null;
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

            //muestra el cuadro predeterminado 
            if (imprimir.ShowDialog() == true)
            {
                //obtiene visualmente el formulario
                var visual = new DrawingVisual();
                using (var context = visual.RenderOpen())
                {
                    var brush = new VisualBrush(this);
                    context.DrawRectangle(brush, null, new Rect(new Point(0, 0), new Size(this.ActualWidth, this.ActualHeight)));
                }

                //para ajustar tamaño
                double scale = Math.Min(imprimir.PrintableAreaWidth / this.ActualWidth, imprimir.PrintableAreaHeight / this.ActualHeight);
                visual.Transform = new ScaleTransform(scale, scale);

                // Imprimir el contenido visual ajustado
                imprimir.PrintVisual(visual, "Formulario Inscripcion.");
            }
        }
    }
}
