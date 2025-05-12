using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IOrdemFabricacaoItemTemporariaRepository
    {
        Task Adicionar(OrdemFabricacaoItemTemporaria ordemFabricacaoItemTemporaria);
    }
}
