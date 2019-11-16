using MOGESP.Entities.Dominio;
using MOGESP.Entities.Utilidades;
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
        private string[] puestos = new string[4] {"Investigador 1", "Agente de Proteccion", "Custodio de detenidos", "Agente de localizacion" };
        private string[] estados = new string[4] { "Nombrado", "Positivo", "Pendiente", "Negativo" };
        //
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
        public ContenedorCuadrogeneral traeCuadroGeneral(String numeroConvovatoria, int numeroFlujo)
        {
            List<CuadroGeneral> cuadroGeneral = cuadroGeneralDatos.traeCuadroGeneral(numeroConvovatoria, numeroFlujo);
            return traeCuadroGeneralContenedor(cuadroGeneral);
        }
        
        private ContenedorCuadrogeneral traeCuadroGeneralContenedor(List<CuadroGeneral> cuadroGeneral)
        {
            int cantidadPruebasGH = 0;
            int cantidadAntecedentes = 0;
            int cantidadVialidad = 0;
            int cantidadToxicologia = 0;
            int cantidadPruebasMedicas = 0;
            int cantidadPositivosEnEspera = 0;
            int cantidadNegativos = 0;
            int cantidadPendientes = 0;
            int cantidadNombrados = 0;

            foreach (CuadroGeneral tupla in cuadroGeneral)
            {
                if (tupla.CantidadDiasAdminPruebasGH != 0 ||tupla.CantidadDiasPruebasGH !=0 &&
                 tupla.Condicion.Equals("Pendiente"))
                {
                    cantidadPruebasGH = cantidadPruebasGH + 1;
                }
                if(tupla.CantidadDiasAdminAntecedentes != 0 || tupla.CantidadDiasAntecedentes != 0 &&
                 tupla.Condicion.Equals("Pendiente"))
                {
                    cantidadAntecedentes = cantidadAntecedentes + 1;
                }
                if (tupla.CantidadDiasAdminPruebasMedicas != 0 || tupla.CantidadDiasPruebasMedicas != 0 &&
                 tupla.Condicion.Equals("Pendiente"))
                {
                    cantidadPruebasMedicas = cantidadPruebasMedicas + 1;
                }
                if (tupla.CantidadDiasAdminToxicologia != 0 || tupla.CantidadDiasToxicologia != 0 &&
                  tupla.Condicion.Equals("Pendiente"))
                {
                    cantidadToxicologia = cantidadToxicologia + 1;
                }
                if (
                    tupla.CantidadDiasAdminVialidad != 0 || tupla.CantidadDiasVialidad != 0 &&
                    tupla.Condicion.Equals("Pendiente"))
                {
                    cantidadVialidad = cantidadVialidad + 1;
                }
                //--------------------------------------------------------------
                if (tupla.Condicion.Equals("Positivo"))
                {
                    cantidadPositivosEnEspera = cantidadPositivosEnEspera + 1;
                }
                else if (tupla.Condicion.Equals("Negativo"))
                {
                    cantidadNegativos = cantidadNegativos + 1;
                }
                else if (tupla.Condicion.Equals("Pendiente"))
                {
                    cantidadPendientes = cantidadPendientes + 1;
                }
                else if (tupla.Condicion.Equals("Nombrado"))
                {
                    cantidadNombrados = cantidadNombrados + 1;
                }
            }
            ContenedorCuadrogeneral contenedor = new ContenedorCuadrogeneral(cuadroGeneral,cantidadPruebasGH, cantidadAntecedentes
                , cantidadVialidad, cantidadToxicologia, cantidadPruebasMedicas, cantidadPositivosEnEspera
                , cantidadNegativos, cantidadPendientes, cantidadNombrados);
            return contenedor;
        }
        
        public ContenedorCuadrogeneral traeCuadroGeneralFiltrado(String numeroConvovatoria, int numeroFlujo, int filtroEstado, int filtroPuesto)
        {
            ContenedorCuadrogeneral contenedorSinFiltrar = traeCuadroGeneral(numeroConvovatoria, numeroFlujo);

            ContenedorCuadrogeneral contenedorFiltrado = new ContenedorCuadrogeneral();
            if (filtroEstado == 0 & filtroPuesto > 0)
            {
                contenedorFiltrado = traeCuadroGeneralFiltradoPorPuesto(contenedorSinFiltrar, filtroPuesto);
            }else if (filtroEstado > 0 & filtroPuesto == 0)
            {
                contenedorFiltrado = traeCuadroGeneralFiltradoPorCondicion(contenedorSinFiltrar, filtroEstado);
            }else if (filtroEstado > 0 & filtroPuesto > 0)
            {
                contenedorFiltrado = traeCuadroGeneralFiltradoPorPuestoYCondicion(contenedorSinFiltrar, filtroPuesto, filtroEstado);
            }

            return contenedorFiltrado;
        }

        private ContenedorCuadrogeneral traeCuadroGeneralFiltradoPorPuesto(ContenedorCuadrogeneral contenedorSinFiltrar, int filtroPuesto)
        {
            List<CuadroGeneral> listaCuadroGeneralFiltrado = new List<CuadroGeneral>();
            foreach (CuadroGeneral tupla in contenedorSinFiltrar.ListaCuadroGeneral)
            {
                foreach (Puesto puesto in tupla.PuestosAplica)
                {
                    if (puesto.Nombre.Equals(puestos[filtroPuesto-1]))
                    {
                        listaCuadroGeneralFiltrado.Add(tupla);
                        break;
                    }
                }

            }
            return traeCuadroGeneralContenedor(listaCuadroGeneralFiltrado);
        }
        private ContenedorCuadrogeneral traeCuadroGeneralFiltradoPorCondicion(ContenedorCuadrogeneral contenedorSinFiltrar, int filtroEstado)
        {
            List<CuadroGeneral> listaCuadroGeneralFiltrado = new List<CuadroGeneral>();
            foreach (CuadroGeneral tupla in contenedorSinFiltrar.ListaCuadroGeneral)
            {
                foreach (Puesto puesto in tupla.PuestosAplica)
                {
                    if (puesto.Condicion.Equals(estados[filtroEstado - 1]))
                    {
                        listaCuadroGeneralFiltrado.Add(tupla);
                        break;
                    }
                }


            }
            return traeCuadroGeneralContenedor(listaCuadroGeneralFiltrado);
        }
        private ContenedorCuadrogeneral traeCuadroGeneralFiltradoPorPuestoYCondicion(ContenedorCuadrogeneral contenedorSinFiltrar, int filtroPuesto, int filtroEstado)
        {
            ContenedorCuadrogeneral contenedorFiltradoPorPuesto = traeCuadroGeneralFiltradoPorPuesto(contenedorSinFiltrar, filtroPuesto);
            List<CuadroGeneral> listaCuadroGeneralFiltrado = new List<CuadroGeneral>();
            foreach (CuadroGeneral tupla in contenedorSinFiltrar.ListaCuadroGeneral)
            {
                foreach (Puesto puesto in tupla.PuestosAplica)
                {
                    if (puesto.Condicion.Equals(estados[filtroEstado-1]) & puesto.Nombre.Equals(puestos[filtroPuesto-1]))
                    {
                        listaCuadroGeneralFiltrado.Add(tupla);
                        break;
                    }
                }

            }
            return traeCuadroGeneralContenedor(listaCuadroGeneralFiltrado);
        }

    }
}
