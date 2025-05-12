using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class OrdemFabricacaoArquivoRepository : IOrdemFabricacaoArquivoRepository
    {
        private readonly CratosArquivosDbContext _contexto;

        public OrdemFabricacaoArquivoRepository(CratosArquivosDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(OrdemFabricacaoArquivo ordemFabricacaoArquivo)
        {
            await _contexto.OrdemFabricacaoArquivo.AddAsync(ordemFabricacaoArquivo);
        }

        public async Task RemoverMassa(List<OrdemFabricacaoArquivo> ordemFabricacaoArquivo, CancellationToken cancellationToken = default)
        {
            _contexto.OrdemFabricacaoArquivo.RemoveRange(ordemFabricacaoArquivo);
        }

        public async Task<List<OrdemFabricacaoArquivo>> ObterPorIdOrdemFabricacaoArquivo(Guid? id)
        {
            return await _contexto.OrdemFabricacaoArquivo
                                  .Where(x => x.IdOrdemFabricacao == id)
                                  .ToListAsync();
        }

        // Método ajustado para buscar por chave composta (idContaAPagar, NItem)
        public async Task<OrdemFabricacaoArquivo?> ObterPorId(Guid? id)
        {
            return await _contexto.OrdemFabricacaoArquivo
                .FirstOrDefaultAsync(p => p.IdOrdemFabricacao == id);
        }

        public async Task<OrdemFabricacaoArquivo?> ObterOrdemFabricacaoArquivoPorId(Guid? idOrdemFabricacao, int SqArquivo)
        {
            return await _contexto.OrdemFabricacaoArquivo
                .FirstOrDefaultAsync(p => p.IdOrdemFabricacao == idOrdemFabricacao && p.SqArquivo == SqArquivo);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.OrdemFabricacaoArquivo.AnyAsync(x => x.IdOrdemFabricacao == id);
        }

        public async Task AdicionarEmMassa(List<OrdemFabricacaoArquivo> ordensFabricacoesArquivos, CancellationToken cancellationToken = default)
        {
            await _contexto.OrdemFabricacaoArquivo.AddRangeAsync(ordensFabricacoesArquivos, cancellationToken);
        }

        public async Task<List<OrdemFabricacaoArquivo>> RetornarOrdensFabricacoesArquivosExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.OrdemFabricacaoArquivo;
            var query = FiltroBuilder<OrdemFabricacaoArquivo>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}
