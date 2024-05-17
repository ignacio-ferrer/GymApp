using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp
{
    internal class DatosMedicos
    {
        //primera fila
        public string  lesionOsea{ get; set; }
        public bool  preguntaUno{ get; set; }
        public string  lesionMuscular{ get; set; }
        public bool preguntaDos { get; set; }
        public string  enfermedadCardio{ get; set; }
        public bool preguntaTres { get; set; }
        public bool preguntaCuatro { get; set; }
        public bool  preguntaAsmatico{ get; set; }
        public bool preguntaDiabetico { get; set; }
        public bool preguntaEpileptico { get; set; }
        public bool preguntaFumador { get; set; }
        

        //Segunda fila
        public bool preguntaMareos { get; set; }
        public bool preguntaDesmayos { get; set; }
        public bool preguntaRespirar { get; set; }
        public bool preguntaNauseas { get; set; }
        public bool preguntaSiete { get; set; }
        public bool preguntaOcho{ get; set; }
        public bool preguntaNueve { get; set; }

        public DatosMedicos(string lesionOsea = "", bool preguntaUno = false, string lesionMuscular = "", bool preguntaDos = false, string enfermedadCardio="", bool preguntaTres = false, bool preguntaCuatro = false, bool preguntaAsmatico = false, bool preguntaDiabetico = false, bool preguntaEpileptico = false, bool preguntaFumador = false, bool preguntaMareos = false, bool preguntaDesmayos = false, bool preguntaRespirar = false, bool preguntaNauseas = false, bool preguntaSiete = false, bool preguntaOcho = false, bool preguntaNueve = false)
        {
            this.lesionOsea = lesionOsea;
            this.preguntaUno = preguntaUno;
            this.lesionMuscular = lesionMuscular;
            this.preguntaDos = preguntaDos;
            this.enfermedadCardio = enfermedadCardio;
            this.preguntaTres = preguntaTres;
            this.preguntaCuatro = preguntaCuatro;
            this.preguntaAsmatico = preguntaAsmatico;
            this.preguntaDiabetico = preguntaDiabetico;
            this.preguntaEpileptico = preguntaEpileptico;
            this.preguntaFumador = preguntaFumador;
            this.preguntaMareos = preguntaMareos;
            this.preguntaDesmayos = preguntaDesmayos;
            this.preguntaRespirar = preguntaRespirar;
            this.preguntaNauseas = preguntaNauseas;
            this.preguntaSiete = preguntaSiete;
            this.preguntaOcho = preguntaOcho;
            this.preguntaNueve = preguntaNueve;
        }
    }
}
