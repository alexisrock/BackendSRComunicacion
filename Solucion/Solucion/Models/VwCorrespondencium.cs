using System;
using System.Collections.Generic;

#nullable disable

namespace Solucion.Models
{
    public partial class VwCorrespondencium
    {
        public string IdCorrespondencia { get; set; }
        public int? IdRemitente { get; set; }
        public int? IdDestinatario { get; set; }
        public string RutaArchivo { get; set; }
        public string Observacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string Remitente { get; set; }
        public string Destinatario { get; set; }
    }
}
