using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;

namespace Infra.Repositories
{
    public class OrdemFabricacaoItemTemporariaRepository : IOrdemFabricacaoItemTemporariaRepository
    {
        private readonly ApplicationDbContext _contexto;

        public OrdemFabricacaoItemTemporariaRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(OrdemFabricacaoItemTemporaria ordemFabricacaoItemTemporaria)
        {
            await _contexto.OrdemFabricacaoItemTemporaria.AddAsync(ordemFabricacaoItemTemporaria);
        }
    }
}