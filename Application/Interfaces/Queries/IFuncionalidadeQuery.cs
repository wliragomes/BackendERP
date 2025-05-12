using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Funcionalidades.Filtro;
using Application.DTOs.Funcionalidades;
using Application.DTOs.NiveisAcessos;

namespace Application.Interfaces.Queries
{
    public interface IFuncionalidadeQuery
    {
        Task<PaginacaoResponse<FuncionalidadeFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);

        Task<FuncionalidadeByCodeDto?> RetornarPorId(Guid id);
        Task<List<NivelAcessoByCodeDto>> RetornarPorIdFuncionalidade(Guid id);
    }
}
