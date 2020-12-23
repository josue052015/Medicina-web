using System;
using System.Collections.Generic;

namespace Medicina.Models
{
    public partial class Identificacions
    {
        public Identificacions()
        {
            Pacientes = new HashSet<Pacientes>();
        }

        public int IdentificacionId { get; set; }
        public string TipoIdentificacion { get; set; }

        public ICollection<Pacientes> Pacientes { get; set; }
    }
}
