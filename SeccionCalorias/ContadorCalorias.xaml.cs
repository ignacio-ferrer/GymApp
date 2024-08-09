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
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace GymApp.SeccionCalorias
{
    public partial class ContadorCalorias : Page
    {
        private ConsumirApi _apiClient;

        public ContadorCalorias()
        {
            InitializeComponent();
            Edades();

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

                    try
                    {
                        var items = JArray.Parse(result);
                        if (items.Count > 0)
                        {
                            var item = items[0]; 
                            MostrarNutrientes(item);
                        }
                        else
                        {
                            ResultTextBlock.Text = "No se encontraron resultados.";
                        }
                    }
                    catch (JsonException)
                    {
                        try
                        {
                            var item = JObject.Parse(result);
                            MostrarNutrientes(item);
                        }
                        catch (JsonException ex)
                        {
                            ResultTextBlock.Text = $"Error: {ex.Message}\nJSON Response:\n{result}";
                        }
                    }
                }
                catch (TaskCanceledException)
                {
                    ResultTextBlock.Text = "Error: La solicitud ha sido cancelada. Asegúrese de que la conexión a Internet sea estable y vuelva a intentarlo.";
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

        private void MostrarNutrientes(JToken item)
        {
            var name = item["name"]?.ToString() ?? "Desconocido";
            var calories = item["nutrition"]?["Calories"]?.ToString() ?? "Desconocido";
            var protein = item["nutrition"]?["Protein"]?.ToString() ?? "Desconocido";
            var carbohydrates = item["nutrition"]?["Carbs"]?.ToString() ?? "Desconocido";
            var fat = item["nutrition"]?["Fat"]?.ToString() ?? "Desconocido";

            var formattedResult = $"Nombre: {name}\n" +
                                  $"Calorías: {calories}\n" +
                                  $"Proteína: {protein}\n" +
                                  $"Carbohidratos: {carbohydrates}\n" +
                                  $"Grasa: {fat}";

            ResultTextBlock.Text = formattedResult;
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

            if (RadioPocoEjercicio.IsChecked.HasValue && RadioPocoEjercicio.IsChecked.Value)
            {
                if (sexo == "Masculino")
                {
                    primeraSuma = 13.397 * peso;
                    segundaSuma = 4.799 * altura;
                    primeraResta = 5.677 * edad;

                    TMBHombre = 88.362 + primeraSuma + segundaSuma - primeraResta;

                    resultado = TMBHombre * pocoEjercicio;
                }
                else
                {
                    primeraSuma = 9.247 * peso;
                    segundaSuma = 3.098 * altura;
                    primeraResta = 4.330 * edad;

                    TMBMujer = 447.593 + primeraSuma + segundaSuma - primeraResta;

                    resultado = TMBMujer * pocoEjercicio;
                }

                caloriasFinales = +resultado;

                BoxResultadoCalorias.Text = caloriasFinales.ToString("F2");
            }

            if (RadioEjercicioLigero.IsChecked.HasValue && RadioEjercicioLigero.IsChecked.Value)
            {
                if (sexo == "Masculino")
                {
                    primeraSuma = 13.397 * peso;
                    segundaSuma = 4.799 * altura;
                    primeraResta = 5.677 * edad;

                    TMBHombre = 88.362 + primeraSuma + segundaSuma - primeraResta;

                    resultado = TMBHombre * ejercicioLigero;
                }
                else
                {
                    primeraSuma = 9.247 * peso;
                    segundaSuma = 3.098 * altura;
                    primeraResta = 4.330 * edad;

                    TMBMujer = 447.593 + primeraSuma + segundaSuma - primeraResta;

                    resultado = TMBMujer * ejercicioLigero;
                }

                caloriasFinales = +resultado;

                BoxResultadoCalorias.Text = caloriasFinales.ToString("F2");
            }

            if (RadioEjercicioModerado.IsChecked.HasValue && RadioEjercicioModerado.IsChecked.Value)
            {
                if (sexo == "Masculino")
                {
                    primeraSuma = 13.397 * peso;
                    segundaSuma = 4.799 * altura;
                    primeraResta = 5.677 * edad;

                    TMBHombre = 88.362 + primeraSuma + segundaSuma - primeraResta;

                    resultado = TMBHombre * ejercicioModerado;
                }
                else
                {
                    primeraSuma = 9.247 * peso;
                    segundaSuma = 3.098 * altura;
                    primeraResta = 4.330 * edad;

                    TMBMujer = 447.593 + primeraSuma + segundaSuma - primeraResta;

                    resultado = TMBMujer * ejercicioModerado;
                }

                caloriasFinales = +resultado;

                BoxResultadoCalorias.Text = caloriasFinales.ToString("F2");
            }

            if (RadioEjercicioFuerte.IsChecked.HasValue && RadioEjercicioFuerte.IsChecked.Value)
            {
                if (sexo == "Masculino")
                {
                    primeraSuma = 13.397 * peso;
                    segundaSuma = 4.799 * altura;
                    primeraResta = 5.677 * edad;

                    TMBHombre = 88.362 + primeraSuma + segundaSuma - primeraResta;

                    resultado = TMBHombre * ejercicioFuerte;
                }
                else
                {
                    primeraSuma = 9.247 * peso;
                    segundaSuma = 3.098 * altura;
                    primeraResta = 4.330 * edad;

                    TMBMujer = 447.593 + primeraSuma + segundaSuma - primeraResta;

                    resultado = TMBMujer * ejercicioFuerte;
                }

                caloriasFinales = +resultado;

                BoxResultadoCalorias.Text = caloriasFinales.ToString("F2");
            }

            if (RadioEjercicioMuyFuerte.IsChecked.HasValue && RadioEjercicioMuyFuerte.IsChecked.Value)
            {
                if (sexo == "Masculino")
                {
                    primeraSuma = 13.397 * peso;
                    segundaSuma = 4.799 * altura;
                    primeraResta = 5.677 * edad;

                    TMBHombre = 88.362 + primeraSuma + segundaSuma - primeraResta;

                    resultado = TMBHombre * ejercicioMuyFuerte;
                }
                else
                {
                    primeraSuma = 9.247 * peso;
                    segundaSuma = 3.098 * altura;
                    primeraResta = 4.330 * edad;

                    TMBMujer = 447.593 + primeraSuma + segundaSuma - primeraResta;

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

        private void Edades()
        {
            for (int i = 5; i < 101; i++)
            {
                edadComboBox.Items.Add(i);
            }
        }
    }
}
