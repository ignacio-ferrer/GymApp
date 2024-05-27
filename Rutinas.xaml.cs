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
    public partial class Rutinas : Page
    {
        //grupo muscular grande
        public ObservableCollection<Ejercicio> EjerciciosPecho { get; set; }
        public ObservableCollection<Ejercicio> EjerciciosEspalda { get; set; }
        public ObservableCollection<Ejercicio> EjerciciosPiernas { get; set; }

        //grupo muscular chico
        public ObservableCollection<Ejercicio> EjerciciosBiceps { get; set; }
        public ObservableCollection<Ejercicio> EjerciciosTriceps { get; set; }
        public ObservableCollection<Ejercicio> EjerciciosHombros { get; set; }
        public ObservableCollection<Ejercicio> EjerciciosTrapecio { get; set; }
        public ObservableCollection<Ejercicio> EjerciciosGemelos { get; set; }

        public ObservableCollection<Ejercicio> EjerciciosSeleccionados { get; set; }
        public ICommand ComandoAgregarEjercicios { get; set; }

        public Rutinas()
        {
            InitializeComponent();

            //GRUPO MUSCULAR GRANDE
            EjerciciosPecho = new ObservableCollection<Ejercicio>
            {
                new Ejercicio { Nombre = "Press de banca"},
                new Ejercicio { Nombre = "Press en banco inclinado"},
                new Ejercicio { Nombre = "Peck Deck"},
                new Ejercicio { Nombre = "Apertura en polea"},
                new Ejercicio { Nombre = "Flexiones de brazo"}
            };

            EjerciciosEspalda = new ObservableCollection<Ejercicio>
            {
                new Ejercicio { Nombre = "Peso muerto"},
                new Ejercicio { Nombre = "Remo con barra"},
                new Ejercicio { Nombre = "Jalon alto en polea"},
                new Ejercicio { Nombre = "Pull Over"},
                new Ejercicio { Nombre = "Dominadas"}
            };

            EjerciciosPiernas = new ObservableCollection<Ejercicio>
            {
                new Ejercicio { Nombre = "Sentadilla"},
                new Ejercicio { Nombre = "Prensa"},
                new Ejercicio { Nombre = "Extension de cuadriceps en maquina"},
                new Ejercicio { Nombre = "Curl femoral en maquina"},
                new Ejercicio { Nombre = "Hip Thrust"}
            };


            //GRUPO MUSCULAR CHICO
            EjerciciosBiceps = new ObservableCollection<Ejercicio>
            {
                new Ejercicio { Nombre = "Curl inclinado en banco con mancuernas (Enfasis en cabeza larga)"},
                new Ejercicio { Nombre = "Curl en banco scott con barra Z (Enfasis en cabeza corta)"},
                new Ejercicio { Nombre = "Curl martillo (Enfasis en el braquial)"}
            };

            EjerciciosTriceps = new ObservableCollection<Ejercicio>
            {
                new Ejercicio { Nombre = "Extensiones de triceps sobre cabeza (Enfasis en cabeza larga)"},
                new Ejercicio { Nombre = "Jalon de tricep (Enfasis en cabeza lateral)"},
                new Ejercicio { Nombre = "Fondos (Enfasis en cabeza medial)"}
            };

            EjerciciosHombros = new ObservableCollection<Ejercicio>
            {
                new Ejercicio { Nombre = "Press militar"},
                new Ejercicio { Nombre = "Vuelos laterales"},
                new Ejercicio { Nombre = "Peck Deck"}
            };

            EjerciciosTrapecio = new ObservableCollection<Ejercicio>
            {
                new Ejercicio { Nombre = "Encogimientos de hombro"},
                new Ejercicio { Nombre = "Remo al cuello"}
            };

            EjerciciosGemelos = new ObservableCollection<Ejercicio>
            {
                new Ejercicio { Nombre = "Elevacion de talones"},
                new Ejercicio { Nombre = "Extension de gemelos sentado"}
            };

            EjerciciosSeleccionados = new ObservableCollection<Ejercicio>();
            ComandoAgregarEjercicios = new RelayCommand(AgregarEjercicios);

            DataContext = this;
        }

        private void AgregarEjercicios(object parameter)
        {
            if (parameter is Ejercicio exercise && !EjerciciosSeleccionados.Contains(exercise))
            {
                EjerciciosSeleccionados.Add(exercise);
            }
        }

        private void BtnImprimirRutina_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            //muestra el cuadro predeterminado 
            if (printDialog.ShowDialog() == true)
            {
                //obtiene visualmente el formulario
                var visual = new DrawingVisual();
                using (var context = visual.RenderOpen())
                {
                    var brush = new VisualBrush(this);
                    context.DrawRectangle(brush, null, new Rect(new Point(0, 0), new Size(this.ActualWidth, this.ActualHeight)));
                }

                //para ajustar tamaño
                double scale = Math.Min(printDialog.PrintableAreaWidth / this.ActualWidth, printDialog.PrintableAreaHeight / this.ActualHeight);
                visual.Transform = new ScaleTransform(scale, scale);

                // Imprimir el contenido visual ajustado
                printDialog.PrintVisual(visual, "Rutina Personalizada.");
            }
        }
    }

    public class Ejercicio
    {
        public string Nombre { get; set; }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Predicate<object> canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
