using System;

namespace MOGESP.Entities.Dominio
{
    public class TestOtros
    {

        public TestOtros()
        {
        }

        public TestOtros(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
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