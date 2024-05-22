﻿using System;
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
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //DatosPersonales datosPersonales = new DatosPersonales();
        }


        private void BtnInscripciones_Click(object sender, RoutedEventArgs e)
        {
            frameInscripciones.Navigate(new Uri("Inscripciones.xaml", UriKind.Relative));
        }

        private void BtnClientes_Click(object sender, RoutedEventArgs e)
        {
            frameInscripciones.Navigate(new Uri("Clientes.xaml", UriKind.Relative));

        }

        private void BtnRutinas_Click(object sender, RoutedEventArgs e)
        {
            frameInscripciones.Navigate(new Uri("Rutinas.xaml", UriKind.Relative));
        }
    }
}
