using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;

namespace Infra.Context
{
    public class CratosArquivosDbContext : BaseDbContext<CratosArquivosDbContext>, INewUnitOfWork
    {
        public CratosArquivosDbContext(DbContextOptions<CratosArquivosDbContext> options)
        : base(options)
        { }

        public DbSet<OrdemFabricacaoArquivo> OrdemFabricacaoArquivo { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(CratosArquivosDbContext).Assembly);
            builder.UseCollation("SQL_Latin1_General_CP1_CI_AI");
            //builder.RegistrarSeeds();
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
