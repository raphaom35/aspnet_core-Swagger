using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<LancamentoHoras> LancamentoHora { get; set; }
        public DbSet<Desenvolvedor> Desenvolvedores { get; set; }
        public DbSet<Projetos> Projeto { get; set; }
        public DbSet<Ranking> Rankings { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

            foreach (var entidades in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) entidades.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

    }
}
