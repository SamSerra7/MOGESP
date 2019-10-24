using MOGESP.DataAccess.TRAN.Datos;
using MOGESP.Entities.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOGESP.ServiceLayer.Servicio
{
    class ClaseServicio
    {
        readonly ClaseDatos claseDatos = new ClaseDatos();

        /// <summary>
        /// 16/10/2019
        /// Valeria Leiva Quirós
        /// Este método retorna una lista con todos los elementos del catálogo
        /// </summary>
        /// <returns>IEnumerable<Clase></returns>
        /// 
        public IEnumerable<Clase> consultarAsistencia()
        {
            return claseDatos.ConsultarClases() ?? throw new Exception("No hay registros de clase");

        }

        /// <summary>
        /// 16/10/2019
        /// Valeria Leiva Quirós
        /// Este método ingresa una nueva opcion al catálogo
        /// </summary>
        public void insertarClase(string nombre)
        {
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre)) throw new Exception("El nombre es requerido");
            claseDatos.insertarClase(nombre);
        }



        /// <summary>
        /// 16/10/2019
        /// Valeria Leiva Quirós
        /// Este método modifica un tipo de clase
        /// </summary>
        public void modificarClase(int id, string nombre)
        {

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre)) throw new Exception("El nombre es requerido");
            if (id > 0) throw new Exception("El id debe ser positivo");
            claseDatos.modificarClase(id, nombre);
        }



        /// <summary>
        /// 16/10/2019
        /// Valeria Leiva Quirós
        /// Este método elimina una opcion en el catálogo
        /// </summary>
        public void eliminarClase(int id)
        {
            if (id > 0) throw new Exception("El id debe ser positivo");
            claseDatos.eliminarClase(id);
        }
    }
}
