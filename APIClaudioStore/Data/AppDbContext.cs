using APIClaudioStore.Models;
using Microsoft.EntityFrameworkCore;

namespace APIClaudioStore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Produto>().HasKey(k => k.Id);
            mb.Entity<Produto>().Property(p => p.Nome).HasMaxLength(100);
            mb.Entity<Produto>().Property(p => p.Preco).HasPrecision(10, 2);
            mb.Entity<Produto>().Property(p => p.Descricao).HasMaxLength(250);
            mb.Entity<Produto>().Property(p => p.ImagemUrl).HasMaxLength(300);
        }
    }
}
