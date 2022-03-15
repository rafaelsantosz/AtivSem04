using Microsoft.EntityFrameworkCore;

namespace APICurso.Models
{
    public partial class BDServicoContext : DbContext
    {
        public BDServicoContext()
        {
        }

        public BDServicoContext(DbContextOptions<BDServicoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LimiteCliente> LimiteClientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=BDServico;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<LimiteCliente>(entity =>
            {
                entity.HasKey(e => e.CodigoCliente)
                    .HasName("PK__LimiteCl__6B8A31AD73926908");

                entity.ToTable("LimiteCliente");

                entity.Property(e => e.CodigoCliente).HasColumnName("codigoCliente");

                entity.Property(e => e.NomeCliente)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomeCliente");

                entity.Property(e => e.ValorLimite).HasColumnName("valorLimite");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
