using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SGPI.Models
{
    public partial class SGPIBDContext : DbContext
    {
        public SGPIBDContext()
        {
        }

        public SGPIBDContext(DbContextOptions<SGPIBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asignatura> Asignaturas { get; set; } = null!;
        public virtual DbSet<Documento> Documentos { get; set; } = null!;
        public virtual DbSet<Entrevistum> Entrevista { get; set; } = null!;
        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;
        public virtual DbSet<Genero> Generos { get; set; } = null!;
        public virtual DbSet<Homologacion> Homologacions { get; set; } = null!;
        public virtual DbSet<Pago> Pagos { get; set; } = null!;
        public virtual DbSet<Programa> Programas { get; set; } = null!;
        public virtual DbSet<Programacion> Programacions { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<TipoHomologacion> TipoHomologacions { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-3DO278OT;Database=SGPIBD;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asignatura>(entity =>
            {
                entity.HasKey(e => e.Idasignatura)
                    .HasName("PK__tmp_ms_x__2E8CCF3529F537D8");

                entity.ToTable("Asignatura");

                entity.Property(e => e.Idasignatura).HasColumnName("IDAsignatura");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Idprograma).HasColumnName("IDPrograma");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdprogramaNavigation)
                    .WithMany(p => p.Asignaturas)
                    .HasForeignKey(d => d.Idprograma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_IDProgramaAsignatura");
            });

            modelBuilder.Entity<Documento>(entity =>
            {
                entity.HasKey(e => e.IdDoc)
                    .HasName("PK__Document__0E65F8DB75DD8FCD");

                entity.ToTable("Documento");

                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Entrevistum>(entity =>
            {
                entity.HasKey(e => e.Identrevista)
                    .HasName("PK__Entrevis__05824BE9760C13E6");

                entity.Property(e => e.Identrevista).HasColumnName("IDEntrevista");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Idestudiante).HasColumnName("IDEstudiante");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.HasOne(d => d.IdestudianteNavigation)
                    .WithMany(p => p.Entrevista)
                    .HasForeignKey(d => d.Idestudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_IDEstudiante");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Entrevista)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_IDUsuario");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.Idestudiante)
                    .HasName("PK__Estudian__908672BBD3C6A5FB");

                entity.ToTable("Estudiante");

                entity.Property(e => e.Idestudiante).HasColumnName("IDEstudiante");

                entity.Property(e => e.Archivo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Idpago).HasColumnName("IDPago");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.HasOne(d => d.IdpagoNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.Idpago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_IDPago");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_IDUsuarioEstudiante");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.Idgenero)
                    .HasName("PK__Genero__40E9040F100CA7DD");

                entity.ToTable("Genero");

                entity.Property(e => e.Idgenero).HasColumnName("IDGenero");

                entity.Property(e => e.Genero1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Genero");
            });

            modelBuilder.Entity<Homologacion>(entity =>
            {
                entity.HasKey(e => e.Idhomologacion)
                    .HasName("PK__Homologa__01DC9432B623200C");

                entity.ToTable("Homologacion");

                entity.Property(e => e.Idhomologacion)
                    .ValueGeneratedNever()
                    .HasColumnName("IDHomologacion");

                entity.Property(e => e.CodigoHomologacion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Idasignatura).HasColumnName("IDAsignatura");

                entity.Property(e => e.Idestudiante).HasColumnName("IDEstudiante");

                entity.Property(e => e.Idprograma).HasColumnName("IDPrograma");

                entity.Property(e => e.IdtipoHomologacion).HasColumnName("IDTipoHomologacion");

                entity.Property(e => e.NomAsigHomologacion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodoAcademico)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdasignaturaNavigation)
                    .WithMany(p => p.Homologacions)
                    .HasForeignKey(d => d.Idasignatura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AsignaturaaHomologacion");

                entity.HasOne(d => d.IdestudianteNavigation)
                    .WithMany(p => p.Homologacions)
                    .HasForeignKey(d => d.Idestudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_EstudianteHomologacion");

                entity.HasOne(d => d.IdprogramaNavigation)
                    .WithMany(p => p.Homologacions)
                    .HasForeignKey(d => d.Idprograma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ProgramaHomologacion");

                entity.HasOne(d => d.IdtipoHomologacionNavigation)
                    .WithMany(p => p.Homologacions)
                    .HasForeignKey(d => d.IdtipoHomologacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TipoHomologacion");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => e.Idpago)
                    .HasName("PK__Pagos__8A5C3DEE15BC37D6");

                entity.Property(e => e.Idpago).HasColumnName("IDPago");

                entity.Property(e => e.Fecha).HasColumnType("date");
            });

            modelBuilder.Entity<Programa>(entity =>
            {
                entity.HasKey(e => e.Idprograma)
                    .HasName("PK__Programa__072DB4261C2B0322");

                entity.ToTable("Programa");

                entity.Property(e => e.Idprograma).HasColumnName("IDPrograma");

                entity.Property(e => e.Programa1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Programa");
            });

            modelBuilder.Entity<Programacion>(entity =>
            {
                entity.HasKey(e => e.Idprogramacion)
                    .HasName("PK__Programa__E8038DE4FC9EB6B4");

                entity.ToTable("Programacion");

                entity.Property(e => e.Idprogramacion).HasColumnName("IDProgramacion");

                entity.Property(e => e.FechaProgramacion).HasColumnType("datetime");

                entity.Property(e => e.Idasignatura).HasColumnName("IDAsignatura");

                entity.Property(e => e.Idprograma).HasColumnName("IDPrograma");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.Property(e => e.PeriodoAcademico)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Sala)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdasignaturaNavigation)
                    .WithMany(p => p.Programacions)
                    .HasForeignKey(d => d.Idasignatura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_IDAsignaturaProgramacion");

                entity.HasOne(d => d.IdprogramaNavigation)
                    .WithMany(p => p.Programacions)
                    .HasForeignKey(d => d.Idprograma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_IDProgramaProgramacion");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Programacions)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_IDUsuarioProgramacion");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.Idrol)
                    .HasName("PK__Rol__A681ACB61C0900DB");

                entity.ToTable("Rol");

                entity.Property(e => e.Idrol).HasColumnName("IDRol");

                entity.Property(e => e.Rol1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Rol");
            });

            modelBuilder.Entity<TipoHomologacion>(entity =>
            {
                entity.HasKey(e => e.IdtipoHomologacion)
                    .HasName("PK__TipoHomo__ECF4DCC38B0C2766");

                entity.ToTable("TipoHomologacion");

                entity.Property(e => e.IdtipoHomologacion)
                    .ValueGeneratedNever()
                    .HasColumnName("IDTipoHomologacion");

                entity.Property(e => e.TipoHomologacion1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TipoHomologacion");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario)
                    .HasName("PK__Usuario__5231116939A386C0");

                entity.ToTable("Usuario");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Iddoc).HasColumnName("IDDoc");

                entity.Property(e => e.Idgenero).HasColumnName("IDGenero");

                entity.Property(e => e.Idprograma).HasColumnName("IDPrograma");

                entity.Property(e => e.Idrol).HasColumnName("IDRol");

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerNombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoNombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IddocNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Iddoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_IDDoc");

                entity.HasOne(d => d.IdgeneroNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Idgenero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_IGenero");

                entity.HasOne(d => d.IdprogramaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Idprograma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_IDPrograma");

                entity.HasOne(d => d.IdrolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Idrol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_IDRol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
