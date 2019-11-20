using System;
using System.Collections.Generic;
using System.Text;

namespace MOGESP.Entities.Dominio
{
	public class Concurso
	{

		public Concurso()
		{
		}

		private int idconcurso;
		public int idConcurso
		{
			get
			{
				return idconcurso;
			}
			set
			{
				if (value > 0) throw new Exception("El id del concurso debe ser positivo");
				idconcurso = value;
			}
		}

		private string nombreConcurso;
		public string NombreConcurso
		{
			get { return nombreConcurso; }
			set
			{
				nombreConcurso = value ?? throw new Exception("El campo de nombreConcurso es requerido");
			}
		}

		private DateTime fechaConcurso;
		public DateTime FechaConcurso
		{
			get { return fechaConcurso; }
			set
			{
				if (value == null) throw new Exception("La fecha del concurso no debe de ser nula");
				fechaConcurso = value;
			}
		}

		private Puesto puesto;
		public Puesto Puesto
		{
			get { return puesto; }
			set { puesto = value ?? throw new Exception("El puesto debe existir"); }
		}

	}
}
