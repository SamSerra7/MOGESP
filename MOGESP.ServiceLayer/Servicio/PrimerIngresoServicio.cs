using MOGESP.Entities.Dominio;
using MOGESP.DataAccess.TRAN.Datos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOGESP.ServiceLayer.Servicio
{
    /// <summary>
    /// Clase que gestiona las reglas de negocio de los primeros ingresos
    /// </summary>
    public class PrimerIngresoServicio
    {

        readonly PrimerIngresoDatos primerIngresoDatos = new PrimerIngresoDatos();


        /// <summary>
        /// 16/10/2019
        /// Samuel Serrano Guerra
        /// Método que retorna todos los primeros ingresos
        /// </summary>
        /// <returns>IEnumerable<PrimerIngreso></returns>
        public IEnumerable<PrimerIngreso> getAllPrimerosIngresos()
        {
            return primerIngresoDatos.getAllPrimerosIngresos() ?? throw new Exception("No hay registros de primer ingreso");
        }

        public PrimerIngreso getPrimerIngreso( string cedula)
        {
            return primerIngresoDatos.getPrimerIngreso(cedula) ?? throw new Exception("No hay registros de primer ingreso");
        }

        public void insertarPrimerIngreso(PrimerIngreso PI)
        {
            if (PI == null) throw new Exception("No puede ingresar datos nulos primer ingreso");
            primerIngresoDatos.insertarPrimerIngreso(PI);
        }

        public void modificarPrimerIngreso(PrimerIngreso PI)
        {
            if (PI == null) throw new Exception("No se puede ingresar datos nulos primer ingreso");
            primerIngresoDatos.ModificarPrimerIngreso(PI);
        }

    }
}
