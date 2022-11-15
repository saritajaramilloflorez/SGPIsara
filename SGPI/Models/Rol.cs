using System;
using System.Collections.Generic;

namespace SGPI.Models
{
    public partial class Rol
    {
        public Rol()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Idrol { get; set; }
        public string? Rol1 { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
