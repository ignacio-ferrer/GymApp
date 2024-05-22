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
        public ObservableCollection<Ejercicio> EjerciciosDisponibles { get; set; }
        public ObservableCollection<Ejercicio> EjerciciosSeleccionados { get; set; }
        public ICommand ComandoAgregarEjercicios { get; set; }

        public Rutinas()
        {
            InitializeComponent();

            EjerciciosDisponibles = new ObservableCollection<Ejercicio>
            {
                new Ejercicio { Name = "Pendular circular - Codman" },
                new Ejercicio { Name = "Almeja o abducción de cadera con mini banda" },
                new Ejercicio { Name = "Equilibrio a una pierna sobre tabla de equilibrio" },
                new Ejercicio { Name = "Puente de glúteos con mini banda elástica" }
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
    }

    public class Ejercicio
    {
        public string Name { get; set; }
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
