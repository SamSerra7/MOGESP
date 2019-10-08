using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Dominio
{
    public class PrimerIngreso : Persona
    {
        public PrimerIngreso(string cedula, string nombre, string primerApellido, string segundoApellido, List<string> correos, List<int> telefonos, string direccion) 
                                :base(cedula, nombre, primerApellido, segundoApellido, correos, telefonos, direccion)
        {   
           
        }

        private Flujo flujo;

        public Flujo Flujo
        {
            get { return flujo; }
            set { flujo = value; }
        }
       
        




    }
}
