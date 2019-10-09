using System;

namespace Modelo.Dominio
{
    public class EvaluacionPuesto
    {




        private Clase clase;
        public Clase Clase
        {
            get { return clase; }
            set { clase = value ?? throw new Exception("El puesto debe tener una clase"); }
        }


        private ResultEvaluacion resultEvaluacion;

        public ResultEvaluacion ResultEvaluacion
        {
            get { return resultEvaluacion; }
            set { resultEvaluacion = value; }
        }



    }
}