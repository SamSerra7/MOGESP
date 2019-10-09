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

        private string numeroConvocatoria;

        public string NumeroConvocatoria
        {
            get { return numeroConvocatoria; }
            set {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) throw new Exception("El número de convocatoria es requerido");
                numeroConvocatoria = value; }
        }


        public Flujo Flujo { get; set; }


        public List<EvaluacionPuesto> EvaluacionesPuestos { get; set; }
        

    }
}