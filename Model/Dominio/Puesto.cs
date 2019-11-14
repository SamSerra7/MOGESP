using System;
using System.Collections.Generic;
using System.Text;

namespace MOGESP.Entities.Dominio
{
    public class Puesto
    {

        public Puesto()
        {
        }

        public Puesto(int idPuesto, string nombrePuesto, string condicion)
        {
            IdPuesto = idPuesto;
            Nombre = nombrePuesto;
            Condicion = condicion;
        }

        

        private int idPuesto;
        public int IdPuesto
        {
            get
            {
                return idPuesto;
            }
            set
            {
                if (value < 0) throw new Exception("El id debe ser positivo");
                idPuesto = value;
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
        private string condicion;
        public string Condicion
        {
            get
            {
                return condicion;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) throw new Exception("La condicion es requerido");
                condicion = value;
            }
        }

    }

   
}
