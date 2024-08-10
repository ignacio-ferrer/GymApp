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
        private int clienteID;
        private string lesionOsea;
        private string lesionMuscular;
        private string enfermedadCardiovascular;
        private string afixia;
        private string asmatico;
        private string diabetico;
        private string epileptico;
        private string fumador;
        private string mareos;
        private string desmayos;
        private string respirar;
        private string nauseas;
        private string anemia;
        private string embarazada;

        public int ClienteID
        {
            get { return clienteID; }
            set { clienteID = value; }
        }

        public string LesionOsea
        {
            get { return lesionOsea; }
            set { lesionOsea = value; }
        }

        public string LesionMuscular
        {
            get { return lesionMuscular; }
            set { lesionMuscular = value; }
        }

        public string EnfermedadCardiovascular
        {
            get { return enfermedadCardiovascular; }
            set { enfermedadCardiovascular = value; }
        }

        public string Afixia
        {
            get { return afixia; }
            set { afixia = value; }
        }

        public string Asmatico
        {
            get { return asmatico; }
            set { asmatico = value; }
        }

        public string Diabetico
        {
            get { return diabetico; }
            set { diabetico = value; }
        }

        public string Epileptico
        {
            get { return epileptico; }
            set { epileptico = value; }
        }

        public string Fumador
        {
            get { return fumador; }
            set { fumador = value; }
        }

        public string Mareos
        {
            get { return mareos; }
            set { mareos = value; }
        }

        public string Desmayos
        {
            get { return desmayos; }
            set { desmayos = value; }
        }

        public string Respirar
        {
            get { return respirar; }
            set { respirar = value; }
        }

        public string Nauseas
        {
            get { return nauseas; }
            set { nauseas = value; }
        }

        public string Anemia
        {
            get { return anemia; }
            set { anemia = value; }
        }

        public string Embarazada
        {
            get { return embarazada; }
            set { embarazada = value; }
        }

        public DatosMedicos()
        {
            this.clienteID = ClienteID;
            this.lesionOsea = LesionOsea;
            this.lesionMuscular = LesionMuscular;
            this.enfermedadCardiovascular = EnfermedadCardiovascular;
            this.afixia = Afixia;
            this.asmatico = Asmatico;
            this.diabetico = Diabetico;
            this.epileptico = Epileptico;
            this.fumador = Fumador;
            this.mareos = Mareos;
            this.desmayos = Desmayos;
            this.respirar = Respirar;
            this.nauseas = Nauseas;
            this.anemia = Anemia;
            this.embarazada = Embarazada;
        }
    }
}
