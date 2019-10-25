using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MOGESP.DataAccess.TRAN.Datos
{
	/// <summary>
	/// Autor: Jesus Torres R
	/// 24/oct/2019
	/// Clase que administra los Puestos que pueden ser ocupados en BD
	/// </summary>
	public class PuestoDatos
	{
		//variable conexion
		private ConexionDatos conexion = new ConexionDatos();


		/// <summary>
		/// Autor: Jesus Torres
		/// 24/oct/2019
		/// Este método retorna una lista con todos los Puestos
		/// </summary>
		/// <returns>List<string></returns>
		public List<string> cosultarPuestos()
		{

			List<string> puestos = new List<string>();

			SqlConnection sqlConnection = conexion.conexion();

			SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_ConsultarPuesto ", sqlConnection);

			SqlDataReader reader;
			sqlConnection.Open();
			reader = sqlCommand.ExecuteReader();

			while (reader.Read())
			{
				puestos.Add(reader["TC_NombreClasePuesto"].ToString());
			}

			sqlConnection.Close();

			return puestos;
		}

		/// <summary>
		/// Autor: Jesus Torres 
		/// 24/oct/2019
		/// Este método ingresa un nuevo puesto a ofrecer
		/// </summary>
		public void insertarPuesto(int idClasePuesto, string nombrePuesto)
		{
			SqlConnection sqlConnection = conexion.conexion();

			SqlCommand insertarPuesto = new SqlCommand(@"EXEC PA_InsertarPuesto @idClasePuesto,  @nombrePuesto", sqlConnection);

			insertarPuesto.Parameters.AddWithValue("@idClasePuesto ", idClasePuesto);
			insertarPuesto.Parameters.AddWithValue("@nombrePuesto", nombrePuesto);


			sqlConnection.Open();
			insertarPuesto.ExecuteReader();
			sqlConnection.Close();

		}


		/// <summary>
		/// Autor: Jesus Torres 
		/// 24/oct/2019
		/// Este método actualiza un puesto 
		/// </summary>
		public void actualizarPuesto(int idClasePuesto, string nombrePuesto)
		{
			SqlConnection sqlConnection = conexion.conexion();

			SqlCommand actualizarPuesto = new SqlCommand(@"EXEC PA_ActualizarPuesto @idClasePuesto,  @nombrePuesto", sqlConnection);

			actualizarPuesto.Parameters.AddWithValue("@idClasePuesto ", idClasePuesto);
			actualizarPuesto.Parameters.AddWithValue("@nombrePuesto", nombrePuesto);


			sqlConnection.Open();
			actualizarPuesto.ExecuteReader();
			sqlConnection.Close();

		}

		/// <summary>
		/// Autor: Jesus Torres 
		/// 24/oct/2019
		/// Este método elimina un puesto 
		/// </summary>
		public void eliminarPuesto(string nombrePuesto)
		{
			SqlConnection sqlConnection = conexion.conexion();

			SqlCommand eliminarPuesto = new SqlCommand(@"EXEC PA_EliminarPuesto  @nombrePuesto", sqlConnection);

			eliminarPuesto.Parameters.AddWithValue("@nombrePuesto", nombrePuesto);


			sqlConnection.Open();
			eliminarPuesto.ExecuteReader();
			sqlConnection.Close();

		}

	}
}
