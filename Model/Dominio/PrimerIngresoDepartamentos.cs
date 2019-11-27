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

        public PrimerIngresoDepartamentos(string numeroCedula, string nombreCompleto, DepartamentoPruebasGH departamentoPruebasGH, DepartamentoAntecedentes departamentoAntecedentes, DepartamentoPruebasMedicas departamentoPruebasMedicas, DepartamentoVialidad departamentoVialidad, DepartamentoToxicologia departamentoToxicologia)
        {
            NumeroCedula = numeroCedula ?? throw new ArgumentNullException(nameof(numeroCedula));
            Nombre = nombreCompleto ?? throw new ArgumentNullException(nameof(nombreCompleto));
            DepartamentoPruebasGH = departamentoPruebasGH ?? throw new ArgumentNullException(nameof(departamentoPruebasGH));
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
                numeroCedula = value ?? throw new Exception("El campo de NumeroCedula es requerido");
            }
        }
        private string nombreCompleto;
        public string Nombre
        {
            get { return nombreCompleto; }
            set
            {
                nombreCompleto = value ?? throw new Exception("El campo de nombre es requerido");
            }
        }

        /*Informacion Tabla PruebasGH*/
        private DepartamentoPruebasGH departamentoPruebasGH;
        public DepartamentoPruebasGH DepartamentoPruebasGH
        {
            get { return departamentoPruebasGH; }
            set
            {
                if (value == null) throw new Exception("El campo de departamentoPruebas es requerido");
                departamentoPruebasGH = value;
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
