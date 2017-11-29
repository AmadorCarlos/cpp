using Microsoft.AspNet.Identity.EntityFramework;
using CPP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CPP.Contexto
{
    public class ModeloContexto : IdentityDbContext<ApplicationUser>
    {
        public ModeloContexto() : base("DefaultConnection",
            throwIfV1Schema: false)
        {
            Database.SetInitializer<ModeloContexto>(null);
        }

        public static ModeloContexto Create()
        {
            return new ModeloContexto();
        }


        public DbSet<Cita> Citas { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Enfermedad> Enfermedades { get; set; }
        public DbSet<EspecialidadDoctor> EspecialidadesDoctor { get; set; }
        public DbSet<EstadoCivil> EstadosCiviles { get; set; }
        public DbSet<Examen> Examenes { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Familiar> Familiares { get; set; }
        public DbSet<HistorialClinico> HistorialesClinicos { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<OcupacionPaciente> OcupacionesPaciente { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Sexo> Sexo { get; set; }
        public DbSet<TipodeSangre> TiposdeSangre { get; set; }
        public DbSet<TipoExamen> TipoExamen { get; set; }
        public DbSet<Tratamiento> Tratamientos { get; set; }
        


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
           /* modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(250));

            #region EntityConfiguration




            #endregion
            */
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(entry => entry.GetType().GetProperty("DateCreation") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DateCreation").CurrentValue = System.DateTime.Now;
                }
            }

            foreach (var entry in ChangeTracker.Entries()
                .Where(entry => entry.GetType().GetProperty("DateModification") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DateModification").CurrentValue = System.DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DateModification").CurrentValue = System.DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

        
    }
}