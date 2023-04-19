using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace HistoriaClinica.Models
{
    public class ActualizarPaciente
    {
        private readonly List<Paciente> pacientes = new List<Paciente>();

        public ActualizarPaciente(List<Paciente> pacientes, int id, string historiaClinica, string enfermedadRelevante, double costosTratamientos)
        {
            this.pacientes = pacientes;
            this.id = id;
            this.historiaClinica = historiaClinica;
            this.enfermedadRelevante = enfermedadRelevante;
            this.costosTratamientos = costosTratamientos;
        }

        public int id { get; set; }
        public string historiaClinica { get; set; }
        public string enfermedadRelevante { get; set; }
        public double costosTratamientos { get; set; }

        public bool buscarPacienteParaActualizar ()
        {
            bool flagPaciente = false;

            foreach (Paciente paciente in pacientes) 
            {
                if (paciente.persona.id == id) 
                {
                    flagPaciente = true;
                    paciente.historiaClinica = historiaClinica;
                    paciente.enfermedadRelevante = enfermedadRelevante;
                    paciente.costosTratamientos = costosTratamientos;
                }
            }
            if (!flagPaciente) { return false; }
            else { return true; }
        }

        public List<Persona> obtenerLitaPacienteActualizado() 
        {
            if (buscarPacienteParaActualizar()) 
            {
                return new List<Persona>();
            }
            return new List<Persona>();
        }
    }
}