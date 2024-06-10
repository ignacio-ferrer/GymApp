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
using GymApp.API;
using Newtonsoft.Json.Linq;

namespace GymApp
{
    public partial class ContadorCalorias : Page
    {
        private ConsumirApi _apiClient;
        public ContadorCalorias()
        {
            InitializeComponent();
            Edades();

            //api
            _apiClient = new ConsumirApi();
        }

        private async void FetchButton_Click(object sender, RoutedEventArgs e)
        {
            string foodItem = FoodTextBox.Text;
            if (!string.IsNullOrEmpty(foodItem))
            {
                try
                {
                    ResultTextBlock.Text = "Obteniendo Informacion...";
                    string result = await _apiClient.SearchByKeywordAsync(foodItem);

                    // Parse the JSON result to extract and format the nutrients
                    var items = JArray.Parse(result);
                    if (items.Count > 0)
                    {
                        var item = items[0]; // Tomar solo el primer resultado
                        var name = item["brand_name"]?.ToString() ?? item["description"]?.ToString() ?? "Desconocido";
                        var calories = item["nutritional_contents"]?["energy"]?["value"]?.ToString() ?? "Desconocido";
                        var protein = item["nutritional_contents"]?["protein"]?.ToString() ?? "Desconocido";
                        var carbohydrates = item["nutritional_contents"]?["carbohydrates"]?.ToString() ?? "Desconocido";
                        var fat = item["nutritional_contents"]?["fat"]?.ToString() ?? "Desconocido";
                        var fiber = item["nutritional_contents"]?["fiber"]?.ToString() ?? "Desconocido";

                        var formattedResult = $"Nombre: {name}\n" +
                                              $"Calorías: {calories}\n" +
                                              $"Proteína: {protein}\n" +
                                              $"Carbohidratos: {carbohydrates}\n" +
                                              $"Grasa: {fat}\n" +
                                              $"Fibra: {fiber}";

                        ResultTextBlock.Text = formattedResult;
                    }
                    else
                    {
                        ResultTextBlock.Text = "No se encontraron resultados.";
                    }
                }
                catch (Exception ex)
                {
                    ResultTextBlock.Text = $"Error: {ex.Message}";
                }
            }
            else
            {
                ResultTextBlock.Text = "Por favor, ingresa un alimento.";
            }
        }

