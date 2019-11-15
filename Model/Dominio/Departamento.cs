using System;
using System.Collections.Generic;
using System.Text;

namespace MOGESP.Entities.Dominio
{
    public class Departamento
    {




        public Departamento()
        {
        }

        public Departamento(DateTime fechaIngresoAdministracion, int cantidadDiasAdministracion, 
            DateTime fechaIngreso, string oficioIngreso, int diasAlaFecha, 
            DateTime fechaSalida, int cantidadDiasTotalesTramite, string oficioRespuesta,
            string estadoResultHojaEnvioGH, List<string> estado)
        {
            FechaIngresoAdministracion = fechaIngresoAdministracion;
            CantidadDiasAdministracion = cantidadDiasAdministracion;
            FechaIngreso = fechaIngreso;
            OficioIngreso = oficioIngreso;
            DiasAlaFecha = diasAlaFecha;
            FechaSalida = fechaSalida;
            OficioRespuesta = oficioRespuesta;
            CantidadDiasTotalesTramite = cantidadDiasTotalesTramite;
            EstadoResultHojaEnvioGH = estadoResultHojaEnvioGH;
            EstadoLista = estado;
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
                oficioRespuesta = value ?? throw new Exception("El campo de oficioResulta es requerido");
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

        private List<string> estadoLista;
        public List<string> EstadoLista
        {
            get { return estadoLista; }
            set
            {
                estadoLista = value ?? throw new Exception("El campo de estado es requerido");
            }
        }

    }

}

