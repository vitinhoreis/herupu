using Herupu.DAO.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Herupu.DAL.Context
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<HistoricoAluno> HistoricoAluno { get; set; }
        public DbSet<Atividade> Atividade { get; set; }
        public DbSet<AtividadeItem> AtividadeItem { get; set; }

        public DataBaseContext() 
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                string connectionString = config.GetConnectionString("HerupuDbConnection").ToString();

                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), null);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().ToTable("T_ALUNO");
            modelBuilder.Entity<HistoricoAluno>().ToTable("T_HISTORICO_ALUNO");
            modelBuilder.Entity<Atividade>().ToTable("T_ATIVIDADE");
            modelBuilder.Entity<AtividadeItem>().ToTable("T_ATIVIDADE_ITEM");

            modelBuilder.Entity<AtividadeItem>()
                       .HasOne<Atividade>()
                       .WithMany()
                       .HasForeignKey(p => p.IdAtividade);

            modelBuilder.Entity<HistoricoAluno>()
                .HasOne<Aluno>()
                .WithMany()
                .HasForeignKey(p => p.IdAluno);
        }
    }
}
