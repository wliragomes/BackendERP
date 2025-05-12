using Application.Interfaces.Queries;
using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.ContasBancarias.Filtro;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.ContasBancarias;
using SharedKernel.Configuration.Extensions;

namespace Infra.Queries.ContasBancarias
{
    public class ContaBancariaQuery : IContaBancariaQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public ContaBancariaQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<ContaBancariaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.ContaBancaria.AsNoTracking();

            var data = query.Select(x => new ContaBancariaFilterDto
            {
                Id = x.Id,
                Descricao = x.Descricao,
                IdBanco = x.IdBanco,
            });

            var response = await data.RetonarFiltroCustomizado<ContaBancariaFilterDto, ContaBancariaFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<ContaBancariaByCodeDto?> RetornarPorId(Guid id)
        {
            var ContaBancaria = await _dbContext.ContaBancaria
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (ContaBancaria != null)
            {
                return new ContaBancariaByCodeDto
                {
                    Id = ContaBancaria.Id,
                    Descricao = ContaBancaria.Descricao,
                    IdBanco = ContaBancaria.IdBanco,
                    Agencia = ContaBancaria.Agencia,
                    DigitoAgencia = ContaBancaria.DigitoAgencia,
                    Conta  = ContaBancaria.Conta,
                    DigitoConta = ContaBancaria.DigitoConta,
                    LimiteEspecial = ContaBancaria.LimiteEspecial,
                    ValorLimiteEspecial = ContaBancaria.ValorLimiteEspecial,
                    ContaGarantida = ContaBancaria.ContaGarantida,
                    ValorContaGarantida = ContaBancaria.ValorContaGarantida,
                };
            }

            return null;
        }
    }
}
