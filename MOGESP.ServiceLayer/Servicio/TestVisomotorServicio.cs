using MOGESP.DataAccess.TRAN.Datos;
using MOGESP.Entities.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOGESP.ServiceLayer.Servicio
{
    public class TestVisomotorServicio
    {
        readonly TestVisomotorDatos testVisomotor = new TestVisomotorDatos();

        /// <summary>
        /// 16/10/2019
        /// Valeria Leiva Quirós
        /// Método que retorna todos los primeros ingresos
        /// </summary>
        /// <returns>IEnumerable<TestVisomotor></returns>
        public IEnumerable<TestVisomotor> consultarTestVisomotor()
        {
            return testVisomotor.ConsultarTestVisomotor() ?? throw new Exception("No hay registros de Test Visomotor");


        }

        /// <summary>
        /// 16/10/2019
        /// Valeria Leiva Quirós
        /// Este método ingresa un nuevo tipo de test visomotor
        /// </summary>
        public void insertarTestVisomotor(string nombre)
        {
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre)) throw new Exception("El nombre es requerido");
            testVisomotor.insertarTestVisomotor(nombre);
        }



        /// <summary>
        /// 16/10/2019
        /// Valeria Leiva Quirós
        /// Este método modifica un tipo de test
        /// </summary>
        public void modificarTestVisomotor(int id, string nombre)
        {
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre)) throw new Exception("El nombre es requerido");
            if (id > 0) throw new Exception("El id debe ser positivo");
            testVisomotor.modificarTestVisomotor(id,nombre);
        }



        /// <summary>
        /// 16/10/2019
        /// Valeria Leiva Quirós
        /// Este método elimina un tipo de test
        /// </summary>
        public void eliminarTestVisomotor(int id)
        {
            if (id > 0) throw new Exception("El id debe ser positivo");
            testVisomotor.eliminarTestVisomotor(id);
        }
    }














}

