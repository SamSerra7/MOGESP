using System;
using System.Collections.Generic;
using System.Text;

namespace MOGESP.Entities.Dominio
{
    public class DepartamentoAntecedentes
    {

        public DepartamentoAntecedentes()
        {
        }

        public DepartamentoAntecedentes(string numeroCedula, DateTime fechaIngresoAdministracion, int cantidadDiasAdministracion, DateTime fechaIngreso, string oficioIngreso, DateTime fechaResultado, int zonaTrabajo, int diasALaFecha, DateTime fechaSalida, int cantidadDiasTotalesTramite, string oficioRespuesta, string estadoResultHojaEnvioGH)
        {
            NumeroCedula = numeroCedula ?? throw new ArgumentNullException(nameof(numeroCedula));
            FechaIngresoAdministracion = fechaIngresoAdministracion;
            CantidadDiasAdministracion = cantidadDiasAdministracion;
            FechaIngreso = fechaIngreso;
            OficioIngreso = oficioIngreso;
            FechaResultado = fechaResultado;
            ZonaTrabajo = zonaTrabajo;
            DiasALaFecha = diasALaFecha;
            FechaSalida = fechaSalida;
            CantidadDiasTotalesTramite = cantidadDiasTotalesTramite;
            OficioRespuesta = oficioRespuesta;
            EstadoResultHojaEnvioGH = estadoResultHojaEnvioGH;
        }

        private string numeroCedula;
        public string NumeroCedula
        {
            get { return numeroCedula; }
            set
            {
                if (value == null || value.Trim().Equals("")) throw new Exception("El campo de numeroCedula es requerido");
                numeroCedula = value;
            }
        }

        private DateTime fechaIngresoAdministracion;
        public DateTime FechaIngresoAdministracion
        {
            get { return fechaIngresoAdministracion; }
            set
            {
                if (value == null) throw new Exception("El campo de fechaIngresoAdministracion es requerido");
                fechaIngresoAdministracion = value;
            }
        }

        private int cantidadDiasAdministracion;
        public int CantidadDiasAdministracion
        {
            get { return cantidadDiasAdministracion; }
            set
            {
                if (value < 0) throw new Exception("El campo de cantidadDiasAdministracion es requerido");
                cantidadDiasAdministracion = value;
            }
        }

        private DateTime fechaIngreso;
        public DateTime FechaIngreso
        {
            get { return fechaIngreso; }
            set
            {
                if (value == null) throw new Exception("El campo de fechaIngreso es requerido");
                fechaIngreso = value;
            }
        }

        private string oficioIngreso;
        public string OficioIngreso
        {
            get { return oficioIngreso; }
            set
            {
                oficioIngreso = value ?? throw new Exception("El campo de oficioIngreso es requerido");
            }
        }

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

        private int diasALaFecha;
        public int DiasALaFecha
        {
            get { return diasALaFecha; }
            set
            {
                if (value < 0) throw new Exception("El campo de diasALaFecha es requerido");
                diasALaFecha = value;
            }
        }

        private DateTime fechaSalida;
        public DateTime FechaSalida
        {
            get { return fechaSalida; }
            set
            {
                if (value == null) throw new Exception("El campo de fechaSalida es requerido");
                fechaSalida = value;
            }
        }

        private int cantidadDiasTotalesTramite;
        public int CantidadDiasTotalesTramite
        {
            get { return cantidadDiasTotalesTramite; }
            set
            {
                if (value < 0) throw new Exception("El campo de cantidadDiasTotalesTramite es requerido");
                cantidadDiasTotalesTramite = value;
            }
        }

        private string oficioRespuesta;
        public string OficioRespuesta
        {
            get { return oficioRespuesta; }
            set
            {
                oficioRespuesta = value ?? throw new Exception("El campo de oficioRespuesta es requerido");
            }
        }

        private string estadoResultHojaEnvioGH;
        public string EstadoResultHojaEnvioGH
        {
            get { return estadoResultHojaEnvioGH; }
            set
            {
                estadoResultHojaEnvioGH = value ?? throw new Exception("El campo de estadoResultHojaEnvioGH es requerido");
            }
        }

    }



}
