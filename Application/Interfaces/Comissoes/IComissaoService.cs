using Application.DTOs.Comissoes.Adicionar;
using Application.DTOs.Comissoes.Atualizar;
using Application.DTOs.Comissoes.Excluir;
using Application.DTOs.Comissoes.Filtro;
using Application.DTOs.Comissoes;
using Domain.Commands.Comissoes.Adicionar;
using Domain.Commands.Comissoes.Atualizar;
using Domain.Commands.Comissoes.Excluir;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Comissoes
{
    public interface IComissaoService
    {
        Task<FormularioResponse<AdicionarComissaoCommand>> Adicionar(AdicionarComissaoRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarComissaoCommand>> Atualizar(AtualizarComissaoRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirComissaoCommand>>> Excluir(ExcluirComissaoDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<ComissaoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<List<ComissaoGetDto>> RetornarComissaoGet(Guid idPessoa, DateTime? dataEmissaoInicial, DateTime? dataEmissaoFinal, DateTime? dataVencimentoInicial, DateTime? dataVencimentoFinal, Guid? idStatus);
        Task<ComissaoByCodeDto?> RetornarPorId(Guid id);
    }
}
