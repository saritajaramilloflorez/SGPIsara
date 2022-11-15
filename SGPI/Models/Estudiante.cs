using System;
using System.Collections.Generic;

namespace SGPI.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            Entrevista = new HashSet<Entrevistum>();
            Homologacions = new HashSet<Homologacion>();
        }

        public int Idestudiante { get; set; }
        public string? Archivo { get; set; }
        public int? Idusuario { get; set; }
        public int? Idpago { get; set; }
        public bool Egresado { get; set; }

        public virtual Pago IdpagoNavigation { get; set; } = null!;
        public virtual Usuario IdusuarioNavigation { get; set; } = null!;
        public virtual ICollection<Entrevistum> Entrevista { get; set; }
        public virtual ICollection<Homologacion> Homologacions { get; set; }
    }
}
