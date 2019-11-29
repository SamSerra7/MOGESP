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
                departamentoPruebasGH.FechaIngresoAdministracion = (reader["TF_FechaIngresoAdministracion"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaIngresoAdministracion"]) : DateTime.Parse("12-31-1999");
                departamentoPruebasGH.CantidadDiasAdministracion = (reader["TN_CantidadDiasAdm"] != DBNull.Value) ? Convert.ToInt32(reader["TN_CantidadDiasAdm"]) : 0;
                departamentoPruebasGH.Ubicacion = reader["TC_Ubicacion"].ToString() ?? " ";
                departamentoPruebasGH.FechaIngreso = (reader["TF_FechaIngreso"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaIngreso"]) : DateTime.Parse("12-31-1999");
                departamentoPruebasGH.Oficio = reader["TC_Oficio"].ToString() ?? " ";
                departamentoPruebasGH.DiasAlaFecha = (reader["TN_DiasALaFecha"] != DBNull.Value) ? Convert.ToInt32(reader["TN_DiasALaFecha"]) : 0;
                departamentoPruebasGH.OficioIngreso = reader["TC_OficioIngreso"].ToString() ?? " ";
                departamentoPruebasGH.FechaTrasladoPsicologosAdmin = (reader["TF_FechaTrasladoPsicologosAdm"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaTrasladoPsicologosAdm"]) : DateTime.Parse("12-31-1999");
                departamentoPruebasGH.FechaDevolucionGHDeAdmin = (reader["TF_FechaDevolucionGHDeAdm"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaDevolucionGHDeAdm"]) : DateTime.Parse("12-31-1999");
                departamentoPruebasGH.CantidadDiasPsicologiaAdmin = (reader["TN_CantidadDiasPsicologiaAdm"] != DBNull.Value) ? Convert.ToInt32(reader["TN_CantidadDiasPsicologiaAdm"]) : 0; 
                departamentoPruebasGH.FechaLimiteSegunPlazo = (reader["TF_FechaLimiteSegunPlazo"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaLimiteSegunPlazo"]) : DateTime.Parse("12-31-1999");
                departamentoPruebasGH.DiasALaFechaDeFechaLimiteSegunPlazo = (reader["TN_DiasALaFechaDeFechaLimiteSegunPlazo"] != DBNull.Value) ? Convert.ToInt32(reader["TN_DiasALaFechaDeFechaLimiteSegunPlazo"]) : 0;
                departamentoPruebasGH.DiasTramiteGHDespuesDevuelto = (reader["TN_DiasTramiteGHDespuesDevuelto"] != DBNull.Value) ? Convert.ToInt32(reader["TN_DiasTramiteGHDespuesDevuelto"]) : 0;
                departamentoPruebasGH.FechaSalida = (reader["TF_FechaSalida"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaSalida"]) : DateTime.Parse("12-31-1999");
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
                departamentoAntecedentes.FechaIngresoAdministracion = (reader["TF_FechaIngresoAdministracion"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaIngresoAdministracion"]) : DateTime.Parse("12-31-1999");
                departamentoAntecedentes.CantidadDiasAdministracion = (reader["TN_CantidadDiasAdm"] != DBNull.Value) ? Convert.ToInt32(reader["TN_CantidadDiasAdm"]) : 0; 
                departamentoAntecedentes.FechaIngreso = (reader["TF_FechaIngreso"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaIngreso"]) : DateTime.Parse("12-31-1999");
                departamentoAntecedentes.OficioIngreso = reader["TC_OficioIngreso"].ToString() ?? " ";
                departamentoAntecedentes.DiasAlaFecha = (reader["TN_DiasALaFecha"] != DBNull.Value) ? Convert.ToInt32(reader["TN_DiasALaFecha"]) : 0; 
                departamentoAntecedentes.FechaResultado = (reader["TF_FechaFechaResultado"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaFechaResultado"]) : DateTime.Parse("12-31-1999");
                departamentoAntecedentes.ZonaTrabajo = (reader["TN_ZonaDeTrabajo"] != DBNull.Value) ? Convert.ToInt32(reader["TN_ZonaDeTrabajo"]) : 0; 
                departamentoAntecedentes.FechaSalida = (reader["TF_FechaSalida"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaSalida"]) : DateTime.Parse("12-31-1999");
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
                departamentoVialidad.FechaIngresoAdministracion = (reader["TF_FechaIngresoAdministracion"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaIngresoAdministracion"]) : DateTime.Parse("12-31-1999");
                departamentoVialidad.CantidadDiasAdministracion = (reader["TN_CantidadDiasAdm"] != DBNull.Value) ? Convert.ToInt32(reader["TN_CantidadDiasAdm"]) : 0; 
                departamentoVialidad.FechaIngreso = (reader["TF_FechaIngresoTransportes"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaIngresoTransportes"]) : DateTime.Parse("12-31-1999");
                departamentoVialidad.DiasParaCita = (reader["TN_DiasParaCita"] != DBNull.Value) ? Convert.ToInt32(reader["TN_DiasParaCita"]) : 0;
                departamentoVialidad.OficioIngreso = reader["TC_OficioIngreso"].ToString() ?? " ";
                departamentoVialidad.FechaCita = (reader["TF_FechaFechaCita"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaFechaCita"]) : DateTime.Parse("12-31-1999");
                departamentoVialidad.FechaSalida = (reader["TF_FechaSalida"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaSalida"]) : DateTime.Parse("12-31-1999");
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
                departamentoPruebasMedicas.FechaIngresoAdministracion = (reader["TF_FechaIngresoAdministracion"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaIngresoAdministracion"]) : DateTime.Parse("12-31-1999");
                departamentoPruebasMedicas.CantidadDiasAdministracion = (reader["TN_CantidadDiasAdm"] != DBNull.Value) ? Convert.ToInt32(reader["TN_CantidadDiasAdm"]) : 0; 
                departamentoPruebasMedicas.FechaIngreso = (reader["TF_FechaIngreso"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaIngreso"]) : DateTime.Parse("12-31-1999");
                departamentoPruebasMedicas.OficioIngreso = reader["TC_OficioIngreso"].ToString() ?? " ";
                departamentoPruebasMedicas.FechaResultadoOCitaPM = (reader["TF_FechaResultadoOCitaPM"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaResultadoOCitaPM"]) : DateTime.Parse("12-31-1999");
                departamentoPruebasMedicas.DiasAlaFecha = (reader["TN_DiasALaFecha"] != DBNull.Value) ? Convert.ToInt32(reader["TN_DiasALaFecha"]) : 0; 
                departamentoPruebasMedicas.FechaEnvioAPMdeGH = (reader["TF_FechaEnvioAPMdeGH"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaEnvioAPMdeGH"]) : DateTime.Parse("12-31-1999");
                departamentoPruebasMedicas.FechaSalida = (reader["TF_FechaSalida"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaSalida"]) : DateTime.Parse("12-31-1999");
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
                departamentoToxicologia.FechaIngresoAdministracion = (reader["TF_FechaIngresoAdministracion"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaIngresoAdministracion"]) : DateTime.Parse("12-31-1999");
                departamentoToxicologia.CantidadDiasAdministracion = (reader["TN_CantidadDiasAdm"] != DBNull.Value) ? Convert.ToInt32(reader["TN_CantidadDiasAdm"]) : 0;
                departamentoToxicologia.FechaIngreso = (reader["TF_FechaIngreso"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaIngreso"]) : DateTime.Parse("12-31-1999");
                departamentoToxicologia.OficioIngreso = reader["TC_OficioIngreso"].ToString() ?? " ";
                departamentoToxicologia.FechaCita = (reader["TF_FechaCita"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaCita"]) : DateTime.Parse("12-31-1999");
                departamentoToxicologia.DiasAlaFecha = (reader["TN_DiasALaFecha"] != DBNull.Value) ? Convert.ToInt32(reader["TN_DiasALaFecha"]) : 0;
                departamentoToxicologia.DiasParaCita = (reader["TN_DiasParaCita"] != DBNull.Value) ? Convert.ToInt32(reader["TN_DiasParaCita"]) : 0;
                departamentoToxicologia.FechaSalida = (reader["TF_FechaSalida"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaSalida"]) : DateTime.Parse("12-31-1999");
                departamentoToxicologia.CantidadDiasTotalesTramite = (reader["TN_CantidadDiasTotalesTramite"] != DBNull.Value) ? Convert.ToInt32(reader["TN_CantidadDiasTotalesTramite"]) : 0; 
                departamentoToxicologia.OficioRespuesta = reader["TC_OficioRespuesta"].ToString() ?? " ";
                departamentoToxicologia.FechaEstado = (reader["TF_FechaEstado"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaEstado"]) : DateTime.Parse("12-31-1999");
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
            primerIngresoDepartamentos.DepartamentoVialidad = getDepartamentoVialidad(cedulaPrimerIngreso);
            primerIngresoDepartamentos.DepartamentoPruebasGH = getDepartamentoPruebasGH(cedulaPrimerIngreso);
            primerIngresoDepartamentos.DepartamentoPruebasMedicas = getDepartamentoPruebasMedicas(cedulaPrimerIngreso);
            primerIngresoDepartamentos.DepartamentoToxicologia = getDepartamentoToxicologia(cedulaPrimerIngreso);

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

            
            actualizarPruebasGH.Parameters.AddWithValue("@numeroDeCedula", cedula);

            if (departamentoPruebasGH.FechaIngresoAdministracion.Date != DateTime.Parse("12-31-1999"))
                actualizarPruebasGH.Parameters.AddWithValue("@TF_FechaIngresoAdministracion", departamentoPruebasGH.FechaIngresoAdministracion);
            else
                actualizarPruebasGH.Parameters.AddWithValue("@TF_FechaIngresoAdministracion", DBNull.Value);

            actualizarPruebasGH.Parameters.AddWithValue("@TN_CantidadDiasAdm", departamentoPruebasGH.CantidadDiasAdministracion);
            actualizarPruebasGH.Parameters.AddWithValue("@TC_Ubicacion", departamentoPruebasGH.Ubicacion);

            if (departamentoPruebasGH.FechaIngreso.Date != DateTime.Parse("12-31-1999"))
                actualizarPruebasGH.Parameters.AddWithValue("@TF_FechaIngreso", departamentoPruebasGH.FechaIngreso);
            else
                actualizarPruebasGH.Parameters.AddWithValue("@TF_FechaIngreso", DBNull.Value);

            actualizarPruebasGH.Parameters.AddWithValue("@TC_OficioIngreso", departamentoPruebasGH.OficioIngreso);
            actualizarPruebasGH.Parameters.AddWithValue("@TN_DiasALaFecha", departamentoPruebasGH.DiasAlaFecha);

            if (departamentoPruebasGH.FechaTrasladoPsicologosAdmin.Date != DateTime.Parse("12-31-1999"))
                actualizarPruebasGH.Parameters.AddWithValue("@TF_FechaTrasladoPsicologosAdm", departamentoPruebasGH.FechaTrasladoPsicologosAdmin);
            else
                actualizarPruebasGH.Parameters.AddWithValue("@TF_FechaTrasladoPsicologosAdm", DBNull.Value);

            actualizarPruebasGH.Parameters.AddWithValue("@TC_Oficio", departamentoPruebasGH.Oficio);

            if (departamentoPruebasGH.FechaDevolucionGHDeAdmin.Date != DateTime.Parse("12-31-1999"))
                actualizarPruebasGH.Parameters.AddWithValue("@TF_FechaDevolucionGHDeAdm", departamentoPruebasGH.FechaDevolucionGHDeAdmin);
            else
                actualizarPruebasGH.Parameters.AddWithValue("@TF_FechaDevolucionGHDeAdm", DBNull.Value);

            actualizarPruebasGH.Parameters.AddWithValue("@TN_CantidadDiasPsicologiaAdm", departamentoPruebasGH.CantidadDiasPsicologiaAdmin);

            if (departamentoPruebasGH.FechaLimiteSegunPlazo.Date != DateTime.Parse("12-31-1999"))
                actualizarPruebasGH.Parameters.AddWithValue("@TF_FechaLimiteSegunPlazo", departamentoPruebasGH.FechaLimiteSegunPlazo);
            else
                actualizarPruebasGH.Parameters.AddWithValue("@TF_FechaLimiteSegunPlazo", DBNull.Value);

            actualizarPruebasGH.Parameters.AddWithValue("@TN_DiasALaFechaDeFechaLimiteSegunPlazo", departamentoPruebasGH.DiasALaFechaDeFechaLimiteSegunPlazo);
            actualizarPruebasGH.Parameters.AddWithValue("@TN_DiasTramiteGHDespuesDevuelto", departamentoPruebasGH.DiasTramiteGHDespuesDevuelto);

            if (departamentoPruebasGH.FechaSalida.Date != DateTime.Parse("12-31-1999"))
                actualizarPruebasGH.Parameters.AddWithValue("@TF_FechaSalida", departamentoPruebasGH.FechaSalida);
            else
                actualizarPruebasGH.Parameters.AddWithValue("@TF_FechaSalida", DBNull.Value);

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

            SqlCommand actualizarAntecedentes = new SqlCommand(@"EXEC PA_ActualizaTMOGESP_Antecedentes
                                            @numeroDeCedula,
											@TF_FechaIngresoAdministracion,
											@TN_CantidadDiasAdm,
                                            @TF_FechaIngreso,
											@TC_OficioIngreso,
											@TF_FechaFechaResultado,
                                            @TN_ZonaDeTrabajo,
                                            @TN_DiasALaFecha,
											@TF_FechaSalida,
											@TN_CantidadDiasTotalesTramite,
											@TC_OficioRespuesta,
											@TN_EstadoResultHojaEnvioGH", sqlConnection);


            actualizarAntecedentes.Parameters.AddWithValue("@numeroDeCedula", cedula);

            if (departamentoAntecedentes.FechaIngresoAdministracion.Date != DateTime.Parse("12-31-1999"))
                actualizarAntecedentes.Parameters.AddWithValue("@TF_FechaIngresoAdministracion", departamentoAntecedentes.FechaIngresoAdministracion);
            else
                actualizarAntecedentes.Parameters.AddWithValue("@TF_FechaIngresoAdministracion", DBNull.Value);

            actualizarAntecedentes.Parameters.AddWithValue("@TN_CantidadDiasAdm", departamentoAntecedentes.CantidadDiasAdministracion);

            if (departamentoAntecedentes.FechaIngreso.Date != DateTime.Parse("12-31-1999"))
                actualizarAntecedentes.Parameters.AddWithValue("@TF_FechaIngreso", departamentoAntecedentes.FechaIngreso);
            else
                actualizarAntecedentes.Parameters.AddWithValue("@TF_FechaIngreso", DBNull.Value);

            actualizarAntecedentes.Parameters.AddWithValue("@TC_OficioIngreso", departamentoAntecedentes.OficioIngreso);

            if (departamentoAntecedentes.FechaResultado.Date != DateTime.Parse("12-31-1999"))
                actualizarAntecedentes.Parameters.AddWithValue("@TF_FechaFechaResultado", departamentoAntecedentes.FechaResultado);
            else
                actualizarAntecedentes.Parameters.AddWithValue("@TF_FechaFechaResultado", DBNull.Value);

            actualizarAntecedentes.Parameters.AddWithValue("@TN_ZonaDeTrabajo", departamentoAntecedentes.ZonaTrabajo);
            actualizarAntecedentes.Parameters.AddWithValue("@TN_DiasALaFecha", departamentoAntecedentes.DiasAlaFecha);

            if (departamentoAntecedentes.FechaSalida.Date != DateTime.Parse("12-31-1999"))
                actualizarAntecedentes.Parameters.AddWithValue("@TF_FechaSalida", departamentoAntecedentes.FechaSalida);
            else
                actualizarAntecedentes.Parameters.AddWithValue("@TF_FechaSalida", DBNull.Value);

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

            SqlCommand actualizarVialidad = new SqlCommand(@"EXEC PA_ActualizaTMOGESP_Vialidad 
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
            if (departamentoVialidad.FechaIngresoAdministracion.Date != DateTime.Parse("12-31-1999"))
                actualizarVialidad.Parameters.AddWithValue("@TF_FechaIngresoAdministracion", departamentoVialidad.FechaIngresoAdministracion);
            else
                actualizarVialidad.Parameters.AddWithValue("@TF_FechaIngresoAdministracion", DBNull.Value);
            actualizarVialidad.Parameters.AddWithValue("@TN_CantidadDiasAdm", departamentoVialidad.CantidadDiasAdministracion);
            if (departamentoVialidad.FechaIngreso.Date != DateTime.Parse("12-31-1999"))
                actualizarVialidad.Parameters.AddWithValue("@TF_FechaIngresoTransportes", departamentoVialidad.FechaIngreso);
            else
                actualizarVialidad.Parameters.AddWithValue("@TF_FechaIngresoTransportes", DBNull.Value);
            actualizarVialidad.Parameters.AddWithValue("@TC_OficioIngreso", departamentoVialidad.OficioIngreso);
            if (departamentoVialidad.FechaCita.Date != DateTime.Parse("12-31-1999"))
                actualizarVialidad.Parameters.AddWithValue("@TF_FechaFechaCita", departamentoVialidad.FechaCita);
            else
                actualizarVialidad.Parameters.AddWithValue("@TF_FechaFechaCita", DBNull.Value);
            actualizarVialidad.Parameters.AddWithValue("@TN_DiasParaCita", departamentoVialidad.DiasParaCita);
            if (departamentoVialidad.FechaSalida.Date != DateTime.Parse("12-31-1999"))
                actualizarVialidad.Parameters.AddWithValue("@TF_FechaSalida", departamentoVialidad.FechaSalida);
            else
                actualizarVialidad.Parameters.AddWithValue("@TF_FechaSalida", DBNull.Value);
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

            SqlCommand actualizarPruebasMedicas = new SqlCommand(@"EXEC PA_ActualizaTMOGESP_PruebasMedicas
                                            @numeroDeCedula,
											@TF_FechaIngresoAdministracion,
											@TN_CantidadDiasAdm,
											@TF_FechaIngreso,
                                            @TF_FechaEnvioAPMdeGH,
											@TC_OficioIngreso,
											@TF_FechaResultadoOCitaPM,
                                            @TN_DiasALaFecha,
											@TF_FechaSalida,
											@TN_CantidadDiasTotalesTramite,
											@TC_OficioRespuesta", sqlConnection);

            actualizarPruebasMedicas.Parameters.AddWithValue("@numeroDeCedula", cedula);

            if (departamentoPruebasMedicas.FechaIngresoAdministracion.Date != DateTime.Parse("12-31-1999"))
                actualizarPruebasMedicas.Parameters.AddWithValue("@TF_FechaIngresoAdministracion", departamentoPruebasMedicas.FechaIngresoAdministracion);
            else
                actualizarPruebasMedicas.Parameters.AddWithValue("@TF_FechaIngresoAdministracion", DBNull.Value);

            actualizarPruebasMedicas.Parameters.AddWithValue("@TN_CantidadDiasAdm", departamentoPruebasMedicas.CantidadDiasAdministracion);

            if (departamentoPruebasMedicas.FechaIngreso.Date != DateTime.Parse("12-31-1999"))
                actualizarPruebasMedicas.Parameters.AddWithValue("@TF_FechaIngreso", departamentoPruebasMedicas.FechaIngreso);
            else
                actualizarPruebasMedicas.Parameters.AddWithValue("@TF_FechaIngreso", DBNull.Value);

            if (departamentoPruebasMedicas.FechaEnvioAPMdeGH.Date != DateTime.Parse("12-31-1999"))
                actualizarPruebasMedicas.Parameters.AddWithValue("@TF_FechaEnvioAPMdeGH", departamentoPruebasMedicas.FechaEnvioAPMdeGH);
            else
                actualizarPruebasMedicas.Parameters.AddWithValue("@TF_FechaEnvioAPMdeGH", DBNull.Value);

            actualizarPruebasMedicas.Parameters.AddWithValue("@TC_OficioIngreso", departamentoPruebasMedicas.OficioIngreso);

            if (departamentoPruebasMedicas.FechaResultadoOCitaPM.Date != DateTime.Parse("12-31-1999"))
                actualizarPruebasMedicas.Parameters.AddWithValue("@TF_FechaResultadoOCitaPM", departamentoPruebasMedicas.FechaResultadoOCitaPM);
            else
                actualizarPruebasMedicas.Parameters.AddWithValue("@TF_FechaResultadoOCitaPM", DBNull.Value);

            actualizarPruebasMedicas.Parameters.AddWithValue("@TN_DiasALaFecha", departamentoPruebasMedicas.DiasAlaFecha);

            if (departamentoPruebasMedicas.FechaSalida.Date != DateTime.Parse("12-31-1999"))
                actualizarPruebasMedicas.Parameters.AddWithValue("@TF_FechaSalida", departamentoPruebasMedicas.FechaSalida);
            else
                actualizarPruebasMedicas.Parameters.AddWithValue("@TF_FechaSalida", DBNull.Value);

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

            SqlCommand actualizarToxicologia = new SqlCommand(@"EXEC PA_ActualizaTMOGESP_Toxicologia 
                                            @numeroDeCedula,
											@TF_FechaIngresoAdministracion,
											@TN_CantidadDiasAdm,
											@TF_FechaIngreso,
											@TC_OficioIngreso,
                                            @TF_FechaCita,
                                            @TN_DiasParaCita,
                                            @TN_DiasALaFecha,
											@TF_FechaSalida,
											@TN_CantidadDiasTotalesTramite,
											@TC_OficioRespuesta,
											@TF_FechaEstado,
                                            @TN_FechaEstadoCantDias", sqlConnection);

            actualizarToxicologia.Parameters.AddWithValue("@numeroDeCedula", cedula);

            if (departamentoToxicologia.FechaIngresoAdministracion.Date != DateTime.Parse("12-31-1999"))
                actualizarToxicologia.Parameters.AddWithValue("@TF_FechaIngresoAdministracion", departamentoToxicologia.FechaIngresoAdministracion);
            else
                actualizarToxicologia.Parameters.AddWithValue("@TF_FechaIngresoAdministracion", DBNull.Value);

            actualizarToxicologia.Parameters.AddWithValue("@TN_CantidadDiasAdm", departamentoToxicologia.CantidadDiasAdministracion);

            if (departamentoToxicologia.FechaIngreso.Date != DateTime.Parse("12-31-1999"))
                actualizarToxicologia.Parameters.AddWithValue("@TF_FechaIngreso", departamentoToxicologia.FechaIngreso);
            else
                actualizarToxicologia.Parameters.AddWithValue("@TF_FechaIngreso", DBNull.Value);

            actualizarToxicologia.Parameters.AddWithValue("@TC_OficioIngreso", departamentoToxicologia.OficioIngreso);

            if (departamentoToxicologia.FechaCita.Date != DateTime.Parse("12-31-1999"))
                actualizarToxicologia.Parameters.AddWithValue("@TF_FechaCita", departamentoToxicologia.FechaCita);
            else
                actualizarToxicologia.Parameters.AddWithValue("@TF_FechaCita", DBNull.Value);

            actualizarToxicologia.Parameters.AddWithValue("@TN_DiasParaCita", departamentoToxicologia.DiasParaCita);
            actualizarToxicologia.Parameters.AddWithValue("@TN_DiasALaFecha", departamentoToxicologia.DiasAlaFecha);

            if (departamentoToxicologia.FechaSalida.Date != DateTime.Parse("12-31-1999"))
                actualizarToxicologia.Parameters.AddWithValue("@TF_FechaSalida", departamentoToxicologia.FechaSalida);
            else
                actualizarToxicologia.Parameters.AddWithValue("@TF_FechaSalida", DBNull.Value);

            actualizarToxicologia.Parameters.AddWithValue("@TN_CantidadDiasTotalesTramite", departamentoToxicologia.CantidadDiasTotalesTramite);
            actualizarToxicologia.Parameters.AddWithValue("@TC_OficioRespuesta", departamentoToxicologia.OficioRespuesta);

            if (departamentoToxicologia.FechaEstado.Date != DateTime.Parse("12-31-1999"))
                actualizarToxicologia.Parameters.AddWithValue("@TF_FechaEstado", departamentoToxicologia.FechaEstado);
            else
                actualizarToxicologia.Parameters.AddWithValue("@TF_FechaEstado", DBNull.Value);

            actualizarToxicologia.Parameters.AddWithValue("@TN_FechaEstadoCantDias", departamentoToxicologia.FechaEstadoCantDias);

            sqlConnection.Open();
            actualizarToxicologia.ExecuteReader();

            sqlConnection.Close();
            actualizarToxicologia.Dispose();

        }


    }



}

