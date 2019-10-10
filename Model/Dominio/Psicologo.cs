using System;

namespace Modelo.Dominio
{
    public class Psicologo
    {
        public Psicologo()
        {
        }

        public Psicologo(string cedula, string nombre)
        {
            Cedula = cedula;
            Nombre = nombre;
        }

        private string cedula;
        public string Cedula
        {
            get
            {
                return cedula;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) throw new Exception("La cédula es requerida");
                cedula = value;
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