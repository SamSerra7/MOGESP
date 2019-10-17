using MOGESP.Entities.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MOGESP.DataAccess.TRAN.Datos
{
    /// <summary>
    /// Clase que administra el catálogo sobre los test de Competencia
    /// </summary>
    public class TestCompetenciasDatos
    {//variable conexion
        private ConexionDatos conexion = new ConexionDatos();


        /// <summary>
        /// Autores: Samuel y Valeria
        /// 10/10/19
        /// Este método retorna una lista con todos los elementos del catalogo
        /// </summary>
        /// <returns>List<TestCompetencia></returns>
        /// 
        public List<TestCompetencias> ConsultarTestCompetencias()
        {

            List<TestCompetencias> tests = new List<TestCompetencias>();

            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_ConsultarTestCompetencias ", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            TestCompetencias test;

            while (reader.Read())
            {

                test = new TestCompetencias();

                test.Id = Convert.ToInt32(reader["TN_IdTestCompetencias"].ToString());
                test.Nombre = reader["TC_Nombre"].ToString();

                tests.Add(test);
            }

            sqlConnection.Close();
            return tests;
        }

        /// <summary>
        /// Autores: Samuel y Valeria
        /// 10/10/19
        /// Este método ingresa un nuevo tipo de test de competencias
        /// </summary>
        public void insertarTestCompetencias(string nombre)
        {
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand insertarTest = new SqlCommand(@"EXEC PA_InsertarTestCompetencias (@TC_Nombre = @Nombre)", sqlConnection);

            insertarTest.Parameters.AddWithValue("@Nombre", nombre);


            sqlConnection.Open();
            insertarTest.ExecuteReader();
            sqlConnection.Close();
        }



        /// <summary>
        /// Autores: Samuel y Valeria
        /// 10/10/19
        /// Este método modifica un tipo de test
        /// </summary>
        public void modificarTestCompetencias(int id, string nombre)
        {
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand modificarTest = new SqlCommand(@"EXEC PA_ModificarTestCompetencias @TN_IdTestCompetencias = @Id, @TC_Nombre = @Nombre", sqlConnection);

            modificarTest.Parameters.AddWithValue("@Id", id);
            modificarTest.Parameters.AddWithValue("@Nombre", nombre);

            sqlConnection.Open();
            modificarTest.ExecuteReader();
            sqlConnection.Close();
        }



        /// <summary>
        /// Autores: Samuel y Valeria
        /// 10/10/19
        /// Este método elimina un tipo de test
        /// </summary>
        public void eliminarTestCompetencias(int id)
        {
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand eliminarTest = new SqlCommand(@"EXEC PA_EliminarTestCompetencias @TN_IdTestCompetencias = @Id", sqlConnection);

            eliminarTest.Parameters.AddWithValue("@Id", id);

            sqlConnection.Open();
            eliminarTest.ExecuteReader();
            sqlConnection.Close();
        }
    }
}