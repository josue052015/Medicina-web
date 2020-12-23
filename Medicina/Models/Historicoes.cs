using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medicina.Models
{
    public partial class Historicoes
    {
        public int HistoricoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [Display(Name = "Identificacion")]
        public string NumeroIdentificacion { get; set; }

        [Display(Name = "Antecendes Personales")]
        public string AntecendesPersonales { get; set; }

        [Display(Name = "Motivo de consulta")]
        public string MotivoConsulta { get; set; }

        [Display(Name = "Examen físico")]
        public string ExamenFisico { get; set; }

        [Display(Name = "Tratamientos o estudios")]
        public string TratamientosOEstudios { get; set; }

        [Display(Name = "Resultado de Laboratorio")]
        public string ResultadoLaboratorio { get; set; }

        [Display(Name = "Identificacion")]
        public string Indicaciones { get; set; }

        [Display(Name = "Fecha de hoy")]
        public DateTime FechaHoy { get; set; }

        [Display(Name = "Fecha para volver")]
        public DateTime? FechaVolver { get; set; }

        [Display(Name = "Fecha de primera vez")]
        public DateTime? FechaPrimeraVez { get; set; }
    }
}
