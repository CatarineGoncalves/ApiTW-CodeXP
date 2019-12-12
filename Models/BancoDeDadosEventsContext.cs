using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BancoDeDadosTw.Models
{
    public partial class BancoDeDadosEventsContext : DbContext
    {
        public BancoDeDadosEventsContext()
        {
        }

        public BancoDeDadosEventsContext(DbContextOptions<BancoDeDadosEventsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Comunidade> Comunidade { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<Padrinho> Padrinho { get; set; }
        public virtual DbSet<Sala> Sala { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Uploadtw> Uploadtw { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DESKTOP-3SK1N4M\\SQLEXPRESS;Database=BancoDeDadosEvents;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__A3C02A1051ABBB01");

                entity.Property(e => e.NomeCategoria).IsUnicode(false);

                entity.Property(e => e.StatusCategoria).IsFixedLength();
            });

            modelBuilder.Entity<Comunidade>(entity =>
            {
                entity.HasKey(e => e.IdComunidade)
                    .HasName("PK__Comunida__0BA193C35DAAF430");

                entity.Property(e => e.ContatoComunidade).IsUnicode(false);

                entity.Property(e => e.NomeComunidade).IsUnicode(false);

                entity.Property(e => e.NomeResponsavelComunidade).IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Comunidade)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Comunidad__IdUsu__44FF419A");
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.IdEvento)
                    .HasName("PK__Evento__034EFC0426DED1B1");

                entity.Property(e => e.AlimentacaoEvento).IsFixedLength();

                entity.Property(e => e.CondicaoEvento).IsFixedLength();

                entity.Property(e => e.DescricaoEvento).IsUnicode(false);

                entity.Property(e => e.LibrasEvento).IsFixedLength();

                entity.Property(e => e.LocalizacaoEvento).IsUnicode(false);

                entity.Property(e => e.NomeEvento).IsUnicode(false);

                entity.Property(e => e.RestricaoAlimentacao).IsUnicode(false);

                entity.Property(e => e.StatusEvento).IsFixedLength();

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Evento__IdCatego__5441852A");

                entity.HasOne(d => d.IdSalaNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.IdSala)
                    .HasConstraintName("FK__Evento__IdSala__534D60F1");

                entity.HasOne(d => d.IdUploadNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.IdUpload)
                    .HasConstraintName("FK__Evento__IdUpload__52593CB8");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Evento__IdUsuari__5535A963");
            });

            modelBuilder.Entity<Padrinho>(entity =>
            {
                entity.HasKey(e => e.IdPadrinho)
                    .HasName("PK__Padrinho__0FDA1C9B7C3C1BB1");

                entity.HasOne(d => d.IdEventoNavigation)
                    .WithMany(p => p.Padrinho)
                    .HasForeignKey(d => d.IdEvento)
                    .HasConstraintName("FK__Padrinho__IdEven__59063A47");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Padrinho)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Padrinho__IdUsua__5812160E");
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.HasKey(e => e.IdSala)
                    .HasName("PK__Sala__A04F9B3BFEE535D1");

                entity.HasIndex(e => e.DescricaoSala)
                    .HasName("UQ__Sala__F1843DD1080DE26D")
                    .IsUnique();

                entity.HasIndex(e => e.NomeSala)
                    .HasName("UQ__Sala__42FCBC0EE1FC9E47")
                    .IsUnique();

                entity.Property(e => e.DescricaoSala).IsUnicode(false);

                entity.Property(e => e.NomeSala).IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__CA04062B480B47FB");

                entity.Property(e => e.NomeTipoUsuario).IsUnicode(false);
            });

            modelBuilder.Entity<Uploadtw>(entity =>
            {
                entity.HasKey(e => e.IdUpload)
                    .HasName("PK__UPLOADTw__36363856853ED1E2");

                entity.Property(e => e.ImgEvento).IsUnicode(false);

                entity.Property(e => e.ImgSala).IsUnicode(false);

                entity.Property(e => e.ImgUser).IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF975B19082C");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuario__A9D105345B2B65B2")
                    .IsUnique();

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.NomeUser).IsUnicode(false);

                entity.Property(e => e.Senha).IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuario__IdTipoU__412EB0B6");

                entity.HasOne(d => d.UploadNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.Upload)
                    .HasConstraintName("FK__Usuario__Upload__4222D4EF");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
