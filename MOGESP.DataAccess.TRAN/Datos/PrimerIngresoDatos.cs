﻿using MOGESP.Entities.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MOGESP.DataAccess.TRAN.Datos
{
    /// <summary>
    /// Clase que administra los primeros ingresos
    /// </summary>
    public class PrimerIngresoDatos
    {
        //variable conexion
        private ConexionDatos conexion = new ConexionDatos();

        //variables
        private CorreoDatos correoDatos = new CorreoDatos();
        private TelefonoDatos telefonoDatos = new TelefonoDatos();



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

        /// <summary>
        /// Autores: Samuel y Valeria
        /// 9/10/19
        /// Este método retorna una lista con todos los primeros ingresos.
        /// </summary>
        /// <returns>List<PrimerIngreso></returns>
        public List<PrimerIngreso> getAllPrimerosIngresos()
        {

            List<PrimerIngreso> primerosIngresos = new List<PrimerIngreso>();

            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_ConsultarPrimerosIngresos", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            PrimerIngreso primerIngreso;

            while (reader.Read())
            {
                primerIngreso = new PrimerIngreso();
			
                primerIngreso.Cedula = reader["TC_NumeroCedula"].ToString();
                primerIngreso.Nombre = reader["TC_Nombre"].ToString();
                primerIngreso.PrimerApellido = reader["TC_PrimerApellido"].ToString();
                primerIngreso.SegundoApellido = reader["TC_SegundoApellido"].ToString();
                primerIngreso.Sexo = Convert.ToChar(reader["TC_Sexo"].ToString());
                primerIngreso.Direccion = reader["TC_Direccion"].ToString();
                primerIngreso.NumeroConvocatoria = reader["TC_NumeroConvocatoria"].ToString();
                primerIngreso.NumeroFlujo = Convert.ToInt32(reader["TN_NumeroFlujo"].ToString());

                primerIngreso.Correos = correoDatos.CosultarCorreosPorPrimerIngreso(primerIngreso.Cedula);
                primerIngreso.Telefonos = telefonoDatos.CosultarTelefonosPorPrimerIngreso(primerIngreso.Cedula);


                primerosIngresos.Add(primerIngreso);
            }

            sqlConnection.Close();

            return primerosIngresos;
        }


        public PrimerIngreso getPrimerIngreso(string numeroCedula)
        {

            PrimerIngreso primerIngreso = new PrimerIngreso();

            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_ConsultarPrimerIngreso @numeroDeCedula", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@numeroDeCedula", numeroCedula);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {


                primerIngreso.Cedula = reader["TC_NumeroCedula"].ToString();
                primerIngreso.Nombre = reader["TC_Nombre"].ToString();
                primerIngreso.PrimerApellido = reader["TC_PrimerApellido"].ToString();
                primerIngreso.SegundoApellido = reader["TC_SegundoApellido"].ToString();
                primerIngreso.Sexo = Convert.ToChar(reader["TC_Sexo"].ToString());
                primerIngreso.Direccion = reader["TC_Direccion"].ToString();
                primerIngreso.NumeroConvocatoria = reader["TC_NumeroConvocatoria"].ToString();
                primerIngreso.NumeroFlujo = Convert.ToInt32(reader["TN_NumeroFlujo"].ToString());
                primerIngreso.FechaIngreso = Convert.ToDateTime(reader["TF_FechaIngreso"].ToString());
                primerIngreso.IdCondicion = reader["Condicion"].ToString();

                primerIngreso.Correos = correoDatos.CosultarCorreosPorPrimerIngreso(primerIngreso.Cedula);
                primerIngreso.Telefonos = telefonoDatos.CosultarTelefonosPorPrimerIngreso(primerIngreso.Cedula);

                
            }

            sqlConnection.Close();

            primerIngreso.ListaCondiciones = ordenarListaEstado(getListaEstado(), primerIngreso.IdCondicion);

            return primerIngreso;
        }
        public void updatePrimerIngreso(PrimerIngreso primerIngreso)
        {

            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_ActualizaTMOGESP_PrimerIngreso
                                                            @TN_NumeroFlujo,
                                                            @TC_NumeroCedula,
                                                            @TC_Nombre,
                                                            @TC_PrimerApellido,
                                                            @TC_SegundoApellido,
                                                            @TC_Direccion,
                                                            @nombreCondicion", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@TN_NumeroFlujo", primerIngreso.NumeroFlujo);
            sqlCommand.Parameters.AddWithValue("@TC_NumeroCedula", primerIngreso.Cedula);
            sqlCommand.Parameters.AddWithValue("@TC_Nombre", primerIngreso.Nombre);
            sqlCommand.Parameters.AddWithValue("@TC_PrimerApellido", primerIngreso.PrimerApellido);
            sqlCommand.Parameters.AddWithValue("@TC_SegundoApellido", primerIngreso.SegundoApellido);
            sqlCommand.Parameters.AddWithValue("@TC_Direccion", primerIngreso.Direccion);
            sqlCommand.Parameters.AddWithValue("@nombreCondicion", primerIngreso.IdCondicion);


            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            

            sqlConnection.Close();
            sqlCommand.Dispose();
        }

        /// <summary>
        /// Autores: Samuel 
        /// 10/10/19
        /// Este método ingresa un primer ingreso.
        /// </summary>
        public void insertarPrimerIngreso(PrimerIngreso primerIngreso)
        {

            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand insertarPI = new SqlCommand(@"EXEC PA_InsertarPrimerosIngresos @NumeroConvocatoria, @NumeroFlujo, @Cedula, @Nombre, 
                                                        @PrimerApellido, @SegundoApellido, @Direccion, @Sexo", sqlConnection);


            insertarPI.Parameters.AddWithValue("@Cedula", primerIngreso.Cedula);
            insertarPI.Parameters.AddWithValue("@Nombre", primerIngreso.Nombre);
            insertarPI.Parameters.AddWithValue("@PrimerApellido", primerIngreso.PrimerApellido);
            insertarPI.Parameters.AddWithValue("@SegundoApellido", primerIngreso.SegundoApellido);
            insertarPI.Parameters.AddWithValue("@Sexo", primerIngreso.Sexo);
            insertarPI.Parameters.AddWithValue("@Direccion", primerIngreso.Direccion);
            insertarPI.Parameters.AddWithValue("@NumeroConvocatoria", primerIngreso.NumeroConvocatoria);
            insertarPI.Parameters.AddWithValue("@NumeroFlujo", primerIngreso.NumeroFlujo);

            sqlConnection.Open();
            insertarPI.ExecuteReader();

            if (primerIngreso.Correos.Count != 0) { 
                foreach (var correo in primerIngreso.Correos)
                {
                    correoDatos.insertarCorreoPorPersona(primerIngreso.Cedula,correo);
                }
            }

            if (primerIngreso.Telefonos.Count != 0)
            {
                foreach (var telefono in primerIngreso.Telefonos)
                {
                    telefonoDatos.insertarTelefonoPorPersona(primerIngreso.Cedula, telefono);
                }
            }

            sqlConnection.Close();
            insertarPI.Dispose();
        }


        /// <summary>
        /// Autores: Samuel 
        /// 10/10/19
        /// Este método modifica un primer ingreso.
        /// </summary>
        public void ModificarPrimerIngreso(PrimerIngreso primerIngreso)
        {

            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand insertarPI = new SqlCommand(@"EXEC PA_ModificarPrimerIngreso @TC_NumeroCedula = @Cedula, @TC_Nombre = @Nombre, @TC_PrimerApellido = @PrimerApellido, @TC_SegundoApellido = @SegundoApellido, 
                                                                            @TC_Sexo = @Sexo, @TC_Direccion = @Direccion, @TC_NumeroConvocatoria = @NumeroConvocatoria, @TN_NumeroFlujo = @NumeroFlujo ", sqlConnection);


            insertarPI.Parameters.AddWithValue("@Cedula", primerIngreso.Cedula);
            insertarPI.Parameters.AddWithValue("@Nombre", primerIngreso.Nombre);
            insertarPI.Parameters.AddWithValue("@PrimerApellido", primerIngreso.PrimerApellido);
            insertarPI.Parameters.AddWithValue("@SegundoApellido", primerIngreso.SegundoApellido);
            insertarPI.Parameters.AddWithValue("@Sexo", primerIngreso.Sexo);
            insertarPI.Parameters.AddWithValue("@NumeroConvocatoria", primerIngreso.NumeroConvocatoria);
            insertarPI.Parameters.AddWithValue("@NumeroFlujo", primerIngreso.NumeroFlujo);            

            sqlConnection.Open();
            insertarPI.ExecuteReader();
            sqlConnection.Close();
        }




    }
}
