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
    public partial class ContadorCalorias : Page
    {
        public ContadorCalorias()
        {
            InitializeComponent();
            Edades();
        }

        private void Edades()
        {
            for(int i = 5; i < 101; i++)
            {
                edadComboBox.Items.Add(i);
            }
        }

        private void BtnCalcularCalorias_Click(object sender, RoutedEventArgs e)
        {
            double TMBHombre, TMBMujer;

            int altura = int.Parse(BoxAltura.Text);
            int peso = int.Parse(BoxPeso.Text);
            int edad = int.Parse(edadComboBox.Text);
            string sexo = sexoComboBox.Text;

            double pocoEjercicio = 1.2 , ejercicioLigero = 1.375 , ejercicioModerado = 1.55 , ejercicioFuerte = 1.725 , ejercicioMuyFuerte = 1.9;
            double caloriasFinales , resultado, primeraSuma , segundaSuma , primeraResta; 

            //1
            if (RadioPocoEjercicio.IsChecked.HasValue && RadioPocoEjercicio.IsChecked.Value)
            {
                if(sexo == "Masculino")
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

                caloriasFinales =+ resultado;

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
    }
}
