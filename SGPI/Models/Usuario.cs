using System;
using System.Collections.Generic;

namespace SGPI.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Entrevista = new HashSet<Entrevistum>();
            Estudiantes = new HashSet<Estudiante>();
            Programacions = new HashSet<Programacion>();
        }

        public int? Idusuario { get; set; }
        public string? NumeroDocumento { get; set; }
        public int? Iddoc { get; set; }
        public string? PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string? PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public int? Idgenero { get; set; }
        public string? Email { get; set; }
        public int? Idrol { get; set; }
        public string? Password { get; set; }
        public int? Idprograma { get; set; }

        public virtual Documento? IddocNavigation { get; set; } = null!;
        public virtual Genero? IdgeneroNavigation { get; set; } = null!;
        public virtual Programa? IdprogramaNavigation { get; set; } = null!;
        public virtual Rol? IdrolNavigation { get; set; } = null!;
        public virtual ICollection<Entrevistum> Entrevista { get; set; }
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
        public virtual ICollection<Programacion> Programacions { get; set; }
    }
}
