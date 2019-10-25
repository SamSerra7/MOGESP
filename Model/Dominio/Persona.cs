using System;
using System.Collections.Generic;

namespace MOGESP.Entities.Dominio
{
    public abstract class Persona
    {

        public Persona()
        {

        }


        protected Persona(string cedula, string nombre, string primerApellido, string segundoApellido, char sexo, List<string> correos, List<String> telefonos, string direccion)
        {
            Cedula = cedula;
            Nombre = nombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            Sexo = sexo;
            Correos = correos;
            Telefonos = telefonos;
            Direccion = direccion;
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
        private string primerApellido;
        public string PrimerApellido
        {
            get
            {
                return primerApellido;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) throw new Exception("El primer apellido es requerido");
                primerApellido = value;
            }
        }
        private string segundoApellido;
        public string SegundoApellido
        {
            get
            {
                return segundoApellido;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) throw new Exception("El segundo apellido es requerido");
                segundoApellido = value;
            }
        }

        private List<string> correos;

        public List<string> Correos
        {
            get { return correos; }
            set { correos = value ?? throw new Exception("Al menos un correo es requerido"); }
        }

        private List<String> telefonos;

        public List<String> Telefonos
        {
            get { return telefonos; }
            set { telefonos = value ?? throw new Exception("Al menos un teléfono es requerido"); }
        }

        private string direccion;
        public string Direccion
        {
            get
            {
                return direccion;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) throw new Exception("La dirección es requerida");
                direccion = value;
            }
        }


        private char sexo;

        public char Sexo
        {
            get { return sexo; }
            set {
                if (char.IsNumber(value) || char.IsWhiteSpace(value)) throw new Exception("El sexo no puede ser un número y es requerido");
                sexo = value;
            }
        }


    }
}
