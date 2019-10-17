using System;

namespace MOGESP.Entities.Dominio
{
    public class Asistencia
    {

        public Asistencia(int id, string nombre)
        {
            IdAsistencia = id;
            Nombre = nombre;
        }

        public Asistencia()
        {
        }


        private int idAsistencia;
        public int IdAsistencia
        {
            get
            {
                return idAsistencia;
            }
            set
            {
                if (value > 0) throw new Exception("El id debe ser positivo");
                idAsistencia = value;
            }
        }


        private string nombre;


        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) throw new Exception("El nombre es requerido");
                nombre = value;
            }
        }

    }
}