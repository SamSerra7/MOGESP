using MOGESP.DataAccess.TRAN.Datos;
using MOGESP.Entities.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOGESP.ServiceLayer.Servicio
{
	public class ConcursoServicio
	{

		readonly ConcursoDatos concursoDatos = new ConcursoDatos();


		/// <summary>
		/// Jesus Torres
		/// 19/nov/2019
		/// Método que retorna todos los Concursos que opta un fncionario
		/// </summary>
		/// <returns>IEnumerable<Funcionario></returns>
		public IEnumerable<Concurso> ListarConcursosPorFuncionario(string cedula)
		{
			return concursoDatos.ListarConcursosPorFuncionario(cedula) ?? throw new Exception("No hay registros de funcionarios");
		}

		/// <summary>
		/// Jesus Torres
		/// 19/nov/2019
		/// Método que retorna todos los Concursos disponibles
		/// </summary>
		/// <returns>IEnumerable<Funcionario></returns>
		public IEnumerable<Concurso> ListarConcursos()
		{
			return concursoDatos.ListarConcursos() ?? throw new Exception("No hay registros de funcionarios");
		}
		/// <summary>
		/// Jesus Torres
		/// 19/nov/2019
		/// Envia a capa de datos para insertar un concurso
		/// </summary>
		public void insertarConcurso(Concurso concurso)
		{
			concursoDatos.insertarConcurso(concurso);
		}
	}
}
