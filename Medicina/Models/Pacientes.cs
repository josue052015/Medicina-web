using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medicina.Models
{
    public partial class Pacientes
    {
        public int PacienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Sexo { get; set; }
        public int Identificacion { get; set; }

        [Display(Name = "Numero de identificacion")]
        public string NumeroIdentificacion { get; set; }

        [Display(Name = "Telefono de Casa")]
        public string TelefonoCasa { get; set; }

        [Display(Name = "Telefono Celular")]
        public string TelefonoCelular { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? FechaNacimiento { get; set; }

        public int? Edad { get; set; }

        [Display(Name = "Tipo de Seguro")]
        public int TipoSeguro { get; set; }

        [Display(Name = "Fecha de PrimeraVez")]
        public DateTime? FechaPrimeraVez { get; set; }


        public Identificacions IdentificacionNavigation { get; set; }
        public Sexos SexoNavigation { get; set; }
        public Seguros TipoSeguroNavigation { get; set; }
    }
}
