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
        private int ClienteId; 
        private string nombre; 
        private string apellido;
        private int edad;
        private int dni;
        private string sexo;
        private DateTime? fechaNacimiento = DateTime.MinValue;
        private string direccion;
        private string localidad;
        private int codigoPostal;
        private string grupoSanguineo;
        private int telefono;
        private int telefonoEmergencia;
        private string correo;
        private DateTime? fechaInscripcion = DateTime.MinValue;
        private string metodoDePago;
        private int valorDeCuota;

        public int ClienteID
        {
            get { return ClienteId; }
            set { ClienteId = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }

        public int Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        public DateTime? FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Localidad
        {
            get { return localidad; }
            set { localidad = value; }
        }

        public int CodigoPostal
        {
            get { return codigoPostal; }
            set { codigoPostal = value; }
        }

        public string GrupoSanguineo
        {
            get { return grupoSanguineo; }
            set { grupoSanguineo = value; }
        }

        public int Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public int TelefonoEmergencia
        {
            get { return telefonoEmergencia; }
            set { telefonoEmergencia = value; }
        }

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        public DateTime? FechaInscripcion
        {
            get { return fechaInscripcion; }
            set { fechaInscripcion = value; }
        }

        public string MetodoDePago
        {
            get { return metodoDePago; }
            set { metodoDePago = value; }
        }

        public int ValorDeCuota
        {
            get { return valorDeCuota; }
            set { valorDeCuota = value; }
        }

        public DatosPersonales(int ClienteId = 0, string nombre = "", string apellido = "", int edad = 0, int dni = 0, string sexo = "", DateTime? fechaNacimiento = null, string direccion = "", string localidad = "", int codigoPostal = 0, string grupoSanguineo = "", int telefono = 0, int telefonoEmergencia = 0, string correo = "", DateTime? fechaInscripcion = null, string metodoDePago = "", int valorDeCuota = 0)
        {
            this.ClienteId = ClienteId;
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.dni = dni;
            this.sexo = sexo;
            this.fechaNacimiento = fechaNacimiento ?? DateTime.MinValue;
            this.direccion = direccion;
            this.localidad = localidad;
            this.codigoPostal = codigoPostal;
            this.grupoSanguineo = grupoSanguineo;
            this.telefono = telefono;
            this.telefonoEmergencia = telefonoEmergencia;
            this.correo = correo;
            this.fechaInscripcion = fechaInscripcion ?? DateTime.MinValue;
            this.metodoDePago = metodoDePago;
            this.valorDeCuota = valorDeCuota;
        }        
    }
}
