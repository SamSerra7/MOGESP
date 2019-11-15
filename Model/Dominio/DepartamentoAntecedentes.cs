using System;
using System.Collections.Generic;
using System.Text;

namespace MOGESP.Entities.Dominio
{
    public class DepartamentoAntecedentes : Departamento
    {

       
        private DateTime fechaResultado;
        public DateTime FechaResultado
        {
            get { return fechaResultado; }
            set
            {
                if (value == null) throw new Exception("El campo de fechaResultado es requerido");
                fechaResultado = value;
            }
        }

        private int zonaTrabajo;

        public int ZonaTrabajo
        {
            get { return zonaTrabajo; }
            set
            {
                if (value < 0) throw new Exception("El campo de zonaTrabajo es requerido");
                zonaTrabajo = value;
            }
        }

    }



}
