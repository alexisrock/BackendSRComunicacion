using System;
using System.Collections.Generic;

#nullable disable

namespace Solucion.Models
{
    public partial class TipoRemDe
    {
        public TipoRemDe()
        {
            RemDes = new HashSet<RemDe>();
        }

        public int IdTipoRemDes { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<RemDe> RemDes { get; set; }
    }
}
