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

        public void actualizarAntecedentes(DepartamentoAntecedentes departamentoAntecedentes, string cedulaPI)
        {
            if ((departamentoAntecedentes == null) || (cedulaPI == null)) throw new Exception("No puede ingresar datos nulos actualizarAntecedentes");
            primerIngresoDepartamentosDatos.actualizarAntecedentes(departamentoAntecedentes, cedulaPI);
        }

        public void actualizarVialidad(DepartamentoVialidad departamentoVialidad, string cedulaPI)
        {
            if ((departamentoVialidad == null) || (cedulaPI == null)) throw new Exception("No puede ingresar datos nulos actualizarVialidad");
            primerIngresoDepartamentosDatos.actualizarVialidad(departamentoVialidad, cedulaPI);
        }

        public void actualizarPruebasMedicas(DepartamentoPruebasMedicas departamentoPMedicas, string cedulaPI)
        {
            if ((departamentoPMedicas == null) || (cedulaPI == null)) throw new Exception("No puede ingresar datos nulos actualizarPruebasMedicas");
            primerIngresoDepartamentosDatos.actualizarPruebasMedicas(departamentoPMedicas, cedulaPI);
        }

        public void actualizarToxicologia(DepartamentoToxicologia departamentoToxicologia, string cedulaPI)
        {
            if ((departamentoToxicologia == null) || (cedulaPI == null)) throw new Exception("No puede ingresar datos nulos actualizarToxicologia");
            primerIngresoDepartamentosDatos.actualizarToxicologia(departamentoToxicologia, cedulaPI);
        }

    }
}
