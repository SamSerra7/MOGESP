using MOGESP.Entities.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MOGESP.DataAccess.TRAN.Datos
{
    /// <summary>
    /// Clase que administra el catálogo sobre los test Visomotor
    /// </summary>
    public class TestVisomotorDatos
    {//variable conexion
        private ConexionDatos conexion = new ConexionDatos();


        /// <summary>
        /// Autores: Samuel y Valeria
        /// 10/10/19
        /// Este método retorna una lista con todos los elementos del catalogo
        /// </summary>
        /// <returns>List<TestVisomotor></returns>
        /// 
        public List<TestVisomotor> ConsultarTestVisomotor()
        {

            List<TestVisomotor> tests = new List<TestVisomotor>();

            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_ConsultarTestVisomotor ", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            TestVisomotor test;

            while (reader.Read())
            {

                test = new TestVisomotor();

                test.Id = Convert.ToInt32(reader["TN_IdTestVisomotor"].ToString());
                test.Nombre = reader["TC_Nombre"].ToString();

                tests.Add(test);
            }

            sqlConnection.Close();
            return tests;
        }

        /// <summary>
        /// Autores: Samuel y Valeria
        /// 10/10/19
        /// Este método ingresa un nuevo tipo de test visomotor
        /// </summary>
        public void insertarTestVisomotor(string nombre)
        {
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand insertarTest = new SqlCommand(@"EXEC PA_InsertarTestVisomotor (@TC_Nombre = @Nombre)", sqlConnection);

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
        public void modificarTestVisomotor(int id, string nombre)
        {
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand modificarTest = new SqlCommand(@"EXEC PA_ModificarTestVisomotor @TN_IdTestVisomotor = @Id, @TC_Nombre = @Nombre", sqlConnection);

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
        public void eliminarTestVisomotor(int id)
        {
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand eliminarTest = new SqlCommand(@"EXEC PA_EliminarTestVisomotor @TN_IdTestVisomotor = @Id", sqlConnection);

            eliminarTest.Parameters.AddWithValue("@Id", id);

            sqlConnection.Open();
            eliminarTest.ExecuteReader();
            sqlConnection.Close();
        }
    }
}