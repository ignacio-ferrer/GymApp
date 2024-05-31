using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Configuration;
using System.Windows;

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
                var sql = "SELECT nombre, apellido, edad, dni, sexo, fechaNacimiento, direccion, localidad, codigoPostal, telefono, telefonoEmergencia, correo, fechaInscripcion FROM Cliente";
                var datosPersonales = connection.Query<DatosPersonales>(sql).ToList();
                return connection.Query<DatosPersonales>(sql).ToList();
            }
        }

        public void AgregarCliente(DatosPersonales datosPersonales)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "INSERT INTO Cliente (nombre, apellido , edad, dni, sexo, fechaNacimiento, direccion, localidad, codigoPostal, telefono, telefonoEmergencia, correo, fechaInscripcion) VALUES (@nombre, @apellido , @edad, @dni, @sexo, @fechaNacimiento, @direccion, @localidad, @codigoPostal, @telefono, @telefonoEmergencia, @correo, @fechaInscripcion)";
                connection.Execute(sql, datosPersonales);
            }
        }
    }
}
