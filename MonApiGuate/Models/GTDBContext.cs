using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MonApiGuate.Models
{
    public partial class GTDBContext : DbContext
    {
        public GTDBContext()
        {
        }

        public GTDBContext(DbContextOptions<GTDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AmountConfigurations> AmountConfigurations { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<CortesCajeroes> CortesCajeroes { get; set; }
        public virtual DbSet<CuentasTelepeajes> CuentasTelepeajes { get; set; }
        public virtual DbSet<Historico> Historico { get; set; }
        public virtual DbSet<HistoricoListas> HistoricoListas { get; set; }
        public virtual DbSet<ListaNegra> ListaNegra { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<MontosRecargables> MontosRecargables { get; set; }
        public virtual DbSet<OperacionesCajeroes> OperacionesCajeroes { get; set; }
        public virtual DbSet<OperacionesSerBipagos> OperacionesSerBipagos { get; set; }
        public virtual DbSet<Parametrizables> Parametrizables { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AmountConfigurations>(entity =>
            {
                entity.HasKey(e => new { e.Concept, e.Amount })
                    .HasName("PK_dbo.AmountConfigurations");

                entity.Property(e => e.Concept).HasMaxLength(20);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_dbo.AspNetUserRoles");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.Property(e => e.AddressCliente).HasMaxLength(300);

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Cp).HasColumnName("CP");

                entity.Property(e => e.DateTcliente)
                    .HasColumnName("DateTCliente")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmailCliente).HasMaxLength(150);

                entity.Property(e => e.IdCajero)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Nit).HasColumnName("NIT");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.NumCliente)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.PhoneCliente).HasMaxLength(50);
            });

            modelBuilder.Entity<CortesCajeroes>(entity =>
            {
                entity.Property(e => e.Comentario).HasMaxLength(300);

                entity.Property(e => e.DateTapertura)
                    .HasColumnName("DateTApertura")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateTcierre)
                    .HasColumnName("DateTCierre")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCajero).HasMaxLength(128);

                entity.Property(e => e.NumCorte)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<CuentasTelepeajes>(entity =>
            {
                entity.Property(e => e.DateTcuenta)
                    .HasColumnName("DateTCuenta")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCajero)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.NumCuenta)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.SaldoCuenta).HasMaxLength(20);

                entity.Property(e => e.TypeCuenta)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.CuentasTelepeajes)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK_dbo.CuentasTelepeajes_dbo.Clientes_ClienteId");
            });

            modelBuilder.Entity<Historico>(entity =>
            {
                entity.Property(e => e.Carril).HasMaxLength(10);

                entity.Property(e => e.Clase).HasMaxLength(10);

                entity.Property(e => e.Cuerpo).HasMaxLength(10);

                entity.Property(e => e.Delegacion).HasMaxLength(35);

                entity.Property(e => e.Evento).HasMaxLength(10);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Operador).HasMaxLength(20);

                entity.Property(e => e.Plaza).HasMaxLength(35);

                entity.Property(e => e.SaldoActualizado).HasMaxLength(20);

                entity.Property(e => e.SaldoAnterior).HasMaxLength(20);

                entity.Property(e => e.Tag).HasMaxLength(25);
            });

            modelBuilder.Entity<HistoricoListas>(entity =>
            {
                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<ListaNegra>(entity =>
            {
                entity.Property(e => e.Clase).HasMaxLength(30);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.IdCajero)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.NumCliente).HasMaxLength(30);

                entity.Property(e => e.NumCuenta).HasMaxLength(30);

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Observacion)
                    .IsRequired()
                    .HasMaxLength(280);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<OperacionesCajeroes>(entity =>
            {
                entity.Property(e => e.Concepto)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.DateToperacion)
                    .HasColumnName("DateTOperacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TipoPago).HasMaxLength(30);

                entity.HasOne(d => d.Corte)
                    .WithMany(p => p.OperacionesCajeroes)
                    .HasForeignKey(d => d.CorteId)
                    .HasConstraintName("FK_dbo.OperacionesCajeroes_dbo.CortesCajeroes_CorteId");
            });

            modelBuilder.Entity<OperacionesSerBipagos>(entity =>
            {
                entity.ToTable("OperacionesSerBIpagos");

                entity.Property(e => e.Concepto).HasMaxLength(30);

                entity.Property(e => e.DateTopSerBi)
                    .HasColumnName("DateTOpSerBI")
                    .HasColumnType("datetime");

                entity.Property(e => e.NoReferencia).HasMaxLength(30);

                entity.Property(e => e.NumAutoriBanco).HasMaxLength(20);

                entity.Property(e => e.NumAutoriProveedor).HasMaxLength(20);

                entity.Property(e => e.Numero).HasMaxLength(30);

                entity.Property(e => e.Tipo).HasMaxLength(20);
            });

            modelBuilder.Entity<Parametrizables>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cruzes).HasColumnName("cruzes");

                entity.Property(e => e.Destino).HasColumnName("destino");

                entity.Property(e => e.Destinoresidente).HasColumnName("destinoresidente");

                entity.Property(e => e.Extension).HasColumnName("extension");

                entity.Property(e => e.Minutos).HasColumnName("minutos");

                entity.Property(e => e.Origen).HasColumnName("origen");
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.Property(e => e.DateTtag)
                    .HasColumnName("DateTTag")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCajero)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.NumTag)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SaldoTag).HasMaxLength(20);

                entity.HasOne(d => d.Cuenta)
                    .WithMany(p => p.Tags)
                    .HasForeignKey(d => d.CuentaId)
                    .HasConstraintName("FK_dbo.Tags_dbo.CuentasTelepeajes_CuentaId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
