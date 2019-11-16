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

        public PrimerIngresoDepartamentos getPrimerIngresoDepartamentos(string nombrePI, string primerApellidoPI, string segundoApellidoPI, string cedulaPI)
        {
            return primerIngresoDepartamentosDatos.getPrimerIngresoDepartamentos(nombrePI, primerApellidoPI, segundoApellidoPI, cedulaPI);
        }

        public void actualizarPruebasGH(DepartamentoPruebasGH departamentoPruebasGH, string cedulaPI)
        {
            if ( (departamentoPruebasGH == null) || (cedulaPI == null)) throw new Exception("No puede ingresar datos nulos actualizarPruebasGH");
            primerIngresoDepartamentosDatos.actualizarPruebasGH(departamentoPruebasGH, cedulaPI);
        }

    }
}
