using System;
using System.Collections.Generic;
using System.Text;

namespace MOGESP.Entities.Dominio
{
    public class DepartamentoPruebasGH
    {

        public DepartamentoPruebasGH()
        {
        }

        public DepartamentoPruebasGH(string numeroCedula, DateTime fechaIngresoAdministracion, int cantidadDiasAdministracion, DateTime fechaIngreso, string oficioIngreso, int diasALaFecha, DateTime fechaTrasladoPsicologosAdmin, string numOficio, DateTime fechaDevolucionGHDeAdmin, int cantidadDiasPsicologiaAdmin, DateTime fechaLimiteSegunPlazo, int diasALaFechaDeFechaLimiteSegunPlazo, int diasTramiteGHDespuesDevuelto, DateTime fechaSalida, int cantidadDiasTotalesTramite, string oficioRespuesta, string estadoResultHojaEnvioGH)
        {
            NumeroCedula = numeroCedula ?? throw new ArgumentNullException(nameof(numeroCedula));
            FechaIngresoAdministracion = fechaIngresoAdministracion;
            CantidadDiasAdministracion = cantidadDiasAdministracion;
            FechaIngreso = fechaIngreso;
            OficioIngreso = oficioIngreso;
            DiasALaFecha = diasALaFecha;
            FechaTrasladoPsicologosAdmin = fechaTrasladoPsicologosAdmin;
            NumOficio = numOficio;
            FechaDevolucionGHDeAdmin = fechaDevolucionGHDeAdmin;
            CantidadDiasPsicologiaAdmin = cantidadDiasPsicologiaAdmin;
            FechaLimiteSegunPlazo = fechaLimiteSegunPlazo;
            DiasALaFechaDeFechaLimiteSegunPlazo = diasALaFechaDeFechaLimiteSegunPlazo;
            DiasTramiteGHDespuesDevuelto = diasTramiteGHDespuesDevuelto;
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

        private string ubicacion;
        public string Ubicacion
        {
            get { return ubicacion; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new Exception("El campo de ubicacion es requerido");
                ubicacion = value;
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

        private DateTime fechaTrasladoPsicologosAdmin;
        public DateTime FechaTrasladoPsicologosAdmin
        {
            get { return fechaTrasladoPsicologosAdmin; }
            set
            {
                if (value == null) throw new Exception("El campo de fechaTrasladoPsicologosAdmin es requerido");
                fechaTrasladoPsicologosAdmin = value;
            }
        }

        private string numOficio;
        public string NumOficio
        {
            get { return numOficio; }
            set
            {
                numOficio = value ?? throw new Exception("El campo de numOficio es requerido");
            }
        }

        private DateTime fechaDevolucionGHDeAdmin;
        public DateTime FechaDevolucionGHDeAdmin
        {
            get { return fechaDevolucionGHDeAdmin; }
            set
            {
                if (value == null) throw new Exception("El campo de fechaDevolucionGHDeAdmin es requerido");
                fechaDevolucionGHDeAdmin = value;
            }
        }

        private int cantidadDiasPsicologiaAdmin;
        public int CantidadDiasPsicologiaAdmin
        {
            get { return cantidadDiasPsicologiaAdmin; }
            set
            {
                if (value < 0) throw new Exception("El campo de cantidadDiasPsicologiaAdmin es requerido");
                cantidadDiasPsicologiaAdmin = value;
            }
        }

        private DateTime fechaLimiteSegunPlazo;
        public DateTime FechaLimiteSegunPlazo
        {
            get { return fechaLimiteSegunPlazo; }
            set
            {
                if (value == null) throw new Exception("El campo de fechaLimiteSegunPlazo es requerido");
                fechaLimiteSegunPlazo = value;
            }
        }

        private int diasALaFechaDeFechaLimiteSegunPlazo;
        public int DiasALaFechaDeFechaLimiteSegunPlazo
        {
            get { return diasALaFechaDeFechaLimiteSegunPlazo; }
            set
            {
                if (value < 0) throw new Exception("El campo de diasALaFechaDeFechaLimiteSegunPlazo es requerido");
                diasALaFechaDeFechaLimiteSegunPlazo = value;
            }
        }

        private int diasTramiteGHDespuesDevuelto;
        public int DiasTramiteGHDespuesDevuelto
        {
            get { return diasTramiteGHDespuesDevuelto; }
            set
            {
                if (value < 0) throw new Exception("El campo de diasTramiteGHDespuesDevuelto es requerido");
                diasTramiteGHDespuesDevuelto = value;
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
