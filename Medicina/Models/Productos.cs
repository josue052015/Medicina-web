using System;
using System.Collections.Generic;

namespace Medicina.Models
{
    public partial class Productos
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public double? Itbis { get; set; }
        public double? Descuentos { get; set; }
        public string Codigo { get; set; }
    }
}
