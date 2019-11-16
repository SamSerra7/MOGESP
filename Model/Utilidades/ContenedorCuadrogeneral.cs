using System;
using System.Collections.Generic;
using System.Text;
using MOGESP.Entities.Dominio;

namespace MOGESP.Entities.Utilidades
{
    public class ContenedorCuadrogeneral
    {
        private List<CuadroGeneral> listaCuadroGeneral;// = new List<CuadroGeneral>();
        public List<CuadroGeneral> ListaCuadroGeneral
        {
            get { return listaCuadroGeneral; }
            set
            {
                listaCuadroGeneral = value ?? throw new Exception("La lista de cuadro general es requerida");
            }
        }
        private int cantidadPruebasGH;
        public int CantidadPruebasGH
        {
            get { return cantidadPruebasGH; }
            set
            {
                if (value < 0) throw new Exception("La cantidadPruebasGH debe ser mayor a cero");
                cantidadPruebasGH = value;
            }
        }
        private int cantidadAntecedentes;
        public int CantidadAntecedentes
        {
            get { return cantidadAntecedentes; }
            set
            {
                if (value < 0) throw new Exception("La cantidadAntecedentes debe ser mayor a cero");
                cantidadAntecedentes = value;
            }
        }
        private int cantidadVialidad;
        public int CantidadVialidad
        {
            get { return cantidadVialidad; }
            set
            {
                if (value < 0) throw new Exception("La cantidadVialidad debe ser mayor a cero");
                cantidadVialidad = value;
            }
        }
        private int cantidadToxicologia;
        public int CantidadToxicologia
        {
            get { return cantidadToxicologia; }
            set
            {
                if (value < 0) throw new Exception("La cantidadToxicologia debe ser mayor a cero");
                cantidadToxicologia = value;
            }
        }
        private int cantidadPruebasMedicas;
        public int CantidadPruebasMedicas
        {
            get { return cantidadPruebasMedicas; }
            set
            {
                if (value < 0) throw new Exception("La cantidadPruebasMedicas debe ser mayor a cero");
                cantidadPruebasMedicas = value;
            }
        }
        private int cantidadPositivosEnEspera;
        public int CantidadPositivosEnEspera
        {
            get { return cantidadPositivosEnEspera; }
            set
            {
                if (value < 0) throw new Exception("La cantidadPositivosEnEspera debe ser mayor a cero");
                cantidadPositivosEnEspera = value;
            }
        }
        private int cantidadNegativos;
        public int CantidadNegativos
        {
            get { return cantidadNegativos; }
            set
            {
                if (value < 0) throw new Exception("La cantidadNegativos debe ser mayor a cero");
                cantidadNegativos = value;
            }
        }
        private int cantidadPendientes;
        public int CantidadPendientes
        {
            get { return cantidadPendientes; }
            set
            {
                if (value < 0) throw new Exception("La cantidadPendientes debe ser mayor a cero");
                cantidadPendientes = value;
            }
        }
        private int cantidadNombrados;
        public int CantidadNombrados
        {
            get { return cantidadNombrados; }
            set
            {
                if (value < 0) throw new Exception("La cantidadNombrados debe ser mayor a cero");
                cantidadNombrados = value;
            }
        }

        public ContenedorCuadrogeneral()
        {
        }

        public ContenedorCuadrogeneral(List<CuadroGeneral> listaCuadroGeneral, int cantidadPruebasGH, int cantidadAntecedentes, int cantidadVialidad, int cantidadToxicologia, int cantidadPruebasMedicas, int cantidadPositivosEnEspera, int cantidadNegativos, int cantidadPendientes, int cantidadNombrados)
        {
            ListaCuadroGeneral = listaCuadroGeneral;
            CantidadPruebasGH = cantidadPruebasGH;
            CantidadAntecedentes = cantidadAntecedentes;
            CantidadVialidad = cantidadVialidad;
            CantidadToxicologia = cantidadToxicologia;
            CantidadPruebasMedicas = cantidadPruebasMedicas;
            CantidadPositivosEnEspera = cantidadPositivosEnEspera;
            CantidadNegativos = cantidadNegativos;
            CantidadPendientes = cantidadPendientes;
            CantidadNombrados = cantidadNombrados;
        }
    }
}
