using MOGESP.Entities.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MOGESP.DataAccess.TRAN.Datos
{
    /// <summary>
    /// Clase que administra los funcionarios
    /// </summary>
    public class FuncionariosDatos
    {
        //variable conexion
        private ConexionDatos conexion = new ConexionDatos();

        //variables
        private CorreoDatos correoDatos = new CorreoDatos();
        private TelefonoDatos telefonoDatos = new TelefonoDatos();

        /// <summary>
        /// Autores: Samuel 
        /// 7/11/19
        /// Este método retorna una lista con todos los funcionarios.
        /// </summary>
        /// <returns>List<Funcionario></returns>
        public List<Funcionario> ListarFuncionarios()
        {

            List<Funcionario> funcionarios = new List<Funcionario>();

            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_ConsultarFuncionarios", sqlConnection);

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



        /// <summary>
        /// Autores: Samuel 
        /// 10/10/19
        /// Este método ingresa un primer ingreso.
        /// </summary>
        public void InsertarFuncionario(PrimerIngreso primerIngreso)
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




    }
}
