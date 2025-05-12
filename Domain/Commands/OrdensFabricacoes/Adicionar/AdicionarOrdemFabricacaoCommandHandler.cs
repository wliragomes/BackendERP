using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;
using System.Text;

namespace Domain.Commands.OrdensFabricacoes.Adicionar
{
    public class AdicionarOrdemFabricacaoCommandHandler : IRequestHandler<AdicionarOrdemFabricacaoCommand, FormularioResponse<AdicionarOrdemFabricacaoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUnitOfWorkArquivos _unitOfWorkArquivos;
        private readonly IValidator<AdicionarOrdemFabricacaoCommand> _validator;
        private const int _indece = 0;

        public AdicionarOrdemFabricacaoCommandHandler(IUnitOfWork unitOfWork, IUnitOfWorkArquivos unitOfWorkArquivos, IValidator<AdicionarOrdemFabricacaoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _unitOfWorkArquivos = unitOfWorkArquivos;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarOrdemFabricacaoCommand>> Handle(AdicionarOrdemFabricacaoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarOrdemFabricacaoCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            int novoSqOrdemFabricacaoCodigo = (await _unitOfWork.OrdemFabricacaoRepository.ObterUltimoSqOrdemFabricacaoCodigo()) + 1;
            int novoSqOrdemFabricacaoAno = DateTime.Now.Year % 100;

            OrdemFabricacao ordemFabricacao = new
            (
                command.IdVenda,
                novoSqOrdemFabricacaoCodigo,
                novoSqOrdemFabricacaoAno,
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

            var ordemFabricacaoArquivos = new List<OrdemFabricacaoArquivo>();
            if (command.OrdemFabricacaoArquivo != null && command.OrdemFabricacaoArquivo.Any())
            {
                int contador = 1;

                foreach (var arquivoCommand in command.OrdemFabricacaoArquivo)
                {
                    byte[] arquivoBytes = Convert.FromBase64String(arquivoCommand.Arquivo);
                    string extensao = Path.GetExtension(arquivoCommand.NomeOriginal);
                    if (string.IsNullOrEmpty(extensao))
                    {
                        extensao = ".jpg"; // Default para .jpg se não houver extensão
                    }

                    var nomeArquivo = Guid.NewGuid().ToString() + extensao;

                    var arquivo = new OrdemFabricacaoArquivo(
                        ordemFabricacao.Id,
                        contador,
                        arquivoCommand.Descricao,
                        arquivoCommand.NomeOriginal,
                        nomeArquivo,
                        arquivoCommand.EnderecoOriginal,
                        arquivoCommand.EnderecoDestino,
                        arquivoBytes
                    );

                    ordemFabricacaoArquivos.Add(arquivo);
                    contador++;
                }
            }

            var ordemFabricacaoItens = command.OrdemFabricacaoItem != null && command.OrdemFabricacaoItem.Any()
                ? CriarOrdemFabricacaoItem(command.OrdemFabricacaoItem, ordemFabricacao.Id)
                : new List<OrdemFabricacaoItem>();

            await _unitOfWork.OrdemFabricacaoRepository.Adicionar(ordemFabricacao);

            if (ordemFabricacaoArquivos.Any())
            {
                await _unitOfWorkArquivos.OrdemFabricacaoArquivoRepository.AdicionarEmMassa(ordemFabricacaoArquivos);
            }

            if (ordemFabricacaoItens.Any())
            {
                await _unitOfWork.OrdemFabricacaoItemRepository.AdicionarEmMassa(ordemFabricacaoItens);
            }

            response.Formulario!.SetId(ordemFabricacao.Id);

            await _unitOfWork.CommitAsync(cancellationToken);
            await _unitOfWorkArquivos.CommitAsync(cancellationToken);

            string sql = $"EXEC [dbo].[PR_PLANEJAMENTO] '{ordemFabricacao.Id}'";
            await _unitOfWork.ExecuteSqlRawAsync(sql, cancellationToken);

            return response;
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
