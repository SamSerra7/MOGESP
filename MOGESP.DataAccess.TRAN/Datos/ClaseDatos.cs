using MOGESP.Entities.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MOGESP.DataAccess.TRAN.Datos
{
    /// <summary>
    /// Clase que administra el catálogo sobre la clase
    /// </summary>
    public class ClaseDatos
    {//variable conexion
        private ConexionDatos conexion = new ConexionDatos();


        /// <summary>
        /// Autores: Samuel y Valeria
        /// 10/10/19
        /// Este método retorna una lista con todos los elementos del catalogo
        /// </summary>
        /// <returns>List<Clase></returns>
        /// 
        public List<Clase> ConsultarClases()
        {

            List<Clase> clases = new List<Clase>();

            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_ConsultarClase ", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            Clase clase;

            while (reader.Read())
            {

                clase = new Clase();

                clase.IdClase = Convert.ToInt32(reader["TN_IdClase"].ToString());
                clase.Nombre = reader["TC_Nombre"].ToString();

                clases.Add(clase);
            }

            sqlConnection.Close();
            return clases;
        }

        /// <summary>
        /// Autores: Samuel y Valeria
        /// 10/10/19
        /// Este método ingresa una nueva clase
        /// </summary>
        public void insertarClase(string nombre)
        {
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand insertarClase = new SqlCommand(@"EXEC PA_InsertarClase (@TC_Nombre = @Nombre)", sqlConnection);

            insertarClase.Parameters.AddWithValue("@Nombre", nombre);


            sqlConnection.Open();
            insertarClase.ExecuteReader();
            sqlConnection.Close();
        }



        /// <summary>
        /// Autores: Samuel y Valeria
        /// 10/10/19
        /// Este método modifica un tipo de clase
        /// </summary>
        public void modificarClase(int id, string nombre)
        {
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand modificarClase = new SqlCommand(@"EXEC PA_ModificarClase @TN_IdClase = @Id, @TC_Nombre = @Nombre", sqlConnection);

            modificarClase.Parameters.AddWithValue("@Id", id);
            modificarClase.Parameters.AddWithValue("@Nombre", nombre);

            sqlConnection.Open();
            modificarClase.ExecuteReader();
            sqlConnection.Close();
        }



        /// <summary>
        /// Autores: Samuel y Valeria
        /// 10/10/19
        /// Este método elimina una clase
        /// </summary>
        public void eliminarClase(int id)
        {
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand eliminarClase = new SqlCommand(@"EXEC PA_EliminarClase @TN_IdClase = @Id", sqlConnection);

            eliminarClase.Parameters.AddWithValue("@Id", id);

            sqlConnection.Open();
            eliminarClase.ExecuteReader();
            sqlConnection.Close();
        }
    }
}