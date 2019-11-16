using MOGESP.Entities.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MOGESP.DataAccess.TRAN.Datos
{
	/// <summary>
	/// Clase que administra los primeros ingresos que son elegibles
	/// </summary>
	public class PrimerIngresoElegibleDatos
	{

		//variable conexion a base de datos
		private ConexionDatos conexion = new ConexionDatos();

		//variables para consulta
		private CorreoDatos correoDatos = new CorreoDatos();
		private TelefonoDatos telefonoDatos = new TelefonoDatos();
		private PuestoDatos puestoDatos = new PuestoDatos();


		/// <summary>
		/// Jesús Torres
		/// 10/nov/2019
		/// Efecto: Este método retorna una lista con todos los primeros ingresos elegibles.
		/// Requiere: condicion de puestos que indica que condicion de puesto desea consultar
		/// Modifica: 
		/// <returns>IEnumerable<PrimerIngresoElegibles></returns>
		/// </summary>
		public IEnumerable<PrimerIngresoElegible> getAllPrimerosIngresosElegibles(int condicionPuesto)
		{
			List<PrimerIngresoElegible> primerosIngresosElegibles = new List<PrimerIngresoElegible>();

			SqlConnection sqlConnection = conexion.conexion();

			SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_ConsultarPrimerosIngresosPorCondicion @condicion", sqlConnection);
			sqlCommand.Parameters.AddWithValue("@condicion", condicionPuesto);
			SqlDataReader reader;
			sqlConnection.Open();
			reader = sqlCommand.ExecuteReader();

			PrimerIngresoElegible primerIngresoElegible;

			while (reader.Read())
			{
				primerIngresoElegible = new PrimerIngresoElegible();

				primerIngresoElegible.Cedula = reader["TC_NumeroCedula"].ToString();
				primerIngresoElegible.Nombre = reader["TC_Nombre"].ToString();
				primerIngresoElegible.PrimerApellido = reader["TC_PrimerApellido"].ToString();
				primerIngresoElegible.SegundoApellido = reader["TC_SegundoApellido"].ToString();
				primerIngresoElegible.Sexo = Convert.ToChar(reader["TC_Sexo"].ToString());
				primerIngresoElegible.Direccion = reader["TC_Direccion"].ToString();
				primerIngresoElegible.FechaIngreso = Convert.ToDateTime(reader["TF_FechaIngreso"].ToString());
				primerIngresoElegible.Correos = correoDatos.CosultarCorreosPorPrimerIngreso(primerIngresoElegible.Cedula);
				primerIngresoElegible.Telefonos = telefonoDatos.CosultarTelefonosPorPrimerIngreso(primerIngresoElegible.Cedula);
				primerIngresoElegible.PuestosElegibles = puestoDatos.CosultarPuestos(primerIngresoElegible.Cedula, condicionPuesto);

				primerosIngresosElegibles.Add(primerIngresoElegible);
			}

			sqlConnection.Close();

			return primerosIngresosElegibles;
		}
	}
}
