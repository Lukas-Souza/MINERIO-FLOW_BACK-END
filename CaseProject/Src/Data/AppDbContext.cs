using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<LotMinerio> LotesMinerio => Set<LotMinerio>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                //  Schema
                modelBuilder.HasDefaultSchema("public");

                // Insert 

                modelBuilder.Entity<LotMinerio>(e =>
            {
                // Table
                e.ToTable("lot_minerio");
                // Define a chave primária
                e.HasKey(e => e.IdLote); 
        
                // Insert values in Table
                e.Property(e => e.IdLote).HasColumnName("id_lote");
                e.Property( e => e.Teor).HasColumnName("teor");
                e.Property(e => e.PesoQuantidade).HasColumnName("peso_quantidade");
                e.Property(e => e.ValorPKilo).HasColumnName("valor_p_kilo");
                e.Property(e => e.UnidadeDeMedidaPeso).HasColumnName("unidade_medida");
                e.Property(e => e.TipoMinerio).HasColumnName("tipo_minerio");
                e.Property(e => e.Status).HasColumnName("status");
                e.Property(e=> e.DataExtracao).HasColumnName("data_extracao");
                e.Property(e => e.IdMineradora).HasColumnName("id_mineradora");
                

            });
            }
            catch (Exception err)
            {
                
                Console.WriteLine("Ocorreu um erro no AppDBCOntext: " + err);
            }
  
        }
    }
}