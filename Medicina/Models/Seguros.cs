using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medicina.Models
{
    public partial class Seguros
    {
        public Seguros()
        {
            Pacientes = new HashSet<Pacientes>();
        }

        public int TipoSeguroId { get; set; }

        [Display(Name ="Seguros")]
        public string Seguro1 { get; set; }

        public ICollection<Pacientes> Pacientes { get; set; }
    }
}
