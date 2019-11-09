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
    public class CuadroGeneralServicio
    {

        readonly CuadroGeneralDatos cuadroGeneralDatos = new CuadroGeneralDatos();


        /// <summary>
        /// 16/10/2019
        /// Samuel Serrano Guerra
        /// Método que retorna todos los primeros ingresos
        /// </summary>
        /// <returns>IEnumerable<PrimerIngreso></returns>
        public IEnumerable<String> traerNumerosConvocatoria()
        {
            return cuadroGeneralDatos.traerNumerosConvocatoria() ?? throw new Exception("No hay registros de convocatorias");
        }

        /// <summary>
        /// Autores: Manfred
        /// 5/11/19
        /// Este método retorna una lista con todos los numeros de flujos por convocatoria.
        /// </summary>
        /// <returns>List<int></returns>
        public List<int> traerNumerosDeFlujoPorConvocatoria(String numeroConvocatoria)
        {
            return cuadroGeneralDatos.traerNumerosDeFlujoPorConvocatoria(numeroConvocatoria) ?? throw new Exception("No hay registros de convocatorias");
        }
        /// <summary>
        /// Autores: Manfred
        /// 7/11/19
        /// Este método retorna una lista que conforma la tabla de los primeros ingresos del cuadro general y puede ser filtrada por numero de convocatoria y numero de flujo.
        /// </summary>
        /// <returns>List<CuadroGeneral></returns>
        public List<CuadroGeneral> traeCuadroGeneral(String numeroConvovatoria, int numeroFlujo)
        {
            return cuadroGeneralDatos.traeCuadroGeneral(numeroConvovatoria, numeroFlujo);
        }
     }
}
