using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai_medical_webAPI.Domains;

#nullable disable

namespace senai_medical_webAPI.Context
{
    //Scaffold-DbContext "Data Source=LAPTOP-DF9B3HCO\SQLEXPRESS; Initial Catalog=Medical_Senai;
    //user id=sa; pwd=senai@132;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Domains -ContextDir Context -Context GufiContext

    public partial class MedicalContext : DbContext
    {
        public MedicalContext()
        {
        }

        public MedicalContext(DbContextOptions<MedicalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clinica> Clinicas { get; set; }
        public virtual DbSet<Consultum> Consulta { get; set; }
        public virtual DbSet<Especialidade> Especialidades { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<Situacao> Situacaos { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
               // optionsBuilder.UseSqlServer("Data Source=LAPTOP-DF9B3HCO\\SQLEXPRESS; Initial Catalog=Medical_Senai; user id=sa; pwd=senai@132;");
                optionsBuilder.UseSqlServer("Data Source=NOTE0113B2\\SQLEXPRESS; Initial Catalog=Medical_Senai; user id=SA; pwd=Senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.Idclinica)
                    .HasName("PK__Clinica__718FA91F22C716BF");

                entity.ToTable("Clinica");

                entity.HasIndex(e => e.RazaoSocial, "UQ__Clinica__448779F0C298E745")
                    .IsUnique();

                entity.HasIndex(e => e.Endereço, "UQ__Clinica__4DFC5FCEDCB0C4B2")
                    .IsUnique();

                entity.HasIndex(e => e.NomeClinica, "UQ__Clinica__5D092ACE0EA57754")
                    .IsUnique();

                entity.HasIndex(e => e.Cnpj, "UQ__Clinica__AA57D6B4200B7EE4")
                    .IsUnique();

                entity.Property(e => e.Idclinica).HasColumnName("IDClinica");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ")
                    .IsFixedLength(true);

                entity.Property(e => e.Endereço)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NomeClinica)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Consultum>(entity =>
            {
                entity.HasKey(e => e.Idconsulta)
                    .HasName("PK__Consulta__420D6C8CDE6824AC");

                entity.Property(e => e.Idconsulta).HasColumnName("IDConsulta");

                entity.Property(e => e.DataConsulta).HasColumnType("date");

                entity.Property(e => e.DescricaoConsulta)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Não apresenta uma descrição dos sintomas')");

                entity.Property(e => e.Idmedico).HasColumnName("IDMedico");

                entity.Property(e => e.Idpaciente).HasColumnName("IDPaciente");

                entity.Property(e => e.Idsituacao).HasColumnName("IDSituacao");

                entity.HasOne(d => d.IdmedicoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.Idmedico)
                    .HasConstraintName("FK__Consulta__IDMedi__534D60F1");

                entity.HasOne(d => d.IdpacienteNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.Idpaciente)
                    .HasConstraintName("FK__Consulta__IDPaci__5441852A");

                entity.HasOne(d => d.IdsituacaoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.Idsituacao)
                    .HasConstraintName("FK__Consulta__IDSitu__5535A963");
            });

            modelBuilder.Entity<Especialidade>(entity =>
            {
                entity.HasKey(e => e.Idespecialidade)
                    .HasName("PK__Especial__3C94B59FE027B340");

                entity.ToTable("Especialidade");

                entity.HasIndex(e => e.NomeEspecialidade, "UQ__Especial__D6E5EBAEAE5D50C9")
                    .IsUnique();

                entity.Property(e => e.Idespecialidade).HasColumnName("IDEspecialidade");

                entity.Property(e => e.NomeEspecialidade)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.IDmedico)
                    .HasName("PK__Medico__DCA3F5803EC80571");

                entity.ToTable("Medico");

                entity.HasIndex(e => e.Crm, "UQ__Medico__C1F887FFCACFE71B")
                    .IsUnique();

                entity.Property(e => e.IDmedico).HasColumnName("iDMedico");

                entity.Property(e => e.Crm)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CRM");

                entity.Property(e => e.Idclinica).HasColumnName("IDClinica");

                entity.Property(e => e.Idespecialidade).HasColumnName("IDEspecialidade");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.Property(e => e.NomeMedico)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdclinicaNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.Idclinica)
                    .HasConstraintName("FK__Medico__IDClinic__48CFD27E");

                entity.HasOne(d => d.IdespecialidadeNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.Idespecialidade)
                    .HasConstraintName("FK__Medico__IDEspeci__47DBAE45");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("FK__Medico__IDUsuari__46E78A0C");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.Idpaciente)
                    .HasName("PK__Paciente__94DF170FCB570E1A");

                entity.ToTable("Paciente");

                entity.HasIndex(e => e.Rg, "UQ__Paciente__321537C8F7D26B66")
                    .IsUnique();

                entity.HasIndex(e => e.Endereço, "UQ__Paciente__4DFC5FCEF80C2516")
                    .IsUnique();

                entity.HasIndex(e => e.Cpf, "UQ__Paciente__C1F89731FB36DBDC")
                    .IsUnique();

                entity.Property(e => e.Idpaciente).HasColumnName("IDPaciente");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CPF")
                    .IsFixedLength(true);

                entity.Property(e => e.DataNasc).HasColumnType("date");

                entity.Property(e => e.Endereço)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.Property(e => e.NomePac)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("RG")
                    .IsFixedLength(true);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("FK__Paciente__IDUsua__4E88ABD4");
            });

            modelBuilder.Entity<Situacao>(entity =>
            {
                entity.HasKey(e => e.Idsituacao)
                    .HasName("PK__Situacao__24531FA770E1B12C");

                entity.ToTable("Situacao");

                entity.Property(e => e.Idsituacao).HasColumnName("IDSituacao");

                entity.Property(e => e.QualSituacao)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdtipoUsuario)
                    .HasName("PK__tipoUsua__53289754935B8C89");

                entity.ToTable("tipoUsuario");

                entity.Property(e => e.IdtipoUsuario).HasColumnName("IDTipoUsuario");

                entity.Property(e => e.PerfisDeUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A64C76FA52");

                entity.ToTable("Usuario");

                entity.HasIndex(e => e.Email, "UQ__Usuario__A9D10534CC2E7C8A")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdtipoUsuario).HasColumnName("IDTipoUsuario");

                entity.Property(e => e.NomeUsu)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdtipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdtipoUsuario)
                    .HasConstraintName("FK__Usuario__IDTipoU__3D5E1FD2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
