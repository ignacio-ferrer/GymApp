using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Configuration;
using System.Windows;
using System.Data;
using System;
using GymApp.SeccionInscripciones;

namespace GymApp.Data
{
    internal class RepositorioMedico
    {
        private string connectionString;
        DatosMedicos datosMedicos = new DatosMedicos();
        DatosPersonales datosPersonales = new DatosPersonales();

        public RepositorioMedico()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Probando"].ConnectionString;
        }

        public List<DatosMedicos>ObtenerFichaMedica()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "SELECT IdCliente, LesionOsea, LesionMuscular , EnfermedadCardiovascular, Afixia, Asmatico, Diabetico, Epileptico, Fumador, Mareos, Desmayos, Respirar , Nauseas, Anemia, Embarazada FROM ProbandoFichaMedica";
                return connection.Query<DatosMedicos>(sql).ToList();
            }
        }

        public void AgregarFichaMedica(DatosMedicos datosMedicos)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var enableIdentityInsertCommand = new SqlCommand("SET IDENTITY_INSERT dbo.ProbandoFichaMedica ON;", connection);
                enableIdentityInsertCommand.ExecuteNonQuery();

                var insertCommand = new SqlCommand(@"
            INSERT INTO ProbandoFichaMedica (
                IdCliente, LesionOsea, LesionMuscular, EnfermedadCardiovascular, Afixia, 
                Asmatico, Diabetico, Epileptico, Fumador, Mareos, 
                Desmayos, Respirar, Nauseas, Anemia, Embarazada) 
            VALUES (
                @IdCliente, @LesionOsea, @LesionMuscular, @EnfermedadCardiovascular, @Afixia, 
                @Asmatico, @Diabetico, @Epileptico, @Fumador, @Mareos, 
                @Desmayos, @Respirar, @Nauseas, @Anemia, @Embarazada);", connection);

                insertCommand.Parameters.AddWithValue("@IdCliente", datosMedicos.ClienteID);
                insertCommand.Parameters.AddWithValue("@LesionOsea", datosMedicos.LesionOsea);
                insertCommand.Parameters.AddWithValue("@LesionMuscular", datosMedicos.LesionMuscular);
                insertCommand.Parameters.AddWithValue("@EnfermedadCardiovascular", datosMedicos.EnfermedadCardiovascular);
                insertCommand.Parameters.AddWithValue("@Afixia", datosMedicos.Afixia);
                insertCommand.Parameters.AddWithValue("@Asmatico", datosMedicos.Asmatico);
                insertCommand.Parameters.AddWithValue("@Diabetico", datosMedicos.Diabetico);
                insertCommand.Parameters.AddWithValue("@Epileptico", datosMedicos.Epileptico);
                insertCommand.Parameters.AddWithValue("@Fumador", datosMedicos.Fumador);
                insertCommand.Parameters.AddWithValue("@Mareos", datosMedicos.Mareos);
                insertCommand.Parameters.AddWithValue("@Desmayos", datosMedicos.Desmayos);
                insertCommand.Parameters.AddWithValue("@Respirar", datosMedicos.Respirar);
                insertCommand.Parameters.AddWithValue("@Nauseas", datosMedicos.Nauseas);
                insertCommand.Parameters.AddWithValue("@Anemia", datosMedicos.Anemia);
                insertCommand.Parameters.AddWithValue("@Embarazada", datosMedicos.Embarazada);

                insertCommand.ExecuteNonQuery();

                var disableIdentityInsertCommand = new SqlCommand("SET IDENTITY_INSERT dbo.ProbandoFichaMedica OFF;", connection);
                disableIdentityInsertCommand.ExecuteNonQuery();
            }
        }

        public void BorrarFichaMedica(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "DELETE FROM ProbandoFichaMedica WHERE IdCliente = @IdCliente";
                connection.Execute(sql, new { IdCliente = id });
            }
        }
    }
}
