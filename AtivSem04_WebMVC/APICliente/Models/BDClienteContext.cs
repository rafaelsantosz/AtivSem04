using Microsoft.EntityFrameworkCore;

namespace APICliente.Models
{
    public partial class BDClienteContext : DbContext
    {
        public BDClienteContext()
        {
        }

        public BDClienteContext(DbContextOptions<BDClienteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<VendasCliente> VendasClientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=BDCliente;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<VendasCliente>(entity =>
            {
                entity.HasKey(e => e.IdVenda)
                    .HasName("PK__VendasCl__077BEC282929F95E");

                entity.ToTable("VendasCliente");

                entity.Property(e => e.IdVenda).HasColumnName("idVenda");

                entity.Property(e => e.CodigoCliente).HasColumnName("codigoCliente");

                entity.Property(e => e.DataVenda)
                    .HasColumnType("date")
                    .HasColumnName("dataVenda");

                entity.Property(e => e.ValorVenda).HasColumnName("valorVenda");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
