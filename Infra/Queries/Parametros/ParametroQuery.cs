using Application.Interfaces.Queries;
using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Parametros.Filtro;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.Parametros;
using SharedKernel.Configuration.Extensions;
using Domain.Entities;

namespace Infra.Queries.Parametros
{
    public class ParametroQuery : IParametroQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public ParametroQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<ParametroFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Parametro.AsNoTracking();

            var data = query.Select(x => new ParametroFilterDto
            {
                Id = x.Id,
                Nome = x.Nome,
                Descricao = x.Descricao,
            });

            var response = await data.RetonarFiltroCustomizado<ParametroFilterDto, ParametroFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<ParametroByCodeDto?> RetornarPorId(Guid id)
        {
            var Parametro = await _dbContext.Parametro
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            var jumbo = await _dbContext.MedidaJumbo
            .AsNoTracking().ToListAsync();
            if (Parametro != null)
            {
                var medidaJumbo = jumbo.FirstOrDefault();

                return new ParametroByCodeDto
                {
                    Id = Parametro.Id,
                    Nome = Parametro.Nome,
                    Aba = Parametro.Aba,
                    Descricao = Parametro.Descricao,
                    ExibirDescricao = Parametro.ExibirDescricao,
                    BlocoDescricao = Parametro.BlocoDescricao,
                    Descricao2 = Parametro.Descricao2,
                    ExibirDescricao2 = Parametro.ExibirDescricao2,
                    BlocoDescricao2 = Parametro.BlocoDescricao2,
                    Valor = Parametro.Valor,
                    ExibirValor = Parametro.ExibirValor,
                    BlocoValor = Parametro.BlocoValor,
                    Valor2 = Parametro.Valor2,
                    ExibirValor2 = Parametro.ExibirValor2,
                    BlocoValor2 = Parametro.BlocoValor2,
                    Verdade = Parametro.Verdade,
                    ExibirVerdade = Parametro.ExibirVerdade,
                    BlocoVerdade = Parametro.BlocoVerdade,
                    CaixaDeTexto = Parametro.CaixaDeTexto,
                    ExibirCaixaDeTexto = Parametro.ExibirCaixaDeTexto,
                    Criptografado = Parametro.Criptografado,
                    BlocoCaixaDeTexto = Parametro.BlocoCaixaDeTexto,
                    CaixaDeTexto2 = Parametro.CaixaDeTexto2,
                    ExibirCaixaDeTexto2 = Parametro.ExibirCaixaDeTexto2,
                    Criptografado2 = Parametro.Criptografado2,
                    BlocoCaixaDeTexto2 = Parametro.BlocoCaixaDeTexto2,
                    CaixaDeData = Parametro.CaixaDeData,
                    ExibirCaixaDeData = Parametro.ExibirCaixaDeData,
                    BlocoCaixaDeData = Parametro.BlocoCaixaDeData,
                    CaixaDeData2 = Parametro.CaixaDeData2,
                    ExibirCaixaDeData2 = Parametro.ExibirCaixaDeData2,
                    BlocoCaixaDeData2 = Parametro.BlocoCaixaDeData2,
                    Help = Parametro.Help,
                    ExibirHelp = Parametro.ExibirHelp,
                    BlocoHelp = Parametro.BlocoHelp,
                    MedidaJumbo = medidaJumbo == null ? null : new MedidaJumboDto
                    {
                        Id = medidaJumbo.Id,
                        Ordem = medidaJumbo.Ordem,
                        Habilitar = medidaJumbo.Habilitar,
                        Altura = medidaJumbo.Altura,
                        Largura = medidaJumbo.Largura
                    }
                };
            }

            return null;
        }

        public async Task<PaginacaoResponse<ParametroMedidaDto>> RetornarParametroMedida(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.MedidaParametro.AsNoTracking();

            var data = query.Select(x => new ParametroMedidaDto
            {
                ToneladaFrete = x.ToneladaFrete
            });

            var response = await data.RetonarFiltroCustomizado<ParametroMedidaDto, ParametroMedidaDto>(paginacaoRequest);
            return response;
        }
    }
}