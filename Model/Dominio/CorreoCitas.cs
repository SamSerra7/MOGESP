using System;

namespace MOGESP.Entities.Dominio
{
    public class CorreoCitas
    {
        public CorreoCitas(int id, EstCorreo estCorreo, DateTime fecEstCorreo, int maxDiasJustificacion)
        {
            Id = id;
            EstCorreo = estCorreo;
            FecEstCorreo = fecEstCorreo;
            MaxDiasJustificacion = maxDiasJustificacion;
        }
        public CorreoCitas()
        {

        }


        private int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value > 0) throw new Exception("El id debe ser positivo");
                id = value;
            }
        }

        private EstCorreo estCorreo;

        

        public EstCorreo EstCorreo
        {
            get { return estCorreo; }
            set { estCorreo = value ?? throw new Exception("El estado del correo es requerido"); }
        }

        public DateTime FecEstCorreo { get; set; }

        public int MaxDiasJustificacion { get; set; }
        

    }
}