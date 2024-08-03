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

                insertCommand.Parameters.AddWithValue("@IdCliente", datosMedicos.clienteID);
                insertCommand.Parameters.AddWithValue("@LesionOsea", datosMedicos.lesionOsea);
                insertCommand.Parameters.AddWithValue("@LesionMuscular", datosMedicos.lesionMuscular);
                insertCommand.Parameters.AddWithValue("@EnfermedadCardiovascular", datosMedicos.enfermedadCardiovascular);
                insertCommand.Parameters.AddWithValue("@Afixia", datosMedicos.afixia);
                insertCommand.Parameters.AddWithValue("@Asmatico", datosMedicos.asmatico);
                insertCommand.Parameters.AddWithValue("@Diabetico", datosMedicos.diabetico);
                insertCommand.Parameters.AddWithValue("@Epileptico", datosMedicos.epileptico);
                insertCommand.Parameters.AddWithValue("@Fumador", datosMedicos.fumador);
                insertCommand.Parameters.AddWithValue("@Mareos", datosMedicos.mareos);
                insertCommand.Parameters.AddWithValue("@Desmayos", datosMedicos.desmayos);
                insertCommand.Parameters.AddWithValue("@Respirar", datosMedicos.respirar);
                insertCommand.Parameters.AddWithValue("@Nauseas", datosMedicos.nauseas);
                insertCommand.Parameters.AddWithValue("@Anemia", datosMedicos.anemia);
                insertCommand.Parameters.AddWithValue("@Embarazada", datosMedicos.embarazada);

                insertCommand.ExecuteNonQuery();

                var disableIdentityInsertCommand = new SqlCommand("SET IDENTITY_INSERT dbo.ProbandoFichaMedica OFF;", connection);
                disableIdentityInsertCommand.ExecuteNonQuery();
            }
        }

        public void BorrarFichaMedica(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "DELETE FROM ProbandoFichaMedica WHERE Id = @Id";
                connection.Execute(sql, new { Id = id });
            }
        }
    }
}
