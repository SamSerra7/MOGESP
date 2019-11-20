using MOGESP.DataAccess.TRAN.Datos;
using MOGESP.Entities.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOGESP.ServiceLayer.Servicio
{
	public class PuestoServicio
	{
		readonly PuestoDatos puestoDatos = new PuestoDatos();


		/// <summary>
		/// Jesus Torres
		/// 19/nov/2019
		/// Método que retorna todos los Puestos ingresados
		/// </summary>
		/// <returns>IEnumerable<Funcionario></returns>
		public IEnumerable<Puesto> ListarPuestos()
		{
			return puestoDatos.ListarPuestos() ?? throw new Exception("No hay registros de puestos");
		}
	}
}
