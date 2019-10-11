using Modelo.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MOGESP.DataAccess.TRAN.Datos
{
    /// <summary>
    /// Clase que administra el catalogo de test de personalidad de los PI
    /// </summary>
    public class TestPersonalidadDatos
    {
        //variable conexion
        private ConexionDatos conexion = new ConexionDatos();


        /// <summary>
        /// Autores: Samuel y Valeria
        /// 10/10/19
        /// Este método retorna una lista con todos los elementos del catalogo
        /// </summary>
        /// <returns>List<int></returns>
        public List<TestPersonalidad> ConsultarTestPersonalidad()
        {

            List<TestPersonalidad> tests = new List<TestPersonalidad>();

            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_ConsultarTestPersonalidad ", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            TestPersonalidad test;

            while (reader.Read())
            {

                test = new TestPersonalidad();

                test.Id = Convert.ToInt32(reader["TN_IdTestPersonalidad"].ToString());
                test.Nombre = reader["TC_Nombre"].ToString();

                tests.Add(test);
            }

            sqlConnection.Close();
            return tests;
        }

        /// <summary>
        /// Autores: Samuel y Valeria
        /// 10/10/19
        /// Este método ingresa un nuevo tipo de test de personalidad
        /// </summary>
        public void insertarTestPersonalidad(string nombre)
        {
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand insertarTest = new SqlCommand(@"EXEC PA_InsertarTestPersonalidad (@TC_Nombre = @Nombre)", sqlConnection);

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
        public void modificarTestPersonalidad(int id,string nombre)
        {
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand modificarTest = new SqlCommand(@"EXEC PA_ModificarTestPersonalidad @TN_IdTestPersonalidad = @Id, @TC_Nombre = @Nombre", sqlConnection);

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
        public void eliminarTestPersonalidad(int id)
        {
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand eliminarTest = new SqlCommand(@"EXEC PA_EliminarTestPersonalidad @TN_IdTestPersonalidad = @Id", sqlConnection);

            eliminarTest.Parameters.AddWithValue("@Id", id);

            sqlConnection.Open();
            eliminarTest.ExecuteReader();
            sqlConnection.Close();
        }

    }
}
