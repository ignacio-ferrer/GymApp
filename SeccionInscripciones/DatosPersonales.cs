﻿using System;
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
        public int ClienteId { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int edad { get; set; }
        public int dni { get; set; }
        public string sexo { get; set; }
        public DateTime? fechaNacimiento { get; set; } = DateTime.MinValue;
        public string direccion { get; set; }
        public string localidad { get; set; }
        public int codigoPostal { get; set; }
        public string grupoSanguineo { get; set; }
        public int telefono { get; set; }
        public int telefonoEmergencia { get; set; }
        public string correo { get; set; }
        public DateTime? fechaInscripcion { get; set; } = DateTime.MinValue;
        public string metodoDePago { get; set; }
        public int valorDeCuota { get; set; }

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
