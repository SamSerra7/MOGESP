using MOGESP.DataAccess.TRAN.Datos;
using MOGESP.Entities.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOGESP.ServiceLayer.Servicio
{
	/// <summary>
	/// Clase que gestiona las reglas de negocio de los primeros ingresos elegibles
	/// </summary>
	public class PrimerIngresoElegiblesServicio
	{
		readonly PrimerIngresoElegibleDatos primerIngresoElegibleDatos = new PrimerIngresoElegibleDatos();

		/// <summary>
		/// Jesús Torres
		/// 10/nov/2019
		/// Efecto: enlaza la capa de datos con la capa de controladores de Base de Primeros Ingresos
		/// Requiere: Condicion de puesto, indica que condicion de puesto desea consultar
		/// Modifica: 
		/// <returns>IEnumerable<PrimerIngresoElegibles></returns>
		/// </summary>
		public IEnumerable<PrimerIngresoElegible> getAllPrimerosIngresosElegibles(int condicionPuesto)
		{
			return primerIngresoElegibleDatos.getAllPrimerosIngresosElegibles(condicionPuesto) ?? throw new Exception("No hay registros de primer ingreso elegibles");
		}
	}
}
