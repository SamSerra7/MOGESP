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
            String conexion = "Server=163.178.173.148;Database=MOGESPProd;User id=estudiantesrp;Password=estudiantesrp;";
            conexion = "Server=DESKTOP-QI4QP2A\\SQLEXPRESS;Database=MOGESP;User id=usrMOGESP;Password=usrMOGESP;"; 
            return new SqlConnection(conexion);
        }


    }

}