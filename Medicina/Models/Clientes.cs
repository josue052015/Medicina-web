using System;
using System.Collections.Generic;

namespace Medicina.Models
{
    public partial class Clientes
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Identificacion { get; set; }
        public string Vendedor { get; set; }
    }
}