        private void BtnCalcularCalorias_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(edadComboBox.Text) ||
                    string.IsNullOrWhiteSpace(BoxAltura.Text) ||
                    string.IsNullOrWhiteSpace(sexoComboBox.Text) ||
                    string.IsNullOrWhiteSpace(BoxPeso.Text))
                {
                    MessageBox.Show("Todos los campos son obligatorios.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            double TMBHombre, TMBMujer;

            int altura = int.Parse(BoxAltura.Text);
            int peso = int.Parse(BoxPeso.Text);
            int edad = int.Parse(edadComboBox.Text);
            string sexo = sexoComboBox.Text;

            double pocoEjercicio = 1.2, ejercicioLigero = 1.375, ejercicioModerado = 1.55, ejercicioFuerte = 1.725, ejercicioMuyFuerte = 1.9;
            double caloriasFinales, resultado, primeraSuma, segundaSuma, primeraResta;

            //1
            if (RadioPocoEjercicio.IsChecked.HasValue && RadioPocoEjercicio.IsChecked.Value)
            {
                if (sexo == "Masculino")
                {
                    //HOMBRE
                    primeraSuma = 13.397 * peso;
                    segundaSuma = 4.799 * altura;
                    primeraResta = 5.677 * edad;

                    //HOMBRE
                    TMBHombre = 88.362 + primeraSuma + segundaSuma - primeraResta;

                    //HOMBRE
                    resultado = TMBHombre * pocoEjercicio;
                }
                else
                {
                    //MUJER
                    primeraSuma = 9.247 * peso;
                    segundaSuma = 3.098 * altura;
                    primeraResta = 4.330 * edad;

                    //MUJER
                    TMBMujer = 447.593 + primeraSuma + segundaSuma - primeraResta;

                    //MUJER
                    resultado = TMBMujer * pocoEjercicio;
                }

                caloriasFinales = +resultado;

                BoxResultadoCalorias.Text = caloriasFinales.ToString("F2");
            }

            //2
            if (RadioEjercicioLigero.IsChecked.HasValue && RadioEjercicioLigero.IsChecked.Value)
            {
                if (sexo == "Masculino")
                {
                    //HOMBRE
                    primeraSuma = 13.397 * peso;
                    segundaSuma = 4.799 * altura;
                    primeraResta = 5.677 * edad;

                    //HOMBRE
                    TMBHombre = 88.362 + primeraSuma + segundaSuma - primeraResta;

                    //HOMBRE
                    resultado = TMBHombre * ejercicioLigero;
                }
                else
                {
                    //MUJER
                    primeraSuma = 9.247 * peso;
                    segundaSuma = 3.098 * altura;
                    primeraResta = 4.330 * edad;

                    //MUJER
                    TMBMujer = 447.593 + primeraSuma + segundaSuma - primeraResta;

                    //MUJER
                    resultado = TMBMujer * ejercicioLigero;
                }

                caloriasFinales = +resultado;

                BoxResultadoCalorias.Text = caloriasFinales.ToString("F2");
            }

            //3
            if (RadioEjercicioModerado.IsChecked.HasValue && RadioEjercicioModerado.IsChecked.Value)
            {
                if (sexo == "Masculino")
                {
                    //HOMBRE
                    primeraSuma = 13.397 * peso;
                    segundaSuma = 4.799 * altura;
                    primeraResta = 5.677 * edad;

                    //HOMBRE
                    TMBHombre = 88.362 + primeraSuma + segundaSuma - primeraResta;

                    //HOMBRE
                    resultado = TMBHombre * ejercicioModerado;
                }
                else
                {
                    //MUJER
                    primeraSuma = 9.247 * peso;
                    segundaSuma = 3.098 * altura;
                    primeraResta = 4.330 * edad;

                    //MUJER
                    TMBMujer = 447.593 + primeraSuma + segundaSuma - primeraResta;

                    //MUJER
                    resultado = TMBMujer * ejercicioModerado;
                }

                caloriasFinales = +resultado;

                BoxResultadoCalorias.Text = caloriasFinales.ToString("F2");
            }

            //4
            if (RadioEjercicioFuerte.IsChecked.HasValue && RadioEjercicioFuerte.IsChecked.Value)
            {
                if (sexo == "Masculino")
                {
                    //HOMBRE
                    primeraSuma = 13.397 * peso;
                    segundaSuma = 4.799 * altura;
                    primeraResta = 5.677 * edad;

                    //HOMBRE
                    TMBHombre = 88.362 + primeraSuma + segundaSuma - primeraResta;

                    //HOMBRE
                    resultado = TMBHombre * ejercicioFuerte;
                }
                else
                {
                    //MUJER
                    primeraSuma = 9.247 * peso;
                    segundaSuma = 3.098 * altura;
                    primeraResta = 4.330 * edad;

                    //MUJER
                    TMBMujer = 447.593 + primeraSuma + segundaSuma - primeraResta;

                    //MUJER
                    resultado = TMBMujer * ejercicioFuerte;
                }

                caloriasFinales = +resultado;

                BoxResultadoCalorias.Text = caloriasFinales.ToString("F2");
            }

            //5
            if (RadioEjercicioMuyFuerte.IsChecked.HasValue && RadioEjercicioMuyFuerte.IsChecked.Value)
            {
                if (sexo == "Masculino")
                {
                    //HOMBRE
                    primeraSuma = 13.397 * peso;
                    segundaSuma = 4.799 * altura;
                    primeraResta = 5.677 * edad;

                    //HOMBRE
                    TMBHombre = 88.362 + primeraSuma + segundaSuma - primeraResta;

                    //HOMBRE
                    resultado = TMBHombre * ejercicioMuyFuerte;
                }
                else
                {
                    //MUJER
                    primeraSuma = 9.247 * peso;
                    segundaSuma = 3.098 * altura;
                    primeraResta = 4.330 * edad;

                    //MUJER
                    TMBMujer = 447.593 + primeraSuma + segundaSuma - primeraResta;

                    //MUJER
                    resultado = TMBMujer * ejercicioMuyFuerte;
                }

                caloriasFinales = +resultado;

                BoxResultadoCalorias.Text = caloriasFinales.ToString("F2");
            }
        }

        private void BoxNumerico_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                MessageBox.Show("Por favor, introduce solo números.");
                e.Handled = true;
            }
        }

        private void BtnLimpiarDatos_Click(object sender, RoutedEventArgs e)
        {
            BoxAltura.Clear();
            BoxPeso.Clear();
            edadComboBox.SelectedItem = null;
            sexoComboBox.SelectedItem = null;
        }


        //para que las edades vayan del 5 al 100
        private void Edades()
        {
            for (int i = 5; i < 101; i++)
            {
                edadComboBox.Items.Add(i);
            }
        }
    }
}
