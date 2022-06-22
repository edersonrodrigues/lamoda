using Rgm.Repository.Map;
using Microsoft.EntityFrameworkCore;
using Rgm.Domain.Entities.Entities;

namespace Rgm.Repository.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
                    : base(options)
        {
        }

        public DbSet<Aluno_Entity> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new TokenMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
