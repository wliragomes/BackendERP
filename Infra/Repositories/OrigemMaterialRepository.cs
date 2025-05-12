using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class OrigemMaterialRepository : IOrigemMaterialRepository
    {
        private readonly ApplicationDbContext _contexto;

        public OrigemMaterialRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(OrigemMaterial origemmaterial)
        {
            await _contexto.OrigemMaterial.AddAsync(origemmaterial);
        }

        public async Task<OrigemMaterial?> ObterPorId(Guid? id)
        {
            return await _contexto.OrigemMaterial.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.OrigemMaterial.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string descricao, Guid? id)
        {
            return await _contexto.OrigemMaterial.AnyAsync(x => x.Nome == descricao && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<OrigemMaterial> origemmaterial, CancellationToken cancellationToken = default)
        {
            await _contexto.OrigemMaterial.AddRangeAsync(origemmaterial, cancellationToken);
        }

        public async Task<List<OrigemMaterial>> RetornarOrigemMateriaisExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.OrigemMaterial;
            var query = FiltroBuilder<OrigemMaterial>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }

    }
}
