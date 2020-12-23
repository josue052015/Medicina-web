using System;
using System.Collections.Generic;

namespace Medicina.Models
{
    public partial class Sexos
    {
        public Sexos()
        {
            Pacientes = new HashSet<Pacientes>();
        }

        public int SexoId { get; set; }
        public string TipoSexo { get; set; }

        public ICollection<Pacientes> Pacientes { get; set; }
    }
}
