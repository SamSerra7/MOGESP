using MOGESP.Entities.Dominio;
using MOGESP.DataAccess.TRAN.Datos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOGESP.ServiceLayer.Servicio
{
    /// <summary>
    /// Clase que gestiona las reglas de negocio de los funcionarios
    /// </summary>
    public class FuncionarioServicio
    {

        readonly FuncionarioDatos funcionarioDatos = new FuncionarioDatos();


        /// <summary>
        /// 7/11/2019
        /// Samuel Serrano Guerra
        /// Método que retorna todos los funcionarios
        /// </summary>
        /// <returns>IEnumerable<Funcionario></returns>
        public IEnumerable<Funcionario> ListarFuncionarios()
        {
            return funcionarioDatos.ListarFuncionarios() ?? throw new Exception("No hay registros de primer ingreso");
        }

    }
}
