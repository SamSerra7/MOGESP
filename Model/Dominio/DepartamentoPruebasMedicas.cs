using System;
using System.Collections.Generic;
using System.Text;

namespace MOGESP.Entities.Dominio
{
    public class DepartamentoPruebasMedicas
    {

        public DepartamentoPruebasMedicas()
        {
        }

        public DepartamentoPruebasMedicas(string numeroCedula, DateTime fechaIngresoAdministracion, int cantidadDiasAdministracion, DateTime fechaIngreso, DateTime fechaEnvioAPMdeGH, string oficioIngreso, DateTime fechaResultadoOCitaPM, int diasAlaFecha, DateTime fechaSalida, int cantidadDiasTotalesTramite, string oficioRespuesta)
        {
            NumeroCedula = numeroCedula ?? throw new ArgumentNullException(nameof(numeroCedula));
            FechaIngresoAdministracion = fechaIngresoAdministracion;
            CantidadDiasAdministracion = cantidadDiasAdministracion;
            FechaIngreso = fechaIngreso;
            FechaEnvioAPMdeGH = fechaEnvioAPMdeGH;
            OficioIngreso = oficioIngreso;
            FechaResultadoOCitaPM = fechaResultadoOCitaPM;
            DiasAlaFecha = diasAlaFecha;
            FechaSalida = fechaSalida;
            CantidadDiasTotalesTramite = cantidadDiasTotalesTramite;
            OficioRespuesta = oficioRespuesta;
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

        private string oficioIngreso;
        public string OficioIngreso
        {
            get { return oficioIngreso; }
            set
            {
                oficioIngreso = value ?? throw new Exception("El campo de oficioIngreso es requerido");
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

    }

}
