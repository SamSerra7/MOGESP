using MOGESP.Entities.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MOGESP.DataAccess.TRAN.Datos
{
    /// <summary>
    /// Clase que administra los primeros ingresos
    /// </summary>
    public class CuadroGeneralDatos
    {
        //variable conexion
        private ConexionDatos conexion = new ConexionDatos();

        //variables
        private CorreoDatos correoDatos = new CorreoDatos();
        private TelefonoDatos telefonoDatos = new TelefonoDatos();

        /// <summary>
        /// Autores: Manfred
        /// 5/11/19
        /// Este método retorna una lista con todos los numeros de convocatoria.
        /// </summary>
        /// <returns>List<String></returns>
        public List<String> traerNumerosConvocatoria()
        {

            List<String> numerosConvocatoria = new List<String>();

            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_NumerosConvocatoria", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            String numConvocatoria;

            while (reader.Read())
            {

                numConvocatoria = reader["TC_NumeroConvocatoria"].ToString();


                numerosConvocatoria.Add(numConvocatoria);
            }

            sqlConnection.Close();

            return numerosConvocatoria;
        }

        /// <summary>
        /// Autores: Manfred
        /// 5/11/19
        /// Este método retorna una lista con todos los numeros de flujos por convocatoria.
        /// </summary>
        /// <returns>List<int></returns>
        public List<int> traerNumerosDeFlujoPorConvocatoria(String numConvocatoria)
        {

            List<int> numerosFlujo = new List<int>();

            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_NumerosDeFlujoPorConvocatoria @numeroConvocatoria", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@numeroConvocatoria", numConvocatoria);
            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            int numFlujo;

            while (reader.Read())
            {

                numFlujo = Convert.ToInt32(reader["TN_NumeroFlujo"]);


                numerosFlujo.Add(numFlujo);
            }

            sqlConnection.Close();

            return numerosFlujo;
        }






    }
}
