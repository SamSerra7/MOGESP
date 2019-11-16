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
        private DepartamentoPruebasMedicas departamentoPruebasMedicas;
        private DepartamentoVialidad departamentoVialidad;
        private DepartamentoAntecedentes departamentoAntecedentes;
        private DepartamentoPruebasGH departamentoPruebasGH;
        private DepartamentoToxicologia departamentoToxicologia;

        /* Obtiene la lista de estados de BD*/
        private List<string> getListaEstado()
        {
            List<string> listaEstados = new List<string>();
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"SELECT TC_Nombre FROM dbo.TMOGESP_ResultHojaEnvioGH", sqlConnection);
            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();


            while (reader.Read())
            {
                listaEstados.Add(reader["TC_Nombre"].ToString() ?? " ");
            }

            sqlConnection.Close();


            return listaEstados;
        }

        /*Ordena de manera que el primero es el estado que tiene la persona*/
        private List<string> ordenarListaEstado(List<string> listaEstado, string estado)
        {
            for (int aux = 0; aux < listaEstado.Count; aux++)
            {

                if (listaEstado[aux].Equals(estado))
                {
                    listaEstado[aux] = listaEstado[0];
                    listaEstado[0] = estado;
                }

            }

            return listaEstado;
        }

        private DepartamentoPruebasGH getDepartamentoPruebasGH(string cedulaPI)
        {
            departamentoPruebasGH = new DepartamentoPruebasGH();
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_Seleccionar_TMOGESP_PruebasGH @numeroDeCedula ", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@numeroDeCedula", cedulaPI);
            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();


            while (reader.Read())
            {
                departamentoPruebasGH.NumConcurso = reader["TC_NumeroConvocatoria"].ToString() ?? " ";
                departamentoPruebasGH.FechaIngresoAdministracion = (reader["TF_FechaIngresoAdministracion"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaIngresoAdministracion"]) : default;
                departamentoPruebasGH.CantidadDiasAdministracion = (reader["TN_CantidadDiasAdm"] != DBNull.Value) ? Convert.ToInt32(reader["TN_CantidadDiasAdm"]) : 0;
                departamentoPruebasGH.Ubicacion = reader["TC_Ubicacion"].ToString() ?? " ";
                departamentoPruebasGH.FechaIngreso = (reader["TF_FechaIngreso"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaIngreso"]) : default;
                departamentoPruebasGH.OficioIngreso = reader["TC_OficioIngreso"].ToString() ?? " ";
                departamentoPruebasGH.Oficio = reader["TC_Oficio"].ToString() ?? " ";
                departamentoPruebasGH.DiasAlaFecha = (reader["TN_DiasALaFecha"] != DBNull.Value) ? Convert.ToInt32(reader["TN_DiasALaFecha"]) : 0;
                departamentoPruebasGH.DiasALaFechaDeFechaLimiteSegunPlazo = (reader["TN_DiasALaFechaDeFechaLimiteSegunPlazo"] != DBNull.Value) ? Convert.ToInt32(reader["TN_DiasALaFechaDeFechaLimiteSegunPlazo"]) : 0;
                departamentoPruebasGH.FechaTrasladoPsicologosAdmin = (reader["TF_FechaTrasladoPsicologosAdm"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaTrasladoPsicologosAdm"]) : default;
                departamentoPruebasGH.FechaDevolucionGHDeAdmin = (reader["TF_FechaDevolucionGHDeAdm"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaDevolucionGHDeAdm"]) : default;
                departamentoPruebasGH.CantidadDiasPsicologiaAdmin = (reader["TN_CantidadDiasPsicologiaAdm"] != DBNull.Value) ? Convert.ToInt32(reader["TN_CantidadDiasPsicologiaAdm"]) : 0; 
                departamentoPruebasGH.FechaLimiteSegunPlazo = (reader["TF_FechaLimiteSegunPlazo"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaLimiteSegunPlazo"]) : default;
                departamentoPruebasGH.DiasALaFechaDeFechaLimiteSegunPlazo = (reader["TN_DiasALaFechaDeFechaLimiteSegunPlazo"] != DBNull.Value) ? Convert.ToInt32(reader["TN_DiasALaFechaDeFechaLimiteSegunPlazo"]) : 0;
                departamentoPruebasGH.DiasTramiteGHDespuesDevuelto = (reader["TN_DiasTramiteGHDespuesDevuelto"] != DBNull.Value) ? Convert.ToInt32(reader["TN_DiasTramiteGHDespuesDevuelto"]) : 0;
                departamentoPruebasGH.FechaSalida = (reader["TF_FechaSalida"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaSalida"]) : default;
                departamentoPruebasGH.CantidadDiasTotalesTramite = (reader["TN_CantidadDiasTotalesTramite"] != DBNull.Value) ? Convert.ToInt32(reader["TN_CantidadDiasTotalesTramite"]) : 0;
                departamentoPruebasGH.OficioRespuesta = reader["TC_OficioRespuesta"].ToString() ?? " ";
                departamentoPruebasGH.EstadoResultHojaEnvioGH = reader["TC_Nombre"].ToString() ?? " ";

            }

            sqlConnection.Close();

            departamentoPruebasGH.EstadoLista = ordenarListaEstado(getListaEstado(), departamentoPruebasGH.EstadoResultHojaEnvioGH);

            return departamentoPruebasGH;
        }

        private DepartamentoAntecedentes getDepartamentoAntecedentes(string cedulaPI)
        {
            departamentoAntecedentes = new DepartamentoAntecedentes();
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_Seleccionar_TMOGESP_Antecedentes @numeroDeCedula ", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@numeroDeCedula", cedulaPI);
            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();


            while (reader.Read())
            {
                departamentoAntecedentes.FechaIngresoAdministracion = (reader["TF_FechaIngresoAdministracion"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaIngresoAdministracion"]) : default; 
                departamentoAntecedentes.CantidadDiasAdministracion = (reader["TN_CantidadDiasAdm"] != DBNull.Value) ? Convert.ToInt32(reader["TN_CantidadDiasAdm"]) : 0; 
                departamentoAntecedentes.FechaIngreso = (reader["TF_FechaIngreso"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaIngreso"]) : default; 
                departamentoAntecedentes.OficioIngreso = reader["TC_OficioIngreso"].ToString() ?? " ";
                departamentoAntecedentes.DiasAlaFecha = (reader["TN_DiasALaFecha"] != DBNull.Value) ? Convert.ToInt32(reader["TN_DiasALaFecha"]) : 0; 
                departamentoAntecedentes.FechaResultado = (reader["TF_FechaFechaResultado"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaFechaResultado"]) : default; 
                departamentoAntecedentes.ZonaTrabajo = (reader["TN_ZonaDeTrabajo"] != DBNull.Value) ? Convert.ToInt32(reader["TN_ZonaDeTrabajo"]) : 0; 
                departamentoAntecedentes.FechaSalida = (reader["TF_FechaSalida"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaSalida"]) : default; 
                departamentoAntecedentes.CantidadDiasTotalesTramite = (reader["TN_CantidadDiasTotalesTramite"] != DBNull.Value) ? Convert.ToInt32(reader["TN_CantidadDiasTotalesTramite"]) : 0;
                departamentoAntecedentes.OficioRespuesta = reader["TC_OficioRespuesta"].ToString() ?? " ";
                departamentoAntecedentes.EstadoResultHojaEnvioGH = reader["TC_Nombre"].ToString() ?? " ";
            }
            sqlConnection.Close();

            departamentoAntecedentes.EstadoLista = ordenarListaEstado(getListaEstado(), departamentoAntecedentes.EstadoResultHojaEnvioGH);

            return departamentoAntecedentes;
        }

        private DepartamentoVialidad getDepartamentoVialidad(string cedulaPI)
        {
            departamentoVialidad = new DepartamentoVialidad();
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_Seleccionar_TMOGESP_Vialidad @numeroDeCedula ", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@numeroDeCedula", cedulaPI);
            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();


            while (reader.Read())
            {
                departamentoVialidad.FechaIngresoAdministracion = (reader["TF_FechaIngresoAdministracion"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaIngresoAdministracion"]) : default; 
                departamentoVialidad.CantidadDiasAdministracion = (reader["TN_CantidadDiasAdm"] != DBNull.Value) ? Convert.ToInt32(reader["TN_CantidadDiasAdm"]) : 0; 
                departamentoVialidad.FechaIngreso = (reader["TF_FechaIngresoTransportes"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaIngresoTransportes"]) : default; 
                departamentoVialidad.DiasParaCita = (reader["TN_DiasParaCita"] != DBNull.Value) ? Convert.ToInt32(reader["TN_DiasParaCita"]) : 0;
                departamentoVialidad.OficioIngreso = reader["TC_OficioIngreso"].ToString() ?? " ";
                departamentoVialidad.FechaCita = (reader["TF_FechaFechaCita"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaFechaCita"]) : default; 
                departamentoVialidad.FechaSalida = (reader["TF_FechaSalida"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaSalida"]) : default; 
                departamentoVialidad.CantidadDiasTotalesTramite = (reader["TN_CantidadDiasTotalesTramite"] != DBNull.Value) ? Convert.ToInt32(reader["TN_CantidadDiasTotalesTramite"]) : 0; 
                departamentoVialidad.OficioRespuesta = reader["TC_OficioRespuesta"].ToString() ?? " ";
                departamentoVialidad.EstadoResultHojaEnvioGH = reader["TC_Nombre"].ToString() ?? " ";
            }

            sqlConnection.Close();

            departamentoVialidad.EstadoLista = ordenarListaEstado(getListaEstado(), departamentoVialidad.EstadoResultHojaEnvioGH);

            return departamentoVialidad;
        }

        private DepartamentoPruebasMedicas getDepartamentoPruebasMedicas(string cedulaPI)
        {
            departamentoPruebasMedicas = new DepartamentoPruebasMedicas();
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_Seleccionar_TMOGESP_PruebasMedicas @numeroDeCedula ", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@numeroDeCedula", cedulaPI);
            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();


            while (reader.Read())
            {
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

        private DepartamentoToxicologia getDepartamentoToxicologia(string cedulaPI)
        {
            departamentoToxicologia = new DepartamentoToxicologia();
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_Seleccionar_TMOGESP_Toxicologia @numeroDeCedula ", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@numeroDeCedula", cedulaPI);
            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();


            while (reader.Read())
            {
                departamentoToxicologia.FechaIngresoAdministracion = Convert.ToDateTime(reader["TF_FechaIngresoAdministracion"]);
                departamentoToxicologia.CantidadDiasAdministracion = Convert.ToInt32(reader["TN_CantidadDiasAdm"]);
                departamentoToxicologia.FechaIngreso = Convert.ToDateTime(reader["TF_FechaIngreso"]);
                departamentoToxicologia.OficioIngreso = reader["TC_OficioIngreso"].ToString();
                departamentoToxicologia.FechaCita = Convert.ToDateTime(reader["TF_FechaCita"]);
                departamentoToxicologia.DiasAlaFecha = Convert.ToInt32(reader["TN_DiasALaFecha"]);
                departamentoToxicologia.DiasParaCita = Convert.ToInt32(reader["TN_DiasParaCita"]);
                departamentoToxicologia.FechaSalida = Convert.ToDateTime(reader["TF_FechaSalida"]);
                departamentoToxicologia.CantidadDiasTotalesTramite = Convert.ToInt32(reader["TN_CantidadDiasTotalesTramite"]);
                departamentoToxicologia.OficioRespuesta = reader["TC_OficioRespuesta"].ToString();
                departamentoToxicologia.FechaEstado = Convert.ToDateTime(reader["TF_FechaEstado"]);
                departamentoToxicologia.FechaEstadoCantDias = Convert.ToInt32(reader["TN_FechaEstadoCantDias"]);
            }

            sqlConnection.Close();

            return departamentoToxicologia;
        }

        public PrimerIngresoDepartamentos getPrimerIngresoDepartamentos(string nombrePI = "", string cedulaPI = "")
        {

            PrimerIngresoDepartamentos primerIngresoDepartamentos = new PrimerIngresoDepartamentos();

            primerIngresoDepartamentos.NumeroCedula = cedulaPI;
            primerIngresoDepartamentos.NombrePI = nombrePI;
            primerIngresoDepartamentos.DepartamentoAntecedentes = getDepartamentoAntecedentes(cedulaPI);
            primerIngresoDepartamentos.DepartamentoPruebasGH = getDepartamentoPruebasGH(cedulaPI);
            // primerIngresoDepartamentos.DepartamentoPruebasMedicas = getDepartamentoPruebasMedicas(cedulaPI);
            //primerIngresoDepartamentos.DepartamentoToxicologia = getDepartamentoToxicologia(cedulaPI);
            primerIngresoDepartamentos.DepartamentoVialidad = getDepartamentoVialidad(cedulaPI);

            return primerIngresoDepartamentos;
        }

        public void actualizarPruebasGH(DepartamentoPruebasGH departamentoPruebasGH, string cedulaPI)
        {

            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand actualizarPruebasGH = new SqlCommand(@"EXEC PA_ActualizaTMOGESP_PruebasGH 
                                            @numeroDeCedula,
											@TF_FechaIngresoAdministracion,
											@TN_CantidadDiasAdm,
											@TC_Ubicacion,
											@TF_FechaIngreso,
											@TC_OficioIngreso,
											@TN_DiasALaFecha,
											@TF_FechaTrasladoPsicologosAdm,
											@TC_Oficio,
											@TF_FechaDevolucionGHDeAdm,
											@TN_CantidadDiasPsicologiaAdm,
											@TF_FechaLimiteSegunPlazo,
											@TN_DiasALaFechaDeFechaLimiteSegunPlazo,
											@TN_DiasTramiteGHDespuesDevuelto,
											@TF_FechaSalida,
											@TN_CantidadDiasTotalesTramite,
											@TC_OficioRespuesta,
											@TN_EstadoResultHojaEnvioGH", sqlConnection);


            actualizarPruebasGH.Parameters.AddWithValue("@numeroDeCedula", cedulaPI);
            actualizarPruebasGH.Parameters.AddWithValue("@TF_FechaIngresoAdministracion", departamentoPruebasGH.FechaIngresoAdministracion);
            actualizarPruebasGH.Parameters.AddWithValue("@TN_CantidadDiasAdm", departamentoPruebasGH.CantidadDiasAdministracion);
            actualizarPruebasGH.Parameters.AddWithValue("@TC_Ubicacion", departamentoPruebasGH.Ubicacion);
            actualizarPruebasGH.Parameters.AddWithValue("@TF_FechaIngreso", departamentoPruebasGH.FechaIngreso);
            actualizarPruebasGH.Parameters.AddWithValue("@TC_OficioIngreso", departamentoPruebasGH.OficioIngreso);
            actualizarPruebasGH.Parameters.AddWithValue("@TN_DiasALaFecha", departamentoPruebasGH.DiasAlaFecha);
            actualizarPruebasGH.Parameters.AddWithValue("@TF_FechaTrasladoPsicologosAdm", departamentoPruebasGH.FechaTrasladoPsicologosAdmin);
            actualizarPruebasGH.Parameters.AddWithValue("@TC_Oficio", departamentoPruebasGH.Oficio);
            actualizarPruebasGH.Parameters.AddWithValue("@TF_FechaDevolucionGHDeAdm", departamentoPruebasGH.FechaDevolucionGHDeAdmin);
            actualizarPruebasGH.Parameters.AddWithValue("@TN_CantidadDiasPsicologiaAdm", departamentoPruebasGH.CantidadDiasPsicologiaAdmin);
            actualizarPruebasGH.Parameters.AddWithValue("@TF_FechaLimiteSegunPlazo", departamentoPruebasGH.FechaLimiteSegunPlazo);
            actualizarPruebasGH.Parameters.AddWithValue("@TN_DiasALaFechaDeFechaLimiteSegunPlazo", departamentoPruebasGH.DiasALaFechaDeFechaLimiteSegunPlazo);
            actualizarPruebasGH.Parameters.AddWithValue("@TN_DiasTramiteGHDespuesDevuelto", departamentoPruebasGH.DiasTramiteGHDespuesDevuelto);
            actualizarPruebasGH.Parameters.AddWithValue("@TF_FechaSalida", departamentoPruebasGH.FechaSalida);
            actualizarPruebasGH.Parameters.AddWithValue("@TN_CantidadDiasTotalesTramite", departamentoPruebasGH.CantidadDiasTotalesTramite);
            actualizarPruebasGH.Parameters.AddWithValue("@TC_OficioRespuesta", departamentoPruebasGH.OficioRespuesta);
            actualizarPruebasGH.Parameters.AddWithValue("@TN_EstadoResultHojaEnvioGH", departamentoPruebasGH.EstadoResultHojaEnvioGH);

            sqlConnection.Open();
            actualizarPruebasGH.ExecuteReader();

            sqlConnection.Close();
            actualizarPruebasGH.Dispose();
        }

    }



}

