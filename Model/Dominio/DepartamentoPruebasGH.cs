using System;
using System.Collections.Generic;
using System.Text;

namespace MOGESP.Entities.Dominio
{
    public class DepartamentoPruebasGH : Departamento
    {


        private string numConcurso;
        public string NumConcurso
        {
            get { return numConcurso; }
            set
            {
                numConcurso = value ?? throw new Exception("El campo de numConcurso es requerido");
            }
        }

        private string ubicacion;
        public string Ubicacion
        {
            get { return ubicacion; }
            set
            {
                ubicacion = value ?? throw new Exception("El campo de numOficio es requerido"); 
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

        private string oficio;
        public string Oficio
        {
            get { return oficio; }
            set
            {
                oficio = value ?? throw new Exception("El campo de numOficio es requerido");
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

    }



}
