using System;
using System.Collections.Generic;
using System.Text;

namespace MOGESP.Entities.Dominio
{
    public class DepartamentoToxicologia : Departamento
    {

        private DateTime fechaCita;
        public DateTime FechaCita
        {
            get { return fechaCita; }
            set
            {
                if (value == null) throw new Exception("El campo de fechaCita es requerido");
                fechaCita = value;
            }
        }

        private int diasParaCita;
        public int DiasParaCita
        {
            get { return diasParaCita; }
            set
            {
                if (value < 0) throw new Exception("El campo de diasParaCita es requerido");
                diasParaCita = value;
            }
        }

        private DateTime fechaEstado;
        public DateTime FechaEstado
        {
            get { return fechaEstado; }
            set
            {
                if (value == null) throw new Exception("El campo de fechaEstado es requerido");
                fechaEstado = value;
            }
        }

        private int fechaEstadoCantDias;
        public int FechaEstadoCantDias
        {
            get { return fechaEstadoCantDias; }
            set
            {
                if (value < 0) throw new Exception("El campo de fechaEstadoCantDias es requerido");
                fechaEstadoCantDias = value;
            }
        }

    }
}
