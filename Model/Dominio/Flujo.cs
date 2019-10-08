using System;

namespace Modelo.Dominio
{
    public class Flujo
    {
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