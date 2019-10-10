﻿using Modelo.Dominio;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MOGESP.DataAccess.TRAN.Datos
{
    /// <summary>
    /// Clase que administra los correos de las personas
    /// </summary>
    public class CorreoDatos
    {
        //variable conexion
        private ConexionDatos conexion = new ConexionDatos();


        /// <summary>
        /// Autores: Samuel y Valeria
        /// 9/10/19
        /// Este método retorna una lista con todos los correos de un primer ingreso
        /// </summary>
        /// <returns>List<string></returns>
        public List<string> CosultarCorreosPorPrimerIngreso(string cedula)
        {

            List<string> correos = new List<string>();

            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_ConsultarCorreosPorPI @NumeroCedula = @Cedula ", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@Cedula", cedula);
            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                correos.Add(reader["TC_Correo"].ToString());
            }

            sqlConnection.Close();

            return correos;
        }


    }
}
