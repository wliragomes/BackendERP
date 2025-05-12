using Application.Interfaces.Queries;
using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Bancos.Filtro;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.Bancos;
using SharedKernel.Configuration.Extensions;

namespace Infra.Queries.Bancos
{
    public class BancoQuery : IBancoQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public BancoQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<BancoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Banco.AsNoTracking();

            var data = query.Select(x => new BancoFilterDto
            {
                Id = x.Id,
                Nome = x.Nome,
                NaoSomar = x.NaoSomar,
                NumeroBanco = x.NumeroBanco
            });

            var response = await data.RetonarFiltroCustomizado<BancoFilterDto, BancoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<BancoByCodeDto?> RetornarPorId(Guid id)
        {
            var Banco = await _dbContext.Banco
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (Banco != null)
            {
                return new BancoByCodeDto
                {
                    Id = Banco.Id,
                    Nome = Banco.Nome,
                    NaoSomar = Banco.NaoSomar,
                    NumeroBanco = Banco.NumeroBanco,
                };
            }

            return null;
        }
    }
}
