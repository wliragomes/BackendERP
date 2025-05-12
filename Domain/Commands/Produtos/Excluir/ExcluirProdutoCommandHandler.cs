using Domain.Constant;
using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.Excluir
{
    public class ExcluirProdutoCommandHandler : IRequestHandler<ExcluirProdutoCommand, List<FormularioResponse<ExcluirProdutoCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirProdutoCommand>> _response = new();

        public ExcluirProdutoCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirProdutoCommand>>> Handle(ExcluirProdutoCommand command, CancellationToken cancellationToken)
        {
            var produto = await _unitOfWork.ProdutoRepository.RetornarProdutosExcluirMassa(command.FiltroBase);

            if (!produto.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(produto);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }
                
        private void AddErroNaResposta(ExcluirProdutoCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirProdutoCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Produto> produtos)
        {
            var index = 0;
            foreach (var produto in produtos)
            {

                produto.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirProdutoCommand>(index));
                index++;
            }
        }
    }
}