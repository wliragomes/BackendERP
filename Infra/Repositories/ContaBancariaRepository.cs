using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class ContaBancariaRepository : IContaBancariaRepository
    {
        private readonly ApplicationDbContext _contexto;

        public ContaBancariaRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(ContaBancaria contaBancaria)
        {
            await _contexto.ContaBancaria.AddAsync(contaBancaria);
        }

        public async Task<ContaBancaria?> ObterPorId(Guid? id)
        {
            return await _contexto.ContaBancaria.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.ContaBancaria.AnyAsync(x => x.Id == id);
        }

        public async Task AdicionarEmMassa(List<ContaBancaria> contasBancarias, CancellationToken cancellationToken = default)
        {
            await _contexto.ContaBancaria.AddRangeAsync(contasBancarias, cancellationToken);
        }

        public async Task<List<ContaBancaria>> RetornarContasBancariasExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.ContaBancaria;
            var query = FiltroBuilder<ContaBancaria>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}