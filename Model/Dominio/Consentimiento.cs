using System;

namespace Modelo.Dominio
{
    public class Consentimiento
    {

        public Consentimiento(int idConsentimiento, string nombre)
        {
            IdConsentimiento = idConsentimiento;
            Nombre = nombre;
        }

        public Consentimiento()
        {

        }


        private int idConsentimiento;
        public int IdConsentimiento
        {
            get
            {
                return idConsentimiento;
            }
            set
            {
                if (value > 0) throw new Exception("El id debe ser positivo");
                idConsentimiento = value;
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