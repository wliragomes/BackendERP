using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Funcionalidades.Adicionar;
using Application.DTOs.Funcionalidades.Atualizar;
using Application.DTOs.Funcionalidades.Excluir;
using Application.DTOs.Funcionalidades.Filtro;
using Application.DTOs.Funcionalidades;
using Domain.Commands.Funcionalidades.Adicionar;
using Domain.Commands.Funcionalidades.Atualizar;
using Domain.Commands.Funcionalidades.Excluir;
using Application.DTOs.NiveisAcessos;

namespace Application.Interfaces.Bancos
{
    public interface IFuncionalidadeService
    {
        Task<FormularioResponse<AdicionarFuncionalidadeCommand>> Adicionar(AdicionarFuncionalidadeRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarFuncionalidadeCommand>> Atualizar(AtualizarFuncionalidadeRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirFuncionalidadeCommand>>> Excluir(ExcluirFuncionalidadeDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<FuncionalidadeFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<FuncionalidadeByCodeDto?> RetornarPorId(Guid id);
        Task<List<NivelAcessoByCodeDto>> RetornarPorIdFuncionalidade(Guid id);
    }
}
