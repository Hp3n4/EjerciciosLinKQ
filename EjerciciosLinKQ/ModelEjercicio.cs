using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EjerciciosLinKQ
{
    public partial class ModelEjercicio : DbContext
    {
        public ModelEjercicio()
            : base("name=ModelEjercicio")
        {
        }

        public virtual DbSet<alumnos> alumnos { get; set; }
        public virtual DbSet<departamentos> departamentos { get; set; }
        public virtual DbSet<distritos> distritos { get; set; }
        public virtual DbSet<notas> notas { get; set; }
        public virtual DbSet<provincias> provincias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<alumnos>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<departamentos>()
                .Property(e => e.departamento)
                .IsUnicode(false);

            modelBuilder.Entity<departamentos>()
                .HasMany(e => e.provincias)
                .WithRequired(e => e.departamentos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<distritos>()
                .Property(e => e.distrito)
                .IsUnicode(false);

            modelBuilder.Entity<provincias>()
                .Property(e => e.provincia)
                .IsUnicode(false);

            modelBuilder.Entity<provincias>()
                .HasMany(e => e.distritos)
                .WithRequired(e => e.provincias)
                .WillCascadeOnDelete(false);
        }
    }
}
