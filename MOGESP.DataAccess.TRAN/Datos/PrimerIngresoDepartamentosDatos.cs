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
                listaEstados.Add(reader["TC_Nombre"].ToString());
            }

            sqlConnection.Close();


            return listaEstados;
        }

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

        public DepartamentoPruebasGH getDepartamentoPruebasGH(string cedulaPI)
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

                departamentoPruebasGH.FechaIngresoAdministracion = (reader["TF_FechaIngresoAdministracion"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaIngresoAdministracion"]) : default;
                departamentoPruebasGH.CantidadDiasAdministracion = (reader["TN_CantidadDiasAdm"] != DBNull.Value) ? Convert.ToInt32(reader["TN_CantidadDiasAdm"]) : 0;
                departamentoPruebasGH.Ubicacion = reader["TC_Ubicacion"].ToString() ?? "";
                departamentoPruebasGH.FechaIngreso = (reader["TF_FechaIngreso"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaIngreso"]) : default;
                departamentoPruebasGH.OficioIngreso = reader["TC_OficioIngreso"].ToString() ?? "";
                departamentoPruebasGH.DiasAlaFecha = (reader["TN_DiasALaFecha"] != DBNull.Value) ? Convert.ToInt32(reader["TN_DiasALaFecha"]) : 0;
                departamentoPruebasGH.FechaTrasladoPsicologosAdmin = (reader["TF_FechaTrasladoPsicologosAdm"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaTrasladoPsicologosAdm"]) : default; 
                departamentoPruebasGH.CantidadDiasPsicologiaAdmin = (reader["TN_CantidadDiasPsicologiaAdm"] != DBNull.Value) ? Convert.ToInt32(reader["TN_CantidadDiasPsicologiaAdm"]) : 0; 
                departamentoPruebasGH.FechaLimiteSegunPlazo = (reader["TF_FechaLimiteSegunPlazo"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaLimiteSegunPlazo"]) : default;
                departamentoPruebasGH.DiasALaFechaDeFechaLimiteSegunPlazo = (reader["TN_DiasALaFechaDeFechaLimiteSegunPlazo"] != DBNull.Value) ? Convert.ToInt32(reader["TN_DiasALaFechaDeFechaLimiteSegunPlazo"]) : 0;
                departamentoPruebasGH.DiasTramiteGHDespuesDevuelto = (reader["TN_DiasTramiteGHDespuesDevuelto"] != DBNull.Value) ? Convert.ToInt32(reader["TN_DiasTramiteGHDespuesDevuelto"]) : 0;
                departamentoPruebasGH.FechaSalida = (reader["TF_FechaSalida"] != DBNull.Value) ? Convert.ToDateTime(reader["TF_FechaSalida"]) : default;
                departamentoPruebasGH.CantidadDiasTotalesTramite = (reader["TN_CantidadDiasTotalesTramite"] != DBNull.Value) ? Convert.ToInt32(reader["TN_CantidadDiasTotalesTramite"]) : 0;
                departamentoPruebasGH.OficioRespuesta = reader["TC_OficioRespuesta"].ToString() ?? "";

            }

            sqlConnection.Close();

            departamentoPruebasGH.EstadoLista = ordenarListaEstado(getListaEstado(), departamentoPruebasGH.EstadoResultHojaEnvioGH);

            return departamentoPruebasGH;
        }

        public DepartamentoAntecedentes getDepartamentoAntecedentes(string cedulaPI)
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
                departamentoAntecedentes.FechaIngresoAdministracion = Convert.ToDateTime(reader["TF_FechaIngresoAdministracion"]);
                departamentoAntecedentes.CantidadDiasAdministracion = Convert.ToInt32(reader["TN_CantidadDiasAdm"]);
                departamentoAntecedentes.FechaIngreso = Convert.ToDateTime(reader["TF_FechaIngreso"]);
                departamentoAntecedentes.OficioIngreso = reader["TC_OficioIngreso"].ToString();
                departamentoAntecedentes.DiasAlaFecha = Convert.ToInt32(reader["TN_DiasALaFecha"]);
                departamentoAntecedentes.FechaResultado = Convert.ToDateTime(reader["TF_FechaFechaResultado"]);
                departamentoAntecedentes.ZonaTrabajo = Convert.ToInt32(reader["TN_ZonaDeTrabajo"]);
                departamentoAntecedentes.FechaSalida = Convert.ToDateTime(reader["TF_FechaSalida"]);
                departamentoAntecedentes.CantidadDiasTotalesTramite = Convert.ToInt32(reader["TN_CantidadDiasTotalesTramite"]);
                departamentoAntecedentes.OficioRespuesta = reader["TC_OficioRespuesta"].ToString();
                departamentoAntecedentes.EstadoResultHojaEnvioGH = reader["TC_Nombre"].ToString();
            }
            sqlConnection.Close();

            departamentoAntecedentes.EstadoLista = ordenarListaEstado(getListaEstado(), departamentoAntecedentes.EstadoResultHojaEnvioGH);

            return departamentoAntecedentes;
        }


        public DepartamentoVialidad getDepartamentoVialidad(string cedulaPI)
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
                departamentoVialidad.FechaIngresoAdministracion = Convert.ToDateTime(reader["TF_FechaIngresoAdministracion"]);
                departamentoVialidad.CantidadDiasAdministracion = Convert.ToInt32(reader["TN_CantidadDiasAdm"]);
                departamentoVialidad.FechaIngreso = Convert.ToDateTime(reader["TF_FechaIngresoTransportes"]);
                departamentoVialidad.OficioIngreso = reader["TC_OficioIngreso"].ToString();
                departamentoVialidad.DiasParaCita = Convert.ToInt32(reader["TN_DiasParaCita"]);
                departamentoVialidad.FechaCita = Convert.ToDateTime(reader["TF_FechaFechaCita"]);
                departamentoVialidad.FechaSalida = Convert.ToDateTime(reader["TF_FechaSalida"]);
                departamentoVialidad.CantidadDiasTotalesTramite = Convert.ToInt32(reader["TN_CantidadDiasTotalesTramite"]);
                departamentoVialidad.OficioRespuesta = reader["TC_OficioRespuesta"].ToString();
                departamentoVialidad.EstadoResultHojaEnvioGH = reader["TC_Nombre"].ToString();
            }

            sqlConnection.Close();

            departamentoVialidad.EstadoLista = ordenarListaEstado(getListaEstado(), departamentoVialidad.EstadoResultHojaEnvioGH);

            return departamentoVialidad;
        }

        public DepartamentoPruebasMedicas getDepartamentoPruebasMedicas(string cedulaPI)
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

            departamentoPruebasMedicas.EstadoLista = ordenarListaEstado(getListaEstado(), departamentoPruebasMedicas.EstadoResultHojaEnvioGH);

            return departamentoPruebasMedicas;
        }

        public DepartamentoToxicologia getDepartamentoToxicologia(string cedulaPI)
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

            departamentoToxicologia.EstadoLista = ordenarListaEstado(getListaEstado(), departamentoToxicologia.EstadoResultHojaEnvioGH);

            return departamentoToxicologia;
        }

        public PrimerIngresoDepartamentos getPrimerIngresoDepartamentos(string nombrePI = "", string cedulaPI = "")
        {

            PrimerIngresoDepartamentos primerIngresoDepartamentos = new PrimerIngresoDepartamentos();

            primerIngresoDepartamentos.NumeroCedula = cedulaPI;
            primerIngresoDepartamentos.NombrePI = nombrePI;
            //primerIngresoDepartamentos.DepartamentoAntecedentes = getDepartamentoAntecedentes(cedulaPI);
            primerIngresoDepartamentos.DepartamentoPruebasGH = getDepartamentoPruebasGH(cedulaPI);
            // primerIngresoDepartamentos.DepartamentoPruebasMedicas = getDepartamentoPruebasMedicas(cedulaPI);
            //primerIngresoDepartamentos.DepartamentoToxicologia = getDepartamentoToxicologia(cedulaPI);
            //primerIngresoDepartamentos.DepartamentoVialidad = getDepartamentoVialidad(cedulaPI);

            return primerIngresoDepartamentos;
        }


    }



}

