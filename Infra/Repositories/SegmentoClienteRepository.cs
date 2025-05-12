using Domain.Entities.Pessoas;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class SegmentoClienteRepository : ISegmentoClienteRepository
    {
        private readonly ApplicationDbContext _contexto;
        public SegmentoClienteRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(SegmentoCliente segmentocliente)
        {
            await _contexto.SegmentoCliente.AddAsync(segmentocliente);
        }

        public Task AdicionarEmMassa(List<SegmentoCliente> segmentoclientes, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExisteDescricaoAsync(string descricao, Guid? id)
        {
            return await _contexto.SegmentoCliente.AnyAsync(x => x.Descricao == descricao && x.Id != id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.SegmentoCliente.AnyAsync(x => x.Id == id);
        }

        public async Task<SegmentoCliente?> ObterPorId(Guid? id)
        {
            return await _contexto.SegmentoCliente.FindAsync(id);
        }

        public async Task<List<SegmentoCliente>> RetornarSegmentoClientesExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.SegmentoCliente;
            var query = FiltroBuilder<SegmentoCliente>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}
