using MOGESP.Entities.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MOGESP.DataAccess.TRAN.Datos
{
    /// <summary>
    /// Clase que administra la hoja de citas de primeros ingresos
    /// </summary>
    public class HojaCitasDatos
    {
        //variable conexion
        private ConexionDatos conexion = new ConexionDatos();


        /// <summary>
        /// Autores: Samuel 
        /// 15/11/19
        /// Este método retorna una lista con las citas de los primeros ingresos.
        /// </summary>
        /// <returns>SqlDataAdapter</returns>
        public SqlDataAdapter getHojaCitasPI()
        {

            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"SELECT [TN_IdPrimerIngreso] , [TC_NombrePsicologo] , [TF_FechaCita] , [TN_IdCorreoCita] , [TN_IdAsistencia]
                                                        FROM [MOGESP].[dbo].[TMOGESP_HojaCitasPI]", sqlConnection);

            SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);

            return sda;
        }


    }
}
