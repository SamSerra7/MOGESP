using MOGESP.Entities.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MOGESP.DataAccess.TRAN.Datos
{
	/// <summary>
	/// Clase que administra los concursos disponibles en BD
	/// </summary>
	public class ConcursoDatos
	{
		//variable conexion
		private ConexionDatos conexion = new ConexionDatos();

		/// <summary>
		/// Autor: Jesus Torres
		/// 19/nov/19
		/// Este método retorna una lista con todos los Concursos que opta un funcionario
		/// </summary>
		/// <returns>List<Funcionario></returns>
		public List<Concurso> ListarConcursosPorFuncionario(string cedula)
		{

			List<Concurso> concursos = new List<Concurso>();

			SqlConnection sqlConnection = conexion.conexion();

			SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_ConsultarConcursosOptaFuncionario @cedula", sqlConnection);
			sqlCommand.Parameters.AddWithValue("@cedula", cedula);

			SqlDataReader reader;
			sqlConnection.Open();
			reader = sqlCommand.ExecuteReader();

			Concurso concurso;

			while (reader.Read())
			{
				concurso = new Concurso();

				concurso.NombreConcurso = reader["TC_NombreConcurso"].ToString();
				concurso.FechaConcurso = Convert.ToDateTime(reader["TF_FechaIngresoConcurso"]).Date;
				Puesto puesto = new Puesto();
				puesto.Nombre = reader["NombrePuesto"].ToString();
				concurso.Puesto = puesto;
				concursos.Add(concurso);
			}

			sqlConnection.Close();

			return concursos;
		}

		/// <summary>
		/// Autor: Jesus Torres
		/// 19/nov/19
		/// Inserta en BD, un nuevo concurso
		/// </summary>
		public void insertarConcurso(Concurso concurso)
		{
			SqlConnection sqlConnection = conexion.conexion();

			SqlCommand insertarConcurso = new SqlCommand(@"EXEC PA_InsertarConcurso @NombreConcurso, @FechaIngresoConcurso, @idPuesto ", sqlConnection);


			insertarConcurso.Parameters.AddWithValue("@NombreConcurso", concurso.NombreConcurso);
			insertarConcurso.Parameters.AddWithValue("@FechaIngresoConcurso", concurso.FechaConcurso);
			insertarConcurso.Parameters.AddWithValue("@idPuesto", concurso.Puesto.IdPuesto);
	

			sqlConnection.Open();
			insertarConcurso.ExecuteReader();
			sqlConnection.Close();
			insertarConcurso.Dispose();
		}


		/// <summary>
		/// Autor: Jesus Torres
		/// 19/nov/19
		/// Este método retorna una lista con todos los Concursos Disponibles.
		/// </summary>
		/// <returns>List<Funcionario></returns>
		public List<Concurso> ListarConcursos()
		{

			List<Concurso> concursos = new List<Concurso>();

			SqlConnection sqlConnection = conexion.conexion();

			SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_ConsultarConcursos", sqlConnection);

			SqlDataReader reader;
			sqlConnection.Open();
			reader = sqlCommand.ExecuteReader();

			Concurso concurso;

			while (reader.Read())
			{
				concurso = new Concurso();

				concurso.NombreConcurso = reader["TC_NombreConcurso"].ToString();
				concurso.FechaConcurso = Convert.ToDateTime(reader["TF_FechaIngresoConcurso"]).Date;
				Puesto puesto = new Puesto();
				puesto.Nombre = reader["TC_NombreClasePuesto"].ToString();
				puesto.IdPuesto = Convert.ToInt32(reader["TN_IdPuesto"]);
				concurso.Puesto = puesto;
				concursos.Add(concurso);
			}

			sqlConnection.Close();

			return concursos;
		}
	}
}
