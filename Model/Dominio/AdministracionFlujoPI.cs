using System;

namespace Modelo.Dominio
{
    public class AdministracionFlujoPI
    {

        public AdministracionFlujoPI(int idAdministracionFlujoPI, HojaCitasPI hojaCitas, DateTime fechaDeLlegada, DateTime fechaSalida, DateTime fechaIngresoDev, DateTime fechaAtencionDev)
        {
            IdAdministracionFlujoPI = idAdministracionFlujoPI;
            HojaCitas = hojaCitas;
            FechaDeLlegada = fechaDeLlegada;
            this.fechaSalida = fechaSalida;
            this.fechaIngresoDev = fechaIngresoDev;
            this.fechaAtencionDev = fechaAtencionDev;
        }

        public AdministracionFlujoPI()
        {

        }

        private int idAdministracionFlujoPI;
        public int IdAdministracionFlujoPI
        {
            get
            {
                return idAdministracionFlujoPI;
            }
            set
            {
                if (value > 0) throw new Exception("El id debe ser positivo");
                idAdministracionFlujoPI = value;
            }
        }

        private HojaCitasPI hojaCitas;

        public HojaCitasPI HojaCitas
        {
            get { return hojaCitas; }
            set { hojaCitas = value ?? throw new Exception("Debe tener una hoja de citas asociada"); }
        }


        private DateTime fechaDeLlegada;

        

        public DateTime FechaDeLlegada
        {
            get { return fechaDeLlegada; }
            set {
                if (value > DateTime.Now) throw new Exception("Debe tener una hoja de citas asociada");
                fechaDeLlegada = value;
            }
        }

        public DateTime fechaSalida { get; set; }

        public DateTime fechaIngresoDev { get; set; }

        public DateTime fechaAtencionDev { get; set; }

    }
}