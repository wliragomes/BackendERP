using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Configuration.Extensions;
using Application.DTOs.Impostos.CstIcmss.Filtro;
using Application.Interfaces.Queries;
using Application.DTOs.Impostos.CstIpis.Filtro;
using Application.DTOs.Impostos.CstIpis;
using Application.DTOs.Impostos.CstIcmsOrigemMateriais.Filtro;
using Application.DTOs.Impostos.CstIcmsOrigemMateriais;
using Application.DTOs.Impostos.Piss.Filtro;
using Application.DTOs.Impostos.Coffinss.Filtro;
using Application.DTOs.Impostos.Cofinss.Filtro;

namespace Infra.Queries.Impostos
{
    public class ImpostoQuery : IImpostoQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public ImpostoQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<CstIcmsFilterDto>> RetornarCstIcmsPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.CST_ICMS.AsNoTracking();

            var data = query.Select(x => new CstIcmsFilterDto
            {
                Id = x.Id,
                Nome = x.Nome,
                DescontaIcms = x.DescontaIcms,
                CstIcmsAmigavel = x.CstIcmsAmigavel
            });

            var response = await data.RetonarFiltroCustomizado<CstIcmsFilterDto, CstIcmsFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<CstIcmsByCodeDto?> RetornarCstIcmsPorId(Guid id)
        {
            var CST_ICMS = await _dbContext.CST_ICMS
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (CST_ICMS != null)
            {
                return new CstIcmsByCodeDto
                {
                    Id = CST_ICMS.Id,
                    Nome = CST_ICMS.Nome,
                    DescontaIcms = CST_ICMS.DescontaIcms,
                    CstIcmsAmigavel = CST_ICMS.CstIcmsAmigavel,
                };
            }

            return null;
        }

        public async Task<PaginacaoResponse<CstIpiFilterDto>> RetornarCstIpiPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.CST_IPI.AsNoTracking();

            var data = query.Select(x => new CstIpiFilterDto
            {
                Id = x.Id,
                Nome = x.Nome,
                CstIpiAmigavel = x.CstIpiAmigavel,
                CobraIpi = x.CobraIpi,
                EntradaSaida = x.EntradaSaida
            });

            var response = await data.RetonarFiltroCustomizado<CstIpiFilterDto, CstIpiFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<CstIpiByCodeDto?> RetornarCstIpiPorId(Guid id)
        {
            var CST_IPI = await _dbContext.CST_IPI
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (CST_IPI != null)
            {
                return new CstIpiByCodeDto
                {
                    Id = CST_IPI.Id,
                    Nome = CST_IPI.Nome,
                    CstIpiAmigavel = CST_IPI.CstIpiAmigavel,
                    CobraIpi = CST_IPI.CobraIpi,
                    EntradaSaida = CST_IPI.EntradaSaida,
                };
            }

            return null;
        }

        public async Task<PaginacaoResponse<CstIcmsOrigemMaterialFilterDto>> RetornarCstIcmsOrigemMaterialPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.CST_ICMS_Origem_Material.AsNoTracking();

            var data = query.Select(x => new CstIcmsOrigemMaterialFilterDto
            {
                Id = x.Id,
                Nome = x.Nome,
                CST_ICMS_Amigavel_Origem_Material = x.CST_ICMS_Amigavel_Origem_Material
            });

            var response = await data.RetonarFiltroCustomizado<CstIcmsOrigemMaterialFilterDto, CstIcmsOrigemMaterialFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<CST_ICMS_Origem_MaterialByCodeDto?> RetornarCstIcmsOrigemMaterialPorId(Guid id)
        {
            var CST_ICMS_Origem_Material = await _dbContext.CST_ICMS_Origem_Material
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (CST_ICMS_Origem_Material != null)
            {
                return new CST_ICMS_Origem_MaterialByCodeDto
                {
                    Id = CST_ICMS_Origem_Material.Id,
                    Nome = CST_ICMS_Origem_Material.Nome,
                    CST_ICMS_Amigavel_Origem_Material = CST_ICMS_Origem_Material.CST_ICMS_Amigavel_Origem_Material
                };
            }

            return null;
        }

        public async Task<PaginacaoResponse<PisFilterDto>> RetornarPisPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Pis.AsNoTracking();

            var data = query.Select(x => new PisFilterDto
            {
                Id = x.Id,
                Nome = x.Nome,
                DescontaPis = x.DescontaPis,
                PisAmigavel = x.PisAmigavel
            });

            var response = await data.RetonarFiltroCustomizado<PisFilterDto, PisFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<PisByCodeDto?> RetornarPisPorId(Guid id)
        {
            var pis = await _dbContext.Pis
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (pis != null)
            {
                return new PisByCodeDto
                {
                    Id = pis.Id,
                    Nome = pis.Nome,
                    DescontaPis = pis.DescontaPis,
                    PisAmigavel = pis.PisAmigavel
                };
            }
            return null;
        }

        public async Task<PaginacaoResponse<CofinsFilterDto>> RetornarCofinsPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Cofins.AsNoTracking();

            var data = query.Select(x => new CofinsFilterDto
            {
                Id = x.Id,
                Nome = x.Nome,
                DescontaCofins = x.DescontaCofins,
                CofinsAmigavel = x.CofinsAmigavel
            });

            var response = await data.RetonarFiltroCustomizado<CofinsFilterDto, CofinsFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<CofinsByCodeDto?> RetornarCofinsPorId(Guid id)
        {
            var pis = await _dbContext.Cofins
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (pis != null)
            {
                return new CofinsByCodeDto
                {
                    Id = pis.Id,
                    Nome = pis.Nome,
                    DescontaCofins = pis.DescontaCofins,
                    CofinsAmigavel = pis.CofinsAmigavel
                };
            }
            return null;
        }
    }
}
