using System;

namespace Modelo.Dominio
{
    public class FlujoPI
    {

        public FlujoPI(int numeroFlujoPI, AdministracionFlujoPI administracionFlujo, PsicologiaFlujoPI psicologiaFlujo)
        {
            NumeroFlujoPI = numeroFlujoPI;
            AdministracionFlujo = administracionFlujo;
            PsicologiaFlujo = psicologiaFlujo;
        }


        public FlujoPI()
        {

        }

        private int numeroFlujoPI;

        public int NumeroFlujoPI
        {
            get { return numeroFlujoPI; }
            set {
                if (value > 0) throw new Exception("El id debe ser positivo");
                numeroFlujoPI = value;
            }
        }



        private AdministracionFlujoPI administracionFlujo;

        public AdministracionFlujoPI AdministracionFlujo
        {
            get { return administracionFlujo; }
            set { administracionFlujo = value?? throw new Exception("Debe pasar por administración"); }
        }
        private PsicologiaFlujoPI psicologiaFlujo;

     
        public PsicologiaFlujoPI PsicologiaFlujo
        {
            get { return psicologiaFlujo; }
            set { psicologiaFlujo = value ?? throw new Exception("Debe pasar por psciología"); }
        }




    }
}