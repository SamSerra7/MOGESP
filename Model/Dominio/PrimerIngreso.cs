using System;
using System.Collections.Generic;
using System.Text;

namespace MOGESP.Entities.Dominio
{
    /// <summary>
    /// Clase que gestiona primer ingreso
    /// </summary>
    public class PrimerIngreso : Persona
    {


        public PrimerIngreso()
        {

        }
       
        public PrimerIngreso(string cedula, string nombre, string primerApellido, string segundoApellido, char sexo, List<string> correos, List<String> telefonos, string direccion, string numeroConvocatoria, int NumeroFlujo) 
                                :base(cedula, nombre, primerApellido, segundoApellido, sexo, correos, telefonos, direccion)
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


        public int NumeroFlujo { get; set; }


        public List<EvaluacionPuesto> EvaluacionesPuestos { get; set; }
        

    }
}