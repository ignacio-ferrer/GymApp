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
            connectionString = ConfigurationManager.ConnectionStrings["AppGymDB"].ConnectionString;
        }

        public List <DatosPersonales> ObtenerClientes()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "SELECT ClienteId, nombre, apellido, edad, dni, sexo, fechaNacimiento, direccion, localidad, codigoPostal, grupoSanguineo , telefono, telefonoEmergencia, correo, fechaInscripcion , metodoDePago , valorDeCuota FROM Cliente";
                return connection.Query<DatosPersonales>(sql).ToList();
            }
        }

        public void AgregarCliente(DatosPersonales datosPersonales)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("AgregarAlCliente", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@nombre", datosPersonales.nombre);
                command.Parameters.AddWithValue("@apellido", datosPersonales.apellido);
                command.Parameters.AddWithValue("@edad", datosPersonales.edad);
                command.Parameters.AddWithValue("@dni", datosPersonales.dni);
                command.Parameters.AddWithValue("@sexo", datosPersonales.sexo);
                command.Parameters.AddWithValue("@fechaNacimiento", datosPersonales.fechaNacimiento);
                command.Parameters.AddWithValue("@direccion", datosPersonales.direccion);
                command.Parameters.AddWithValue("@localidad", datosPersonales.localidad);
                command.Parameters.AddWithValue("@codigoPostal", datosPersonales.codigoPostal);
                command.Parameters.AddWithValue("@grupoSanguineo", datosPersonales.grupoSanguineo);
                command.Parameters.AddWithValue("@telefono", datosPersonales.telefono);
                command.Parameters.AddWithValue("@telefonoEmergencia", datosPersonales.telefonoEmergencia);
                command.Parameters.AddWithValue("@correo", datosPersonales.correo);
                command.Parameters.AddWithValue("@fechaInscripcion", datosPersonales.fechaInscripcion);
                command.Parameters.AddWithValue("@metodoDePago", datosPersonales.metodoDePago);
                command.Parameters.AddWithValue("@valorDeCuota", datosPersonales.valorDeCuota);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void EditarUsuario(DatosPersonales cliente)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "EXEC EditarAlCliente @ClienteId, @nombre, @apellido, @edad, @dni, @sexo, @fechaNacimiento, @direccion, @localidad, @codigoPostal, @grupoSanguineo, @telefono, @telefonoEmergencia, @correo, @fechaInscripcion, @metodoDePago, @valorDeCuota";

                var parameters = new
                {
                    ClienteId = datosPersonales.ClienteId,
                    nombre = datosPersonales.nombre,
                    apellido = datosPersonales.apellido,
                    edad = datosPersonales.edad,
                    dni = datosPersonales.dni,
                    sexo = datosPersonales.sexo,
                    fechaNacimiento =datosPersonales.fechaNacimiento,
                    direccion = datosPersonales.direccion,
                    localidad = datosPersonales.localidad,
                    codigoPostal = datosPersonales.codigoPostal,
                    grupoSanguineo = datosPersonales.grupoSanguineo,
                    telefono = datosPersonales.telefono,
                    telefonoEmergencia = datosPersonales.telefonoEmergencia,
                    correo = datosPersonales.correo,
                    fechaInscripcion = datosPersonales.fechaInscripcion,
                    metodoDePago = datosPersonales.metodoDePago,
                    valorDeCuota = datosPersonales.valorDeCuota
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
                var sql = "DELETE FROM Cliente WHERE ClienteId = @ClienteId";
                connection.Execute(sql, new { ClienteId = clienteId });
            }
        }
    }
}
