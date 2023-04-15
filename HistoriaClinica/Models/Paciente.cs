using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HistoriaClinica.Models
{
    public class Paciente
    {
        public Persona persona { get; set; }
        public Afiliacion afiliacion { get; set; }
        public Eps eps { get; set; }

        public Paciente(string nombre, string apellidos, int id, DateTime fechaNacimiento, string genero,
                        int tipoRegimen, int semanasCotizadas, DateTime fechaIngresoSistemaSalud,
                        DateTime fechaIngresoEps, nombresEps nombreEps,
                        string historiaClinica, string enfermedadRelevante, int cantidadEnfermedades, int tipoAfiliacion, int costosTratamientos)
        {
            persona = new Persona(nombre, apellidos, id, fechaNacimiento, genero);
            afiliacion = new Afiliacion(tipoRegimen, semanasCotizadas, fechaIngresoSistemaSalud);
            eps = new Eps(fechaIngresoEps, nombreEps);

            this.historiaClinica = historiaClinica;
            this.enfermedadRelevante = enfermedadRelevante;
            this.cantidadEnfermedades = cantidadEnfermedades;
            this.tipoAfiliacion = tipoAfiliacion;
            this.costosTratamientos = costosTratamientos;
        }
        public string historiaClinica { get; set; }
        public string enfermedadRelevante { get; set; }
        public int cantidadEnfermedades { get; set; }
        public int tipoAfiliacion { get; set; }
        public int costosTratamientos { get; set; }
    }
}