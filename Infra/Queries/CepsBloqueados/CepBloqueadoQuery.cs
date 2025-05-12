using Application.Interfaces.Queries;
using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.CepsBloqueados.Filtro;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.CepsBloqueados;
using SharedKernel.Configuration.Extensions;

namespace Infra.Queries.CepsBloqueados
{
    public class CepBloqueadoQuery : ICepBloqueadoQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public CepBloqueadoQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<CepBloqueadoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.CepBloqueado.AsNoTracking();

            var data = query.Select(x => new CepBloqueadoFilterDto
            {
                Id = x.Id,
                NumeroCep = x.NumeroCep,
                Descricao = x.Descricao                
            });

            var response = await data.RetonarFiltroCustomizado<CepBloqueadoFilterDto, CepBloqueadoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<CepBloqueadoByCodeDto?> RetornarPorId(Guid id)
        {
            var CepBloqueado = await _dbContext.CepBloqueado
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (CepBloqueado != null)
            {
                return new CepBloqueadoByCodeDto
                {
                    Id = CepBloqueado.Id,
                    NumeroCep = CepBloqueado.NumeroCep,
                    Descricao = CepBloqueado.Descricao,
                    NumeroDe = CepBloqueado.NumeroDe,
                    NumeroAte = CepBloqueado.NumeroAte,
                    Par = CepBloqueado.Par,
                    Impar = CepBloqueado.Impar,
                };
            }

            return null;
        }
    }
}
