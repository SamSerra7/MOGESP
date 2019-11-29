using MOGESP.Entities.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MOGESP.DataAccess.TRAN.Datos
{
    /// <summary>
    /// Clase que administra los funcionarios
    /// </summary>
    public class FuncionarioDatos
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

            SqlCommand sqlCommand = new SqlCommand(@"PA_ListarTablaFuncionarios", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            Funcionario funcionario;

            while (reader.Read())
            {
                funcionario = new Funcionario();

                funcionario.Cedula = reader["TC_NumeroCedula"].ToString();
                funcionario.Nombre = reader["TC_Nombre"].ToString();
                funcionario.PrimerApellido = reader["TC_PrimerApellido"].ToString();
                funcionario.SegundoApellido = reader["TC_SegundoApellido"].ToString();
				funcionario.Sexo = Convert.ToChar(reader["TC_Sexo"].ToString());
				funcionario.Direccion = reader["TC_Direccion"].ToString();
				funcionario.Correos = correoDatos.CosultarCorreosPorFuncionario(funcionario.Cedula);
				funcionario.Telefonos = telefonoDatos.CosultarTelefonosPorFuncionario(funcionario.Cedula);

				funcionarios.Add(funcionario);
            }

            sqlConnection.Close();

            return funcionarios;
        }

		public IEnumerable<Funcionario> obtenerFuncionarioPorIdConcursoParticipante(int idConcurso)
		{
			List<Funcionario> funcionarios = new List<Funcionario>();

			SqlConnection sqlConnection = conexion.conexion();

			SqlCommand sqlCommand = new SqlCommand(@"exec PA_ConsultarFuncionariosPorConcursoEnParticipacion @idConcurso", sqlConnection);
			sqlCommand.Parameters.AddWithValue("@idConcurso", idConcurso);
			SqlDataReader reader;
			sqlConnection.Open();
			reader = sqlCommand.ExecuteReader();

			Funcionario funcionario;

			while (reader.Read())
			{
				funcionario = new Funcionario();

				funcionario.Cedula = reader["TC_NumeroCedula"].ToString();
				funcionario.Nombre = reader["TC_Nombre"].ToString();
				funcionario.PrimerApellido = reader["TC_PrimerApellido"].ToString();
				funcionario.SegundoApellido = reader["TC_SegundoApellido"].ToString();
				funcionario.Sexo = Convert.ToChar(reader["TC_Sexo"].ToString());
				funcionario.Direccion = reader["TC_Direccion"].ToString();
				funcionario.Correos = correoDatos.CosultarCorreosPorFuncionario(funcionario.Cedula);
				funcionario.Telefonos = telefonoDatos.CosultarTelefonosPorFuncionario(funcionario.Cedula);

				funcionarios.Add(funcionario);
			}

			sqlConnection.Close();

			return funcionarios;
		}

		/// <summary>
		/// Autor: Jesus Torres
		/// 19/11/19
		/// Este método retorna un funcionario de acuerdo a su cedula
		/// </summary>
		/// <returns>List<Funcionario></returns>
		public Funcionario obtenerFuncionarioPorCedula(string cedula)
		{
			

			SqlConnection sqlConnection = conexion.conexion();

			SqlCommand sqlCommand = new SqlCommand(@"PA_ConsultarFuncionarioPorCedula @TC_NumeroCedula", sqlConnection);

			sqlCommand.Parameters.AddWithValue("@TC_NumeroCedula", cedula); 
			SqlDataReader reader;
			sqlConnection.Open();
			reader = sqlCommand.ExecuteReader();

			Funcionario funcionario = new Funcionario();

			while (reader.Read())
			{
				

				funcionario.Cedula = reader["TC_NumeroCedula"].ToString();
				funcionario.Nombre = reader["TC_Nombre"].ToString();
				funcionario.PrimerApellido = reader["TC_PrimerApellido"].ToString();
				funcionario.SegundoApellido = reader["TC_SegundoApellido"].ToString();
				funcionario.Sexo = Convert.ToChar(reader["TC_Sexo"].ToString());
				funcionario.Direccion = reader["TC_Direccion"].ToString();
				funcionario.Correos = correoDatos.CosultarCorreosPorFuncionario(funcionario.Cedula);
				funcionario.Telefonos = telefonoDatos.CosultarTelefonosPorFuncionario(funcionario.Cedula);
	
			}

			sqlConnection.Close();

			return funcionario;
		}
	}
}
