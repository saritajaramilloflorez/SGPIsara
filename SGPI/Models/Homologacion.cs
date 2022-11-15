using System;
using System.Collections.Generic;

namespace SGPI.Models
{
    public partial class Homologacion
    {
        public int Idhomologacion { get; set; }
        public int Idestudiante { get; set; }
        public int Idprograma { get; set; }
        public int IdtipoHomologacion { get; set; }
        public string? PeriodoAcademico { get; set; }
        public int Idasignatura { get; set; }
        public string? CodigoHomologacion { get; set; }
        public string? NomAsigHomologacion { get; set; }
        public int CreditosHomologacion { get; set; }
        public double? Nota { get; set; }

        public virtual Asignatura IdasignaturaNavigation { get; set; } = null!;
        public virtual Estudiante IdestudianteNavigation { get; set; } = null!;
        public virtual Programa IdprogramaNavigation { get; set; } = null!;
        public virtual TipoHomologacion IdtipoHomologacionNavigation { get; set; } = null!;
    }
}
