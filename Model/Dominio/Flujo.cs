using System;

namespace Modelo.Dominio
{
    public class Flujo
    {


        private int numeroFlujo;

        public int NumeroFlujo
        {
            get { return numeroFlujo; }
            set {
                if (value > 0) throw new Exception("El id debe ser positivo");
                numeroFlujo = value;
            }
        }



        private AdministracionFlujo administracionFlujo;

        public AdministracionFlujo AdministracionFlujo
        {
            get { return administracionFlujo; }
            set { administracionFlujo = value?? throw new Exception("Debe pasar por administración"); }
        }
        private PsicologiaFlujo psicologiaFlujo;

        public PsicologiaFlujo PsicologiaFlujo
        {
            get { return psicologiaFlujo; }
            set { psicologiaFlujo = value ?? throw new Exception("Debe pasar por psciología"); }
        }




    }
}