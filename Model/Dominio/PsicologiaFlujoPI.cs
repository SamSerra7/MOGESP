using System;

namespace Modelo.Dominio
{
    public class PsicologiaFlujoPI
    {

        public PsicologiaFlujoPI()
        {
        }

        public PsicologiaFlujoPI(int id, HojaCitasPI hojaCitas, DateTime fechaSalida, int certificadoDoneidadMental,
                                    TestPersonalidad testPersonalidad, TestVisomotor testVisomotor, TestCompetencias testCompetencias, OtrosTest otrosTest, Consentimiento consentimiento)
        {
            Id = id;
            HojaCitas = hojaCitas;
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


        private HojaCitasPI hojaCitas;

        public HojaCitasPI HojaCitas
        {
            get { return hojaCitas; }
            set { hojaCitas = value ?? throw new Exception("Debe tener una hoja de citas asociada"); }
        }



        public DateTime FechaSalida
        {
            get;
            set;
        }

        public int CertificadoDoneidadMental
        {
            get;
            set;
        }

        public TestPersonalidad TestPersonalidad
        {
            get;
            set;
        }

        public TestVisomotor TestVisomotor
        {
            get;
            set;
        }


        public TestCompetencias TestCompetencias
        {
            get;
            set;
        }

        public OtrosTest OtrosTest
        {
            get;
            set;
        }


        private Consentimiento consentimiento;
        public Consentimiento Consentimiento
        {
            get;
            set;
        }

    }
}