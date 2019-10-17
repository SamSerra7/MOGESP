using MOGESP.Entities.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MOGESP.DataAccess.TRAN.Datos
{
    /// <summary>
    /// Clase que administra el catálogo sobre la asistencia
    /// </summary>
    public class AsistenciaDatos
    {//variable conexion
        private readonly ConexionDatos conexion = new ConexionDatos();


        /// <summary>
        /// Autores: Samuel y Valeria
        /// 10/10/19
        /// Este método retorna una lista con todos los elementos del catálogo
        /// </summary>
        /// <returns>List<Asistencia></returns>
        /// 
        public List<Asistencia> ConsultarAsistencia()
        {

            List<Asistencia> asistencias = new List<Asistencia>();

            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_ConsultarAsistencia ", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            Asistencia asistencia;

            while (reader.Read())
            {

                asistencia = new Asistencia();

                asistencia.IdAsistencia= Convert.ToInt32(reader["TN_IdAsistencia"].ToString());
                asistencia.Nombre = reader["TC_Nombre"].ToString();

                asistencias.Add(asistencia);
            }

            sqlConnection.Close();
            sqlCommand.Dispose();
            return asistencias;
        }

        /// <summary>
        /// Autores: Samuel y Valeria
        /// 10/10/19
        /// Este método ingresa una nueva opcion al catálogo
        /// </summary>
        public void insertarAsistencia(string nombre)
        {
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand insertarAsistencia = new SqlCommand(@"EXEC PA_InsertarAsistencia (@TC_Nombre = @Nombre)", sqlConnection);

            insertarAsistencia.Parameters.AddWithValue("@Nombre", nombre);


            sqlConnection.Open();
            insertarAsistencia.ExecuteReader();
            sqlConnection.Close();
        }



        /// <summary>
        /// Autores: Samuel y Valeria
        /// 10/10/19
        /// Este método modifica un tipo de asistencia
        /// </summary>
        public void modificarAsistencia(int id, string nombre)
        {
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand modificarAsistencia = new SqlCommand(@"EXEC PA_ModificarAsistencia @TN_IdAsistencia = @Id, @TC_Nombre = @Nombre", sqlConnection);

            modificarAsistencia.Parameters.AddWithValue("@Id", id);
            modificarAsistencia.Parameters.AddWithValue("@Nombre", nombre);

            sqlConnection.Open();
            modificarAsistencia.ExecuteReader();
            sqlConnection.Close();
        }



        /// <summary>
        /// Autores: Samuel y Valeria
        /// 10/10/19
        /// Este método elimina una opcion en el catálogo
        /// </summary>
        public void eliminarAsistencia(int id)
        {
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand eliminarAsistencia = new SqlCommand(@"EXEC PA_EliminarAsistencia @TN_IdAsistencia = @Id", sqlConnection);

            eliminarAsistencia.Parameters.AddWithValue("@Id", id);

            sqlConnection.Open();
            eliminarAsistencia.ExecuteReader();
            sqlConnection.Close();
        }
    }
}