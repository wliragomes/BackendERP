using Application.Interfaces.Queries;
using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.ObraFases.Filtro;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.ObraFases;
using SharedKernel.Configuration.Extensions;
using Application.DTOs.ObraOrigens.Filtro;
using Application.DTOs.ObraOrigens;
using Application.DTOs.ObrasPadrao.Filtro;
using Application.DTOs.ObrasPadrao;
using Application.DTOs.ObrasProjetos.Filtro;
using Application.DTOs.ObrasProjetos;

namespace Infra.Queries.ObraFases
{
    public class ObraQuery : IObraQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public ObraQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<ObraFaseFilterDto>> RetornarObraFasePaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.ObraFase.AsNoTracking();

            var data = query.Select(x => new ObraFaseFilterDto
            {
                Id = x.Id,
                Nome = x.Nome
            });

            var response = await data.RetonarFiltroCustomizado<ObraFaseFilterDto, ObraFaseFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<ObraFaseByCodeDto?> RetornarObraFasePorId(Guid id)
        {
            var obraFase = await _dbContext.ObraFase
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (obraFase != null)
            {
                return new ObraFaseByCodeDto
                {
                    Id = obraFase.Id,
                    Nome = obraFase.Nome
                };
            }

            return null;
        }

        public async Task<PaginacaoResponse<ObraOrigemFilterDto>> RetornarObraOrigemPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.ObraOrigem.AsNoTracking();

            var data = query.Select(x => new ObraOrigemFilterDto
            {
                Id = x.Id,
                Nome = x.Nome
            });

            var response = await data.RetonarFiltroCustomizado<ObraOrigemFilterDto, ObraOrigemFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<ObraOrigemByCodeDto?> RetornarObraOrigemPorId(Guid id)
        {
            var obraOrigem = await _dbContext.ObraOrigem
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (obraOrigem != null)
            {
                return new ObraOrigemByCodeDto
                {
                    Id = obraOrigem.Id,
                    Nome = obraOrigem.Nome
                };
            }

            return null;
        }

        public async Task<PaginacaoResponse<ObraPadraoFilterDto>> RetornarObraPadraoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.ObraPadrao.AsNoTracking();

            var data = query.Select(x => new ObraPadraoFilterDto
            {
                Id = x.Id,
                Nome = x.Nome
            });

            var response = await data.RetonarFiltroCustomizado<ObraPadraoFilterDto, ObraPadraoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<ObraPadraoByCodeDto?> RetornarObraPadraoPorId(Guid id)
        {
            var obraPadrao = await _dbContext.ObraPadrao
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (obraPadrao != null)
            {
                return new ObraPadraoByCodeDto
                {
                    Id = obraPadrao.Id,
                    Nome = obraPadrao.Nome
                };
            }

            return null;
        }

        public async Task<PaginacaoResponse<ObraProjetoFilterDto>> RetornarObraProjetoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.ObraProjeto.AsNoTracking();

            var data = query.Select(x => new ObraProjetoFilterDto
            {
                Id = x.Id,
                Nome = x.Nome
            });

            var response = await data.RetonarFiltroCustomizado<ObraProjetoFilterDto, ObraProjetoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<ObraProjetoByCodeDto?> RetornarObraProjetoPorId(Guid id)
        {
            var obraProjeto = await _dbContext.ObraProjeto
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (obraProjeto != null)
            {
                return new ObraProjetoByCodeDto
                {
                    Id = obraProjeto.Id,
                    Nome = obraProjeto.Nome
                };
            }

            return null;
        }
    }
}
