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
    }
}
