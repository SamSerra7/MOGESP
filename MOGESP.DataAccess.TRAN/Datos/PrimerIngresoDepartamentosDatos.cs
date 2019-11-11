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

        public DepartamentoPruebasGH getDepartamentoPruebasGH(string cedulaPI)
        {

            DepartamentoPruebasGH departamentoPruebasGH = new DepartamentoPruebasGH();

            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_Seleccionar_TMOGESP_PruebasGH @numeroDeCedula ", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@numeroDeCedula", cedulaPI);
            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();


            while (reader.Read())
            {
                departamentoPruebasGH.NumeroCedula = cedulaPI;
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

        public DepartamentoAntecedentes getDepartamentoAntecedentes(string cedulaPI)
        {

            DepartamentoAntecedentes departamentoAntecedentes = new DepartamentoAntecedentes();

            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_Seleccionar_TMOGESP_Antecedentes @numeroDeCedula ", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@numeroDeCedula", cedulaPI);
            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();


            while (reader.Read())
            {
                departamentoAntecedentes.NumeroCedula = cedulaPI;
                departamentoAntecedentes.FechaIngresoAdministracion = Convert.ToDateTime(reader["TF_FechaIngresoAdministracion"]);
                departamentoAntecedentes.CantidadDiasAdministracion = Convert.ToInt32(reader["TN_CantidadDiasAdm"]);
                departamentoAntecedentes.FechaIngreso = Convert.ToDateTime(reader["TF_FechaIngreso"]);
                departamentoAntecedentes.OficioIngreso = reader["TC_OficioIngreso"].ToString();
                departamentoAntecedentes.DiasALaFecha = Convert.ToInt32(reader["TN_DiasALaFecha"]);
                departamentoAntecedentes.FechaResultado = Convert.ToDateTime(reader["TF_FechaFechaResultado"]);
                departamentoAntecedentes.ZonaTrabajo = Convert.ToInt32(reader["TN_ZonaDeTrabajo"]);
                departamentoAntecedentes.FechaSalida = Convert.ToDateTime(reader["TF_FechaSalida"]);
                departamentoAntecedentes.CantidadDiasTotalesTramite = Convert.ToInt32(reader["TN_CantidadDiasTotalesTramite"]);
                departamentoAntecedentes.OficioRespuesta = reader["TC_OficioRespuesta"].ToString();
                departamentoAntecedentes.EstadoResultHojaEnvioGH = reader["TC_Nombre"].ToString();
            }

            sqlConnection.Close();


            return departamentoAntecedentes;
        }


        public DepartamentoVialidad getDepartamentoVialidad(string cedulaPI)
        {

            DepartamentoVialidad departamentoVialidad = new DepartamentoVialidad();

            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_Seleccionar_TMOGESP_Vialidad @numeroDeCedula ", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@numeroDeCedula", cedulaPI);
            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();


            while (reader.Read())
            {
                departamentoVialidad.NumeroCedula = cedulaPI;
                departamentoVialidad.FechaIngresoAdministracion = Convert.ToDateTime(reader["TF_FechaIngresoAdministracion"]);
                departamentoVialidad.CantidadDiasAdministracion = Convert.ToInt32(reader["TN_CantidadDiasAdm"]);
                departamentoVialidad.FechaIngresoTransportes = Convert.ToDateTime(reader["TF_FechaIngresoTransportes"]);
                departamentoVialidad.OficioIngreso = reader["TC_OficioIngreso"].ToString();
                departamentoVialidad.DiasParaCita = Convert.ToInt32(reader["TN_DiasParaCita"]);
                departamentoVialidad.FechaCita = Convert.ToDateTime(reader["TF_FechaFechaCita"]);
                departamentoVialidad.FechaSalida = Convert.ToDateTime(reader["TF_FechaSalida"]);
                departamentoVialidad.CantidadDiasTotalesTramite = Convert.ToInt32(reader["TN_CantidadDiasTotalesTramite"]);
                departamentoVialidad.OficioRespuesta = reader["TC_OficioRespuesta"].ToString();
                departamentoVialidad.EstadoResultHojaEnvioGH = reader["TC_Nombre"].ToString();
            }

            sqlConnection.Close();


            return departamentoVialidad;
        }

        public DepartamentoPruebasMedicas getDepartamentoPruebasMedicas(string cedulaPI)
        {

            DepartamentoPruebasMedicas departamentoPruebasMedicas = new DepartamentoPruebasMedicas();

            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_Seleccionar_TMOGESP_PruebasMedicas @numeroDeCedula ", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@numeroDeCedula", cedulaPI);
            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();


            while (reader.Read())
            {
                departamentoPruebasMedicas.NumeroCedula = cedulaPI;
                departamentoPruebasMedicas.FechaIngresoAdministracion = Convert.ToDateTime(reader["TF_FechaIngresoAdministracion"]);
                departamentoPruebasMedicas.CantidadDiasAdministracion = Convert.ToInt32(reader["TN_CantidadDiasAdm"]);
                departamentoPruebasMedicas.FechaIngreso = Convert.ToDateTime(reader["TF_FechaIngreso"]);
                departamentoPruebasMedicas.OficioIngreso = reader["TC_OficioIngreso"].ToString();
                departamentoPruebasMedicas.FechaResultadoOCitaPM = Convert.ToDateTime(reader["TF_FechaResultadoOCitaPM"]);
                departamentoPruebasMedicas.DiasAlaFecha = Convert.ToInt32(reader["TN_DiasALaFecha"]);
                departamentoPruebasMedicas.FechaEnvioAPMdeGH = Convert.ToDateTime(reader["TF_FechaEnvioAPMdeGH"]);
                departamentoPruebasMedicas.FechaSalida = Convert.ToDateTime(reader["TF_FechaSalida"]);
                departamentoPruebasMedicas.CantidadDiasTotalesTramite = Convert.ToInt32(reader["TN_CantidadDiasTotalesTramite"]);
                departamentoPruebasMedicas.OficioRespuesta = reader["TC_OficioRespuesta"].ToString();
            }

            sqlConnection.Close();


            return departamentoPruebasMedicas;
        }
    }



}

