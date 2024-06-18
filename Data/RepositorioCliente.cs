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
                var sql = "SELECT ClienteId, nombre, apellido, edad, dni, sexo, fechaNacimiento, direccion, localidad, codigoPostal, grupoSanguineo , telefono, telefonoEmergencia, correo, fechaInscripcion FROM Cliente";
                return connection.Query<DatosPersonales>(sql).ToList();
            }
        }

        public void AgregarCliente(DatosPersonales datosPersonales)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "INSERT INTO Cliente (nombre, apellido , edad, dni, sexo, fechaNacimiento, direccion, localidad, codigoPostal, grupoSanguineo, telefono, telefonoEmergencia, correo, fechaInscripcion) VALUES (@nombre, @apellido , @edad, @dni, @sexo, @fechaNacimiento, @direccion, @localidad, @codigoPostal, @grupoSanguineo, @telefono, @telefonoEmergencia, @correo, @fechaInscripcion)";
                connection.Execute(sql, datosPersonales);
            }
        }

        public void EditarUsuario(DatosPersonales cliente)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "UPDATE Cliente SET nombre = @nombre, apellido = @apellido, edad = @edad, dni = @dni , fechaNacimiento = @fechaNacimiento , direccion = @direccion , localidad = @localidad , codigoPostal = @codigoPostal , grupoSanguineo = @grupoSanguineo ,telefono = @telefono , telefonoEmergencia = @telefonoEmergencia , correo = @correo , fechaInscripcion = @fechaInscripcion WHERE ClienteId = @ClienteId";
                connection.Execute(sql, cliente);
            }
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
