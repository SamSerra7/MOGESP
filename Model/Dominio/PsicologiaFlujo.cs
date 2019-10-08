using System;

namespace Modelo.Dominio
{
    public class PsicologiaFlujo
    {

        public PsicologiaFlujo()
        {
        }

        public PsicologiaFlujo(int id, DateTime fechaSalida, int certificadoDoneidadMental, TestPersonalidad testPersonalidad, TestVisomotor testVisomotor, TestCompetencias testCompetencias, OtrosTest otrosTest, string consentimiento)
        {
            Id = id;
            FechaSalida = fechaSalida;
            CertificadoDoneidadMental = certificadoDoneidadMental;
            TestPersonalidad = testPersonalidad;
            TestVisomotor = testVisomotor;
            TestCompetencias = testCompetencias;
            OtrosTest = otrosTest;
            Consentimiento = consentimiento;
        }

        private int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value > 0) throw new Exception("El id debe ser positivo");
                id = value;
            }
        }

        private DateTime fechaSalida;
        public DateTime FechaSalida
        {
            get
            {
                return fechaSalida;
            }
            set
            {

                fechaSalida = value;
            }
        }

        private int certificadoDoneidadMental;
        public int CertificadoDoneidadMental
        {
            get
            {
                return certificadoDoneidadMental;
            }
            set
            {
                if (value > 0) throw new Exception("El id debe ser positivo");
                id = value;
            }
        }

        private TestPersonalidad testPersonalidad;

        public TestPersonalidad  TestPersonalidad
        {
            get { return testPersonalidad; }
            set { testPersonalidad = value; }
        }

        private TestVisomotor testVisomotor;

        public TestVisomotor TestVisomotor
        {
            get { return testVisomotor; }
            set { testVisomotor = value; }
        }


        private TestCompetencias testCompetencias;

        public TestCompetencias TestCompetencias
        {
            get { return testCompetencias; }
            set { testCompetencias = value; }
        }

        private OtrosTest otrosTest;

        public OtrosTest OtrosTest
        {
            get { return otrosTest; }
            set { otrosTest = value; }
        }
        private string consentimiento;
        public string Consentimiento
        {
            get
            {
                return consentimiento;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) throw new Exception("El consentimiento es requerido");
                consentimiento = value;
            }
        }

    }
}