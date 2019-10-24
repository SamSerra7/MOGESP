using MOGESP.DataAccess.TRAN.Datos;
using MOGESP.Entities.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOGESP.ServiceLayer.Servicio
{
    class AsistenciaServicio
    {
        readonly AsistenciaDatos asistenciaDatos = new AsistenciaDatos();

        /// <summary>
        /// 16/10/2019
        /// Valeria Leiva Quirós
        /// Este método retorna una lista con todos los elementos del catálogo
        /// </summary>
        /// <returns>IEnumerable<Asistencia></returns>
        /// 
        public IEnumerable<Asistencia> consultarAsistencia()
        {
            return asistenciaDatos.ConsultarAsistencia() ?? throw new Exception("No hay registros de asistencia");

        }

        /// <summary>
        /// 16/10/2019
        /// Valeria Leiva Quirós
        /// Este método ingresa una nueva opcion al catálogo
        /// </summary>
        public void insertarAsistencia(string nombre)
        {
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre)) throw new Exception("El nombre es requerido");
            asistenciaDatos.insertarAsistencia(nombre);
        }



        /// <summary>
        /// 16/10/2019
        /// Valeria Leiva Quirós
        /// Este método modifica un tipo de asistencia
        /// </summary>
        public void modificarAsistencia(int id, string nombre)
        {

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre)) throw new Exception("El nombre es requerido");
            if (id > 0) throw new Exception("El id debe ser positivo");
           asistenciaDatos.modificarAsistencia(id, nombre);
        }



        /// <summary>
        /// 16/10/2019
        /// Valeria Leiva Quirós
        /// Este método elimina una opcion en el catálogo
        /// </summary>
        public void eliminarAsistencia(int id)
        {
            if (id > 0) throw new Exception("El id debe ser positivo");
            asistenciaDatos.eliminarAsistencia(id);
        }
    }
}
