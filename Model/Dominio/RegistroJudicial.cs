using System;
using System.Collections.Generic;
using System.Text;

namespace MOGESP.Entities.Dominio
{
    public class RegistroJudicial
    {


        private int idRegistro;

        public int IdRegistro
        {
            get { return idRegistro; }
            set {
                if (idRegistro > 0) throw new Exception("El id no puede ser negativo");
                idRegistro = value;
            }
        }



        private Puesto puesto;

        public Puesto Puesto
        {
            get { return puesto; }
            set { puesto = value ?? throw new Exception("El puesto debe existir"); }
        }


        private Funcionario funcionario;

        public Funcionario Funcionario
        {
            get { return funcionario; }
            set { funcionario = value ?? throw new Exception("El funcionario debe existir"); }
        }

        public string ActRegistrosJudiciales { get; set; }


        public int Poliza { get; set; }


        public Puesto Proveniente { get; set; }


        private Destino destino;
        public Destino Destino
        {
            get { return destino; }
            set { destino = value ?? throw new Exception("El destino debe existir"); }
        }


        private DateTime   fechaNombramiento;
        public DateTime FechaNombramiento
        {
            get { return fechaNombramiento; }
            set
            {
                if (value > DateTime.Now) throw new Exception("La fecha no es válida");
                fechaNombramiento = value;
            }
        }


        public string Observaciones { get; set; }



        private DateTime fechaCursoBasico;
        public DateTime FechaCursoBasico        
        {
            get { return fechaCursoBasico; }
            set
            {
                if (value > DateTime.Now) throw new Exception("La fecha no es válida");
                fechaCursoBasico = value;
            }
        }


        private Sector sector;
        public Sector Sector
        {
            get { return sector; }
            set { sector = value ?? throw new Exception("El sector debe existir"); }
        }


    }
}
