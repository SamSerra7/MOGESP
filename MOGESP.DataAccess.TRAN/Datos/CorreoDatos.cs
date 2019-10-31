using MOGESP.Entities.Dominio;
using System;
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

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_ConsultarCorreosPorPI @Cedula ", sqlConnection);

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


        /// <summary>
        /// Autores: Samuel 
        /// 10/10/19
        /// Este método ingresa un correo para una persona
        /// </summary>
        public void insertarCorreoPorPersona(string cedula, string correo)
        {
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand insertarCorreo = new SqlCommand(@"EXEC PA_InsertarCorreoPI @TC_NumeroCedula = @Cedula, @TC_Correo = @Correo", sqlConnection);

            insertarCorreo.Parameters.AddWithValue("@Cedula", cedula);
            insertarCorreo.Parameters.AddWithValue("@Correo", correo);


            sqlConnection.Open();
            insertarCorreo.ExecuteReader();
            sqlConnection.Close();

        }


        /// <summary>
        /// Autores: Samuel 
        /// 10/10/19
        /// Este método modifica un correo para una persona
        /// </summary>
        public void modificarCorreoPorPersona(string cedula,string correo, string correoMod)
        {
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand modificarCorreo = new SqlCommand(@"EXEC PA_ModificarCorreo @TC_NumeroCedula = @Cedula,@TC_Correo = @Correo, @TC_CorreoModif = @CorreoModif", sqlConnection);

            modificarCorreo.Parameters.AddWithValue("@Cedula", cedula);
            modificarCorreo.Parameters.AddWithValue("@Correo", correo);
            modificarCorreo.Parameters.AddWithValue("@CorreoModif", correoMod);


            sqlConnection.Open();
            modificarCorreo.ExecuteReader();
            sqlConnection.Close();
        }
    }
}
