using MOGESP.DataAccess.TRAN.Datos;
using MOGESP.Entities.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOGESP.ServiceLayer.Servicio
{
    class TestOtrosServicio
    {
        readonly TestOtrosDatos testOtrosDatos = new TestOtrosDatos();

        /// <summary>
        /// 16/10/2019
        /// Valeria Leiva Quirós
        /// Método que retorna todos los tests de tipo otros
        /// </summary>
        /// <returns>IEnumerable<TestOtros></returns>
        public IEnumerable<TestOtros> consultarTestOtros()
        {
            return testOtrosDatos.ConsultarTestOtros() ?? throw new Exception("No hay registros de test de tipo otros");


        }

        /// <summary>
        /// 16/10/2019
        /// Valeria Leiva Quirós
        /// Este método ingresa un nuevo tipo de test otros
        /// </summary>
        public void insertarTestOtros(string nombre)
        {
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre)) throw new Exception("El nombre es requerido");
            testOtrosDatos.insertarTestOtros(nombre);
        }



        /// <summary>
        /// 16/10/2019
        /// Valeria Leiva Quirós
        /// Este método modifica un tipo de test
        /// </summary>
        public void modificarTestOtros(int id, string nombre)
        {
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre)) throw new Exception("El nombre es requerido");
            if (id > 0) throw new Exception("El id debe ser positivo");
            testOtrosDatos.modificarTestOtros(id, nombre);
        }



        /// <summary>
        /// 16/10/2019
        /// Valeria Leiva Quirós
        /// Este método elimina un tipo de test
        /// </summary>
        public void eliminarTestOtros(int id)
        {
            if (id > 0) throw new Exception("El id debe ser positivo");
            testOtrosDatos.eliminarTestOtros(id);
        }
    }
}

