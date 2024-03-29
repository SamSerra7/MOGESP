﻿using System;

namespace MOGESP.Entities.Dominio
{
    public class HojaCitasPI
    {




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


        private Asistencia asistencia;
        public Asistencia Asistencia
        {
            get { return asistencia; }
            set { asistencia = value ?? throw new Exception("La asistencia es requerida"); }
        }

        private Psicologo psicologo;

        public Psicologo Psicologo
        {
            get { return psicologo; }
            set { psicologo = value ?? throw new Exception("El psicólogo(a) es requerido(a)"); }
        }

        private CorreoCitas correoCitas;

        public CorreoCitas CorreoCitas
        {
            get { return correoCitas; }
            set { correoCitas = value ?? throw new Exception("La información de correo es requerida"); }
        }

        private DateTime fechaCita;

        public HojaCitasPI(int id, Asistencia asistencia, Psicologo psicologo, CorreoCitas correoCitas, DateTime fechaCita)
        {
            Id = id;
            Asistencia = asistencia;
            Psicologo = psicologo;
            CorreoCitas = correoCitas;
            FechaCita = fechaCita;
        }

        public DateTime FechaCita
        {
            get { return fechaCita; }
            set {
                if(DateTime.Now < value) throw new Exception("La fecha no es válida");
                fechaCita = value; }
        }


    }
}