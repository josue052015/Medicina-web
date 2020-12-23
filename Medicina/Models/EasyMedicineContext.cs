using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Medicina.Models
{
    public partial class EasyMedicineContext : DbContext
    {
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Historicoes> Historicoes { get; set; }
        public virtual DbSet<Identificacions> Identificacions { get; set; }
        public virtual DbSet<Pacientes> Pacientes { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Seguros> Seguros { get; set; }
        public virtual DbSet<Sexos> Sexos { get; set; }
        public virtual DbSet<Sysdiagrams> Sysdiagrams { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DELL\RAYMER;Database=EasyMedicine;Trusted_Connection=True;");
            }
        }

        public EasyMedicineContext(DbContextOptions<EasyMedicineContext> options)
                        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.ClienteId);

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Vendedor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Historicoes>(entity =>
            {
                entity.HasKey(e => e.HistoricoId);

                entity.Property(e => e.AntecendesPersonales).HasColumnName("Antecendes_Personales");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExamenFisico).HasColumnName("Examen_Fisico");

                entity.Property(e => e.FechaHoy)
                    .HasColumnName("Fecha_Hoy")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaPrimeraVez)
                    .HasColumnName("Fecha_PrimeraVez")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaVolver)
                    .HasColumnName("Fecha_Volver")
                    .HasColumnType("datetime");

                entity.Property(e => e.MotivoConsulta).HasColumnName("Motivo_Consulta");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroIdentificacion)
                    .IsRequired()
                    .HasColumnName("Numero_Identificacion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ResultadoLaboratorio).HasColumnName("Resultado_Laboratorio");

                entity.Property(e => e.TratamientosOEstudios).HasColumnName("Tratamientos_O_Estudios");
            });

            modelBuilder.Entity<Identificacions>(entity =>
            {
                entity.HasKey(e => e.IdentificacionId);

                entity.Property(e => e.TipoIdentificacion)
                    .HasColumnName("Tipo_Identificacion")
                    .HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<Pacientes>(entity =>
            {
                entity.HasKey(e => e.PacienteId);

                entity.HasIndex(e => e.Identificacion)
                    .HasName("IX_FK_IdentificacionPaciente");

                entity.HasIndex(e => e.Sexo)
                    .HasName("IX_FK_SexoPaciente");

                entity.HasIndex(e => e.TipoSeguro)
                    .HasName("IX_FK_SeguroPaciente");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("Fecha_Nacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.FechaPrimeraVez)
                    .HasColumnName("Fecha_PrimeraVez")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroIdentificacion)
                    .HasColumnName("Numero_Identificacion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoCasa)
                    .HasColumnName("Telefono_Casa")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoCelular)
                    .HasColumnName("Telefono_Celular")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipoSeguro).HasColumnName("Tipo_Seguro");

                entity.HasOne(d => d.IdentificacionNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.Identificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdentificacionPaciente");

                entity.HasOne(d => d.SexoNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.Sexo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SexoPaciente");

                entity.HasOne(d => d.TipoSeguroNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.TipoSeguro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SeguroPaciente");
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.HasKey(e => e.ProductoId);

                entity.Property(e => e.ProductoId).HasColumnName("productoId");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasColumnName("codigo")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Itbis).HasColumnName("ITBIS");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Seguros>(entity =>
            {
                entity.HasKey(e => e.TipoSeguroId);

                entity.Property(e => e.TipoSeguroId).HasColumnName("Tipo_seguroId");

                entity.Property(e => e.Seguro1)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sexos>(entity =>
            {
                entity.HasKey(e => e.SexoId);

                entity.Property(e => e.TipoSexo)
                    .HasColumnName("Tipo_Sexo")
                    .HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<Sysdiagrams>(entity =>
            {
                entity.HasKey(e => e.DiagramId);

                entity.ToTable("sysdiagrams");

                entity.Property(e => e.DiagramId).HasColumnName("diagram_id");

                entity.Property(e => e.Definition).HasColumnName("definition");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(128);

                entity.Property(e => e.PrincipalId).HasColumnName("principal_id");

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.UsurioId);

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Departamento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Puesto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
