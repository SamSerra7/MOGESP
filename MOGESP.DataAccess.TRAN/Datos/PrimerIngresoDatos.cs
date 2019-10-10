using Modelo.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MOGESP.DataAccess.TRAN.Datos
{
    /// <summary>
    /// Clase que administra los primeros ingresos
    /// </summary>
    public class PrimerIngresoDatos
    {
        //variable conexion
        private ConexionDatos conexion = new ConexionDatos();

        //variables
        private CorreoDatos correoDatos = new CorreoDatos();
        private TelefonoDatos telefonoDatos = new TelefonoDatos();

        /// <summary>
        /// Autores: Samuel y Valeria
        /// 9/10/19
        /// Este método retorna una lista con todos los primeros ingresos.
        /// </summary>
        /// <returns>List<PrimerIngreso></returns>
        public List<PrimerIngreso> getAllPrimerosIngresos()
        {

            List<PrimerIngreso> primerosIngresos = new List<PrimerIngreso>();

            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_ConsultarPrimerosIngresos", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            PrimerIngreso primerIngreso;

            while (reader.Read())
            {
                primerIngreso = new PrimerIngreso();

                primerIngreso.Cedula = reader["TC_NumeroCedula"].ToString();
                primerIngreso.Nombre = reader["TC_Nombre"].ToString();
                primerIngreso.PrimerApellido = reader["TC_PrimerApellido"].ToString();
                primerIngreso.SegundoApellido = reader["TC_SegundoApellido"].ToString();
                primerIngreso.Sexo = Convert.ToChar(reader["TC_Sexo"].ToString());
                primerIngreso.Direccion = reader["TC_Direccion"].ToString();
                primerIngreso.NumeroConvocatoria = reader["TC_NumeroConvocatoria"].ToString();
                primerIngreso.NumeroFlujo = Convert.ToInt32(reader["TN_NumeroFlujo"].ToString());

                primerIngreso.Correos = correoDatos.CosultarCorreosPorPrimerIngreso(primerIngreso.Cedula);
                primerIngreso.Telefonos = telefonoDatos.CosultarTelefonosPorPrimerIngreso(primerIngreso.Cedula);


                primerosIngresos.Add(primerIngreso);
            }

            sqlConnection.Close();

            return primerosIngresos;
        }


    }
}
