using System;
using System.Collections.Generic;
using System.Text;

namespace MOGESP.Entities.Dominio
{
    public class DepartamentoPruebasMedicas : Departamento
    {

        private DateTime fechaEnvioAPMdeGH;
        public DateTime FechaEnvioAPMdeGH
        {
            get { return fechaEnvioAPMdeGH; }
            set
            {
                if (value == null) throw new Exception("El campo de fechaEnvioAPMdeGH es requerido");
                fechaEnvioAPMdeGH = value;
            }
        }

        private DateTime fechaResultadoOCitaPM;
        public DateTime FechaResultadoOCitaPM
        {
            get { return fechaResultadoOCitaPM; }
            set
            {
                if (value == null) throw new Exception("El campo de fechaResultadoOCitaPM es requerido");
                fechaResultadoOCitaPM = value;
            }
        }

    }

}
