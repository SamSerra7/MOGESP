using MOGESP.Entities.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MOGESP.DataAccess.TRAN.Datos
{
    /// <summary>
    /// Clase que administra el catálogo sobre los test de tipo "Otros"
    /// </summary>
    public class TestOtrosDatos
    {//variable conexion
        private ConexionDatos conexion = new ConexionDatos();


        /// <summary>
        /// Autores: Samuel y Valeria
        /// 10/10/19
        /// Este método retorna una lista con todos los elementos del catalogo
        /// </summary>
        /// <returns>List<TestOtros></returns>
        /// 
        public List<TestOtros> ConsultarTestOtros()
        {

            List<TestOtros> tests = new List<TestOtros>();

            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_ConsTestOtros ", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            TestOtros test;

            while (reader.Read())
            {

                test = new TestOtros();

                test.Id = Convert.ToInt32(reader["TN_IdTestOtros"].ToString());
                test.Nombre = reader["TC_Nombre"].ToString();

                tests.Add(test);
            }

            sqlConnection.Close();
            return tests;
        }

        /// <summary>
        /// Autores: Samuel y Valeria
        /// 10/10/19
        /// Este método ingresa un nuevo tipo de test de tipo "otros"
        /// </summary>
        public void insertarTestOtros(string nombre)
        {
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand insertarTest = new SqlCommand(@"EXEC PA_InsertarTestOtros (@TC_Nombre = @Nombre)", sqlConnection);

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
        public void modificarTestOtros(int id, string nombre)
        {
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand modificarTest = new SqlCommand(@"EXEC PA_ModificarTestOtros @TN_IdTestOtros = @Id, @TC_Nombre = @Nombre", sqlConnection);

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
        public void eliminarTestOtros(int id)
        {
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand eliminarTest = new SqlCommand(@"EXEC PA_EliminarTestOtros @TN_IdTestOtros = @Id", sqlConnection);

            eliminarTest.Parameters.AddWithValue("@Id", id);

            sqlConnection.Open();
            eliminarTest.ExecuteReader();
            sqlConnection.Close();
        }
    }
}