using Domain.Constant;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.SetoresProdutos.Excluir
{
    public class ExcluirSetorProdutoCommandHandler : IRequestHandler<ExcluirSetorProdutoCommand, List<FormularioResponse<ExcluirSetorProdutoCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirSetorProdutoCommand>> _response = new();

        public ExcluirSetorProdutoCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirSetorProdutoCommand>>> Handle(ExcluirSetorProdutoCommand command, CancellationToken cancellationToken)
        {
            var setorproduto = await _unitOfWork.SetorProdutoRepository.RetornarSetoresProdutosExcluirMassa(command.FiltroBase);

            if (!setorproduto.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(setorproduto);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirSetorProdutoCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirSetorProdutoCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Domain.Entities.Produtos.SetorProduto> setorproduto)
        {
            var index = 0;
            foreach (var intem in setorproduto)
            {

                intem.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirSetorProdutoCommand>(index));
                index++;
            }
        }
    }
}
