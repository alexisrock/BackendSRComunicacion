using System;
using System.Collections.Generic;

#nullable disable

namespace Solucion.Models
{
    public partial class RemDe
    {
        public RemDe()
        {
            CorrespondenciumIdDestinatarioNavigations = new HashSet<Correspondencium>();
            CorrespondenciumIdRemitenteNavigations = new HashSet<Correspondencium>();
        }

        public int Idremitente { get; set; }
        public string Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int? IdTipoRemDes { get; set; }

        public virtual TipoRemDe IdTipoRemDesNavigation { get; set; }
        public virtual ICollection<Correspondencium> CorrespondenciumIdDestinatarioNavigations { get; set; }
        public virtual ICollection<Correspondencium> CorrespondenciumIdRemitenteNavigations { get; set; }
    }
}
