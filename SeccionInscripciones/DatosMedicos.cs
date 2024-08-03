using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace GymApp
{
    internal class DatosMedicos
    {
        //Primera fila
        public int clienteID { get; set; }
        public string lesionOsea{ get; set; }
        public string lesionMuscular{ get; set; }
        public string enfermedadCardiovascular{ get; set; }
        public string afixia { get; set; }
        public string asmatico { get; set; }
        public string diabetico { get; set; }
        public string epileptico { get; set; }
        public string fumador { get; set; }
        
        //Segunda fila
        public string mareos { get; set; }
        public string desmayos { get; set; }
        public string respirar { get; set; }
        public string nauseas { get; set; }
        public string anemia { get; set; }
        public string embarazada { get; set; }

        public DatosMedicos()
        {
            this.clienteID = clienteID;
            this.lesionOsea = lesionOsea;
            this.lesionMuscular = lesionMuscular;
            this.enfermedadCardiovascular = enfermedadCardiovascular;
            this.afixia = afixia;
            this.asmatico = asmatico;
            this.diabetico = diabetico;
            this.epileptico = epileptico;
            this.fumador = fumador;
            this.mareos = mareos;
            this.desmayos = desmayos;
            this.respirar = respirar;
            this.nauseas = nauseas;
            this.anemia = anemia;
            this.embarazada = embarazada;
        }
    }
}
