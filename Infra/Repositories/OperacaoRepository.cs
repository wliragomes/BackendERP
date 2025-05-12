using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class OperacaoRepository : IOperacaoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public OperacaoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Operacao operacao)
        {
            await _contexto.Operacao.AddAsync(operacao);
        }

        public async Task<Operacao?> ObterPorId(Guid? id)
        {
            return await _contexto.Operacao.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Operacao.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string nome, Guid? id)
        {
            return await _contexto.Operacao.AnyAsync(x => x.Nome == nome && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<Operacao> operacoes, CancellationToken cancellationToken = default)
        {
            await _contexto.Operacao.AddRangeAsync(operacoes, cancellationToken);
        }

        public async Task<List<Operacao>> RetornarOperacoesExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Operacao;
            var query = FiltroBuilder<Operacao>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}