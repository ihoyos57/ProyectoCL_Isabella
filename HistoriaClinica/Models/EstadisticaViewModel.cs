using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HistoriaClinica.Models
{
    public class EstadisticaViewModel
    {   
        public double costosEpsSura { get; set; } = 0;
        public double costosEpsNuevaEPS { get; set; } = 0;
        public double costosEpsSaludTotal { get; set; } = 0;
        public double costosEpsSanitas { get; set; } = 0;

        public double porcentajesCostosEpsSura { get; set; } = 0;
        public double porcentajesCostosEpsNuevaEPS { get; set; } = 0;
        public double porcentajesCostosEpsSaludTotal { get; set; } = 0;
        public double porcentajesCostosEpsSanitas { get; set; } = 0;
        public double porcentajesCostosEpsSavia { get; set; } = 0;

        public double porcentajePacientesPorRangoEdadNiño { get; set; } = 0;
        public double porcentajePacientesPorRangoEdadAdoles { get; set; } = 0;
        public double porcentajePacientesPorRangoEdadJoven { get; set; } = 0;
        public double porcentajePacientesPorRangoEdadAdultoMayor { get; set; } = 0;
        public double porcentajePacientesPorRangoEdadAdulto { get; set; } = 0;
        public double porcentajePacientesPorRangoEdadAnciano { get; set; } = 0;

        public double costosTotales { get; set; } = 0;
        public double porcentajePacientesSinEnfermedad { get; set; } = 0;
        public double porcentajePacientesRegimenContributivo { get; set; } = 0;
        public double porcentajePacientesRegimenSubsidiado { get; set; } = 0;
        public double porcentajePacientesCotizante { get; set; } = 0;
        public double porcentajePacientesBeneficiario { get; set; } = 0;
        public int totalPacientesRelevanteCancer { get; set; } = 0;
        public Persona pacienteMayorCosto { get; set; }
    }
}