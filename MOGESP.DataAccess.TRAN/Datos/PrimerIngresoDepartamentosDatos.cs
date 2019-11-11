using MOGESP.Entities.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MOGESP.DataAccess.TRAN.Datos
{
    public class PrimerIngresoDepartamentosDatos
    {

        //variable conexion
        private ConexionDatos conexion = new ConexionDatos();

        public DepartamentoPruebasGH getDepartamentoPruebasGH(string cedula)
        {

            DepartamentoPruebasGH departamentoPruebasGH = new DepartamentoPruebasGH();

            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_Seleccionar_TMOGESP_PruebasGH @numeroDeCedula ", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@numeroDeCedula", cedula);
            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();


            while (reader.Read())
            {
                departamentoPruebasGH.NumeroCedula = cedula;
                departamentoPruebasGH.FechaIngresoAdministracion = Convert.ToDateTime(reader["TF_FechaIngresoAdministracion"]);
                departamentoPruebasGH.CantidadDiasAdministracion = Convert.ToInt32(reader["TN_CantidadDiasAdm"]);
                departamentoPruebasGH.Ubicacion = reader["TC_Ubicacion"].ToString();
                departamentoPruebasGH.FechaIngreso = Convert.ToDateTime(reader["TF_FechaIngreso"]);
                departamentoPruebasGH.OficioIngreso = reader["TC_OficioIngreso"].ToString();
                departamentoPruebasGH.DiasALaFecha = Convert.ToInt32(reader["TN_DiasALaFecha"]);
                departamentoPruebasGH.FechaTrasladoPsicologosAdmin = Convert.ToDateTime(reader["TF_FechaTrasladoPsicologosAdm"]);
                departamentoPruebasGH.NumOficio = reader["TC_Oficio"].ToString();
                departamentoPruebasGH.CantidadDiasPsicologiaAdmin = Convert.ToInt32(reader["TN_CantidadDiasPsicologiaAdm"]);
                departamentoPruebasGH.FechaLimiteSegunPlazo = Convert.ToDateTime(reader["TF_FechaLimiteSegunPlazo"]);
                departamentoPruebasGH.DiasALaFechaDeFechaLimiteSegunPlazo = Convert.ToInt32(reader["TN_DiasALaFechaDeFechaLimiteSegunPlazo"]);
                departamentoPruebasGH.DiasTramiteGHDespuesDevuelto = Convert.ToInt32(reader["TN_DiasTramiteGHDespuesDevuelto"]);
                departamentoPruebasGH.FechaSalida = Convert.ToDateTime(reader["TF_FechaSalida"]);
                departamentoPruebasGH.CantidadDiasTotalesTramite = Convert.ToInt32(reader["TN_CantidadDiasTotalesTramite"]);
                departamentoPruebasGH.OficioRespuesta = reader["TC_OficioRespuesta"].ToString();
                departamentoPruebasGH.EstadoResultHojaEnvioGH = reader["TC_Nombre"].ToString();
            }

            sqlConnection.Close();


            return departamentoPruebasGH;
        }

        

    }
}
