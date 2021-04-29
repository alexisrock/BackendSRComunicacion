using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solucion.Interfaces
{
    public class ICorrespondencia
    {


        public int? idCorrespondencia { get; set; }
        public int idRemitente { get; set; }
        public int idDestinatario { get; set; }
        public string rutaArchivo { get; set; }
        public string  observacion { get; set; }
        public int? idusuariocreacion { get; set; }
        public DateTime? fechaCreacion { get; set; }
        public int? idusuarioactualizacion { get; set; }
        public DateTime? fechaactualizacion { get; set; }
        public int? tipoCorrespondencia { get; set; }

    }
}
