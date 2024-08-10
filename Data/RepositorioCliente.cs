using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Configuration;
using System.Windows;
using System.Data;
using System;

namespace GymApp.Data
{
    internal class RepositorioCliente
    {
        private string connectionString;
        DatosPersonales datosPersonales = new DatosPersonales();

        public RepositorioCliente()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Probando"].ConnectionString;
        }

        public List <DatosPersonales> ObtenerClientes()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "SELECT ClienteID, nombre, apellido, edad, dni, sexo, fechaNacimiento, direccion, localidad, codigoPostal, grupoSanguineo , telefono, telefonoEmergencia, correo, fechaInscripcion , metodoDePago , valorDeCuota FROM ProbandoCliente";
                return connection.Query<DatosPersonales>(sql).ToList();
            }
        }

        public void AgregarCliente(DatosPersonales datosPersonales)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("InsertarCliente", connection); 
                command.CommandType = CommandType.StoredProcedure;
                 
                command.Parameters.AddWithValue("@nombre", datosPersonales.Nombre);
                command.Parameters.AddWithValue("@apellido", datosPersonales.Apellido);
                command.Parameters.AddWithValue("@edad", datosPersonales.Edad);
                command.Parameters.AddWithValue("@dni", datosPersonales.Dni);
                command.Parameters.AddWithValue("@sexo", datosPersonales.Sexo);
                command.Parameters.AddWithValue("@fechaNacimiento", datosPersonales.FechaNacimiento);
                command.Parameters.AddWithValue("@direccion", datosPersonales.Direccion);
                command.Parameters.AddWithValue("@localidad", datosPersonales.Localidad);
                command.Parameters.AddWithValue("@codigoPostal", datosPersonales.CodigoPostal);
                command.Parameters.AddWithValue("@grupoSanguineo", datosPersonales.GrupoSanguineo);
                command.Parameters.AddWithValue("@telefono", datosPersonales.Telefono);
                command.Parameters.AddWithValue("@telefonoEmergencia", datosPersonales.TelefonoEmergencia);
                command.Parameters.AddWithValue("@correo", datosPersonales.Correo);
                command.Parameters.AddWithValue("@fechaInscripcion", datosPersonales.FechaInscripcion);
                command.Parameters.AddWithValue("@metodoDePago", datosPersonales.MetodoDePago);
                command.Parameters.AddWithValue("@valorDeCuota", datosPersonales.ValorDeCuota);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void EditarUsuario(DatosPersonales cliente)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "EXEC EditarAlCliente @ClienteID, @nombre, @apellido, @edad, @dni, @sexo, @fechaNacimiento, @direccion, @localidad, @codigoPostal, @grupoSanguineo, @telefono, @telefonoEmergencia, @correo, @fechaInscripcion, @metodoDePago, @valorDeCuota";

                var parameters = new
                {
                    ClienteId = datosPersonales.ClienteID,
                    nombre = datosPersonales.Nombre,
                    apellido = datosPersonales.Apellido,
                    edad = datosPersonales.Edad,
                    dni = datosPersonales.Dni,
                    sexo = datosPersonales.Sexo,
                    fechaNacimiento =datosPersonales.FechaNacimiento,
                    direccion = datosPersonales.Direccion,
                    localidad = datosPersonales.Localidad,
                    codigoPostal = datosPersonales.CodigoPostal,
                    grupoSanguineo = datosPersonales.GrupoSanguineo,
                    telefono = datosPersonales.Telefono,
                    telefonoEmergencia = datosPersonales.TelefonoEmergencia,
                    correo = datosPersonales.Correo,
                    fechaInscripcion = datosPersonales.FechaInscripcion,
                    metodoDePago = datosPersonales.MetodoDePago,
                    valorDeCuota = datosPersonales.ValorDeCuota
                };

                connection.Execute(sql, parameters);
            }
        }

        private DateTime EnsureValidSqlDateTime(DateTime dateTime)
        {
            if (dateTime < (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                return (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            return dateTime;
        }

        public void BorrarUsuario(int clienteId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "DELETE FROM ProbandoCliente WHERE ClienteID = @ClienteID";
                connection.Execute(sql, new { ClienteId = clienteId });
            }
        }
    }
}
