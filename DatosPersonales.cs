using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace GymApp
{
    internal class DatosPersonales
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int edad { get; set; }
        public int dni { get; set; }
        public string sexo { get; set; }
        public DateTime? fechaNacimiento { get; set; }
        public string direccion { get; set; }
        public string localidad { get; set; }
        public int codigoPostal { get; set; }
        public int telefono { get; set; }
        public int telefonoEmergencia { get; set; }
        public string correo { get; set; }
        public DateTime? fechaInscripcion { get; set; }

        public DatosPersonales(string nombre = "", string apellido = "", int edad = 0, int dni = 0, string sexo = "", DateTime? fechaNacimiento=null, string direccion = "", string localidad = "", int codigoPostal = 0, int telefono = 0, int telefonoEmergencia = 0, string correo = "", DateTime? fechaInscripcion = null)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.dni = dni;
            this.sexo = sexo;
            this.fechaNacimiento = fechaNacimiento;
            this.direccion = direccion;
            this.localidad = localidad;
            this.codigoPostal = codigoPostal;
            this.telefono = telefono;
            this.telefonoEmergencia = telefonoEmergencia;
            this.correo = correo;
            this.fechaInscripcion = fechaInscripcion;
        }        
    }
}
