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


        public List<int> traerNumerosDeFlujoPorConvocatoria(String numeroConvocatoria)
        {
            return cuadroGeneralDatos.traerNumerosDeFlujoPorConvocatoria(numeroConvocatoria) ?? throw new Exception("No hay registros de convocatorias");
        }
        

    }
}
