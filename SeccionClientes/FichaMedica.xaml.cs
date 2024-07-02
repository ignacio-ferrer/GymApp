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
using System.Windows.Shapes;

namespace GymApp.SeccionClientes
{
    /// <summary>
    /// Lógica de interacción para FichaMedica.xaml
    /// </summary>
    public partial class FichaMedica : Window
    {
        public FichaMedica()
        {
            InitializeComponent();
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
            try
            {
                if (string.IsNullOrWhiteSpace(TextBoxNombre.Text) ||
                    string.IsNullOrWhiteSpace(TextBoxID.Text))
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
        }
    }
}
