using gestao_residuos_ASP.NET.Models;
using Microsoft.EntityFrameworkCore;

namespace gestao_residuos_ASP.NET.Data
{
    public class GestaoResiduosContext : DbContext
    {
        public GestaoResiduosContext(DbContextOptions<GestaoResiduosContext> options) : base(options) { }

        public DbSet<Contato> Contato { get; set; }
        public DbSet<Lixo> Lixo { get; set; }
        public DbSet<ColetaAgendada> ColetaAgendada { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contato>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<ColetaAgendada>()
                .HasOne(c => c.Contato)
                .WithMany()
                .HasForeignKey(c => c.ContatoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ColetaAgendada>()
                .HasOne(c => c.Lixo)
                .WithMany()
                .HasForeignKey(c => c.LixoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
