using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web;
//using System.Web.UI.WebControls;

namespace HistoriaClinica.Models
{
    public class Persona
    {
        public Persona(string nombre, string apellidos, int id, DateTime fechaNacimiento) 
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.id = id;
            this.fechaNacimiento = fechaNacimiento;
            this.edad = DateTime.Today.Year - fechaNacimiento.Year;
        }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public int id { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public int edad { get; set; }
        private string genero { get; set; }
    }
}