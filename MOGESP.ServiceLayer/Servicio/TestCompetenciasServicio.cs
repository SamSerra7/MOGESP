using MOGESP.DataAccess.TRAN.Datos;
using MOGESP.Entities.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOGESP.ServiceLayer.Servicio
{
    class TestCompetenciasServicio
    {
        readonly TestCompetenciasDatos testCompetenciasDatos = new TestCompetenciasDatos();

        /// <summary>
        /// 16/10/2019
        /// Valeria Leiva Quirós
        /// Método que retorna todos los tests de competencias
        /// </summary>
        /// <returns>IEnumerable<TestCompetencias></returns>
        public IEnumerable<TestCompetencias> consultarTestCompetencias()
        {
            return testCompetenciasDatos.ConsultarTestCompetencias() ?? throw new Exception("No hay registros de Test Competencias");


        }

        /// <summary>
        /// 16/10/2019
        /// Valeria Leiva Quirós
        /// Este método ingresa un nuevo tipo de test otros
        /// </summary>
        public void insertarTestCompetencias(string nombre)
        {
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre)) throw new Exception("El nombre es requerido");
            testCompetenciasDatos.insertarTestCompetencias(nombre);
        }



        /// <summary>
        /// 16/10/2019
        /// Valeria Leiva Quirós
        /// Este método modifica un tipo de test
        /// </summary>
        public void modificarTestComptencias(int id, string nombre)
        {
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre)) throw new Exception("El nombre es requerido");
            if (id > 0) throw new Exception("El id debe ser positivo");
            testCompetenciasDatos.modificarTestCompetencias(id, nombre);
        }



        /// <summary>
        /// 16/10/2019
        /// Valeria Leiva Quirós
        /// Este método elimina un tipo de test
        /// </summary>
        public void eliminarTestCompetencias(int id)
        {
            if (id > 0) throw new Exception("El id debe ser positivo");
            testCompetenciasDatos.eliminarTestCompetencias(id);
        }
    }
}

