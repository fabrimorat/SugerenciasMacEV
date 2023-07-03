using Microsoft.EntityFrameworkCore;
using SugerenciasMacEV.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SugerenciasMacEV.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Informe> Informes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Informe>()
                .HasOne(i => i.Modelo)
                .WithMany(m => m.Informes)
                .HasForeignKey(i => i.ModeloId);
        }
    }
}
