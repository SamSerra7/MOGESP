using System;

namespace MOGESP.Entities.Dominio
{
    public class Clase
    {
        public Clase()
        {
        }

        public Clase(int idClase, string nombre)
        {
            IdClase = idClase;
            Nombre = nombre;
        }

        private int idClase;
        public int IdClase
        {
            get
            {
                return idClase;
            }
            set
            {
                if (value > 0) throw new Exception("El id debe ser positivo");
                idClase = value;
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