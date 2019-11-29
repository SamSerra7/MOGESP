using MOGESP.Entities.Dominio;
using MOGESP.DataAccess.TRAN.Datos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace MOGESP.ServiceLayer.Servicio
{
    /// <summary>
    /// Clase que gestiona las reglas de negocio de las citas primeros ingresos
    /// </summary>
    public class HojaCitasPiServicio
    {

        readonly HojaCitasDatos hojaCitasDatos = new HojaCitasDatos();


        /// <summary>
        /// 15/11/2019
        /// Samuel Serrano Guerra
        /// Método que retorna la hoja de citas de los primeros ingresos
        /// </summary>
        /// <returns>SqlDataAdapter</returns>
        public SqlDataAdapter getHojaCitasPI()
        {
            return hojaCitasDatos.getHojaCitasPI() ?? throw new Exception("No hay registros de citas de primer ingreso");
        }

        /// <summary>
        /// 28/11/2019
        /// Samuel Serrano Guerra
        /// Método que inserta una cita para un primer ingreso
        /// </summary>
        public void InsertarCitaPI(string cedula, string nombrePsi, DateTime fechaCita, int idAsist, string nombreEncargadoAdm)
        {

            if(string.IsNullOrEmpty(cedula) || string.IsNullOrEmpty(nombrePsi) || string.IsNullOrEmpty(nombreEncargadoAdm)) throw new Exception("No hay registros de citas de primer ingreso");

            hojaCitasDatos.InsertarCitaPI(cedula, nombrePsi, fechaCita, idAsist, nombreEncargadoAdm); 
        }
    }
}
