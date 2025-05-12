using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.OrdensFabricacoes.Atualizar
{
    public class AtualizarOrdemFabricacaoCommandHandler : IRequestHandler<AtualizarOrdemFabricacaoCommand, FormularioResponse<AtualizarOrdemFabricacaoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUnitOfWorkArquivos _unitOfWorkArquivos;
        private readonly IValidator<AtualizarOrdemFabricacaoCommand> _validator;
        private const int _indice = 0;

        public AtualizarOrdemFabricacaoCommandHandler(IUnitOfWork unitOfWork, IUnitOfWorkArquivos unitOfWorkArquivos, IValidator<AtualizarOrdemFabricacaoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _unitOfWorkArquivos = unitOfWorkArquivos;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarOrdemFabricacaoCommand>> Handle(AtualizarOrdemFabricacaoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarOrdemFabricacaoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var ordemFabricacaoUpdate = await _unitOfWork.OrdemFabricacaoRepository.ObterPorId(command.Id);
            int sqRomaneioCodigo = ordemFabricacaoUpdate.SqOrdemFabricacaoCodigo;
            int sqRomaneioAno = ordemFabricacaoUpdate.SqOrdemFabricacaoAno;

            ordemFabricacaoUpdate.Update(
                command.IdVenda,
                sqRomaneioCodigo,
                sqRomaneioAno,
                command.IdStatus,
                command.IdPessoa,
                command.VidroModulado,
                command.Chapa,
                command.DataCriacao,
                command.DataEfetivacao,
                command.NomeContato,
                command.Telefone,
                command.Celular,
                command.IdEnderecoEntrega,
                command.Obra,
                command.Engenheiro,
                command.Observacao,
                command.EtiquetaGrandeTemperado,
                command.DescargaCliente,
                command.DiasEntrega,
                command.DataEntrega
            );

            var ordemfabricacoesItemExistentes = await _unitOfWork.OrdemFabricacaoItemRepository.ObterOrdemFabricacaoItemPorId(command.Id);
            if (ordemfabricacoesItemExistentes.Any())
            {
                await _unitOfWork.OrdemFabricacaoItemRepository.RemoverMassa(ordemfabricacoesItemExistentes);
            }

            var ordemfabricacoesItem = CriarOrdemFabricacaoItem(command.OrdemFabricacaoItem!, command.Id);

            var arquivosExistentes = await _unitOfWorkArquivos.OrdemFabricacaoArquivoRepository.ObterPorIdOrdemFabricacaoArquivo(command.Id);
            if (arquivosExistentes.Any())
            {
                await _unitOfWorkArquivos.OrdemFabricacaoArquivoRepository.RemoverMassa(arquivosExistentes);
            }

            var ordensFabricacoesArquivos = CriarOrdemFabricacaoArquivo(command.OrdemFabricacaoArquivo!, command.Id);

            await _unitOfWorkArquivos.OrdemFabricacaoArquivoRepository.AdicionarEmMassa(ordensFabricacoesArquivos);
            await _unitOfWork.OrdemFabricacaoItemRepository.AdicionarEmMassa(ordemfabricacoesItem);
            await _unitOfWork.CommitAsync(cancellationToken);
            await _unitOfWorkArquivos.CommitAsync(cancellationToken);

            response.SetFormulario(command);
            return response;
        }

        private List<OrdemFabricacaoArquivo> CriarOrdemFabricacaoArquivo(IEnumerable<OrdemFabricacaoArquivoCommand> OrdemFabricacaoArquivoCommands, Guid ordemFabricacaoArquivoId)
        {
            var arquivos = new List<OrdemFabricacaoArquivo>();
            int contador = 1;

            foreach (var ordemFabricacaoArquivo in OrdemFabricacaoArquivoCommands)
            {
                byte[] arquivoBytes = Convert.FromBase64String(ordemFabricacaoArquivo.Arquivo);
                string extensao = System.IO.Path.GetExtension(ordemFabricacaoArquivo.NomeOriginal);
                if (string.IsNullOrEmpty(extensao))
                {
                    extensao = ".jpg";
                }

                arquivos.Add(new OrdemFabricacaoArquivo(
                    ordemFabricacaoArquivoId,
                    contador++,
                    ordemFabricacaoArquivo.Descricao,
                    ordemFabricacaoArquivo.NomeOriginal,
                    Guid.NewGuid().ToString() + extensao,
                    ordemFabricacaoArquivo.EnderecoOriginal,
                    ordemFabricacaoArquivo.EnderecoDestino,
                    arquivoBytes
                ));
            }

            return arquivos;
        }

        private List<OrdemFabricacaoItem> CriarOrdemFabricacaoItem(IEnumerable<OrdemFabricacaoItemCommand> OrdemFabricacaoItemCommands, Guid ordemFabricacaoId)
        {
            return OrdemFabricacaoItemCommands.Select(ordemFabricacaoItem => new OrdemFabricacaoItem(
                ordemFabricacaoId,
                ordemFabricacaoItem.SqItem,
                ordemFabricacaoItem.SqVendaItem,
                ordemFabricacaoItem.IdProduto,
                ordemFabricacaoItem.NomeProduto,
                ordemFabricacaoItem.DescricaoProduto,
                ordemFabricacaoItem.Espessura,
                ordemFabricacaoItem.Altura,
                ordemFabricacaoItem.Largura,
                ordemFabricacaoItem.Quantidade,
                ordemFabricacaoItem.Aramado,
                ordemFabricacaoItem.Modelado,
                ordemFabricacaoItem.ValorM2,
                ordemFabricacaoItem.ValorM,
                ordemFabricacaoItem.ValorPeso,
                ordemFabricacaoItem.ValorM2Real,
                ordemFabricacaoItem.ValorMReal,
                ordemFabricacaoItem.ValorPesoReal,
                ordemFabricacaoItem.ValorAreaMinima,
                ordemFabricacaoItem.IdSetorProduto,
                ordemFabricacaoItem.IdProjeto,
                ordemFabricacaoItem.AlturaLapidacao,
                ordemFabricacaoItem.LarguraLapidacao,
                ordemFabricacaoItem.Manual,
                ordemFabricacaoItem.Cortado,
                ordemFabricacaoItem.Filete1,
                ordemFabricacaoItem.Filete2,
                ordemFabricacaoItem.Filete3,
                ordemFabricacaoItem.Filete4,
                ordemFabricacaoItem.Industrial1,
                ordemFabricacaoItem.Industrial2,
                ordemFabricacaoItem.Industrial3,
                ordemFabricacaoItem.Industrial4,
                ordemFabricacaoItem.Polida1,
                ordemFabricacaoItem.Polida2,
                ordemFabricacaoItem.Polida3,
                ordemFabricacaoItem.Polida4,
                ordemFabricacaoItem.QuebraCanto,
                ordemFabricacaoItem.Revenda,
                ordemFabricacaoItem.Instalacao,
                ordemFabricacaoItem.ManterEdgeDeletion,
                ordemFabricacaoItem.CancelarEdgeDeletion
            )).ToList();
        }
    }
}
