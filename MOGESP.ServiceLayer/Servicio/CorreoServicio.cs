using MOGESP.DataAccess.TRAN.Datos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOGESP.ServiceLayer.Servicio
{
    class CorreoServicio
    {
        CorreoDatos correosDatos = new CorreoDatos();

        /// <summary>
        /// 16/10/2019
        /// Valeria Leiva Quirós
        /// Este método retorna una lista con todos los correos de un primer ingreso
        /// </summary>
        /// <returns>IEnumerable<string></returns>
        public IEnumerable<string> cosultarCorreosPorPrimerIngreso(string cedula)
        {
            if (string.IsNullOrEmpty(cedula) || string.IsNullOrWhiteSpace(cedula)) throw new Exception("La cedula es requerido");
            return correosDatos.CosultarCorreosPorPrimerIngreso(cedula) ?? throw new Exception("No hay registros de correos asociados");

        }


        /// <summary>
        /// 16/10/2019
        /// Valeria Leiva Quirós
        /// Este método ingresa un correo para una persona
        /// </summary>
        public void insertarCorreoPorPersona(string cedula, string correo)
        {
            if (string.IsNullOrEmpty(cedula) || string.IsNullOrWhiteSpace(cedula)) throw new Exception("La cedula es requerido");
            if (string.IsNullOrEmpty(correo) || string.IsNullOrWhiteSpace(correo)) throw new Exception("El correo es requerido");
            correosDatos.insertarCorreoPorPersona(cedula, correo);

        }


        /// <summary>
        /// 16/10/2019
        /// Valeria Leiva Quirós
        /// Este método modifica un correo para una persona
        /// </summary>
        public void modificarCorreoPorPersona(string cedula, string correo, string correoMod)
        {
            if (string.IsNullOrEmpty(cedula) || string.IsNullOrWhiteSpace(cedula)) throw new Exception("La cedula es requerido");
            if (string.IsNullOrEmpty(correo) || string.IsNullOrWhiteSpace(correo)) throw new Exception("El correo que se desea modificar es requerido");
            if (string.IsNullOrEmpty(correoMod) || string.IsNullOrWhiteSpace(correoMod)) throw new Exception("El correo es requerido");

            correosDatos.modificarCorreoPorPersona(cedula, correo, correoMod);
        }
    }
}
