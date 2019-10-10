using Modelo.Dominio;
using MOGESP.DataAccess.TRAN.Datos;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TesyConsultarTodosPI()
        {
            PrimerIngresoDatos primerIngresoDatos = new PrimerIngresoDatos();

            List<PrimerIngreso> primerosIngresos = new List<PrimerIngreso>();
            primerosIngresos = primerIngresoDatos.getAllPrimerosIngresos();

            Assert.IsNotNull(primerosIngresos);
        }
    }
}