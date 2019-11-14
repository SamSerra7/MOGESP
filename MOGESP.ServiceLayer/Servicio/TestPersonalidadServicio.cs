using MOGESP.DataAccess.TRAN.Datos;
using MOGESP.Entities.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOGESP.ServiceLayer.Servicio
{
    public class TestPersonalidadServicio
    {

        readonly TestPersonalidadDatos testPersonalidadDatos = new TestPersonalidadDatos();

        /// <summary>
        /// 16/10/2019
        /// Valeria Leiva Quirós
        /// Método que retorna todos los tests personalidad
        /// </summary>
        /// <returns>IEnumerable<TestPersonalidad></returns>
        public IEnumerable<TestPersonalidad> consultarTestPersonalidad()
        {
            return testPersonalidadDatos.ConsultarTestPersonalidad() ?? throw new Exception("No hay registros de Test Personalidad");


        }

        /// <summary>
        /// 16/10/2019
        /// Valeria Leiva Quirós
        /// Este método ingresa un nuevo tipo de test personalidad
        /// </summary>
        public void insertarTestPersonalidad(string nombre)
        {
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre)) throw new Exception("El nombre es requerido");
            testPersonalidadDatos.insertarTestPersonalidad(nombre);
        }



        /// <summary>
        /// 16/10/2019
        /// Valeria Leiva Quirós
        /// Este método modifica un tipo de test
        /// </summary>
        public void modificarTestPersonalidad(int id, string nombre)
        {
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre)) throw new Exception("El nombre es requerido");
            if (id > 0) throw new Exception("El id debe ser positivo");
            testPersonalidadDatos.modificarTestPersonalidad(id, nombre);
        }



        /// <summary>
        /// 16/10/2019
        /// Valeria Leiva Quirós
        /// Este método elimina un tipo de test
        /// </summary>
        public void eliminarTestPersonalidad(int id)
        {
            if (id > 0) throw new Exception("El id debe ser positivo");
            testPersonalidadDatos.eliminarTestPersonalidad(id);
        }
    }
}
