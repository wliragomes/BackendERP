using Application.Interfaces.Queries;
using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Duplicatas.Filtro;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Configuration.Extensions;

namespace Infra.Queries.Duplicatas
{
    public class DuplicataQuery : IDuplicataQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public DuplicataQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<DuplicataFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Duplicata.AsNoTracking()
                .Include(ee => ee.Pessoa);

            var data = query.Select(x => new DuplicataFilterDto
            {
                Id = x.Id,
                IdSacado = x.IdSacado,
                NomeSacado = x.Pessoa!.RazaoSocial,
                Numero = x.Numero,
                ValorTotal = x.ValorTotal,
                DataEmissao = x.DataEmissao,
            });

            var response = await data.RetonarFiltroCustomizado<DuplicataFilterDto, DuplicataFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<DuplicataByCodeDto?> RetornarPorId(Guid id)
        {
            var duplicata = await _dbContext.Duplicata
                .AsNoTracking()
                .Where(x => x.Id.Equals(id))
                .FirstOrDefaultAsync();

            var duplicataParcela = await _dbContext.DuplicataParcela
                .AsNoTracking()
                .Where(x => x.IdDuplicata.Equals(id))
                .FirstOrDefaultAsync();

            if (duplicata != null)
            {
                return new DuplicataByCodeDto
                {
                    Id = duplicata.Id,
                    Parcelado = duplicata.Parcelado,
                    Numero = duplicata.Numero,
                    Ano = duplicata.Ano,
                    ValorTotal = duplicata.ValorTotal,
                    QtdParcelas = duplicata.QtdParcelas,
                    DataEmissao = duplicata.DataEmissao,
                    IdSacado = duplicata.IdSacado,
                    Cep = duplicata.Cep,
                    Endereco = duplicata.Endereco,
                    IdCidade = duplicata.IdCidade,
                    IdEstado = duplicata.IdEstado,
                    NumeroEndereco = duplicata.NumeroEndereco,
                    Complemento = duplicata.Complemento,
                    CepCobranca = duplicata.CepCobranca,
                    EnderecoCobranca = duplicata.EnderecoCobranca,
                    IdCidadeCobranca = duplicata.IdCidadeCobranca,
                    IdEstadoCobranca = duplicata.IdEstadoCobranca,
                    NumeroEnderecoCobranca = duplicata.NumeroEnderecoCobranca,
                    ComplementoCobranca = duplicata.ComplementoCobranca,
                    Observacao = duplicata.Observacao,
                    Parcela = duplicataParcela?.Parcela ?? 0,
                    ValorDuplicata = duplicataParcela?.ValorDuplicata ?? 0,
                    ValorDuplicataExtensao = duplicataParcela.ValorDuplicataExtenso,
                    DataVencimento = duplicataParcela.DataVencimento                    
                };
            }
            return null;
        }
    }
}
