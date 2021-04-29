using System;
using System.Collections.Generic;

#nullable disable

namespace Solucion.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            CorrespondenciumIdusuarioactualizacionNavigations = new HashSet<Correspondencium>();
            CorrespondenciumIdusuariocreacionNavigations = new HashSet<Correspondencium>();
        }

        public int IdUser { get; set; }
        public string Documento { get; set; }
        public string Username { get; set; }
        public string Contrasena { get; set; }
        public int? Idrol { get; set; }

        public virtual Role IdrolNavigation { get; set; }
        public virtual ICollection<Correspondencium> CorrespondenciumIdusuarioactualizacionNavigations { get; set; }
        public virtual ICollection<Correspondencium> CorrespondenciumIdusuariocreacionNavigations { get; set; }
    }
}
