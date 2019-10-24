using MOGESP.DataAccess.TRAN.Datos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOGESP.ServiceLayer.Servicio
{
    class TelefonoServicio
    {
        readonly TelefonoDatos telefonoDatos = new TelefonoDatos();


        /// <summary>
        /// 16/10/2019
        /// Valeria Leiva Quirós
        /// Este método retorna una lista con todos los teléfonos de un primer ingreso específicco
        /// <returns>IEnumerable<PrimerIngreso></returns>
        /// </summary>
        public IEnumerable<int> cosultarTelefonosPorPrimerIngreso(string cedula)
        {
            return telefonoDatos.CosultarTelefonosPorPrimerIngreso(cedula) ?? throw new Exception("No hay registros de Test Visomotor");

        }

        /// <summary>
        /// 16/10/2019
        /// Valeria Leiva Quirós
        /// Este método ingresa un teléfono para una persona
        /// </summary>
        public void insertarTelefonoPorPersona(string cedula, int telefono)
        {
            if (string.IsNullOrEmpty(cedula) || string.IsNullOrWhiteSpace(cedula)) throw new Exception("La cedula es requerido");
            if (telefono > 0) throw new Exception("El telefono debe ser positivo");
            telefonoDatos.insertarTelefonoPorPersona(cedula,telefono);

        }



        /// <summary>
        /// 16/10/2019
        /// Valeria Leiva Quirós
        /// Este método modifica un teléfono para una persona
        /// </summary>
        public void modificarTelefonoPorPersona(string cedula, int telefono, int telefonoMod)
        {
            if (string.IsNullOrEmpty(cedula) || string.IsNullOrWhiteSpace(cedula)) throw new Exception("La cedula es requerido");
            if (telefono > 0) throw new Exception("El telefono que se desea modificar debe ser positivo");
            if (telefonoMod > 0) throw new Exception("El telefono a debe ser positivo");
            telefonoDatos.insertarTelefonoPorPersona(cedula, telefono);
        }
    }


}

