using Domain.Constant;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.TiposProdutos.Excluir
{
    public class ExcluirTipoProdutoCommandHandler : IRequestHandler<ExcluirTipoProdutoCommand, List<FormularioResponse<ExcluirTipoProdutoCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirTipoProdutoCommand>> _response = new();

        public ExcluirTipoProdutoCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirTipoProdutoCommand>>> Handle(ExcluirTipoProdutoCommand command, CancellationToken cancellationToken)
        {
            var tipoproduto = await _unitOfWork.TipoProdutoRepository.RetornarTiposProdutosExcluirMassa(command.FiltroBase);

            if (!tipoproduto.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(tipoproduto);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirTipoProdutoCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirTipoProdutoCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Domain.Entities.Produtos.TipoProduto> tipoproduto)
        {
            var index = 0;
            foreach (var intem in tipoproduto)
            {

                intem.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirTipoProdutoCommand>(index));
                index++;
            }
        }
    }
}
