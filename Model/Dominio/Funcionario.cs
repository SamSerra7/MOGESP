using System;
using System.Collections.Generic;
using System.Text;

namespace MOGESP.Entities.Dominio
{
    public class Funcionario : Persona
    {

        public Funcionario()
        {

        }
        
        public Funcionario(string cedula, string nombre, string primerApellido, string segundoApellido, char sexo, List<string> correos, List<String> telefonos, string direccion)
                                : base(cedula, nombre, primerApellido, segundoApellido, sexo, correos, telefonos, direccion)
        {

        }

		public List<Concurso> concursos { get; set; }

	}
}
