using System;
using System.Collections.Generic;
using System.Text;

namespace MOGESP.Entities.Dominio
{
    public class DepartamentoToxicologia
    {

        public DepartamentoToxicologia()
        {
        }

        public DepartamentoToxicologia(string numeroCedula, DateTime fechaIngresoAdministracion, int cantidadDiasAdministracion, DateTime fechaIngreso, string oficioIngreso, DateTime fechaCita, int diasParaCita, int diasAlaFecha, DateTime fechaSalida, int cantidadDiasTotalesTramite, string oficioRespuesta, DateTime fechaEstado, int fechaEstadoCantDias)
        {
            NumeroCedula = numeroCedula ?? throw new ArgumentNullException(nameof(numeroCedula));
            FechaIngresoAdministracion = fechaIngresoAdministracion;
            CantidadDiasAdministracion = cantidadDiasAdministracion;
            FechaIngreso = fechaIngreso;
            OficioIngreso = oficioIngreso;
            FechaCita = fechaCita;
            DiasParaCita = diasParaCita;
            DiasAlaFecha = diasAlaFecha;
            FechaSalida = fechaSalida;
            CantidadDiasTotalesTramite = cantidadDiasTotalesTramite;
            OficioRespuesta = oficioRespuesta;
            FechaEstado = fechaEstado;
            FechaEstadoCantDias = fechaEstadoCantDias;
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

        private int diasAlaFecha;
        public int DiasAlaFecha
        {
            get { return diasAlaFecha; }
            set
            {
                if (value < 0) throw new Exception("El campo de diasAlaFecha es requerido");
                diasAlaFecha = value;
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
            get { return cantidadDiasTotalesTramite; }
            set
            {
                if (value < 0) throw new Exception("El campo de fechaEstadoCantDias es requerido");
                fechaEstadoCantDias = value;
            }
        }

    }
}
