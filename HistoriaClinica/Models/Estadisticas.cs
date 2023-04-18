using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HistoriaClinica.Models
{
    public class Estadisticas
    {
        private readonly List<Paciente> pacientes = new List<Paciente>();

        public Estadisticas(List<Paciente> pacientes)
        {
            this.pacientes = pacientes;

            costosEps.Add(nombresEps.Sura, 0);
            costosEps.Add(nombresEps.NuevaEPS, 0);
            costosEps.Add(nombresEps.SaludTotal, 0);
            costosEps.Add(nombresEps.Sanitas, 0);
            costosEps.Add(nombresEps.Savia, 0);

            porcentajesCostosEps.Add(nombresEps.Sura, 0);
            porcentajesCostosEps.Add(nombresEps.NuevaEPS, 0);
            porcentajesCostosEps.Add(nombresEps.SaludTotal, 0);
            porcentajesCostosEps.Add(nombresEps.Sanitas, 0);
            porcentajesCostosEps.Add(nombresEps.Savia, 0);

            porcentajePacientesPorRangoEdad.Add("Niño", 0);
            porcentajePacientesPorRangoEdad.Add("Adolescente", 0);
            porcentajePacientesPorRangoEdad.Add("Joven", 0);
            porcentajePacientesPorRangoEdad.Add("Adulto", 0);
            porcentajePacientesPorRangoEdad.Add("Adulto Mayor", 0);
            porcentajePacientesPorRangoEdad.Add("Anciano", 0);
        }

        public Dictionary<nombresEps, double> costosEps = new Dictionary<nombresEps, double>();
        public readonly Dictionary<nombresEps, double> porcentajesCostosEps = new Dictionary<nombresEps, double>();
        public readonly Dictionary<string, double> porcentajePacientesPorRangoEdad = new Dictionary<string, double>();

        public double costosTotales { get; set; } = 0;
        public double porcentajePacientesSinEnfermedad { get; set; } = 0;
        public double porcentajePacientesRegimenContributivo { get; set; } = 0;
        public double porcentajePacientesRegimenSubsidiado { get; set; } = 0;
        public double porcentajePacientesCotizante { get; set; } = 0;
        public double porcentajePacientesBeneficiario { get; set; } = 0;
        public int totalPacientesRelevanteCancer { get; set; } = 0;
        public Persona pacienteMayorCosto { get; set; }

        private void calcularTotalCostosPorEps()
        {
            foreach (Paciente paciente in pacientes)
            {
                if (paciente.eps.nombreEps == nombresEps.Sura)
                {
                    costosTotales += paciente.costosTratamientos;
                    costosEps[nombresEps.Sura] += paciente.costosTratamientos;
                }
                else if (paciente.eps.nombreEps == nombresEps.NuevaEPS)
                {
                    costosTotales += paciente.costosTratamientos;
                    costosEps[nombresEps.NuevaEPS] += paciente.costosTratamientos;
                }
                else if (paciente.eps.nombreEps == nombresEps.SaludTotal)
                {
                    costosTotales += paciente.costosTratamientos;
                    costosEps[nombresEps.SaludTotal] += paciente.costosTratamientos;
                }
                else if (paciente.eps.nombreEps == nombresEps.Sanitas)
                {
                    costosTotales += paciente.costosTratamientos;
                    costosEps[nombresEps.Sanitas] += paciente.costosTratamientos;
                }
                else if (paciente.eps.nombreEps == nombresEps.Savia)
                {
                    costosTotales += paciente.costosTratamientos;
                    costosEps[nombresEps.Savia] += paciente.costosTratamientos;
                }
            }
        }

        private void calcularPorcentajeCostosPorEps()
        {
            porcentajesCostosEps[nombresEps.Sura] = (costosEps[nombresEps.Sura] * 100) / costosTotales;
            porcentajesCostosEps[nombresEps.NuevaEPS] = (costosEps[nombresEps.NuevaEPS] * 100) / costosTotales;
            porcentajesCostosEps[nombresEps.SaludTotal] = (costosEps[nombresEps.SaludTotal] * 100) / costosTotales;
            porcentajesCostosEps[nombresEps.Sanitas] = (costosEps[nombresEps.Sanitas] * 100) / costosTotales;
            porcentajesCostosEps[nombresEps.Savia] = (costosEps[nombresEps.Savia] * 100) / costosTotales;
        }

        private void CalcularPorcetajePacentesSinEnfermedad()
        {
            int pacientesSinEnfermedad = 0;

            foreach (Paciente paciente in pacientes)
            {
                if (paciente.cantidadEnfermedades == 0)
                {
                    pacientesSinEnfermedad++;
                }
            }
            porcentajePacientesSinEnfermedad = (pacientesSinEnfermedad * 100) / pacientes.Count;
        }

        private void obtenerPacienteMayorCostos()
        {
            double mayorCosto = 0;
            int indexMayorCosto = 0;

            foreach (Paciente paciente in pacientes)
            {
                if (paciente.costosTratamientos > mayorCosto)
                {
                    indexMayorCosto++;
                    mayorCosto = paciente.costosTratamientos;
                }
            }
            pacienteMayorCosto = pacientes[indexMayorCosto].persona;
        }

        private void calcularPorcentajePacientesRangoEdad()
        {
            int cantidadNinos = 0;
            int cantidadAdolescente = 0;
            int cantidadJovenes = 0;
            int cantidadAdultos = 0;
            int cantidadAdultoMayor = 0;
            int cantidadAncianos = 0;

            foreach (Paciente paciente in pacientes)
            {
                if (paciente.persona.rangoEdad == "Niño") { cantidadNinos++; }
                else if (paciente.persona.rangoEdad == "Adolescente") { cantidadAdolescente++; }
                else if (paciente.persona.rangoEdad == "Joven") { cantidadJovenes++; }
                else if (paciente.persona.rangoEdad == "Adulto") { cantidadAdultos++; }
                else if (paciente.persona.rangoEdad == "Adulto Mayor") { cantidadAdultoMayor++; }
                else if (paciente.persona.rangoEdad == "Anciano") { cantidadAncianos++; }
            }

            porcentajePacientesPorRangoEdad["Niño"] = (cantidadNinos * 100) / pacientes.Count;
            porcentajePacientesPorRangoEdad["Adolescente"] = (cantidadAdolescente * 100) / pacientes.Count;
            porcentajePacientesPorRangoEdad["Joven"] = (cantidadJovenes * 100) / pacientes.Count;
            porcentajePacientesPorRangoEdad["Adulto"] = (cantidadAdultos * 100) / pacientes.Count;
            porcentajePacientesPorRangoEdad["Adulto Mayor"] = (cantidadAdultoMayor * 100) / pacientes.Count;
            porcentajePacientesPorRangoEdad["Anciano"] = (cantidadAncianos * 100) / pacientes.Count;
        }

        private void porcentajePacientesPorRegimen()
        {
            int cantidadContributivo = 0;
            int cantidadSubsidiado = 0;

            foreach (Paciente paciente in pacientes)
            {
                if (paciente.afiliacion.regimen == tipoRegimen.Contributivo) { cantidadContributivo++; }
                else if (paciente.afiliacion.regimen == tipoRegimen.Subsidiado) { cantidadSubsidiado++; }
            }
            porcentajePacientesRegimenContributivo = (cantidadContributivo * 100) / pacientes.Count;
            porcentajePacientesRegimenSubsidiado = (cantidadSubsidiado * 100) / pacientes.Count;
        }

        private void porcentajePacientesPorAfiliacion()
        {
            int cantidadCotizante = 0;
            int cantidadBeneficierio = 0;

            foreach (Paciente paciente in pacientes)
            {
                if (paciente.tipoAfiliacion == tipoAfiliacion.Cotizante) { cantidadCotizante++; }
                else if (paciente.tipoAfiliacion == tipoAfiliacion.beneficiario) { cantidadBeneficierio++; }
            }
            porcentajePacientesCotizante = (cantidadCotizante * 100) / pacientes.Count;
            porcentajePacientesBeneficiario = (cantidadBeneficierio * 100) / pacientes.Count;
        }

        private void totalPacientesConCancer()
        {
            foreach (Paciente paciente in pacientes)
            {
                if (paciente.enfermedadRelevante == "cancer") { totalPacientesRelevanteCancer++; }
            }
        }

        public void calcularEstadisticas()
        {
            calcularTotalCostosPorEps();
            calcularPorcentajeCostosPorEps();
            CalcularPorcetajePacentesSinEnfermedad();
            obtenerPacienteMayorCostos();
            calcularPorcentajePacientesRangoEdad();
            porcentajePacientesPorRegimen();
            porcentajePacientesPorAfiliacion();
            totalPacientesConCancer();
        }
    }
}