using System;
using System.Collections.Generic;
using System.Text;

namespace MOGESP.Entities.Dominio
{
    public class CuadroGeneral
    {
        public CuadroGeneral()
        {
            
        }
        public CuadroGeneral(string numConvocatoria, int numeroFlujo,string numeroCedula, string nombre,string primerAp,string segundoAp, List<Puesto> puestosAplica, String condicion)
        {
            NumeroConvocatoria = numConvocatoria;
            NumeroFlujo = numeroFlujo;
            NumeroCedula = numeroCedula;
            NombrePI = nombre;
            PrimerApellido = primerAp;
            SegundoApellido = segundoAp;
            PuestosAplica = puestosAplica;
            Condicion = condicion;
        }
        //, ,string , string ,string ,string 
        private string numeroConvocatoria;
        public string NumeroConvocatoria
        {
            get { return numeroConvocatoria; }
            set
            {
                if (value == null || value.Trim().Equals("")) throw new Exception("El campo de numeroConvocatoria es requerido");
                numeroConvocatoria = value;
            }
        }
        private int numeroFlujo;
        public int NumeroFlujo
        {
            get { return numeroFlujo; }
            set
            {
                if (value < 0) throw new Exception("El numero de flujo debe ser positivo");
                numeroFlujo = value;
            }
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
        private string nombrePI;
        public string NombrePI
        {
            get { return nombrePI; }
            set
            {
                if (value == null || value.Trim().Equals("")) throw new Exception("El campo de nombrePI es requerido");
                nombrePI = value;
            }
        }
        private string primerApellido;
        public string PrimerApellido
        {
            get { return primerApellido; }
            set
            {
                if (value == null || value.Trim().Equals("")) throw new Exception("El campo de primerApellido es requerido");
                primerApellido = value;
            }
        }
        private string segundoApellido;
        public string SegundoApellido
        {
            get { return segundoApellido; }
            set
            {
                if (value == null || value.Trim().Equals("")) throw new Exception("El campo de segundoApellido es requerido");
                segundoApellido = value;
            }
        }
        private List<Puesto> puestosAplica;
        public List<Puesto> PuestosAplica
        {
            get { return puestosAplica; }
            set
            {
                puestosAplica = value ?? throw new Exception("Los puestos por los que aplica son requeridos");
            }
        }
        private int cantidadDiasAdminPruebasGH;
        public int CantidadDiasAdminPruebasGH
        {
            get { return cantidadDiasAdminPruebasGH; }
            set
            {
                if (value < 0) throw new Exception("La cantidad de dias en Administracion de Pruebas GH debe ser positiva");
                cantidadDiasAdminPruebasGH = value;
            }
        }
        private int cantidadDiasPruebasGH;
        public int CantidadDiasPruebasGH
        {
            get { return cantidadDiasPruebasGH; }
            set
            {
                if (value < 0) throw new Exception("La cantidad de dias en Administracion de Pruebas GH debe ser positiva");
                cantidadDiasPruebasGH = value;
            }
        }

        private int cantidadDiasAdminAntecedentes;
        public int CantidadDiasAdminAntecedentes
        {
            get { return cantidadDiasAdminAntecedentes; }
            set
            {
                if (value < 0) throw new Exception("La cantidad de dias en Administracion de Pruebas GH debe ser positiva");
                cantidadDiasAdminAntecedentes = value;
            }
        }
        private int cantidadDiasAntecedentes;
        public int CantidadDiasAntecedentes
        {
            get { return cantidadDiasAntecedentes; }
            set
            {
                if (value < 0) throw new Exception("La cantidad de dias en Administracion de Pruebas GH debe ser positiva");
                cantidadDiasAntecedentes = value;
            }
        }
        private int cantidadDiasAdminVialidad;
        public int CantidadDiasAdminVialidad
        {
            get { return cantidadDiasAdminVialidad; }
            set
            {
                if (value < 0) throw new Exception("La cantidad de dias en Administracion de Pruebas GH debe ser positiva");
                cantidadDiasAdminVialidad = value;
            }
        }
        private int cantidadDiasVialidad;
        public int CantidadDiasVialidad
        {
            get { return cantidadDiasVialidad; }
            set
            {
                if (value < 0) throw new Exception("La cantidad de dias en Administracion de Pruebas GH debe ser positiva");
                cantidadDiasVialidad = value;
            }
        }
        private DateTime fechaEnvioGHTraslado;
        public DateTime FechaEnvioGHTraslado
        {
            get { return fechaEnvioGHTraslado; }
            set
            {
                if (value == null) throw new Exception("El campo de fechaIngreso es requerido");
                fechaEnvioGHTraslado = value;
            }
        }
        private int cantidadDiasAdminPruebasMedicas;
        public int CantidadDiasAdminPruebasMedicas
        {
            get { return cantidadDiasAdminPruebasMedicas; }
            set
            {
                if (value < 0) throw new Exception("La cantidad de dias en Administracion de Pruebas GH debe ser positiva");
                cantidadDiasAdminPruebasMedicas = value;
            }
        }
        private int cantidadDiasPruebasMedicas;
        public int CantidadDiasPruebasMedicas
        {
            get { return cantidadDiasPruebasMedicas; }
            set
            {
                if (value < 0) throw new Exception("La cantidad de dias en Administracion de Pruebas GH debe ser positiva");
                cantidadDiasPruebasMedicas = value;
            }
        }
        private int cantidadDiasAdminToxicologia;
        public int CantidadDiasAdminToxicologia
        {
            get { return cantidadDiasAdminToxicologia; }
            set
            {
                if (value < 0) throw new Exception("La cantidad de dias en Administracion de Pruebas GH debe ser positiva");
                cantidadDiasAdminToxicologia = value;
            }
        }
        private int cantidadDiasToxicologia;
        public int CantidadDiasToxicologia
        {
            get { return cantidadDiasToxicologia; }
            set
            {
                if (value < 0) throw new Exception("La cantidad de dias en Administracion de Pruebas GH debe ser positiva");
                cantidadDiasToxicologia = value;
            }
        }
        private String condicion;
        public String Condicion
        {
            get { return condicion; }
            set
            {
                if (value == null || value.Trim().Equals("")) throw new Exception("El campo de condicion es requerido");
                condicion = value;
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
        private int cantidadDiasTotalesTramite;
        public int CantidadDiasTotalesTramite
        {
            get { return cantidadDiasTotalesTramite; }
            set
            {
                if (value < 0) throw new Exception("La cantidad de dias en Administracion de Pruebas GH debe ser positiva");
                cantidadDiasTotalesTramite = value;
            }
        }

    }
}
