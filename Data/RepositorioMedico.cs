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

        public RepositorioMedico()
        {
            connectionString = ConfigurationManager.ConnectionStrings["AppGymDB"].ConnectionString;
        }

        public List<DatosMedicos> ObtenerFichaMedica()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "SELECT Id,LesionOsea, LesionMuscular , EnfermedadCardiovascular, Afixia, Asmatico, Diabetico, Epileptico, Fumador, Mareos, Desmayos, Respirar , Nauseas, Anemia, Embarazada FROM FichaMedica";
                return connection.Query<DatosMedicos>(sql).ToList();
            }
        }

        public void AgregarFichaMedica(DatosMedicos datosMedicos)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("AgregarLaFichaMedica", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", datosMedicos.Id);
                command.Parameters.AddWithValue("@LesionOsea", datosMedicos.lesionOsea);
                command.Parameters.AddWithValue("@LesionMuscular", datosMedicos.lesionMuscular);
                command.Parameters.AddWithValue("@EnfermedadCardiovascular", datosMedicos.enfermedadCardiovascular);
                command.Parameters.AddWithValue("@Afixia", datosMedicos.afixia);
                command.Parameters.AddWithValue("@Asmatico", datosMedicos.asmatico);
                command.Parameters.AddWithValue("@Diabetico", datosMedicos.diabetico);
                command.Parameters.AddWithValue("@Epileptico", datosMedicos.epileptico);
                command.Parameters.AddWithValue("@Fumador", datosMedicos.fumador);
                command.Parameters.AddWithValue("@Mareos", datosMedicos.mareos);
                command.Parameters.AddWithValue("@Desmayos", datosMedicos.desmayos);
                command.Parameters.AddWithValue("@Respirar", datosMedicos.respirar);
                command.Parameters.AddWithValue("@Nauseas", datosMedicos.nauseas);
                command.Parameters.AddWithValue("@Anemia", datosMedicos.anemia);
                command.Parameters.AddWithValue("@Embarazada", datosMedicos.embarazada);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void BorrarFichaMedica(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "DELETE FROM FichaMedica WHERE Id = @Id";
                connection.Execute(sql, new { Id = id });
            }
        }
    }
}
