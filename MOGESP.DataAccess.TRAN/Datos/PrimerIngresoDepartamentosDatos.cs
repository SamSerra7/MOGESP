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

        private string getNombrePrimerIngreso(string cedula)
        {
            string nombreCompleto = "";
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"SELECT TC_Nombre, TC_PrimerApellido, TC_SegundoApellido FROM dbo.TMOGESP_PrimerIngreso WHERE (TC_NumeroCedula = @numeroDeCedula)", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@numeroDeCedula", cedula);
            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                nombreCompleto = reader["TC_Nombre"].ToString() ?? " ";
                nombreCompleto += " " + reader["TC_PrimerApellido"].ToString() ?? " ";
                nombreCompleto += " " + reader["TC_SegundoApellido"].ToString() ?? " ";
            }

            sqlConnection.Close();


            return nombreCompleto;
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

        private DepartamentoPruebasGH getDepartamentoPruebasGH(string cedula)
        {
            departamentoPruebasGH = new DepartamentoPruebasGH();
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_Seleccionar_TMOGESP_PruebasGH @numeroDeCedula ", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@numeroDeCedula", cedula);
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

        private DepartamentoAntecedentes getDepartamentoAntecedentes(string cedula)
        {
            departamentoAntecedentes = new DepartamentoAntecedentes();
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_Seleccionar_TMOGESP_Antecedentes @numeroDeCedula ", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@numeroDeCedula", cedula);
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

        private DepartamentoVialidad getDepartamentoVialidad(string cedula)
        {
            departamentoVialidad = new DepartamentoVialidad();
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_Seleccionar_TMOGESP_Vialidad @numeroDeCedula ", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@numeroDeCedula", cedula);
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

        private DepartamentoPruebasMedicas getDepartamentoPruebasMedicas(string cedula)
        {
            departamentoPruebasMedicas = new DepartamentoPruebasMedicas();
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_Seleccionar_TMOGESP_PruebasMedicas @numeroDeCedula ", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@numeroDeCedula", cedula);
            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();


            while (reader.Read())
            {
                departamentoPruebasMedicas.FechaIngresoAdministracion = (reader["TF_FechaIngresoAdministracion"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaIngresoAdministracion"]) : default; 
                departamentoPruebasMedicas.CantidadDiasAdministracion = (reader["TN_CantidadDiasAdm"] != DBNull.Value) ? Convert.ToInt32(reader["TN_CantidadDiasAdm"]) : 0; 
                departamentoPruebasMedicas.FechaIngreso = (reader["TF_FechaIngreso"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaIngreso"]) : default;
                departamentoPruebasMedicas.OficioIngreso = reader["TC_OficioIngreso"].ToString() ?? " ";
                departamentoPruebasMedicas.FechaResultadoOCitaPM = (reader["TF_FechaResultadoOCitaPM"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaResultadoOCitaPM"]) : default; 
                departamentoPruebasMedicas.DiasAlaFecha = (reader["TN_DiasALaFecha"] != DBNull.Value) ? Convert.ToInt32(reader["TN_DiasALaFecha"]) : 0; 
                departamentoPruebasMedicas.FechaEnvioAPMdeGH = (reader["TF_FechaEnvioAPMdeGH"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaEnvioAPMdeGH"]) : default; 
                departamentoPruebasMedicas.FechaSalida = (reader["TF_FechaSalida"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaSalida"]) : default; 
                departamentoPruebasMedicas.CantidadDiasTotalesTramite = (reader["TN_CantidadDiasTotalesTramite"] != DBNull.Value) ? Convert.ToInt32(reader["TN_CantidadDiasTotalesTramite"]) : 0; 
                departamentoPruebasMedicas.OficioRespuesta = reader["TC_OficioRespuesta"].ToString() ?? " ";
            }

            sqlConnection.Close();

            return departamentoPruebasMedicas;
        }

        private DepartamentoToxicologia getDepartamentoToxicologia(string cedula)
        {
            departamentoToxicologia = new DepartamentoToxicologia();
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_Seleccionar_TMOGESP_Toxicologia @numeroDeCedula ", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@numeroDeCedula", cedula);
            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();


            while (reader.Read())
            {
                departamentoToxicologia.FechaIngresoAdministracion = (reader["TF_FechaIngresoAdministracion"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaIngresoAdministracion"]) : default; 
                departamentoToxicologia.CantidadDiasAdministracion = (reader["TN_CantidadDiasAdm"] != DBNull.Value) ? Convert.ToInt32(reader["TN_CantidadDiasAdm"]) : 0;
                departamentoToxicologia.FechaIngreso = (reader["TF_FechaIngreso"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaIngreso"]) : default;
                departamentoToxicologia.OficioIngreso = reader["TC_OficioIngreso"].ToString() ?? " ";
                departamentoToxicologia.FechaCita = (reader["TF_FechaCita"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaCita"]) : default; 
                departamentoToxicologia.DiasAlaFecha = (reader["TN_DiasALaFecha"] != DBNull.Value) ? Convert.ToInt32(reader["TN_DiasALaFecha"]) : 0;
                departamentoToxicologia.DiasParaCita = (reader["TN_DiasParaCita"] != DBNull.Value) ? Convert.ToInt32(reader["TN_DiasParaCita"]) : 0;
                departamentoToxicologia.FechaSalida = (reader["TF_FechaSalida"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaSalida"]) : default; 
                departamentoToxicologia.CantidadDiasTotalesTramite = (reader["TN_CantidadDiasTotalesTramite"] != DBNull.Value) ? Convert.ToInt32(reader["TN_CantidadDiasTotalesTramite"]) : 0; 
                departamentoToxicologia.OficioRespuesta = reader["TC_OficioRespuesta"].ToString() ?? " ";
                departamentoToxicologia.FechaEstado = (reader["TF_FechaEstado"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaEstado"]) : default; 
                departamentoToxicologia.FechaEstadoCantDias = (reader["TN_FechaEstadoCantDias"] != DBNull.Value) ? Convert.ToInt32(reader["TN_FechaEstadoCantDias"]) : 0; 
            }

            sqlConnection.Close();

            return departamentoToxicologia;
        }

        public PrimerIngresoDepartamentos getPrimerIngresoDepartamentos(string cedulaPrimerIngreso = "")
        {

            PrimerIngresoDepartamentos primerIngresoDepartamentos = new PrimerIngresoDepartamentos();

            primerIngresoDepartamentos.NumeroCedula = cedulaPrimerIngreso;
            primerIngresoDepartamentos.Nombre = getNombrePrimerIngreso(cedulaPrimerIngreso);
            primerIngresoDepartamentos.DepartamentoAntecedentes = getDepartamentoAntecedentes(cedulaPrimerIngreso);
            primerIngresoDepartamentos.DepartamentoPruebasGH = getDepartamentoPruebasGH(cedulaPrimerIngreso);
            primerIngresoDepartamentos.DepartamentoPruebasMedicas = getDepartamentoPruebasMedicas(cedulaPrimerIngreso);
            primerIngresoDepartamentos.DepartamentoToxicologia = getDepartamentoToxicologia(cedulaPrimerIngreso);
            primerIngresoDepartamentos.DepartamentoVialidad = getDepartamentoVialidad(cedulaPrimerIngreso);

            return primerIngresoDepartamentos;
        }

        public void actualizarPruebasGH(DepartamentoPruebasGH departamentoPruebasGH, string cedula)
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

            string format = "yyyy-MM-dd HH:mm:ss";
            actualizarPruebasGH.Parameters.AddWithValue("@numeroDeCedula", cedula);
            actualizarPruebasGH.Parameters.AddWithValue("@TF_FechaIngresoAdministracion", DateTime.Parse(
                departamentoPruebasGH.FechaIngresoAdministracion.ToString(format)));
            actualizarPruebasGH.Parameters.AddWithValue("@TN_CantidadDiasAdm", departamentoPruebasGH.CantidadDiasAdministracion);
            actualizarPruebasGH.Parameters.AddWithValue("@TC_Ubicacion", departamentoPruebasGH.Ubicacion);
            actualizarPruebasGH.Parameters.AddWithValue("@TF_FechaIngreso", DateTime.Parse(
                departamentoPruebasGH.FechaIngreso.ToString(format)));
            actualizarPruebasGH.Parameters.AddWithValue("@TC_OficioIngreso", departamentoPruebasGH.OficioIngreso);
            actualizarPruebasGH.Parameters.AddWithValue("@TN_DiasALaFecha", departamentoPruebasGH.DiasAlaFecha);
            actualizarPruebasGH.Parameters.AddWithValue("@TF_FechaTrasladoPsicologosAdm", DateTime.Parse(
                departamentoPruebasGH.FechaTrasladoPsicologosAdmin.ToString(format)));
            actualizarPruebasGH.Parameters.AddWithValue("@TC_Oficio", departamentoPruebasGH.Oficio);
            actualizarPruebasGH.Parameters.AddWithValue("@TF_FechaDevolucionGHDeAdm", DateTime.Parse(
                departamentoPruebasGH.FechaDevolucionGHDeAdmin.ToString(format)));
            actualizarPruebasGH.Parameters.AddWithValue("@TN_CantidadDiasPsicologiaAdm", departamentoPruebasGH.CantidadDiasPsicologiaAdmin);
            actualizarPruebasGH.Parameters.AddWithValue("@TF_FechaLimiteSegunPlazo", DateTime.Parse(
                departamentoPruebasGH.FechaLimiteSegunPlazo.ToString(format)));
            actualizarPruebasGH.Parameters.AddWithValue("@TN_DiasALaFechaDeFechaLimiteSegunPlazo", departamentoPruebasGH.DiasALaFechaDeFechaLimiteSegunPlazo);
            actualizarPruebasGH.Parameters.AddWithValue("@TN_DiasTramiteGHDespuesDevuelto", departamentoPruebasGH.DiasTramiteGHDespuesDevuelto);
            actualizarPruebasGH.Parameters.AddWithValue("@TF_FechaSalida", DateTime.Parse(
                departamentoPruebasGH.FechaSalida.ToString(format)));
            actualizarPruebasGH.Parameters.AddWithValue("@TN_CantidadDiasTotalesTramite", departamentoPruebasGH.CantidadDiasTotalesTramite);
            actualizarPruebasGH.Parameters.AddWithValue("@TC_OficioRespuesta", departamentoPruebasGH.OficioRespuesta);
            actualizarPruebasGH.Parameters.AddWithValue("@TN_EstadoResultHojaEnvioGH", departamentoPruebasGH.EstadoResultHojaEnvioGH);

            sqlConnection.Open();
            actualizarPruebasGH.ExecuteReader();

            sqlConnection.Close();
            actualizarPruebasGH.Dispose();
        }

        public void actualizarAntecedentes(DepartamentoAntecedentes departamentoAntecedentes, string cedula)
        {

            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand actualizarAntecedentes = new SqlCommand(@"EXEC PA_ActualizaTMOGESP_PruebasGH 
                                            @numeroDeCedula,
											@TF_FechaIngreso,
											@TN_CantidadDiasAdm,
											@TF_FechaIngresoTransportes,
											@TC_OficioIngreso,
											@TN_DiasALaFecha,
                                            @TF_FechaFechaResultado,
                                            @TN_ZonaDeTrabajo,
											@TF_FechaSalida,
											@TN_CantidadDiasTotalesTramite,
											@TC_OficioRespuesta,
											@TN_EstadoResultHojaEnvioGH", sqlConnection);


            actualizarAntecedentes.Parameters.AddWithValue("@numeroDeCedula", cedula);
            actualizarAntecedentes.Parameters.AddWithValue("@TF_FechaIngresoAdministracion", departamentoAntecedentes.FechaIngresoAdministracion);
            actualizarAntecedentes.Parameters.AddWithValue("@TN_CantidadDiasAdm", departamentoAntecedentes.CantidadDiasAdministracion);
            actualizarAntecedentes.Parameters.AddWithValue("@TF_FechaIngreso", departamentoAntecedentes.FechaIngreso);
            actualizarAntecedentes.Parameters.AddWithValue("@TC_OficioIngreso", departamentoAntecedentes.OficioIngreso);
            actualizarAntecedentes.Parameters.AddWithValue("@TN_DiasALaFecha", departamentoAntecedentes.DiasAlaFecha);
            actualizarAntecedentes.Parameters.AddWithValue("@TF_FechaFechaResultado", departamentoAntecedentes.FechaResultado);
            actualizarAntecedentes.Parameters.AddWithValue("@TN_ZonaDeTrabajo", departamentoAntecedentes.ZonaTrabajo);
            actualizarAntecedentes.Parameters.AddWithValue("@TF_FechaSalida", departamentoAntecedentes.FechaSalida);
            actualizarAntecedentes.Parameters.AddWithValue("@TN_CantidadDiasTotalesTramite", departamentoAntecedentes.CantidadDiasTotalesTramite);
            actualizarAntecedentes.Parameters.AddWithValue("@TC_OficioRespuesta", departamentoAntecedentes.OficioRespuesta);
            actualizarAntecedentes.Parameters.AddWithValue("@TN_EstadoResultHojaEnvioGH", departamentoAntecedentes.EstadoResultHojaEnvioGH);

            sqlConnection.Open();
            actualizarAntecedentes.ExecuteReader();

            sqlConnection.Close();
            actualizarAntecedentes.Dispose();

        }

        public void actualizarVialidad(DepartamentoVialidad departamentoVialidad, string cedula)
        {

            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand actualizarVialidad = new SqlCommand(@"EXEC PA_ActualizaTMOGESP_PruebasGH 
                                            @numeroDeCedula,
											@TF_FechaIngresoAdministracion,
											@TN_CantidadDiasAdm,
											@TF_FechaIngresoTransportes,
											@TC_OficioIngreso,
											@TF_FechaFechaCita,
                                            @TN_DiasParaCita,
											@TF_FechaSalida,
											@TN_CantidadDiasTotalesTramite,
											@TC_OficioRespuesta,
											@TN_EstadoResultHojaEnvioGH", sqlConnection);

            actualizarVialidad.Parameters.AddWithValue("@numeroDeCedula", cedula);
            actualizarVialidad.Parameters.AddWithValue("@TF_FechaIngresoAdministracion", departamentoVialidad.FechaIngresoAdministracion);
            actualizarVialidad.Parameters.AddWithValue("@TN_CantidadDiasAdm", departamentoVialidad.CantidadDiasAdministracion);
            actualizarVialidad.Parameters.AddWithValue("@TF_FechaIngresoTransportes", departamentoVialidad.FechaIngreso);
            actualizarVialidad.Parameters.AddWithValue("@TC_OficioIngreso", departamentoVialidad.OficioIngreso);
            actualizarVialidad.Parameters.AddWithValue("@TF_FechaFechaCita", departamentoVialidad.FechaCita);
            actualizarVialidad.Parameters.AddWithValue("@TN_DiasParaCita", departamentoVialidad.DiasParaCita);
            actualizarVialidad.Parameters.AddWithValue("@TF_FechaSalida", departamentoVialidad.FechaSalida);
            actualizarVialidad.Parameters.AddWithValue("@TN_CantidadDiasTotalesTramite", departamentoVialidad.CantidadDiasTotalesTramite);
            actualizarVialidad.Parameters.AddWithValue("@TC_OficioRespuesta", departamentoVialidad.OficioRespuesta);
            actualizarVialidad.Parameters.AddWithValue("@TN_EstadoResultHojaEnvioGH", departamentoVialidad.EstadoResultHojaEnvioGH);

            sqlConnection.Open();
            actualizarVialidad.ExecuteReader();

            sqlConnection.Close();
            actualizarVialidad.Dispose();

        }

        public void actualizarPruebasMedicas(DepartamentoPruebasMedicas departamentoPruebasMedicas, string cedula)
        {

            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand actualizarPruebasMedicas = new SqlCommand(@"EXEC PA_ActualizaTMOGESP_PruebasGH 
                                            @numeroDeCedula,
											@TF_FechaIngresoAdministracion,
											@TN_CantidadDiasAdm,
											@TF_FechaIngreso,
											@TC_OficioIngreso,
                                            @TF_FechaEnvioAPMdeGH,
											@TF_FechaResultadoOCitaPM,
											@TF_FechaSalida,
                                            @TN_DiasALaFecha,
											@TN_CantidadDiasTotalesTramite,
											@TC_OficioRespuesta", sqlConnection);

            actualizarPruebasMedicas.Parameters.AddWithValue("@numeroDeCedula", cedula);
            actualizarPruebasMedicas.Parameters.AddWithValue("@TF_FechaIngresoAdministracion", departamentoPruebasMedicas.FechaIngresoAdministracion);
            actualizarPruebasMedicas.Parameters.AddWithValue("@TN_CantidadDiasAdm", departamentoPruebasMedicas.CantidadDiasAdministracion);
            actualizarPruebasMedicas.Parameters.AddWithValue("@TF_FechaIngreso", departamentoPruebasMedicas.FechaIngreso);
            actualizarPruebasMedicas.Parameters.AddWithValue("@TC_OficioIngreso", departamentoPruebasMedicas.OficioIngreso);
            actualizarPruebasMedicas.Parameters.AddWithValue("@TF_FechaEnvioAPMdeGH", departamentoPruebasMedicas.FechaEnvioAPMdeGH);
            actualizarPruebasMedicas.Parameters.AddWithValue("@TF_FechaResultadoOCitaPM", departamentoPruebasMedicas.FechaResultadoOCitaPM);
            actualizarPruebasMedicas.Parameters.AddWithValue("@TN_DiasALaFecha", departamentoPruebasMedicas.DiasAlaFecha);
            actualizarPruebasMedicas.Parameters.AddWithValue("@TF_FechaSalida", departamentoPruebasMedicas.FechaSalida);
            actualizarPruebasMedicas.Parameters.AddWithValue("@TN_CantidadDiasTotalesTramite", departamentoPruebasMedicas.CantidadDiasTotalesTramite);
            actualizarPruebasMedicas.Parameters.AddWithValue("@TC_OficioRespuesta", departamentoPruebasMedicas.OficioRespuesta);

            sqlConnection.Open();
            actualizarPruebasMedicas.ExecuteReader();

            sqlConnection.Close();
            actualizarPruebasMedicas.Dispose();

        }

        public void actualizarToxicologia(DepartamentoToxicologia departamentoToxicologia, string cedula)
        {

            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand actualizarToxicologia = new SqlCommand(@"EXEC PA_ActualizaTMOGESP_PruebasGH 
                                            @numeroDeCedula,
											@TF_FechaIngresoAdministracion,
											@TN_CantidadDiasAdm,
											@TF_FechaIngreso,
											@TC_OficioIngreso,
                                            @TF_FechaCita,
                                            @TN_DiasParaCita,
											@TF_FechaSalida,
                                            @TN_DiasALaFecha,
											@TN_CantidadDiasTotalesTramite,
											@TC_OficioRespuesta,
											@TF_FechaEstado,
                                            @TN_FechaEstadoCantDias", sqlConnection);

            actualizarToxicologia.Parameters.AddWithValue("@numeroDeCedula", cedula);
            actualizarToxicologia.Parameters.AddWithValue("@TF_FechaIngresoAdministracion", departamentoToxicologia.FechaIngresoAdministracion);
            actualizarToxicologia.Parameters.AddWithValue("@TN_CantidadDiasAdm", departamentoToxicologia.CantidadDiasAdministracion);
            actualizarToxicologia.Parameters.AddWithValue("@TF_FechaIngreso", departamentoToxicologia.FechaIngreso);
            actualizarToxicologia.Parameters.AddWithValue("@TC_OficioIngreso", departamentoToxicologia.OficioIngreso);
            actualizarToxicologia.Parameters.AddWithValue("@TF_FechaCita", departamentoToxicologia.FechaCita);
            actualizarToxicologia.Parameters.AddWithValue("@TN_DiasParaCita", departamentoToxicologia.DiasParaCita);
            actualizarToxicologia.Parameters.AddWithValue("@TN_DiasALaFecha", departamentoToxicologia.DiasAlaFecha);
            actualizarToxicologia.Parameters.AddWithValue("@TF_FechaSalida", departamentoToxicologia.FechaSalida);
            actualizarToxicologia.Parameters.AddWithValue("@TN_CantidadDiasTotalesTramite", departamentoToxicologia.CantidadDiasTotalesTramite);
            actualizarToxicologia.Parameters.AddWithValue("@TC_OficioRespuesta", departamentoToxicologia.OficioRespuesta);
            actualizarToxicologia.Parameters.AddWithValue("@TF_FechaEstado", departamentoToxicologia.FechaEstado);
            actualizarToxicologia.Parameters.AddWithValue("@TN_FechaEstadoCantDias", departamentoToxicologia.FechaEstadoCantDias);

            sqlConnection.Open();
            actualizarToxicologia.ExecuteReader();

            sqlConnection.Close();
            actualizarToxicologia.Dispose();

        }


    }



}

