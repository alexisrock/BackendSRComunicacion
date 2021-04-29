using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solucion.Interfaces
{
    public class IUsuarios
    {

        public int?idUser { get; set; }
        public string documento { get; set; }
        public string username { get; set; }
        public string contrasena { get; set; }
        public int? idrol { get; set; }


    }
}
