﻿using MOGESP.Entities.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MOGESP.DataAccess.TRAN.Datos
{
    /// <summary>
    /// Clase que administra los teléfonos de las personas
    /// </summary>
    public class TelefonoDatos
    {
        //variable conexion
        private ConexionDatos conexion = new ConexionDatos();


        /// <summary>
        /// Autores: Samuel y Valeria
        /// 9/10/19
        /// Este método retorna una lista con todos los teléfonos de un primer ingreso específicco
        /// </summary>
        /// <returns>List<int></returns>
        public List<String> CosultarTelefonosPorPrimerIngreso(string cedula)
        {

            List<String> telefonos = new List<String>();

            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_ConsultarTelefonosPorPI @Cedula ", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@Cedula", cedula);
            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                telefonos.Add(reader["TC_Telefono"].ToString());
            }

            sqlConnection.Close();
            return telefonos;
        }

        /// <summary>
        /// Autores: Samuel 
        /// 10/10/19
        /// Este método ingresa un teléfono para una persona
        /// </summary>
        public void insertarTelefonoPorPersona(string cedula, String telefono)
        {
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand insertarTel = new SqlCommand(@"EXEC PA_InsertarTelefonoPI @Cedula, @Tel", sqlConnection);

            insertarTel.Parameters.AddWithValue("@Cedula", cedula);
            insertarTel.Parameters.AddWithValue("@Tel", telefono);


            sqlConnection.Open();
            insertarTel.ExecuteReader();
            sqlConnection.Close();
            insertarTel.Dispose();
        }



        /// <summary>
        /// Autores: Samuel 
        /// 10/10/19
        /// Este método modifica un teléfono para una persona
        /// </summary>
        public void modificarTelefonoPorPersona(string cedula,int telefono, int telefonoMod)
        {
            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand modificarTel = new SqlCommand(@"EXEC PA_ModificarTelefono@Cedula,@Tel, @TelMod", sqlConnection);

            modificarTel.Parameters.AddWithValue("@Cedula", cedula);
            modificarTel.Parameters.AddWithValue("@Tel", telefono);
            modificarTel.Parameters.AddWithValue("@TelMod", telefonoMod);

            sqlConnection.Open();
            modificarTel.ExecuteReader();
            sqlConnection.Close();
        }


		/// <summary>
		/// Autor: Jesus Torres
		/// 17/11/19
		/// Este método retorna una lista con todos los teléfonos de un Funcionario
		/// </summary>
		/// <returns>List<int></returns>
		public List<String> CosultarTelefonosPorFuncionario(string cedula)
		{

			List<String> telefonos = new List<String>();

			SqlConnection sqlConnection = conexion.conexion();

			SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_ConsultarTelefonosPorFuncionario @Cedula ", sqlConnection);

			sqlCommand.Parameters.AddWithValue("@Cedula", cedula);
			SqlDataReader reader;
			sqlConnection.Open();
			reader = sqlCommand.ExecuteReader();

			while (reader.Read())
			{
				telefonos.Add(reader["TC_Telefono"].ToString());
			}

			sqlConnection.Close();
			return telefonos;
		}


	}
}
