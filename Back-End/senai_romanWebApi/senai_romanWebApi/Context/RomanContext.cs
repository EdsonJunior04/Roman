using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai_romanWebApi.Domains;

#nullable disable

namespace senai_romanWebApi.Context
{
    public partial class RomanContext : DbContext
    {
        public RomanContext()
        {
        }

        public RomanContext(DbContextOptions<RomanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Projeto> Projetos { get; set; }
        public virtual DbSet<Tema> Temas { get; set; }
        public virtual DbSet<Tipousuario> Tipousuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=NOTE0113F4\\SQLEXPRESS; Initial Catalog=ROMAN_GEN; user id=sa; pwd=Senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Projeto>(entity =>
            {
                entity.HasKey(e => e.IdProjeto)
                    .HasName("PK__PROJETO__8FCCED76F2BB3E16");

                entity.ToTable("PROJETO");

                entity.Property(e => e.IdProjeto).HasColumnName("idProjeto");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdTema).HasColumnName("idTema");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.HasOne(d => d.IdTemaNavigation)
                    .WithMany(p => p.Projetos)
                    .HasForeignKey(d => d.IdTema)
                    .HasConstraintName("FK__PROJETO__idTema__2F10007B");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Projetos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__PROJETO__idUsuar__2E1BDC42");
            });

            modelBuilder.Entity<Tema>(entity =>
            {
                entity.HasKey(e => e.IdTema)
                    .HasName("PK__TEMA__BCD9EB4847032858");

                entity.ToTable("TEMA");

                entity.HasIndex(e => e.Titulo, "UQ__TEMA__38FA640F96F2E413")
                    .IsUnique();

                entity.Property(e => e.IdTema)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idTema");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("titulo");
            });

            modelBuilder.Entity<Tipousuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TIPOUSUA__03006BFF785A571C");

                entity.ToTable("TIPOUSUARIO");

                entity.HasIndex(e => e.Titulo, "UQ__TIPOUSUA__38FA640FCEB5B2CE")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idTipoUsuario");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("titulo");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__USUARIO__645723A679C53EDA");

                entity.ToTable("USUARIO");

                entity.HasIndex(e => e.Email, "UQ__USUARIO__AB6E61648D5F7663")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__USUARIO__idTipoU__2B3F6F97");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
