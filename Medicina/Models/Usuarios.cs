using System;
using System.Collections.Generic;

namespace Medicina.Models
{
    public partial class Usuarios
    {
        public int UsurioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Puesto { get; set; }
        public string Departamento { get; set; }
        public int Edad { get; set; }
    }
}
