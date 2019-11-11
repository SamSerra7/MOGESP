using System;
using System.Collections.Generic;
using System.Text;

namespace MOGESP.Entities.Dominio
{
    public class DepartamentoVialidad
    {

        public DepartamentoVialidad()
        {
        }

        public DepartamentoVialidad(string numeroCedula, DateTime fechaIngresoAdministracion, int cantidadDiasAdministracion, DateTime fechaIngresoTransportes, string oficioIngreso, DateTime fechaCita, int diasParaCita, DateTime fechaSalida, int cantidadDiasTotalesTramite, string oficioRespuesta, string estadoResultHojaEnvioGH)
        {
            NumeroCedula = numeroCedula ?? throw new ArgumentNullException(nameof(numeroCedula));
            FechaIngresoAdministracion = fechaIngresoAdministracion;
            CantidadDiasAdministracion = cantidadDiasAdministracion;
            FechaIngresoTransportes = fechaIngresoTransportes;
            OficioIngreso = oficioIngreso;
            FechaCita = fechaCita;
            DiasParaCita = diasParaCita;
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

        private DateTime fechaIngresoTransportes;
        public DateTime FechaIngresoTransportes
        {
            get { return fechaIngresoTransportes; }
            set
            {
                if (value == null) throw new Exception("El campo de fechaIngresoTransportes es requerido");
                fechaIngresoTransportes = value;
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
                if (string.IsNullOrEmpty(value)) throw new Exception("El campo de estadoResultHojaEnvioGH es requerido");
                estadoResultHojaEnvioGH = value;
            }
        }

    }



}
