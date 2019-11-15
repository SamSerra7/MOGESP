using MOGESP.Entities.Dominio;
using MOGESP.DataAccess.TRAN.Datos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOGESP.ServiceLayer.Servicio
{
    /// <summary>
    /// Clase que gestiona las reglas de negocio de los primeros ingresos
    /// </summary>
    public class PIDepartamentosServicio
    {
        readonly PrimerIngresoDepartamentosDatos primerIngresoDepartamentosDatos = new PrimerIngresoDepartamentosDatos();

        public PrimerIngresoDepartamentos getPrimerIngresoDepartamentos(string nombrePI, string cedulaPI)
        {
            return primerIngresoDepartamentosDatos.getPrimerIngresoDepartamentos(nombrePI,cedulaPI);
        }

    }
}
