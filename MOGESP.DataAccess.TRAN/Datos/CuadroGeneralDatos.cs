using MOGESP.Entities.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MOGESP.DataAccess.TRAN.Datos
{
    /// <summary>
    /// Clase que administra los primeros ingresos
    /// </summary>
    public class CuadroGeneralDatos
    {
        //variable conexion
        private ConexionDatos conexion = new ConexionDatos();

        //variables
        private CorreoDatos correoDatos = new CorreoDatos();
        private TelefonoDatos telefonoDatos = new TelefonoDatos();

        /// <summary>
        /// Autores: Manfred
        /// 5/11/19
        /// Este método retorna una lista con todos los numeros de convocatoria.
        /// </summary>
        /// <returns>List<String></returns>
        public List<String> traerNumerosConvocatoria()
        {

            List<String> numerosConvocatoria = new List<String>();

            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_NumerosConvocatoria", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            String numConvocatoria;

            while (reader.Read())
            {

                numConvocatoria = reader["TC_NumeroConvocatoria"].ToString();


                numerosConvocatoria.Add(numConvocatoria);
            }

            sqlConnection.Close();

            return numerosConvocatoria;
        }

        /// <summary>
        /// Autores: Manfred
        /// 5/11/19
        /// Este método retorna una lista con todos los numeros de flujos por convocatoria.
        /// </summary>
        /// <returns>List<int></returns>
        public List<int> traerNumerosDeFlujoPorConvocatoria(String numConvocatoria)
        {

            List<int> numerosFlujo = new List<int>();

            SqlConnection sqlConnection = conexion.conexion();

            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_NumerosDeFlujoPorConvocatoria @numeroConvocatoria", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@numeroConvocatoria", numConvocatoria);
            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            int numFlujo;

            while (reader.Read())
            {

                numFlujo = Convert.ToInt32(reader["TN_NumeroFlujo"]);


                numerosFlujo.Add(numFlujo);
            }

            sqlConnection.Close();

            return numerosFlujo;
        }
        /// <summary>
        /// Autores: Manfred
        /// 7/11/19
        /// Este método retorna una lista con todos los puestos de un primer Ingreso.
        /// </summary>
        /// <returns>List<Puesto></returns>
        public List<Puesto> traePuestosDeUnPrimerIngreso(String numeroCedula)
        {
            List<Puesto> puestos = new List<Puesto>();

            SqlConnection sqlConnection = conexion.conexion();
            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_PrimerIngresoPuestoAplicaCed @numeroDeCedula", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@numeroDeCedula", numeroCedula);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            Puesto puesto;
            int idPuesto;
            int idClasePuesto;
            String nombreClasePuesto;


            while (reader.Read())
            {

                idPuesto = Convert.ToInt32(reader["TN_IdPuesto"]);
                idClasePuesto = Convert.ToInt32(reader["TN_IdClasePuesto"]);
                nombreClasePuesto = reader["TC_NombreClasePuesto"].ToString();

                puesto = new Puesto(idClasePuesto, nombreClasePuesto);
                puestos.Add(puesto);
            }

            sqlConnection.Close();


            return puestos;
        }

        /// <summary>
        /// Autores: Manfred
        /// 7/11/19
        /// Este método retorna una lista que conforma la tabla de los primeros ingresos del cuadro general y puede ser filtrada por numero de convocatoria y numero de flujo.
        /// </summary>
        /// <returns>List<CuadroGeneral></returns>
        public List<CuadroGeneral> traeCuadroGeneral(String numeroConvovatoria, int numeroFlujo)
        {
            List<CuadroGeneral> listaCuadroGeneral = new List<CuadroGeneral>();

            SqlConnection sqlConnection = conexion.conexion();
            SqlCommand sqlCommand = new SqlCommand(@"EXEC PA_SeleccionaCuadroGeneralPI @pTC_NumeroConvocatoria, @pTN_NumeroFlujo", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@pTC_NumeroConvocatoria", numeroConvovatoria);
            sqlCommand.Parameters.AddWithValue("@pTN_NumeroFlujo", numeroFlujo);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            PrimerIngreso primerIngreso = new PrimerIngreso();
            CuadroGeneral cuadroGeneral = new CuadroGeneral();
            List<Puesto> puestos = new List<Puesto>();
           
            while (reader.Read())
            {
                cuadroGeneral.NumeroConvocatoria = reader["TC_NumeroConvocatoria"].ToString();
                cuadroGeneral.NumeroFlujo = Convert.ToInt32((reader["TN_NumeroFlujo"]));
                cuadroGeneral.NumeroCedula = reader["TC_NumeroCedula"].ToString();
                cuadroGeneral.NombrePI = reader["TC_Nombre"].ToString();
                cuadroGeneral.PrimerApellido = reader["TC_PrimerApellido"].ToString();
                cuadroGeneral.SegundoApellido = reader["TC_SegundoApellido"].ToString();
                
                if (reader["pghDiasAdm"] == DBNull.Value)
                    cuadroGeneral.CantidadDiasAdminPruebasGH = 0;
                else
                    cuadroGeneral.CantidadDiasAdminPruebasGH = Convert.ToInt32((reader["pghDiasAdm"]));

                if (reader["pghDiasT"] == DBNull.Value)
                    cuadroGeneral.CantidadDiasPruebasGH = 0;
                else
                    cuadroGeneral.CantidadDiasPruebasGH = Convert.ToInt32((reader["pghDiasT"]));

                if (reader["antDiasAdm"] == DBNull.Value)
                    cuadroGeneral.CantidadDiasAdminAntecedentes = 0;
                else
                    cuadroGeneral.CantidadDiasAdminAntecedentes = Convert.ToInt32((reader["antDiasAdm"]));

                if (reader["antDiasT"] == DBNull.Value)
                    cuadroGeneral.CantidadDiasAntecedentes = 0;
                else
                    cuadroGeneral.CantidadDiasAntecedentes = Convert.ToInt32((reader["antDiasT"]));

                if (reader["vialDiasAdm"] == DBNull.Value)
                    cuadroGeneral.CantidadDiasAdminVialidad = 0;
                else
                    cuadroGeneral.CantidadDiasAdminVialidad = Convert.ToInt32((reader["vialDiasAdm"]));

                if (reader["vialDiasT"] == DBNull.Value)
                    cuadroGeneral.CantidadDiasVialidad = 0;
                else
                    cuadroGeneral.CantidadDiasVialidad = Convert.ToInt32((reader["vialDiasT"]));

                if (reader["pmDiasAdm"] == DBNull.Value)
                    cuadroGeneral.CantidadDiasAdminPruebasMedicas = 0;
                else
                    cuadroGeneral.CantidadDiasAdminPruebasMedicas = Convert.ToInt32((reader["pmDiasAdm"]));

                if (reader["pmDiasT"] == DBNull.Value)
                    cuadroGeneral.CantidadDiasPruebasMedicas = 0;
                else
                    cuadroGeneral.CantidadDiasPruebasMedicas = Convert.ToInt32((reader["pmDiasT"]));

                if (reader["txDiasAdm"] == DBNull.Value)
                    cuadroGeneral.CantidadDiasAdminToxicologia = 0;
                else
                    cuadroGeneral.CantidadDiasAdminToxicologia = Convert.ToInt32((reader["txDiasAdm"]));

                if (reader["txDiasT"] == DBNull.Value)
                    cuadroGeneral.CantidadDiasToxicologia = 0;
                else
                    cuadroGeneral.CantidadDiasToxicologia = Convert.ToInt32((reader["txDiasT"]));


                
                puestos = traePuestosDeUnPrimerIngreso(cuadroGeneral.NumeroCedula);

                cuadroGeneral.PuestosAplica = puestos;
                //SE DEBE GENERAR UN CRITERIO PARA GENERAR LA CONDICION
                cuadroGeneral.Condicion = "N/A";
                listaCuadroGeneral.Add(cuadroGeneral);
                cuadroGeneral = new CuadroGeneral();
                puestos = new List<Puesto>();
            }
            sqlConnection.Close();

            
            return listaCuadroGeneral;
        }



     }
}
