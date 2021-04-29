using System;
using System.Collections.Generic;

#nullable disable

namespace Solucion.Models
{
    public partial class Correspondencium
    {
        public string IdCorrespondencia { get; set; }
        public int? IdRemitente { get; set; }
        public int? IdDestinatario { get; set; }
        public string RutaArchivo { get; set; }
        public string Observacion { get; set; }
        public int? Idusuariocreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? Idusuarioactualizacion { get; set; }
        public DateTime? Fechaactualizacion { get; set; }

        public virtual RemDe IdDestinatarioNavigation { get; set; }
        public virtual RemDe IdRemitenteNavigation { get; set; }
        public virtual Usuario IdusuarioactualizacionNavigation { get; set; }
        public virtual Usuario IdusuariocreacionNavigation { get; set; }
    }
}
