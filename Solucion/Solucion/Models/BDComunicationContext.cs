using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Solucion.Models
{
    public partial class BDComunicationContext : DbContext
    {
        public BDComunicationContext()
        {
        }

        public BDComunicationContext(DbContextOptions<BDComunicationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Auditorium> Auditoria { get; set; }
        public virtual DbSet<Correspondencium> Correspondencia { get; set; }
        public virtual DbSet<RemDe> RemDes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<TipoRemDe> TipoRemDes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<VwCorrespondencium> VwCorrespondencia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-G58E8B1\\ALEXISDESARROLLA;Initial Catalog=BDComunication;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Auditorium>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreacion");

                entity.Property(e => e.Fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");

                entity.Property(e => e.IdDestinatario).HasColumnName("idDestinatario");

                entity.Property(e => e.IdRemitente).HasColumnName("idRemitente");

                entity.Property(e => e.Idusuarioactualizacion).HasColumnName("idusuarioactualizacion");

                entity.Property(e => e.Idusuariocreacion).HasColumnName("idusuariocreacion");

                entity.Property(e => e.Observacion)
                    .HasMaxLength(200)
                    .HasColumnName("observacion");

                entity.Property(e => e.RutaArchivo).HasColumnName("rutaArchivo");

                entity.Property(e => e.TypeMov)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("typeMov");
            });

            modelBuilder.Entity<Correspondencium>(entity =>
            {
                entity.HasKey(e => e.IdCorrespondencia)
                    .HasName("PK__Correspo__BC78E9D4256C8AA6");

                entity.Property(e => e.IdCorrespondencia)
                    .HasMaxLength(100)
                    .HasColumnName("idCorrespondencia");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreacion");

                entity.Property(e => e.Fechaactualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaactualizacion");

                entity.Property(e => e.IdDestinatario).HasColumnName("idDestinatario");

                entity.Property(e => e.IdRemitente).HasColumnName("idRemitente");

                entity.Property(e => e.Idusuarioactualizacion).HasColumnName("idusuarioactualizacion");

                entity.Property(e => e.Idusuariocreacion).HasColumnName("idusuariocreacion");

                entity.Property(e => e.Observacion)
                    .HasMaxLength(200)
                    .HasColumnName("observacion");

                entity.Property(e => e.RutaArchivo).HasColumnName("rutaArchivo");

                entity.HasOne(d => d.IdDestinatarioNavigation)
                    .WithMany(p => p.CorrespondenciumIdDestinatarioNavigations)
                    .HasForeignKey(d => d.IdDestinatario)
                    .HasConstraintName("FK__Correspon__idDes__20C1E124");

                entity.HasOne(d => d.IdRemitenteNavigation)
                    .WithMany(p => p.CorrespondenciumIdRemitenteNavigations)
                    .HasForeignKey(d => d.IdRemitente)
                    .HasConstraintName("FK__Correspon__idRem__1FCDBCEB");

                entity.HasOne(d => d.IdusuarioactualizacionNavigation)
                    .WithMany(p => p.CorrespondenciumIdusuarioactualizacionNavigations)
                    .HasForeignKey(d => d.Idusuarioactualizacion)
                    .HasConstraintName("FK__Correspon__idusu__22AA2996");

                entity.HasOne(d => d.IdusuariocreacionNavigation)
                    .WithMany(p => p.CorrespondenciumIdusuariocreacionNavigations)
                    .HasForeignKey(d => d.Idusuariocreacion)
                    .HasConstraintName("FK__Correspon__idusu__21B6055D");
            });

            modelBuilder.Entity<RemDe>(entity =>
            {
                entity.HasKey(e => e.Idremitente)
                    .HasName("PK__RemDes__C2DAF6246FFC41A7");

                entity.Property(e => e.Idremitente).HasColumnName("idremitente");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("direccion");

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("documento");

                entity.Property(e => e.IdTipoRemDes).HasColumnName("idTipoRemDes");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("nombres");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(300)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.IdTipoRemDesNavigation)
                    .WithMany(p => p.RemDes)
                    .HasForeignKey(d => d.IdTipoRemDes)
                    .HasConstraintName("FK__RemDes__idTipoRe__1A14E395");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Roles__3C872F767197F862");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<TipoRemDe>(entity =>
            {
                entity.HasKey(e => e.IdTipoRemDes)
                    .HasName("PK__TipoRemD__21627CA2A84A333C");

                entity.Property(e => e.IdTipoRemDes).HasColumnName("idTipoRemDes");

                entity.Property(e => e.Descripcion).HasMaxLength(300);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Usuarios__3717C9826BAECFBA");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("contrasena");

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("documento");

                entity.Property(e => e.Idrol).HasColumnName("idrol");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("username");

                entity.HasOne(d => d.IdrolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Idrol)
                    .HasConstraintName("FK__Usuarios__idrol__1CF15040");
            });

            modelBuilder.Entity<VwCorrespondencium>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwCorrespondencia");

                entity.Property(e => e.Destinatario)
                    .IsRequired()
                    .HasMaxLength(401);

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("documento");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreacion");

                entity.Property(e => e.IdCorrespondencia)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("idCorrespondencia");

                entity.Property(e => e.IdDestinatario).HasColumnName("idDestinatario");

                entity.Property(e => e.IdRemitente).HasColumnName("idRemitente");

                entity.Property(e => e.Observacion)
                    .HasMaxLength(200)
                    .HasColumnName("observacion");

                entity.Property(e => e.Remitente)
                    .IsRequired()
                    .HasMaxLength(401);

                entity.Property(e => e.RutaArchivo).HasColumnName("rutaArchivo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
