using Application.Interfaces.Queries;
using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Caminhoes.Filtro;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.Caminhoes;
using SharedKernel.Configuration.Extensions;
using Application.DTOs.TiposCarrocerias.Filtro;
using Application.DTOs.TiposCarrocerias;
using Application.DTOs.TiposRodados.Filtro;
using Application.DTOs.TiposRodados;
using Domain.Entities;

namespace Infra.Queries.Caminhoes
{
    public class VeiculoQuery : IVeiculoQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public VeiculoQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<CaminhaoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Caminhao.AsNoTracking();

            var data = query.Select(x => new CaminhaoFilterDto
            {
                Id = x.Id,
                Descricao = x.Descricao,
                Numero = x.Numero,
                Placa = x.Placa
            });

            var response = await data.RetonarFiltroCustomizado<CaminhaoFilterDto, CaminhaoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<CaminhaoByCodeDto?> RetornarPorId(Guid id)
        {
            var Caminhao = await _dbContext.Caminhao
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (Caminhao != null)
            {
                return new CaminhaoByCodeDto
                {
                    Id = Caminhao.Id,
                    Descricao = Caminhao.Descricao,
                    CaminhaoCarreta = Caminhao.CaminhaoCarreta,
                    Numero = Caminhao.Numero,
                    Placa = Caminhao.Placa,
                    Tara = Caminhao.Tara,
                    CapacidadeKg = Caminhao.CapacidadeKg,
                    CapacidadeM3 = Caminhao.CapacidadeM3,
                    IdPessoa = Caminhao.IdPessoa,
                    IdTipoRodado = Caminhao.IdTipoRodado,
                    IdTipoCarroceria = Caminhao.IdTipoCarroceria,
                    IdEstado = Caminhao.IdEstado,
                    Inativo = Caminhao.Inativo                    
                };
            }

            return null;
        }

        public async Task<PaginacaoResponse<TipoCarroceriaFilterDto>> RetornarTipoCarroceriaPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.TipoCarroceria.AsNoTracking();

            var data = query.Select(x => new TipoCarroceriaFilterDto
            {
                Id = x.Id,
                Descricao = x.Descricao
            });

            var response = await data.RetonarFiltroCustomizado<TipoCarroceriaFilterDto, TipoCarroceriaFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<TipoCarroceriaByCodeDto?> RetornarTipoCarroceriaPorId(Guid id)
        {
            var TipoCarroceria = await _dbContext.TipoCarroceria
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (TipoCarroceria != null)
            {
                return new TipoCarroceriaByCodeDto
                {
                    Id = TipoCarroceria.Id,
                    Descricao = TipoCarroceria.Descricao
                };
            }

            return null;
        }

        public async Task<PaginacaoResponse<TipoRodadoFilterDto>> RetornarTipoRodadoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.TipoRodado.AsNoTracking();

            var data = query.Select(x => new TipoRodadoFilterDto
            {
                Id = x.Id,
                Descricao = x.Descricao
            });

            var response = await data.RetonarFiltroCustomizado<TipoRodadoFilterDto, TipoRodadoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<TipoRodadoByCodeDto?> RetornarTipoRodadoPorId(Guid id)
        {
            var TipoRodado = await _dbContext.TipoRodado
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (TipoRodado != null)
            {
                return new TipoRodadoByCodeDto
                {
                    Id = TipoRodado.Id,
                    Descricao = TipoRodado.Descricao
                };
            }

            return null;
        }
    }
}
