using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.Queries;
using Application.DTOs.Estados.Filtro;
using Application.DTOs.Estados;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Configuration.Extensions;

namespace Infra.Queries.Estados
{
    public class EstadoQuery : IEstadoQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public EstadoQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<EstadoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Estado.AsNoTracking();

            var data = query.Select(x => new EstadoFilterDto
            {
                Id = x.Id,
                IdPais = x.IdPais,
                Nome = x.Nome,
                Sigla = x.Sigla,
                CodIBGE = x.CodIBGE,
                AliquotaIcmsInterestadual = x.AliquotaIcmsInterestadual,
                AliquotaIcmsInterna = x.AliquotaIcmsInterna,
                AliquotaIcmsDiferenca = x.AliquotaIcmsDiferenca
            });

            var response = await data.RetonarFiltroCustomizado<EstadoFilterDto, EstadoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<EstadoByCodeDto?> RetornarPorId(Guid id)
        {
            var Estado = await _dbContext.Estado
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (Estado != null)
            {
                return new EstadoByCodeDto
                {
                    Id = Estado.Id,
                    IdPais = Estado.IdPais,
                    Nome = Estado.Nome,
                    Sigla = Estado.Sigla,
                    CodIBGE = Estado.CodIBGE,
                    AliquotaIcmsInterestadual = Estado.AliquotaIcmsInterestadual,
                    AliquotaIcmsInterna = Estado.AliquotaIcmsInterna,
                    AliquotaIcmsDiferenca = Estado.AliquotaIcmsDiferenca
                };
            }

            return null;
        }
    }
}
