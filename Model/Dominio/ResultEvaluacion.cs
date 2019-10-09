using System;

namespace Modelo.Dominio
{
    public class ResultEvaluacion
    {

        private int idResultEvaluacion;
        public int IdResultEvaluacion
        {
            get
            {
                return idResultEvaluacion;
            }
            set
            {
                if (value > 0) throw new Exception("El id debe ser positivo");
                idResultEvaluacion = value;
            }
        }

        private string nombre;



        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) throw new Exception("El nombre es requerido");
                nombre = value;
            }
        }



    }
}