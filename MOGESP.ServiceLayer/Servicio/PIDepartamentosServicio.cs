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

        public PrimerIngresoDepartamentos getPrimerIngresoDepartamentos(string cedulaPrimerIngreso)
        {
            return primerIngresoDepartamentosDatos.getPrimerIngresoDepartamentos(cedulaPrimerIngreso);
        }

        public void actualizarPruebasGH(DepartamentoPruebasGH departamentoPruebasGH, string cedula)
        {
            if ( (departamentoPruebasGH == null) || (cedula == null)) throw new Exception("No puede ingresar datos nulos actualizarPruebasGH");
            primerIngresoDepartamentosDatos.actualizarPruebasGH(departamentoPruebasGH, cedula);
        }

        public void actualizarAntecedentes(DepartamentoAntecedentes departamentoAntecedentes, string cedula)
        {
            if ((departamentoAntecedentes == null) || (cedula == null)) throw new Exception("No puede ingresar datos nulos actualizarAntecedentes");
            primerIngresoDepartamentosDatos.actualizarAntecedentes(departamentoAntecedentes, cedula);
        }

        public void actualizarVialidad(DepartamentoVialidad departamentoVialidad, string cedula)
        {
            if ((departamentoVialidad == null) || (cedula == null)) throw new Exception("No puede ingresar datos nulos actualizarVialidad");
            primerIngresoDepartamentosDatos.actualizarVialidad(departamentoVialidad, cedula);
        }

        public void actualizarPruebasMedicas(DepartamentoPruebasMedicas departamentoPMedicas, string cedula)
        {
            if ((departamentoPMedicas == null) || (cedula == null)) throw new Exception("No puede ingresar datos nulos actualizarPruebasMedicas");
            primerIngresoDepartamentosDatos.actualizarPruebasMedicas(departamentoPMedicas, cedula);
        }

        public void actualizarToxicologia(DepartamentoToxicologia departamentoToxicologia, string cedula)
        {
            if ((departamentoToxicologia == null) || (cedula == null)) throw new Exception("No puede ingresar datos nulos actualizarToxicologia");
            primerIngresoDepartamentosDatos.actualizarToxicologia(departamentoToxicologia, cedula);
        }

    }
}
