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
            return new SqlConnection("Server=163.178.173.148;Database=MOGESPProd;User id=estudiantesrp;Password=estudiantesrp;");
        }


    }

}