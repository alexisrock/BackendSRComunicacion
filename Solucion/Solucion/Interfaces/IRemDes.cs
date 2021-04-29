using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solucion.Interfaces
{
    public class IRemDes
    {

        public int? idremitente { get; set; }
        public string documento { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public int? idTipoRemDes { get; set; }

    }
}
