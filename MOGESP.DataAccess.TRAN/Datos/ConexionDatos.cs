using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MOGESP.DataAccess.TRAN.Datos
{
    internal class ConexionDatos
    {

        public SqlConnection conexion()
        {
            //String conexion = "Server=163.178.173.148;Database=MOGESPProd;User id=estudiantesrp;Password=estudiantesrp;";//paraiso
            //String conexion = "Server=DESKTOP-QI4QP2A\\SQLEXPRESS;Database=MOGESP;User id=usrMOGESP;Password=usrMOGESP;"; //Manfred local
            String conexion = "Server=163.178.107.130;Database=MOGESP;User id=laboratorios;Password=Saucr.118P;";//Turrialba
            return new SqlConnection(conexion);
        }


    }

}