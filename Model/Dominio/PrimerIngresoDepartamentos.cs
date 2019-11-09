using System;
using System.Collections.Generic;
using System.Text;

namespace MOGESP.Entities.Dominio
{
    public class PrimerIngresoDepartamentos
    {

        public PrimerIngresoDepartamentos()
        {
            
        }

        public PrimerIngresoDepartamentos(string numeroCedula, string nombrePI, string primerApellido, string segundoApellido, DepartamentoPruebasGH departamentoPruebas, DepartamentoAntecedentes departamentoAntecedentes, DepartamentoPruebasMedicas departamentoPruebasMedicas, DepartamentoVialidad departamentoVialidad, DepartamentoToxicologia departamentoToxicologia)
        {
            NumeroCedula = numeroCedula ?? throw new ArgumentNullException(nameof(numeroCedula));
            NombrePI = nombrePI ?? throw new ArgumentNullException(nameof(nombrePI));
            PrimerApellido = primerApellido ?? throw new ArgumentNullException(nameof(primerApellido));
            SegundoApellido = segundoApellido ?? throw new ArgumentNullException(nameof(segundoApellido));
            DepartamentoPruebas = departamentoPruebas ?? throw new ArgumentNullException(nameof(departamentoPruebas));
            DepartamentoAntecedentes = departamentoAntecedentes ?? throw new ArgumentNullException(nameof(departamentoAntecedentes));
            DepartamentoPruebasMedicas = departamentoPruebasMedicas ?? throw new ArgumentNullException(nameof(departamentoPruebasMedicas));
            DepartamentoVialidad = departamentoVialidad ?? throw new ArgumentNullException(nameof(departamentoVialidad));
            DepartamentoToxicologia = departamentoToxicologia ?? throw new ArgumentNullException(nameof(departamentoToxicologia));
        }



        /*Informacion General del Primer Ingreso*/
        private string numeroCedula;
        public string NumeroCedula
        {
            get { return numeroCedula; }
            set
            {
                if (value == null || value.Trim().Equals("")) throw new Exception("El campo de numeroCedula es requerido");
                numeroCedula = value;
            }
        }
        private string nombrePI;
        public string NombrePI
        {
            get { return nombrePI; }
            set
            {
                if (value == null || value.Trim().Equals("")) throw new Exception("El campo de nombrePI es requerido");
                nombrePI = value;
            }
        }
        private string primerApellido;
        public string PrimerApellido
        {
            get { return primerApellido; }
            set
            {
                if (value == null || value.Trim().Equals("")) throw new Exception("El campo de primerApellido es requerido");
                primerApellido = value;
            }
        }
        private string segundoApellido;
        public string SegundoApellido
        {
            get { return segundoApellido; }
            set
            {
                if (value == null || value.Trim().Equals("")) throw new Exception("El campo de segundoApellido es requerido");
                segundoApellido = value;
            }
        }

        /*Informacion Tabla PruebasGH*/
        private DepartamentoPruebasGH departamentoPruebas;
        public DepartamentoPruebasGH DepartamentoPruebas
        {
            get { return departamentoPruebas; }
            set
            {
                if (value == null) throw new Exception("El campo de departamentoPruebas es requerido");
                departamentoPruebas = value;
            }
        }

        /*Informacion Tabla Antecedentes*/
        private DepartamentoAntecedentes departamentoAntecedentes;
        public DepartamentoAntecedentes DepartamentoAntecedentes
        {
            get { return departamentoAntecedentes; }
            set
            {
                if (value == null) throw new Exception("El campo de departamentoPruebas es requerido");
                departamentoAntecedentes = value;
            }
        }

        /*Informacion Tabla PruebasMedicas*/
        private DepartamentoPruebasMedicas departamentoPruebasMedicas;
        public DepartamentoPruebasMedicas DepartamentoPruebasMedicas
        {
            get { return departamentoPruebasMedicas; }
            set
            {
                if (value == null) throw new Exception("El campo de departamentoPruebas es requerido");
                departamentoPruebasMedicas = value;
            }
        }

        /*Informacion Tabla Vialidad*/
        private DepartamentoVialidad departamentoVialidad;
        public DepartamentoVialidad DepartamentoVialidad
        {
            get { return departamentoVialidad; }
            set
            {
                if (value == null) throw new Exception("El campo de departamentoPruebas es requerido");
                departamentoVialidad = value;
            }
        }

        /*Informacion Tabla Toxicologia*/
        private DepartamentoToxicologia departamentoToxicologia;
        public DepartamentoToxicologia DepartamentoToxicologia
        {
            get { return departamentoToxicologia; }
            set
            {
                if (value == null) throw new Exception("El campo de departamentoPruebas es requerido");
                departamentoToxicologia = value;
            }
        }

    }
}
