using Application.DTOs.Caminhoes.Adicionar;
using Application.DTOs.Caminhoes.Atualizar;
using Application.DTOs.Caminhoes.Excluir;
using Application.DTOs.Caminhoes.Filtro;
using Application.DTOs.Caminhoes;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.TiposCarrocerias.Adicionar;
using Application.DTOs.TiposCarrocerias.Atualizar;
using Application.DTOs.TiposCarrocerias.Excluir;
using Application.DTOs.TiposCarrocerias.Filtro;
using Application.DTOs.TiposCarrocerias;
using Application.DTOs.TiposRodados.Adicionar;
using Application.DTOs.TiposRodados.Atualizar;
using Application.DTOs.TiposRodados.Excluir;
using Application.DTOs.TiposRodados.Filtro;
using Application.DTOs.TiposRodados;
using Domain.Commands.Caminhoes.Adicionar;
using Domain.Commands.Caminhoes.Atualizar;
using Domain.Commands.Caminhoes.Excluir;
using Domain.Commands.TiposCarrocerias.Adicionar;
using Domain.Commands.TiposCarrocerias.Atualizar;
using Domain.Commands.TiposCarrocerias.Excluir;
using Domain.Commands.TiposRodados.Adicionar;
using Domain.Commands.TiposRodados.Atualizar;
using Domain.Commands.TiposRodados.Excluir;

namespace Application.Interfaces.Veiculos
{
    public interface IVeiculoService
    {
        Task<FormularioResponse<AdicionarCaminhaoCommand>> Adicionar(AdicionarCaminhaoRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarCaminhaoCommand>> Atualizar(AtualizarCaminhaoRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirCaminhaoCommand>>> Excluir(ExcluirCaminhaoDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<CaminhaoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<CaminhaoByCodeDto?> RetornarPorId(Guid id);
        Task<FormularioResponse<AdicionarTipoCarroceriaCommand>> AdicionarTipoCarroceria(AdicionarTipoCarroceriaRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarTipoCarroceriaCommand>> AtualizarTipoCarroceria(AtualizarTipoCarroceriaRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirTipoCarroceriaCommand>>> ExcluirTipoCarroceria(ExcluirTipoCarroceriaDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<TipoCarroceriaFilterDto>> RetornarTipoCarroceriaPaginacao(PaginacaoRequest paginacaoRequest);
        Task<TipoCarroceriaByCodeDto?> RetornarTipoCarroceriaPorId(Guid id);
        Task<FormularioResponse<AdicionarTipoRodadoCommand>> AdicionarTipoRodado(AdicionarTipoRodadoRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarTipoRodadoCommand>> AtualizarTipoRodado(AtualizarTipoRodadoRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirTipoRodadoCommand>>> ExcluirTipoRodado(ExcluirTipoRodadoDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<TipoRodadoFilterDto>> RetornarTipoRodadoPaginacao(PaginacaoRequest paginacaoRequest);
        Task<TipoRodadoByCodeDto?> RetornarTipoRodadoPorId(Guid id);
    }
}
