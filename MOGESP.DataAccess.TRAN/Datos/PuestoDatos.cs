using MOGESP.Entities.Dominio;
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
		/// Jesús Torres
		/// 24/oct/2019
		/// Efecto: Este método retorna una lista con todos los Puestos
		/// Requiere: La cedula a consultar y la condicion de los puestos que se desean consultar
		/// Modifica: 
		/// <returns>IEnumerable<PrimerIngresoElegibles></returns>
		/// </summary>
		public IEnumerable<Puesto> CosultarPuestos(string cedula, int condicionPuesto)
		{

			List<Puesto> puestos = new List<Puesto>();

			SqlConnection sqlConnection = conexion.conexion();

			SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_PrimerIngresoPuestoAplicaCed @Cedula, @condicion", sqlConnection);
			sqlCommand.Parameters.AddWithValue("@Cedula", cedula);
			sqlCommand.Parameters.AddWithValue("@condicion", condicionPuesto);
			SqlDataReader reader;
			sqlConnection.Open();
			reader = sqlCommand.ExecuteReader();

			Puesto puesto; 

			while (reader.Read())
			{
				puesto =  new Puesto();
				puesto.Nombre = reader["TC_NombreClasePuesto"].ToString();
				puesto.IdPuesto = Convert.ToInt32(reader["TN_IdPuesto"].ToString());
				puesto.Condicion = reader["Condicion"].ToString();
				puestos.Add(puesto);
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
