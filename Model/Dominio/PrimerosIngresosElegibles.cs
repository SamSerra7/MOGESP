using System;
using System.Collections.Generic;
using System.Text;

namespace MOGESP.Entities.Dominio
{

	/// <summary>
	/// Jesús Torres
	/// 10/nov/2019
	/// Efecto: Clase que conformará todos la base de primeros ingresos que han sifo elegibles 
	/// durante el procesos de seleccion
	/// </summary>
	public class PrimerIngresoElegible : Persona
	{
		private DateTime fechaIngreso;
		public DateTime FechaIngreso
		{
			get
			{
				return fechaIngreso;
			}
			set
			{
				if (value == null) throw new Exception("La fecha debe ser diferente de un valor nulo");
				fechaIngreso = value;
			}
		}

		public IEnumerable<Puesto> PuestosElegibles { get; set; }


	}
}
