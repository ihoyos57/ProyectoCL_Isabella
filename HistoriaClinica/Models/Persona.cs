using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web;
//using System.Web.UI.WebControls;

namespace HistoriaClinica.Models
{
    public class Persona
    {
        public Persona(string nombre, string apellidos, int id, DateTime fechaNacimiento, string genero)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.id = id;
            this.fechaNacimiento = fechaNacimiento;
            this.genero = genero;

            edad = DateTime.Today.Year - fechaNacimiento.Year;
            rangoEdad = obtenerRangoEdad();
        }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public int id { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public int edad { get; set; }
        public string genero { get; set; }
        public string rangoEdad { get; set; }

        private string obtenerRangoEdad()
        {
            if ((edad >= 0 && edad < 12))
            {
                return "Niño";
            }
            else if (edad >= 12 && edad < 18)
            {
                return "Adolescente";
            }
            else if (edad >= 18 && edad < 30)
            {
                return "Joven";
            }
            else if (edad >= 30 && edad < 55)
            {
                return "Adulto";
            }
            else if (edad >= 55 && edad < 75)
            {
                return "Adulto Mayor";
            }
            else { return "Anciano"; }
        }
    }
}